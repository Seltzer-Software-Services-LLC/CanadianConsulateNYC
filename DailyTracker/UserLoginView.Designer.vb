<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserLoginView
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblFirstName = New System.Windows.Forms.Label()
        Me.lblLastName = New System.Windows.Forms.Label()
        Me.tbFirstName = New System.Windows.Forms.TextBox()
        Me.tbLastName = New System.Windows.Forms.TextBox()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.tbPassword = New System.Windows.Forms.TextBox()
        Me.cmdSubmit = New System.Windows.Forms.Button()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.dtpReportDate = New System.Windows.Forms.DateTimePicker()
        Me.SuspendLayout()
        '
        'lblFirstName
        '
        Me.lblFirstName.Location = New System.Drawing.Point(28, 28)
        Me.lblFirstName.Name = "lblFirstName"
        Me.lblFirstName.Size = New System.Drawing.Size(241, 20)
        Me.lblFirstName.TabIndex = 0
        Me.lblFirstName.Text = "First name (from e-mail address):"
        '
        'lblLastName
        '
        Me.lblLastName.AutoSize = True
        Me.lblLastName.Location = New System.Drawing.Point(28, 76)
        Me.lblLastName.Name = "lblLastName"
        Me.lblLastName.Size = New System.Drawing.Size(241, 20)
        Me.lblLastName.TabIndex = 1
        Me.lblLastName.Text = "Last name (from e-mail address):"
        '
        'tbFirstName
        '
        Me.tbFirstName.Location = New System.Drawing.Point(276, 28)
        Me.tbFirstName.Name = "tbFirstName"
        Me.tbFirstName.Size = New System.Drawing.Size(240, 26)
        Me.tbFirstName.TabIndex = 2
        '
        'tbLastName
        '
        Me.tbLastName.Location = New System.Drawing.Point(275, 76)
        Me.tbLastName.Name = "tbLastName"
        Me.tbLastName.Size = New System.Drawing.Size(240, 26)
        Me.tbLastName.TabIndex = 3
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Location = New System.Drawing.Point(28, 127)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(82, 20)
        Me.lblPassword.TabIndex = 4
        Me.lblPassword.Text = "Password:"
        '
        'tbPassword
        '
        Me.tbPassword.Location = New System.Drawing.Point(275, 127)
        Me.tbPassword.Name = "tbPassword"
        Me.tbPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.tbPassword.Size = New System.Drawing.Size(240, 26)
        Me.tbPassword.TabIndex = 5
        '
        'cmdSubmit
        '
        Me.cmdSubmit.Location = New System.Drawing.Point(240, 237)
        Me.cmdSubmit.Name = "cmdSubmit"
        Me.cmdSubmit.Size = New System.Drawing.Size(75, 34)
        Me.cmdSubmit.TabIndex = 6
        Me.cmdSubmit.Text = "Submit"
        Me.cmdSubmit.UseVisualStyleBackColor = True
        '
        'lblDate
        '
        Me.lblDate.Location = New System.Drawing.Point(28, 181)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(53, 20)
        Me.lblDate.TabIndex = 7
        Me.lblDate.Text = "Date:"
        '
        'dtpReportDate
        '
        Me.dtpReportDate.CustomFormat = "MM/dd/yyyy"
        Me.dtpReportDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpReportDate.Location = New System.Drawing.Point(275, 181)
        Me.dtpReportDate.Name = "dtpReportDate"
        Me.dtpReportDate.Size = New System.Drawing.Size(116, 26)
        Me.dtpReportDate.TabIndex = 8
        '
        'UserLoginView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(549, 297)
        Me.Controls.Add(Me.dtpReportDate)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.cmdSubmit)
        Me.Controls.Add(Me.tbPassword)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.tbLastName)
        Me.Controls.Add(Me.tbFirstName)
        Me.Controls.Add(Me.lblLastName)
        Me.Controls.Add(Me.lblFirstName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "UserLoginView"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Daily Tracker"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblFirstName As Label
    Friend WithEvents lblLastName As Label
    Friend WithEvents tbFirstName As TextBox
    Friend WithEvents tbLastName As TextBox
    Friend WithEvents lblPassword As Label
    Friend WithEvents tbPassword As TextBox
    Friend WithEvents cmdSubmit As Button
    Friend WithEvents lblDate As Label
    Friend WithEvents dtpReportDate As DateTimePicker
End Class
