<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoginForm
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
        components = New ComponentModel.Container()
        FormPanel = New Panel()
        ConfirmErrorLabel = New Label()
        PasswordErrorLabel = New Label()
        UsernameErrorLabel = New Label()
        InfoLabel = New Label()
        ChangeFormLink = New LinkLabel()
        RegisterLoginButton = New Button()
        ConfirmTexbox = New TextBox()
        ConfirmLabel = New Label()
        PasswordTextbox = New TextBox()
        PasswordLabel = New Label()
        UsernameTextbox = New TextBox()
        UsernameLabel = New Label()
        ValidityTimer = New Timer(components)
        FormPanel.SuspendLayout()
        SuspendLayout()
        ' 
        ' FormPanel
        ' 
        FormPanel.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        FormPanel.Controls.Add(ConfirmErrorLabel)
        FormPanel.Controls.Add(PasswordErrorLabel)
        FormPanel.Controls.Add(UsernameErrorLabel)
        FormPanel.Controls.Add(InfoLabel)
        FormPanel.Controls.Add(ChangeFormLink)
        FormPanel.Controls.Add(RegisterLoginButton)
        FormPanel.Controls.Add(ConfirmTexbox)
        FormPanel.Controls.Add(ConfirmLabel)
        FormPanel.Controls.Add(PasswordTextbox)
        FormPanel.Controls.Add(PasswordLabel)
        FormPanel.Controls.Add(UsernameTextbox)
        FormPanel.Controls.Add(UsernameLabel)
        FormPanel.Location = New Point(12, 12)
        FormPanel.Name = "FormPanel"
        FormPanel.Size = New Size(682, 500)
        FormPanel.TabIndex = 0
        ' 
        ' ConfirmErrorLabel
        ' 
        ConfirmErrorLabel.Anchor = AnchorStyles.None
        ConfirmErrorLabel.AutoSize = True
        ConfirmErrorLabel.BackColor = SystemColors.Control
        ConfirmErrorLabel.ForeColor = Color.Red
        ConfirmErrorLabel.Location = New Point(238, 308)
        ConfirmErrorLabel.Name = "ConfirmErrorLabel"
        ConfirmErrorLabel.Size = New Size(53, 20)
        ConfirmErrorLabel.TabIndex = 11
        ConfirmErrorLabel.Text = "Label1"
        ' 
        ' PasswordErrorLabel
        ' 
        PasswordErrorLabel.Anchor = AnchorStyles.None
        PasswordErrorLabel.AutoSize = True
        PasswordErrorLabel.BackColor = SystemColors.Control
        PasswordErrorLabel.ForeColor = Color.Red
        PasswordErrorLabel.Location = New Point(238, 220)
        PasswordErrorLabel.Name = "PasswordErrorLabel"
        PasswordErrorLabel.Size = New Size(53, 20)
        PasswordErrorLabel.TabIndex = 10
        PasswordErrorLabel.Text = "Label1"
        ' 
        ' UsernameErrorLabel
        ' 
        UsernameErrorLabel.Anchor = AnchorStyles.None
        UsernameErrorLabel.AutoSize = True
        UsernameErrorLabel.BackColor = SystemColors.Control
        UsernameErrorLabel.ForeColor = Color.Red
        UsernameErrorLabel.Location = New Point(238, 129)
        UsernameErrorLabel.Name = "UsernameErrorLabel"
        UsernameErrorLabel.Size = New Size(53, 20)
        UsernameErrorLabel.TabIndex = 9
        UsernameErrorLabel.Text = "Label1"
        ' 
        ' InfoLabel
        ' 
        InfoLabel.Anchor = AnchorStyles.None
        InfoLabel.AutoSize = True
        InfoLabel.Font = New Font("Segoe UI", 10.0F)
        InfoLabel.Location = New Point(238, 341)
        InfoLabel.Name = "InfoLabel"
        InfoLabel.Size = New Size(109, 23)
        InfoLabel.TabIndex = 8
        InfoLabel.Text = "No Account?"
        ' 
        ' ChangeFormLink
        ' 
        ChangeFormLink.Anchor = AnchorStyles.None
        ChangeFormLink.AutoSize = True
        ChangeFormLink.Font = New Font("Segoe UI", 10.0F)
        ChangeFormLink.Location = New Point(376, 341)
        ChangeFormLink.Name = "ChangeFormLink"
        ChangeFormLink.Size = New Size(71, 23)
        ChangeFormLink.TabIndex = 7
        ChangeFormLink.TabStop = True
        ChangeFormLink.Text = "Register"
        ' 
        ' RegisterLoginButton
        ' 
        RegisterLoginButton.Anchor = AnchorStyles.None
        RegisterLoginButton.Font = New Font("Segoe UI", 12.0F)
        RegisterLoginButton.Location = New Point(255, 379)
        RegisterLoginButton.Name = "RegisterLoginButton"
        RegisterLoginButton.Size = New Size(121, 45)
        RegisterLoginButton.TabIndex = 6
        RegisterLoginButton.Text = "Login"
        RegisterLoginButton.UseVisualStyleBackColor = True
        ' 
        ' ConfirmTexbox
        ' 
        ConfirmTexbox.Anchor = AnchorStyles.None
        ConfirmTexbox.Font = New Font("Segoe UI", 10.0F)
        ConfirmTexbox.Location = New Point(238, 274)
        ConfirmTexbox.Name = "ConfirmTexbox"
        ConfirmTexbox.PasswordChar = "*"c
        ConfirmTexbox.Size = New Size(172, 30)
        ConfirmTexbox.TabIndex = 5
        ConfirmTexbox.Visible = False
        ' 
        ' ConfirmLabel
        ' 
        ConfirmLabel.Anchor = AnchorStyles.None
        ConfirmLabel.AutoSize = True
        ConfirmLabel.Font = New Font("Segoe UI", 12.0F)
        ConfirmLabel.Location = New Point(238, 244)
        ConfirmLabel.Name = "ConfirmLabel"
        ConfirmLabel.Size = New Size(172, 28)
        ConfirmLabel.TabIndex = 4
        ConfirmLabel.Text = "Confirm Password:"
        ConfirmLabel.Visible = False
        ' 
        ' PasswordTextbox
        ' 
        PasswordTextbox.Anchor = AnchorStyles.None
        PasswordTextbox.Font = New Font("Segoe UI", 10.0F)
        PasswordTextbox.Location = New Point(238, 187)
        PasswordTextbox.Name = "PasswordTextbox"
        PasswordTextbox.PasswordChar = "*"c
        PasswordTextbox.Size = New Size(172, 30)
        PasswordTextbox.TabIndex = 3
        ' 
        ' PasswordLabel
        ' 
        PasswordLabel.Anchor = AnchorStyles.None
        PasswordLabel.AutoSize = True
        PasswordLabel.Font = New Font("Segoe UI", 12.0F)
        PasswordLabel.Location = New Point(238, 155)
        PasswordLabel.Name = "PasswordLabel"
        PasswordLabel.Size = New Size(97, 28)
        PasswordLabel.TabIndex = 2
        PasswordLabel.Text = "Password:"
        ' 
        ' UsernameTextbox
        ' 
        UsernameTextbox.Anchor = AnchorStyles.None
        UsernameTextbox.Font = New Font("Segoe UI", 10.0F)
        UsernameTextbox.Location = New Point(238, 96)
        UsernameTextbox.Name = "UsernameTextbox"
        UsernameTextbox.Size = New Size(172, 30)
        UsernameTextbox.TabIndex = 1
        ' 
        ' UsernameLabel
        ' 
        UsernameLabel.Anchor = AnchorStyles.None
        UsernameLabel.AutoSize = True
        UsernameLabel.Font = New Font("Segoe UI", 12.0F)
        UsernameLabel.Location = New Point(238, 66)
        UsernameLabel.Name = "UsernameLabel"
        UsernameLabel.Size = New Size(103, 28)
        UsernameLabel.TabIndex = 0
        UsernameLabel.Text = "Username:"
        ' 
        ' ValidityTimer
        ' 
        ValidityTimer.Interval = 1000
        ' 
        ' LoginForm
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(706, 524)
        Controls.Add(FormPanel)
        MaximumSize = New Size(825, 650)
        MinimumSize = New Size(375, 450)
        Name = "LoginForm"
        Text = "Ticket System"
        FormPanel.ResumeLayout(False)
        FormPanel.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents FormPanel As Panel
    Friend WithEvents PasswordTextbox As TextBox
    Friend WithEvents PasswordLabel As Label
    Friend WithEvents UsernameTextbox As TextBox
    Friend WithEvents UsernameLabel As Label
    Friend WithEvents RegisterLoginButton As Button
    Friend WithEvents ConfirmTexbox As TextBox
    Friend WithEvents ConfirmLabel As Label
    Friend WithEvents InfoLabel As Label
    Friend WithEvents ChangeFormLink As LinkLabel
    Friend WithEvents UsernameErrorLabel As Label
    Friend WithEvents ConfirmErrorLabel As Label
    Friend WithEvents PasswordErrorLabel As Label
    Friend WithEvents ValidityTimer As Timer
End Class
