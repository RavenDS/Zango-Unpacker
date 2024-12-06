<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Repacker
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Repacker))
        Button1 = New Button()
        FolderBrowseButton = New Button()
        Label2 = New Label()
        FolderTextBox = New TextBox()
        BrowseArchiveButton = New Button()
        Label1 = New Label()
        ArchiveTextBox = New TextBox()
        ProgressBar1 = New ProgressBar()
        InputBrowserDialog = New FolderBrowserDialog()
        BrowseOutputDialog = New SaveFileDialog()
        Label3 = New Label()
        SuspendLayout()
        ' 
        ' Button1
        ' 
        Button1.Cursor = Cursors.Hand
        Button1.Location = New Point(362, 236)
        Button1.Name = "Button1"
        Button1.Size = New Size(142, 58)
        Button1.TabIndex = 0
        Button1.Text = "Repack!"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' FolderBrowseButton
        ' 
        FolderBrowseButton.Cursor = Cursors.Hand
        FolderBrowseButton.Location = New Point(414, 55)
        FolderBrowseButton.Name = "FolderBrowseButton"
        FolderBrowseButton.Size = New Size(90, 39)
        FolderBrowseButton.TabIndex = 14
        FolderBrowseButton.Text = "..."
        FolderBrowseButton.UseVisualStyleBackColor = True
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(12, 122)
        Label2.Name = "Label2"
        Label2.Size = New Size(159, 32)
        Label2.TabIndex = 13
        Label2.Text = "Output (.apk):"
        ' 
        ' FolderTextBox
        ' 
        FolderTextBox.Location = New Point(12, 55)
        FolderTextBox.Name = "FolderTextBox"
        FolderTextBox.Size = New Size(396, 39)
        FolderTextBox.TabIndex = 12
        ' 
        ' BrowseArchiveButton
        ' 
        BrowseArchiveButton.Cursor = Cursors.Hand
        BrowseArchiveButton.Location = New Point(414, 167)
        BrowseArchiveButton.Name = "BrowseArchiveButton"
        BrowseArchiveButton.Size = New Size(90, 39)
        BrowseArchiveButton.TabIndex = 11
        BrowseArchiveButton.Text = "..."
        BrowseArchiveButton.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(12, 10)
        Label1.Name = "Label1"
        Label1.Size = New Size(145, 32)
        Label1.TabIndex = 10
        Label1.Text = "Input folder:"
        ' 
        ' ArchiveTextBox
        ' 
        ArchiveTextBox.Location = New Point(12, 167)
        ArchiveTextBox.Name = "ArchiveTextBox"
        ArchiveTextBox.Size = New Size(396, 39)
        ArchiveTextBox.TabIndex = 9
        ' 
        ' ProgressBar1
        ' 
        ProgressBar1.Location = New Point(12, 236)
        ProgressBar1.Name = "ProgressBar1"
        ProgressBar1.Size = New Size(344, 58)
        ProgressBar1.TabIndex = 8
        ' 
        ' BrowseOutputDialog
        ' 
        BrowseOutputDialog.Filter = "Zango Archive (*.apk)|*.apk|All Files (*.*)|*.*"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 7.875F, FontStyle.Regular, GraphicsUnit.Point)
        Label3.Location = New Point(2, 309)
        Label3.Name = "Label3"
        Label3.Size = New Size(518, 90)
        Label3.TabIndex = 15
        Label3.Text = "Note: folder must be named after the original archive. " & vbCrLf & "                       ex: ""david"" for david0.apk" & vbCrLf & vbCrLf
        ' 
        ' Repacker
        ' 
        AutoScaleDimensions = New SizeF(13F, 32F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(519, 384)
        Controls.Add(Label3)
        Controls.Add(FolderBrowseButton)
        Controls.Add(Label2)
        Controls.Add(FolderTextBox)
        Controls.Add(BrowseArchiveButton)
        Controls.Add(Label1)
        Controls.Add(ArchiveTextBox)
        Controls.Add(ProgressBar1)
        Controls.Add(Button1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        MinimizeBox = False
        Name = "Repacker"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Zango Repacker"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents FolderBrowseButton As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents FolderTextBox As TextBox
    Friend WithEvents BrowseArchiveButton As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents ArchiveTextBox As TextBox
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents InputBrowserDialog As FolderBrowserDialog
    Friend WithEvents BrowseOutputDialog As SaveFileDialog
    Friend WithEvents Label3 As Label
End Class
