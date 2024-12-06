Imports System.IO
Imports System.Text

Public Class Form1
    Dim ArchivePath As String
    Dim FolderPath As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ArchivePath Is Nothing Or ArchiveTextBox.Text = "" Then
            Exit Sub
        End If

        ProgressBar1.Value = 0

        Dim filePath As String = ArchivePath

        Dim outputDirectory As String

        If FolderPath Is Nothing Or FolderTextBox.Text = "" Then
            outputDirectory = ".\extract\"
        Else
            outputDirectory = FolderPath
        End If

        Dim VeryFirstOffset As Integer
        Dim OriginalFileName As String
        Dim FirstFileName As String
        Dim FirstFileOffset As Long
        Dim SecondFileName As String
        Dim SecondFileOffset As Long
        Dim FileCount As Long

        Using reader As New BinaryReader(File.Open(filePath, FileMode.Open))

            ' Go to offset 268 and read 8 bytes as an Integer
            reader.BaseStream.Seek(268, SeekOrigin.Begin)

            VeryFirstOffset = reader.ReadInt32()

            FileCount = (VeryFirstOffset - 12) / 272

            MsgBox("Data Start Offset: " & VeryFirstOffset & vbCrLf & vbCrLf & "File Count: " & FileCount, MsgBoxStyle.Information, "Info")

            If MsgBox("Proceed ?", MsgBoxStyle.YesNo, "Proceed ?") = DialogResult.No Then
                Exit Sub
            End If

            ' Loop until the end of header data (VeryFirstOffset)
            For i = 12 To VeryFirstOffset - 1 Step +272

                ProgressBar1.Maximum = VeryFirstOffset

                reader.BaseStream.Position = i

                ' Read the first 256 bytes as a string
                OriginalFileName = (Encoding.ASCII.GetString(reader.ReadBytes(256)).TrimEnd(vbNullChar))

                'Remove empty/old characters
                Dim parts() As String = OriginalFileName.Split(vbNullChar)
                FirstFileName = parts(0)

                ' Read the next 8 bytes as an integer (little endian)
                FirstFileOffset = reader.ReadInt64()

                ' Skip the next 8 bytes
                reader.BaseStream.Seek(8, SeekOrigin.Current)

                ' Read the next 256 bytes as a string
                SecondFileName = Encoding.ASCII.GetString(reader.ReadBytes(256)).TrimEnd(vbNullChar)

                ' Read the next 8 bytes as an integer (little endian)
                SecondFileOffset = reader.ReadInt64()

                ' Skip the next 8 bytes
                reader.BaseStream.Seek(8, SeekOrigin.Current)


                ' Read data from FirstFileOffset to SecondFileOffset and output to file
                Dim outputFileName As String = Path.Combine(outputDirectory, FirstFileName)
                If Not Directory.Exists(Path.GetDirectoryName(outputFileName)) Then
                    Directory.CreateDirectory(Path.GetDirectoryName(outputFileName))
                End If

                Using writer As New BinaryWriter(File.Open(outputFileName, FileMode.Create))
                    reader.BaseStream.Seek(FirstFileOffset, SeekOrigin.Begin)
                    Dim length As Long = SecondFileOffset - FirstFileOffset
                    If length > reader.BaseStream.Length Then
                        length = reader.BaseStream.Length - FirstFileOffset
                    End If
                    writer.Write(reader.ReadBytes(CInt(length)))
                End Using

                ProgressBar1.Value = i
            Next
        End Using
    End Sub

    Private Sub BrowseArchiveButton_Click(sender As Object, e As EventArgs) Handles BrowseArchiveButton.Click
        If OpenArchiveDialog.ShowDialog = DialogResult.OK Then
            ArchivePath = OpenArchiveDialog.FileName
            ArchiveTextBox.Text = ArchivePath
        End If
    End Sub

    Private Sub FolderBrowseButton_Click(sender As Object, e As EventArgs) Handles FolderBrowseButton.Click
        If BrowseFolderDialog.ShowDialog = DialogResult.OK Then
            FolderPath = BrowseFolderDialog.SelectedPath
            FolderTextBox.Text = FolderPath
        End If
    End Sub

    Private Sub ArchiveTextBox_TextChanged(sender As Object, e As EventArgs) Handles ArchiveTextBox.TextChanged
        ArchivePath = ArchiveTextBox.Text.ToString
        OpenArchiveDialog.FileName = ArchivePath
    End Sub

    Private Sub FolderTextBox_TextChanged(sender As Object, e As EventArgs) Handles FolderTextBox.TextChanged
        FolderPath = FolderTextBox.Text.ToString
        BrowseFolderDialog.SelectedPath = FolderPath
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim url As String = "https://github.com/RavenDS"

        Dim startInfo As New ProcessStartInfo(url)
        startInfo.UseShellExecute = True
        Process.Start(startInfo)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Repacker.Show()
    End Sub
End Class
