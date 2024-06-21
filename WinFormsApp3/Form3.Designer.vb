<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormCreateSubmission
    Inherits System.Windows.Forms.Form

    ' Form overrides dispose to clean up the component list.
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

    ' Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    ' NOTE: The following procedure is required by the Windows Form Designer
    ' It can be modified using the Windows Form Designer.  
    ' Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        txtName = New TextBox()
        txtPhoneNum = New TextBox()
        txtEmail = New TextBox()
        txtGithubLink = New TextBox()
        btnSubmit = New Button()
        btnToggleStopwatch = New Button()
        txtStopwatchTime = New TextBox()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        SuspendLayout()
        ' 
        ' txtName
        ' 
        txtName.Location = New Point(289, 65)
        txtName.Name = "txtName"
        txtName.Size = New Size(267, 27)
        txtName.TabIndex = 0
        ' 
        ' txtPhoneNum
        ' 
        txtPhoneNum.Location = New Point(289, 186)
        txtPhoneNum.Name = "txtPhoneNum"
        txtPhoneNum.Size = New Size(267, 27)
        txtPhoneNum.TabIndex = 1
        ' 
        ' txtEmail
        ' 
        txtEmail.Location = New Point(289, 120)
        txtEmail.Name = "txtEmail"
        txtEmail.Size = New Size(267, 27)
        txtEmail.TabIndex = 2
        ' 
        ' txtGithubLink
        ' 
        txtGithubLink.Location = New Point(289, 259)
        txtGithubLink.Name = "txtGithubLink"
        txtGithubLink.Size = New Size(267, 27)
        txtGithubLink.TabIndex = 3
        ' 
        ' btnSubmit
        ' 
        btnSubmit.BackColor = Color.FromArgb(CByte(52), CByte(152), CByte(219))
        btnSubmit.ForeColor = Color.White
        btnSubmit.Location = New Point(228, 387)
        btnSubmit.Name = "btnSubmit"
        btnSubmit.Size = New Size(244, 40)
        btnSubmit.TabIndex = 4
        btnSubmit.Text = "Submit (Ctrl+S)"
        btnSubmit.UseVisualStyleBackColor = False
        ' 
        ' btnToggleStopwatch
        ' 
        btnToggleStopwatch.BackColor = Color.Yellow
        btnToggleStopwatch.ForeColor = Color.Black
        btnToggleStopwatch.Location = New Point(140, 320)
        btnToggleStopwatch.Name = "btnToggleStopwatch"
        btnToggleStopwatch.Size = New Size(234, 40)
        btnToggleStopwatch.TabIndex = 5
        btnToggleStopwatch.Text = "Toggle Stopwatch (Ctrl+T)"
        btnToggleStopwatch.UseVisualStyleBackColor = False
        ' 
        ' txtStopwatchTime
        ' 
        txtStopwatchTime.Location = New Point(404, 327)
        txtStopwatchTime.Name = "txtStopwatchTime"
        txtStopwatchTime.ReadOnly = True
        txtStopwatchTime.Size = New Size(152, 27)
        txtStopwatchTime.TabIndex = 6
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(154, 68)
        Label1.Name = "Label1"
        Label1.Size = New Size(49, 20)
        Label1.TabIndex = 7
        Label1.Text = "Name"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(154, 127)
        Label2.Name = "Label2"
        Label2.Size = New Size(46, 20)
        Label2.TabIndex = 8
        Label2.Text = "Email"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(140, 189)
        Label3.Name = "Label3"
        Label3.Size = New Size(82, 20)
        Label3.TabIndex = 9
        Label3.Text = "PhoneNum"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(140, 259)
        Label4.Name = "Label4"
        Label4.Size = New Size(79, 20)
        Label4.TabIndex = 10
        Label4.Text = "GithubLink"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(192, 18)
        Label5.Name = "Label5"
        Label5.Size = New Size(322, 20)
        Label5.TabIndex = 11
        Label5.Text = "Karan Sankhe,Slidely Task 2-Create Submissions"
        ' 
        ' FormCreateSubmission
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(711, 450)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(txtStopwatchTime)
        Controls.Add(btnToggleStopwatch)
        Controls.Add(btnSubmit)
        Controls.Add(txtGithubLink)
        Controls.Add(txtEmail)
        Controls.Add(txtPhoneNum)
        Controls.Add(txtName)
        Name = "FormCreateSubmission"
        Text = "Form3"
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents txtName As TextBox
    Friend WithEvents txtPhoneNum As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtGithubLink As TextBox
    Friend WithEvents btnSubmit As Button
    Friend WithEvents btnToggleStopwatch As Button
    Friend WithEvents txtStopwatchTime As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
End Class
