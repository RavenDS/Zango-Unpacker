<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Button1 = New Button()
        ProgressBar1 = New ProgressBar()
        ArchiveTextBox = New TextBox()
        Label1 = New Label()
        BrowseArchiveButton = New Button()
        OpenArchiveDialog = New OpenFileDialog()
        BrowseFolderDialog = New FolderBrowserDialog()
        FolderBrowseButton = New Button()
        Label2 = New Label()
        FolderTextBox = New TextBox()
        Label4 = New Label()
        Label5 = New Label()
        LinkLabel1 = New LinkLabel()
        Button2 = New Button()
        SuspendLayout()
        ' 
        ' Button1
        ' 
        Button1.Cursor = Cursors.Hand
        Button1.Location = New Point(356, 244)
        Button1.Name = "Button1"
        Button1.Size = New Size(148, 58)
        Button1.TabIndex = 0
        Button1.Text = "Unpack"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' ProgressBar1
        ' 
        ProgressBar1.Location = New Point(12, 244)
        ProgressBar1.Name = "ProgressBar1"
        ProgressBar1.Size = New Size(338, 58)
        ProgressBar1.TabIndex = 1
        ' 
        ' ArchiveTextBox
        ' 
        ArchiveTextBox.Location = New Point(12, 58)
        ArchiveTextBox.Name = "ArchiveTextBox"
        ArchiveTextBox.Size = New Size(396, 39)
        ArchiveTextBox.TabIndex = 2
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(12, 13)
        Label1.Name = "Label1"
        Label1.Size = New Size(237, 32)
        Label1.TabIndex = 3
        Label1.Text = "Zango Archive (.apk):"
        ' 
        ' BrowseArchiveButton
        ' 
        BrowseArchiveButton.Cursor = Cursors.Hand
        BrowseArchiveButton.Location = New Point(414, 58)
        BrowseArchiveButton.Name = "BrowseArchiveButton"
        BrowseArchiveButton.Size = New Size(90, 39)
        BrowseArchiveButton.TabIndex = 4
        BrowseArchiveButton.Text = "..."
        BrowseArchiveButton.UseVisualStyleBackColor = True
        ' 
        ' OpenArchiveDialog
        ' 
        OpenArchiveDialog.FileName = "apk"
        ' 
        ' FolderBrowseButton
        ' 
        FolderBrowseButton.Cursor = Cursors.Hand
        FolderBrowseButton.Location = New Point(414, 170)
        FolderBrowseButton.Name = "FolderBrowseButton"
        FolderBrowseButton.Size = New Size(90, 39)
        FolderBrowseButton.TabIndex = 7
        FolderBrowseButton.Text = "..."
        FolderBrowseButton.UseVisualStyleBackColor = True
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(12, 125)
        Label2.Name = "Label2"
        Label2.Size = New Size(118, 32)
        Label2.TabIndex = 6
        Label2.Text = "Extract to:"
        ' 
        ' FolderTextBox
        ' 
        FolderTextBox.Location = New Point(12, 170)
        FolderTextBox.Name = "FolderTextBox"
        FolderTextBox.Size = New Size(396, 39)
        FolderTextBox.TabIndex = 5
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(100, 323)
        Label4.Name = "Label4"
        Label4.Size = New Size(24, 32)
        Label4.TabIndex = 9
        Label4.Text = "-"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 7.875F, FontStyle.Italic, GraphicsUnit.Point)
        Label5.Location = New Point(120, 325)
        Label5.Name = "Label5"
        Label5.Size = New Size(57, 30)
        Label5.TabIndex = 10
        Label5.Text = "2024"
        ' 
        ' LinkLabel1
        ' 
        LinkLabel1.AutoSize = True
        LinkLabel1.Cursor = Cursors.Hand
        LinkLabel1.Font = New Font("Segoe UI Semibold", 7.875F, FontStyle.Bold, GraphicsUnit.Point)
        LinkLabel1.Location = New Point(12, 325)
        LinkLabel1.Name = "LinkLabel1"
        LinkLabel1.Size = New Size(92, 30)
        LinkLabel1.TabIndex = 11
        LinkLabel1.TabStop = True
        LinkLabel1.Text = "ravenDS"
        ' 
        ' Button2
        ' 
        Button2.Cursor = Cursors.Hand
        Button2.Location = New Point(356, 310)
        Button2.Name = "Button2"
        Button2.Size = New Size(148, 58)
        Button2.TabIndex = 12
        Button2.Text = "Repack"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(13F, 32F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(516, 380)
        Controls.Add(Button2)
        Controls.Add(LinkLabel1)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(FolderBrowseButton)
        Controls.Add(Label2)
        Controls.Add(FolderTextBox)
        Controls.Add(BrowseArchiveButton)
        Controls.Add(Label1)
        Controls.Add(ArchiveTextBox)
        Controls.Add(ProgressBar1)
        Controls.Add(Button1)
        FormBorderStyle = FormBorderStyle.Fixed3D
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        MinimizeBox = False
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Zango Unpacker/Repacker"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents ArchiveTextBox As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents BrowseArchiveButton As Button
    Friend WithEvents OpenArchiveDialog As OpenFileDialog
    Friend WithEvents BrowseFolderDialog As FolderBrowserDialog
    Friend WithEvents FolderBrowseButton As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents FolderTextBox As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Button2 As Button

End Class
