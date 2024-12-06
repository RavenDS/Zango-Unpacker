Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports System.Xml
Public Class Repacker
    Dim InputFolderPath As String
    Dim OutputFilePath As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If InputFolderPath Is Nothing Or FolderTextBox.Text = "" Then
            Exit Sub
        End If
        If OutputFilePath Is Nothing Or ArchiveTextBox.Text = "" Then
            OutputFilePath = "output.apk"
        End If
        Dim CurrentOffset As Integer
        Dim NextOffset As Integer
        Dim PreviousOffset As Integer

        Dim davidPath As String = InputFolderPath
        Dim files As List(Of String) = GetAllFiles(davidPath)
        Dim FileCompleteCount As Integer = files.Count

        If FileCompleteCount >= 65535 Then
            MsgBox("Too many files!" & vbCrLf & vbCrLf & "File count must be under 65535", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End If
        Dim FullHeaderLength As Integer = (FileCompleteCount * 272) + 12
        CurrentOffset = FullHeaderLength
        PreviousOffset = FullHeaderLength

        ProgressBar1.Value = 0
        ProgressBar1.Maximum = FileCompleteCount

        Using headerListStream As New FileStream("headerlist.bin", FileMode.Create, FileAccess.Write),
              dataContentStream As New FileStream("datacontent.bin", FileMode.Create, FileAccess.Write)

            For Each filePath In files
                Dim CurrentFileSize As Integer = CInt(New FileInfo(filePath).Length)

                ' Write file content to datacontent.bin
                Dim fileBytes As Byte() = File.ReadAllBytes(filePath)
                dataContentStream.Write(fileBytes, 0, fileBytes.Length)

                ' Prepare the header for headerlist.bin
                Dim headerBytes(271) As Byte
                Dim relativePath As String = filePath.Substring(davidPath.LastIndexOf(Path.DirectorySeparatorChar) + 1).Replace("\", "/")
                Dim pathBytes As Byte() = Encoding.ASCII.GetBytes(relativePath)
                Array.Copy(pathBytes, headerBytes, pathBytes.Length)
                Dim offsetBytes As Byte() = BitConverter.GetBytes(CurrentOffset)
                Dim sizeBytes As Byte() = BitConverter.GetBytes(CurrentFileSize)
                Array.Copy(offsetBytes, 0, headerBytes, 256, offsetBytes.Length)
                Array.Copy(sizeBytes, 0, headerBytes, 264, sizeBytes.Length)

                ' Write the header to headerlist.bin
                headerListStream.Write(headerBytes, 0, headerBytes.Length)

                ' Update offsets
                PreviousOffset = CurrentOffset
                CurrentOffset = PreviousOffset + CurrentFileSize

                ProgressBar1.Value = ProgressBar1.Value + 1
            Next
        End Using
        ' Get the size of datacontent.bin
        Dim dataContentSize As Integer = CInt(New FileInfo("datacontent.bin").Length)

        ' Prepare the initial 12 bytes
        Dim initialBytes(11) As Byte
        Dim magicBytes As Byte() = Encoding.ASCII.GetBytes("arpk")
        Dim dataSizeBytes As Byte() = BitConverter.GetBytes(dataContentSize)
        Dim fileCountBytes As Byte() = BitConverter.GetBytes(FileCompleteCount)

        Array.Copy(magicBytes, 0, initialBytes, 0, magicBytes.Length)
        Array.Copy(dataSizeBytes, 0, initialBytes, 4, dataSizeBytes.Length)
        Array.Copy(fileCountBytes, 0, initialBytes, 8, fileCountBytes.Length)

        ' Read existing content of headerlist.bin
        Dim headerListContent As Byte() = File.ReadAllBytes("headerlist.bin")

        ' Combine the initial bytes with the existing content
        Using headerListFinalStream As New FileStream("headerlist.bin", FileMode.Create, FileAccess.Write)
            headerListFinalStream.Write(initialBytes, 0, initialBytes.Length)
            headerListFinalStream.Write(headerListContent, 0, headerListContent.Length)
        End Using

        ' Concatenate headerlist.bin and datacontent.bin into output.apk
        Using outputStream As New FileStream(OutputFilePath, FileMode.Create, FileAccess.Write)
            Dim headerListBytes As Byte() = File.ReadAllBytes("headerlist.bin")
            Dim dataContentBytes As Byte() = File.ReadAllBytes("datacontent.bin")

            outputStream.Write(headerListBytes, 0, headerListBytes.Length)
            outputStream.Write(dataContentBytes, 0, dataContentBytes.Length)
        End Using

        If File.Exists("headerlist.bin") Then File.Delete("headerlist.bin")
        If File.Exists("datacontent.bin") Then File.Delete("datacontent.bin")

    End Sub

    Function GetAllFiles(path As String) As List(Of String)
        Dim files As New List(Of String)
        files.AddRange(Directory.GetFiles(path, "*.*", SearchOption.AllDirectories))
        files.Sort()
        Return files
    End Function

    Private Sub FolderBrowseButton_Click(sender As Object, e As EventArgs) Handles FolderBrowseButton.Click
        If InputBrowserDialog.ShowDialog = DialogResult.OK Then
            InputFolderPath = InputBrowserDialog.SelectedPath.ToString
            FolderTextBox.Text = InputFolderPath
        End If
    End Sub

    Private Sub BrowseArchiveButton_Click(sender As Object, e As EventArgs) Handles BrowseArchiveButton.Click
        If BrowseOutputDialog.ShowDialog = DialogResult.OK Then
            OutputFilePath = BrowseOutputDialog.FileName.ToString
            ArchiveTextBox.Text = OutputFilePath
        End If
    End Sub

    Private Sub FolderTextBox_TextChanged(sender As Object, e As EventArgs) Handles FolderTextBox.TextChanged
        InputFolderPath = FolderTextBox.Text
        InputBrowserDialog.SelectedPath = InputFolderPath
    End Sub

    Private Sub ArchiveTextBox_TextChanged(sender As Object, e As EventArgs) Handles ArchiveTextBox.TextChanged
        OutputFilePath = ArchiveTextBox.Text
        BrowseOutputDialog.FileName = OutputFilePath
    End Sub
End Class