Imports System.ComponentModel.Design.Serialization
Imports System.Security.Cryptography
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading
Imports Microsoft.Data.Sqlite

Public Class LoginForm
    Dim AwaitingCheck As Action
    Public dbPath As String
    Public Shared connStr As String
    Public Shared Username As String
    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ChangeToLogin()
        SetupDB()
    End Sub

    Private Sub SetupDB()
        dbPath = "TicketsDB.db"
        connStr = $"Filename={dbPath}"

        Using conn As New SqliteConnection(connStr)
            conn.Open()
            Dim sql As String = "CREATE TABLE IF NOT EXISTS Tickets(Id INTEGER PRIMARY KEY, TicketNum TEXT, TicketSubject TEXT, TicketRequestor TEXT, TicketDate TEXT, TicketType TEXT, TicketPriority TEXT, TicketDescription TEXT, TicketStatus TEXT);
                                 CREATE TABLE IF NOT EXISTS Comments(Id INTEGER PRIMARY KEY, TicketId INTEGER, User TEXT, Timestamp Text, CommentText TEXT);
                                 CREATE TABLE IF NOT EXISTS Users(Id INTEGER PRIMARY KEY, Username TEXT, Password TEXT)"
            Using cmd As New SqliteCommand(sql, conn)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub ChangeFormLinkClick(sender As Object, e As EventArgs) Handles ChangeFormLink.Click
        If ChangeFormLink.Text = "Register" Then
            ChangeToRegister()
        Else
            ChangeToLogin()
        End If
    End Sub

    Private Sub ValidCheck(sender As Object, e As EventArgs) Handles UsernameTextbox.TextChanged, PasswordTextbox.TextChanged, ConfirmTexbox.TextChanged

        ValidityTimer.Stop()

        If RegisterLoginButton.Text = "Login" Then
            Return
        End If

        Dim obj = DirectCast(sender, TextBox)

        Select Case obj.Name
            Case "UsernameTextbox"
                If UsernameTextbox.Text = "" Then
                    UsernameErrorLabel.Text = ""
                    Return
                End If
                AwaitingCheck = AddressOf CheckUsername
            Case "PasswordTextbox"
                If PasswordTextbox.Text = "" Then
                    PasswordErrorLabel.Text = ""
                    Return
                End If
                AwaitingCheck = AddressOf CheckPassword
            Case "ConfirmTextbox"
                If ConfirmTexbox.Text = "" Then
                    ConfirmErrorLabel.Text = ""
                    Return
                End If
                AwaitingCheck = AddressOf CheckConfirm
        End Select

        ValidityTimer.Enabled = True
        ValidityTimer.Start()

    End Sub

    Private Sub TextLostFocus(sender As Object, e As EventArgs) Handles UsernameTextbox.LostFocus, PasswordTextbox.LostFocus, ConfirmTexbox.LostFocus
        ValidityTimer.Enabled = False

        If RegisterLoginButton.Text = "Login" Then
            Return
        End If

        Dim obj = DirectCast(sender, TextBox)

        Select Case obj.Name
            Case "UsernameTextbox"
                If UsernameTextbox.Text <> "" Then CheckUsername()
            Case "PasswordTextbox"
                If PasswordTextbox.Text <> "" Then CheckPassword()
            Case "ConfirmTexbox"
                If ConfirmTexbox.Text <> "" Then CheckConfirm()
        End Select
    End Sub

    Private Sub CheckUsername()
        If Regex.IsMatch(UsernameTextbox.Text, "^[a-zA-Z0-9]+$") And Not UserExists(UsernameTextbox.Text) Then
            UsernameErrorLabel.ForeColor = Color.Green
            UsernameErrorLabel.Text = ChrW(9745) & " Good!"
        Else

            UsernameErrorLabel.ForeColor = Color.Red
            UsernameErrorLabel.Text = ChrW(&H274C) & " Invalid Username!"
        End If
    End Sub

    Private Function UserExists(ByVal User As String) As Boolean

        Using conn As New SqliteConnection($"Filename={dbPath}")
            conn.Open()
            Dim sql As String = $"SELECT * FROM Users WHERE Username = @User"
            Using cmd As New SqliteCommand(sql, conn)
                cmd.Parameters.AddWithValue("@User", User.ToUpper())
                Using reader As SqliteDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        If (reader("Username") = User.ToUpper()) Then
                            Return True
                        End If
                    End While
                End Using
            End Using
        End Using

        Return False
    End Function

    Private Sub CheckPassword()
        Dim capTest As String = "[A-Z]"
        Dim strTest As String = "^[a-zA-Z0-9?!@#$%]+$"
        Dim specialTest As String = "[?!@#$%]"

        If Regex.IsMatch(PasswordTextbox.Text, capTest) And Regex.IsMatch(PasswordTextbox.Text, strTest) And Regex.IsMatch(PasswordTextbox.Text, specialTest) Then
            PasswordErrorLabel.ForeColor = Color.Green
            PasswordErrorLabel.Text = ChrW(9745) & " Good!"
        Else

            PasswordErrorLabel.ForeColor = Color.Red
            PasswordErrorLabel.Text = ChrW(&H274C) & " Invalid Password!"
        End If

        If ConfirmTexbox.Text <> "" Then
            CheckConfirm()
        End If
    End Sub

    Private Sub CheckConfirm()
        If PasswordTextbox.Text = ConfirmTexbox.Text Then
            ConfirmErrorLabel.ForeColor = Color.Green
            ConfirmErrorLabel.Text = ChrW(9745) & " Good!"
        Else

            ConfirmErrorLabel.ForeColor = Color.Red
            ConfirmErrorLabel.Text = ChrW(&H274C) & " Passwords do not match!"
        End If
    End Sub

    Private Sub TimerTick(sender As Object, e As EventArgs) Handles ValidityTimer.Tick
        AwaitingCheck()
        ValidityTimer.Enabled = False
    End Sub

    Private Sub LoginOrRegisterClick(sender As Object, e As EventArgs) Handles RegisterLoginButton.Click
        CheckUsername()
        CheckPassword()
        CheckConfirm()

        If RegisterLoginButton.Text = "Register" Then
            If UsernameErrorLabel.Text = ChrW(9745) & " Good!" And PasswordErrorLabel.Text = ChrW(9745) & " Good!" And ConfirmErrorLabel.Text = ChrW(9745) & " Good!" Then
                Dim tempBytes As Byte() = Encoding.UTF8.GetBytes(PasswordTextbox.Text)
                tempBytes = SHA256.HashData(tempBytes)
                Dim hashPassword = Convert.ToHexString(tempBytes)
                InsertNewUser(UsernameTextbox.Text, hashPassword)
                Dim MainWindow As New TicketForm
                Username = UsernameTextbox.Text.ToUpper()
                Me.Hide()
                MainWindow.ShowDialog()
                If Not Me.IsDisposed Then
                    Me.Show()
                    If RegisterLoginButton.Text = "Login" Then
                        ChangeToRegister()
                    End If
                    ChangeToLogin()
                End If
            End If
        Else
            Dim tempBytes As Byte() = Encoding.UTF8.GetBytes(PasswordTextbox.Text)
            tempBytes = SHA256.HashData(tempBytes)
            Dim hashPassword = Convert.ToHexString(tempBytes)
            If AttemptLogin(UsernameTextbox.Text.ToUpper(), hashPassword) Then
                Dim MainWindow As New TicketForm
                Username = UsernameTextbox.Text.ToUpper()
                Me.Hide()
                MainWindow.ShowDialog()
                If Not Me.IsDisposed Then
                    Me.Show()
                    If RegisterLoginButton.Text = "Login" Then
                        ChangeToRegister()
                    End If
                    ChangeToLogin()
                End If
            End If
        End If
    End Sub

    Private Function AttemptLogin(user As String, pass As String)
        Using conn As New SqliteConnection($"Filename={dbPath}")
            conn.Open()
            Dim sql As String = $"SELECT * FROM Users WHERE Username = @User"
            Using cmd As New SqliteCommand(sql, conn)
                cmd.Parameters.AddWithValue("@User", user.ToUpper())
                Using reader As SqliteDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        If (reader("Username") = user.ToUpper()) And reader("Password") = pass Then
                            Return True
                        End If
                    End While
                End Using
            End Using
        End Using
        Return False
    End Function

    Private Sub InsertNewUser(user As String, pass As String)
        Using conn As New SqliteConnection($"Filename={dbPath}")
            Dim sql As String

            conn.Open()

            sql = "INSERT INTO Users (Username, Password)
                            VALUES (@User, @Pass);"
            Using cmd As New SqliteCommand(sql, conn)
                cmd.Parameters.AddWithValue("@User", user.ToUpper())
                cmd.Parameters.AddWithValue("@Pass", pass)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub ChangeToLogin()
        InfoLabel.Top -= 50
        ChangeFormLink.Top -= 50
        RegisterLoginButton.Top -= 50
        ChangeFormLink.Left -= 23

        ConfirmLabel.Visible = False
        ConfirmTexbox.Visible = False
        ConfirmErrorLabel.Visible = False

        InfoLabel.Text = "No Account?"
        ChangeFormLink.Text = "Register"
        RegisterLoginButton.Text = "Login"

        UsernameErrorLabel.Text = ""
        PasswordErrorLabel.Text = ""
        ConfirmErrorLabel.Text = ""

        UsernameTextbox.Text = ""
        PasswordTextbox.Text = ""
        ConfirmTexbox.Text = ""
    End Sub

    Private Sub ChangeToRegister()
        InfoLabel.Top += 50
        ChangeFormLink.Top += 50
        RegisterLoginButton.Top += 50
        ChangeFormLink.Left += 23

        ConfirmLabel.Visible = True
        ConfirmTexbox.Visible = True
        ConfirmErrorLabel.Visible = True

        InfoLabel.Text = "Have an Account?"
        ChangeFormLink.Text = "Login"
        RegisterLoginButton.Text = "Register"

        UsernameTextbox.Text = ""
        PasswordTextbox.Text = ""
        ConfirmTexbox.Text = ""
    End Sub
End Class