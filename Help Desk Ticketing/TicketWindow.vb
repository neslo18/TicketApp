Imports Microsoft.Data.Sqlite

Public Class TicketForm
    Public AddMode = False
    Public AllTickets As New List(Of Ticket)
    Public CurrentTicket As Ticket
    Public loggingOut As Boolean = False

    ' occurs when form loads, used to reset control sizes, DB Retrieval and auto filter
    Private Sub TicketForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FlowLayoutPanelSideList_SizeChanged(FlowLayoutPanelSideList, e)
        FlowLayoutPanelSideList_SizeChanged(MasterSidePanel, e)

        TicketDetailsDate.Text = (Format(Now, "MM/dd/yy"))
        CancelTicket.Visible = False
        TicketDetails.Visible = False

        GetAllTickets()
        FilterByStatus()
    End Sub

#Region "Side Panel Events"
    ' Filters Side Panel on Pending or Complete checkbox changed
    Private Sub PendingCheck_CheckedChanged(sender As Object, e As EventArgs) Handles PendingCheck.CheckedChanged
        FilterByStatus()
    End Sub

    Private Sub CompleteCheck_CheckedChanged(sender As Object, e As EventArgs) Handles CompleteCheck.CheckedChanged
        FilterByStatus()
    End Sub

    ' Shows a Color change if hovered over Ticket in side panel
    Private Sub BeginHover(sender As Object, e As EventArgs)
        Dim currentPanel = DirectCast(sender, Control)

        Do While Microsoft.VisualBasic.Left(currentPanel.Name, 11) <> "TicketPanel"
            currentPanel = currentPanel.Parent
        Loop

        currentPanel.BackColor = Color.Aqua
    End Sub

    ' Resets Color change
    Private Sub EndHover(sender As Object, e As EventArgs)
        Dim currentPanel = DirectCast(sender, Control)

        Do While Microsoft.VisualBasic.Left(currentPanel.Name, 11) <> "TicketPanel"
            currentPanel = currentPanel.Parent
        Loop

        If CurrentTicket IsNot Nothing Then
            If CurrentTicket.TicketPanel IsNot currentPanel Then currentPanel.BackColor = SystemColors.Control
            Return
        End If

        currentPanel.BackColor = SystemColors.Control
    End Sub

    ' Filters Side Panel on Pending or Complete checkbox changed
    Private Sub FilterByStatus()
        Dim Statuses As New List(Of String)

        If PendingCheck.Checked Then
            Statuses.Add("Pending")
        End If

        If CompleteCheck.Checked Then
            Statuses.Add("Complete")
        End If

        For Each tic In AllTickets
            If Statuses.Contains(tic.TicketStatus) Then
                tic.TicketPanel.Visible = True
            Else
                tic.TicketPanel.Visible = False
            End If
        Next
    End Sub

    ' Resets controls sizes to prevent overlap with side of panel
    Private Sub FlowLayoutPanelSideList_SizeChanged(sender As Object, e As EventArgs) Handles MasterSidePanel.SizeChanged, FlowLayoutPanelSideList.SizeChanged

        Dim FlowBox = DirectCast(sender, FlowLayoutPanel)

        For Each control In FlowBox.Controls
            Dim pan = DirectCast(control, Panel)

            pan.Width = FlowLayoutPanelSideList.Width - 30
        Next
    End Sub

    ' Resets controls sizes to prevent overlap with side of panel with new control added
    Private Sub FlowLayoutPanelSideList_ControlAdded(sender As Object, e As ControlEventArgs) Handles FlowLayoutPanelSideList.ControlAdded
        FlowLayoutPanelSideList_SizeChanged(FlowLayoutPanelSideList, e)
        FlowLayoutPanelSideList_SizeChanged(MasterSidePanel, e)
    End Sub

#End Region

#Region "DB Commands"
    ' Gets all Tickets from DB and their comments and adds them to List Object
    Private Sub GetAllTickets()
        Using conn As New SqliteConnection(LoginForm.connStr)
            conn.Open()
            Dim sql As String = "SELECT * FROM Tickets ORDER BY 
                                CASE TicketPriority
                                WHEN 'High' THEN 1
                                WHEN 'Medium' THEN 2
                                WHEN 'Low' THEN 3 
                                END ASC;"
            Using cmd As New SqliteCommand(sql, conn)
                Using reader As SqliteDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim OldTicket = New Ticket(reader("Id"), reader("TicketNum"), reader("TicketSubject"), reader("TicketRequestor"), reader("TicketDate"), reader("TicketType"), reader("TicketPriority"), reader("TicketDescription"), reader("TicketStatus"))
                        OldTicket.TicketPanel = CreateTicketControl(OldTicket)
                        OldTicket.TicketComments = GetComments(OldTicket.Id.ToString())
                        AllTickets.Add(OldTicket)
                    End While
                End Using
            End Using
        End Using
    End Sub

    ' Gets all comments for specific Ticket and returns List object to be added to that class
    Private Function GetComments(Id As String) As List(Of Comment)
        Dim CommentList As New List(Of Comment)
        Using conn As New SqliteConnection(LoginForm.connStr)
            conn.Open()
            Dim sql As String = $"SELECT * FROM Comments Where TicketId='{Id}'"
            Using cmd As New SqliteCommand(sql, conn)
                Using reader As SqliteDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim oldComment = New Comment(reader("Id"), reader("TicketId"), reader("User"), reader("Timestamp"), reader("CommentText"))
                        CommentList.Add(oldComment)
                    End While
                End Using
            End Using
        End Using
        Return CommentList
    End Function

    ' Inserts record into either Ticket or Comment DB Table
    Private Function InsertIntoDB(table As String, data As String(), Optional TicketId As Long = 0) As Long
        Using conn As New SqliteConnection(LoginForm.connStr)
            Dim sql As String
            Dim insertRow As Long

            conn.Open()

            Select Case table
                Case "Tickets"
                    sql = "INSERT INTO Tickets (TicketNum, TicketSubject, TicketRequestor, TicketDate, TicketType, TicketPriority, TicketDescription, TicketStatus)
                            VALUES (@Num, @Subject, @Requestor, @Date, @Type, @Priority, @Description, @Status); SELECT last_insert_rowid();"
                    Using cmd As New SqliteCommand(sql, conn)
                        cmd.Parameters.AddWithValue("@Num", data(0))
                        cmd.Parameters.AddWithValue("@Subject", data(1))
                        cmd.Parameters.AddWithValue("@Requestor", data(2))
                        cmd.Parameters.AddWithValue("@Date", data(3))
                        cmd.Parameters.AddWithValue("@Type", data(4))
                        cmd.Parameters.AddWithValue("@Priority", data(5))
                        cmd.Parameters.AddWithValue("@Description", data(6))
                        cmd.Parameters.AddWithValue("@Status", data(7))
                        insertRow = Convert.ToInt64(cmd.ExecuteScalar())
                    End Using
                Case Else
                    sql = "INSERT INTO Comments (TicketId, User, Timestamp, CommentText)
                            VALUES (@TicketId, @User, @Timestamp, @CommentText); SELECT last_insert_rowid();"
                    Using cmd As New SqliteCommand(sql, conn)
                        cmd.Parameters.AddWithValue("@TicketId", TicketId)
                        cmd.Parameters.AddWithValue("@User", data(0))
                        cmd.Parameters.AddWithValue("@Timestamp", data(1))
                        cmd.Parameters.AddWithValue("@CommentText", data(2))
                        insertRow = Convert.ToInt64(cmd.ExecuteScalar())
                    End Using
            End Select

            Return insertRow
        End Using
    End Function

    ' Updates Status of Ticket from Pending to Complete or vice versa
    Private Sub UpdateStatusInDB(TicketNum As String, TicketStatus As String)
        Using conn As New SqliteConnection(LoginForm.connStr)
            Dim sql As String = "UPDATE Tickets Set TicketStatus = @Status Where TicketNum = @Num"

            conn.Open()
            Using cmd As New SqliteCommand(sql, conn)
                cmd.Parameters.AddWithValue("@Num", TicketNum)
                cmd.Parameters.AddWithValue("@Status", TicketStatus)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    ' Returns highest Ticket Num of its type. Used to determine next number in sequence
    Private Function ReturnLatestNum(ByVal TicketType As String)
        Dim returnValue = ""
        Select Case TicketType
            Case "Request"
                TicketType = "REQ"
            Case "Incident"
                TicketType = "INC"
        End Select

        Using conn As New SqliteConnection(LoginForm.connStr)
            conn.Open()
            Dim sql As String = $"SELECT TicketNum FROM Tickets WHERE TicketNum LIKE '{TicketType}%' ORDER BY TicketType DESC LIMIT 1"
            Using cmd As New SqliteCommand(sql, conn)
                Using reader As SqliteDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        returnValue = reader("TicketNum")
                    End While
                End Using
            End Using
        End Using
        Return returnValue
    End Function
#End Region

#Region "Create Custom Controls"
    ' Creates New Ticket Control in Side Panel
    Private Function CreateTicketControl(issue As Ticket) As Panel
        Dim TicketPanel = New Panel(),
        TicketSubject = New Label(),
        TicketSubjectLabel = New Label(),
        TicketType = New Label(),
        TicketTypeLabel = New Label(),
        TicketTitle = New Panel(),
        TicketTitleBorder = New Panel(),
        TicketDash = New Label(),
        TicketDate = New Label(),
        TicketStatus = New Label(),
        TicketNum = New Label()

        ' TicketPanel
        ' 
        TicketPanel.BorderStyle = BorderStyle.FixedSingle
        TicketPanel.Controls.Add(TicketSubject)
        TicketPanel.Controls.Add(TicketSubjectLabel)
        TicketPanel.Controls.Add(TicketType)
        TicketPanel.Controls.Add(TicketTypeLabel)
        TicketPanel.Controls.Add(TicketTitle)
        TicketPanel.Location = New Point(3, 3)
        TicketPanel.Name = "TicketPanel_" & issue.TicketNum
        TicketPanel.Size = New Size(344, 95)
        ' 
        ' TicketTitle
        ' 
        TicketTitle.Controls.Add(TicketTitleBorder)
        TicketTitle.Controls.Add(TicketDash)
        TicketTitle.Controls.Add(TicketDate)
        TicketTitle.Controls.Add(TicketStatus)
        TicketTitle.Controls.Add(TicketNum)
        TicketTitle.Dock = DockStyle.Top
        TicketTitle.Location = New Point(0, 0)
        TicketTitle.Name = "TicketTitle_" & issue.TicketNum
        TicketTitle.Size = New Size(342, 30)
        ' 
        ' TicketNum
        ' 
        TicketNum.Anchor = AnchorStyles.None
        TicketNum.AutoSize = True
        TicketNum.Location = New Point(50, 5)
        TicketNum.Name = "TicketNum_" & issue.TicketNum
        TicketNum.Size = New Size(102, 20)
        TicketNum.Text = issue.TicketNum
        ' 
        ' TicketDash
        ' 
        TicketDash.Anchor = AnchorStyles.None
        TicketDash.AutoSize = True
        TicketDash.Location = New Point(139, 5)
        TicketDash.Name = "TicketDash_" & issue.TicketNum
        TicketDash.Size = New Size(15, 20)
        TicketDash.Text = "-"
        ' 
        ' TicketStatus
        ' 
        TicketStatus.Anchor = AnchorStyles.None
        TicketStatus.AutoSize = True
        TicketStatus.Location = New Point(160, 5)
        TicketStatus.Name = "TicketStatus_" & issue.TicketNum
        TicketStatus.Size = New Size(62, 20)
        TicketStatus.Text = issue.TicketStatus
        ' 
        ' TicketDate
        ' 
        TicketDate.Anchor = AnchorStyles.None
        TicketDate.AutoSize = True
        TicketDate.Location = New Point(243, 5)
        TicketDate.Name = "TicketDate_" & issue.TicketNum
        TicketDate.Size = New Size(85, 20)
        TicketDate.Text = issue.TicketDate
        ' 
        ' TicketTitleBorder
        ' 
        TicketTitleBorder.BackColor = SystemColors.ActiveCaptionText
        TicketTitleBorder.Dock = DockStyle.Bottom
        TicketTitleBorder.Location = New Point(0, 29)
        TicketTitleBorder.Name = "TicketTitleBorder_" & issue.TicketNum
        TicketTitleBorder.Size = New Size(342, 1)
        ' 
        ' TicketTypeLabel
        ' 
        TicketTypeLabel.Anchor = AnchorStyles.None
        TicketTypeLabel.AutoSize = True
        TicketTypeLabel.Location = New Point(39, 33)
        TicketTypeLabel.Name = "TicketTypeLabel_" & issue.TicketNum
        TicketTypeLabel.Size = New Size(43, 20)
        TicketTypeLabel.Text = "Type: "
        ' 
        ' TicketType
        ' 
        TicketType.Anchor = AnchorStyles.None
        TicketType.AutoSize = True
        TicketType.Location = New Point(106, 33)
        TicketType.Name = "TicketType_" & issue.TicketNum
        TicketType.Size = New Size(62, 20)
        TicketType.Text = issue.TicketType
        ' 
        ' TicketSubjectLabel
        ' 
        TicketSubjectLabel.Anchor = AnchorStyles.None
        TicketSubjectLabel.AutoSize = True
        TicketSubjectLabel.Location = New Point(39, 61)
        TicketSubjectLabel.Name = "TicketSubjectLabel_" & issue.TicketNum
        TicketSubjectLabel.Size = New Size(61, 20)
        TicketSubjectLabel.TabIndex = 5
        TicketSubjectLabel.Text = "Subject:"
        ' 
        ' TicketSubject
        ' 
        TicketSubject.Anchor = AnchorStyles.None
        TicketSubject.AutoSize = True
        TicketSubject.Location = New Point(106, 61)
        TicketSubject.Name = "TicketSubject_" & issue.TicketNum
        TicketSubject.Size = New Size(115, 20)
        TicketSubject.Text = issue.TicketSubject
        TicketSubject.AutoEllipsis = True

        FlowLayoutPanelSideList.Controls.Add(TicketPanel)

        For Each ctrl As Control In TicketPanel.Controls
            If TypeOf ctrl Is Panel Then
                For Each newCtrl As Control In ctrl.Controls
                    AddHandler newCtrl.Click, AddressOf TicketSelect
                    AddHandler newCtrl.MouseEnter, AddressOf BeginHover
                    AddHandler newCtrl.MouseLeave, AddressOf EndHover
                Next
            End If
            AddHandler ctrl.Click, AddressOf TicketSelect
            AddHandler ctrl.MouseEnter, AddressOf BeginHover
            AddHandler ctrl.MouseLeave, AddressOf EndHover
        Next

        AddHandler TicketPanel.Click, AddressOf TicketSelect

        AddHandler TicketPanel.MouseEnter, AddressOf BeginHover
        AddHandler TicketPanel.MouseLeave, AddressOf EndHover

        Return TicketPanel
    End Function

    ' Creates New Label Control for a comment
    Private Sub CreateCommentLabel(Comm As Comment)
        Dim NewLabel As New Label
        CommentsFlowLayout.Controls.Add(NewLabel)
        NewLabel.AutoSize = True
        NewLabel.Location = New Point(13, 10)
        NewLabel.Name = "Comment_" & Comm.Id
        NewLabel.Size = New Size(372, 200)
        NewLabel.TabIndex = 0
        NewLabel.Text = Comm.GetText()
        NewLabel.Margin = New Padding(3, 0, 3, 20)

        CommentsFlowLayout.VerticalScroll.Value = CommentsFlowLayout.VerticalScroll.Maximum
        CommentsFlowLayout.PerformLayout()
    End Sub

#End Region

#Region "Ticket Select, Cancel and Complete/Add"

    ' Resets and Hides Ticket Form to cancel current creation
    Private Sub CancelTicket_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles CancelTicket.LinkClicked
        TicketDetailsSubject.Text = ""
        TicketDetailsRequestor.Text = ""
        TicketDetailsDate.Text = ""
        TicketDetailsType.Text = ""
        TicketDetailsPriority.Text = ""
        TicketDetailsDescription.Text = ""
        TicketDetails.Visible = False
        CancelTicket.Visible = False
        AddMode = False
    End Sub

    ' UnHides Ticket Form to allow new ticket creation
    Private Sub NewTicketToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewTicketToolStripMenuItem.Click
        TicketDetailsSubject.ReadOnly = False
        TicketDetailsSubject.BorderStyle = BorderStyle.Fixed3D
        TicketDetailsSubject.BackColor = SystemColors.Window
        TicketDetailsSubject.Refresh()

        TicketDetailsType.Enabled = True

        TicketDetailsPriority.Enabled = True

        TicketDetailsDescription.ReadOnly = False
        TicketDetailsDescription.BorderStyle = BorderStyle.Fixed3D
        TicketDetailsDescription.BackColor = SystemColors.Window
        TicketDetailsDescription.Refresh()

        TicketDetailsDesciptionTicketsTable.RowStyles(0).SizeType = SizeType.Percent
        TicketDetailsDesciptionTicketsTable.RowStyles(0).Height = 100

        TicketDetailsDesciptionTicketsTable.RowStyles(1).SizeType = SizeType.Percent
        TicketDetailsDesciptionTicketsTable.RowStyles(1).Height = 0

        CommentsFlowLayout.Controls.Clear()

        CommentTextBox.Enabled = False
        CommentSubmit.Enabled = False

        TicketDetailsNum.Text = ""
        dashLabel.Text = ""
        TicketDetailsStatus.Text = ""
        TicketDetailsSubject.Text = ""
        TicketDetailsRequestor.Text = LoginForm.Username
        TicketDetailsDate.Text = (Format(Now, "MM/dd/yy"))
        TicketDetailsType.Text = "Request"
        TicketDetailsPriority.Text = "Low"
        TicketDetailsDescription.Text = ""
        TicketDetails.Visible = True
        CancelTicket.Visible = True
        CurrentTicket = Nothing

        For Each ctrl In FlowLayoutPanelSideList.Controls
            DirectCast(ctrl, Panel).BackColor = SystemColors.Control
        Next

        AddMode = True
        CompleteOrAddTicketButton.Text = "Add"
    End Sub

    ' Selects Ticket to show on Ticket Form
    Private Sub TicketSelect(sender As Object, e As EventArgs)
        Dim currentPanel = DirectCast(sender, Control)
        TicketDetails.Visible = True

        Do While Microsoft.VisualBasic.Left(currentPanel.Name, 11) <> "TicketPanel"
            currentPanel = currentPanel.Parent
        Loop

        For Each ctrl In FlowLayoutPanelSideList.Controls
            DirectCast(ctrl, Panel).BackColor = SystemColors.Control
        Next

        currentPanel.BackColor = Color.Aqua

        TicketDetailsSubject.ReadOnly = True
        TicketDetailsSubject.BorderStyle = BorderStyle.None
        TicketDetailsSubject.BackColor = SystemColors.Control
        TicketDetailsSubject.Refresh()

        CommentsFlowLayout.Controls.Clear()

        TicketDetailsType.Enabled = False

        TicketDetailsPriority.Enabled = False

        TicketDetailsDescription.ReadOnly = True
        TicketDetailsDescription.BorderStyle = BorderStyle.None
        TicketDetailsDescription.BackColor = SystemColors.InactiveBorder
        TicketDetailsDescription.Refresh()

        TicketDetailsDesciptionTicketsTable.RowStyles(0).SizeType = SizeType.Percent
        TicketDetailsDesciptionTicketsTable.RowStyles(0).Height = 35

        TicketDetailsDesciptionTicketsTable.RowStyles(1).SizeType = SizeType.Percent
        TicketDetailsDesciptionTicketsTable.RowStyles(1).Height = 65

        CancelTicket.Visible = False

        CompleteOrAddTicketButton.Text = "Complete"

        CommentTextBox.Enabled = True
        CommentSubmit.Enabled = True

        AddMode = False

        For Each tic In AllTickets
            If tic.TicketPanel Is currentPanel Then
                TicketDetailsNum.Text = tic.TicketNum
                dashLabel.Text = "-"
                TicketDetailsStatus.Text = $"[Status: {tic.TicketStatus}]"
                TicketDetailsSubject.Text = tic.TicketSubject
                TicketDetailsRequestor.Text = tic.TicketRequestor
                TicketDetailsDate.Text = tic.TicketDate
                TicketDetailsType.Text = tic.TicketType
                TicketDetailsPriority.Text = tic.TicketPriority
                TicketDetailsDescription.Text = tic.TicketDescription
                TicketDetails.Visible = True
                CurrentTicket = tic

                If tic.TicketStatus = "Complete" Then
                    CompleteOrAddTicketButton.Text = "ReOpen"
                    CommentTextBox.Enabled = False
                    CommentSubmit.Enabled = False
                End If

                For Each comm In tic.TicketComments
                    CreateCommentLabel(comm)
                Next

                Return
            End If
        Next

    End Sub

    ' Completes, Adds or Reopens Current Ticket
    Private Sub CompleteOrAddTicketButton_Click(sender As Object, e As EventArgs) Handles CompleteOrAddTicketButton.Click
        If CompleteOrAddTicketButton.Text = "ReOpen" Then
            CommentTextBox.Enabled = True
            CommentSubmit.Enabled = True
            TicketDetailsStatus.Text = TicketDetailsStatus.Text.Replace("Complete", "Pending")
            For Each tic In AllTickets
                If tic.TicketNum = TicketDetailsNum.Text Then
                    tic.TicketStatus = "Pending"
                    Dim lbl As Label = DirectCast(Controls.Find("TicketStatus_" & tic.TicketNum, True)(0), Label)
                    lbl.Text = "Pending"
                    CompleteOrAddTicketButton.Text = "Complete"
                    UpdateStatusInDB(tic.TicketNum, tic.TicketStatus)
                    FilterByStatus()
                    Dim row As Long = InsertIntoDB("Comments", {LoginForm.Username, Now.ToString(), "Reopened Ticket"}, tic.Id)
                    Dim Comm As New Comment(row, tic.Id, LoginForm.Username, Now.ToString(), "Reopened Ticket")
                    tic.TicketComments.Add(Comm)
                    CreateCommentLabel(Comm)
                End If
            Next
            Return
        End If

        If AddMode Then
            Dim data(5) As String
            Dim NewTicketNum As String
            Dim InsertRow As Long

            data(0) = TicketDetailsSubject.Text
            data(1) = TicketDetailsRequestor.Text
            data(2) = TicketDetailsDate.Text
            data(3) = TicketDetailsType.Text
            data(4) = TicketDetailsPriority.Text
            data(5) = TicketDetailsDescription.Text

            For Each StrData In data
                If StrData = "" Then
                    Return
                End If
            Next

            NewTicketNum = ReturnLatestNum(data(3))

            If NewTicketNum = "" Then
                NewTicketNum = Microsoft.VisualBasic.Left(data(3).ToUpper(), 3) & "00000001"
            Else
                Dim num As Long
                num = CLng(Microsoft.VisualBasic.Right(NewTicketNum, 8)) + 1
                NewTicketNum = Microsoft.VisualBasic.Left(data(3).ToUpper(), 3) & Format(num, "00000000")
            End If

            Dim DBData = data.Prepend(NewTicketNum).ToArray()

            DBData = DBData.Append("Pending").ToArray()

            InsertRow = InsertIntoDB("Tickets", DBData)

            Dim NewTicket As New Ticket(InsertRow, NewTicketNum, data(0), data(1), data(2), data(3), data(4), data(5), "Pending")
            NewTicket.TicketPanel = CreateTicketControl(NewTicket)

            AllTickets.Add(NewTicket)

            TicketDetailsSubject.Text = ""
            TicketDetailsRequestor.Text = ""
            TicketDetailsDate.Text = ""
            TicketDetailsType.Text = ""
            TicketDetailsPriority.Text = ""
            TicketDetailsDescription.Text = ""
            TicketDetails.Visible = False

            Dim row As Long = InsertIntoDB("Comments", {LoginForm.Username, Now.ToString(), "Created Ticket"}, NewTicket.Id)
            Dim NewComment As New Comment(row, NewTicket.Id, LoginForm.Username, Now.ToString(), "Created Ticket")
            NewTicket.TicketComments.Add(NewComment)
        Else
            For Each ctrl In FlowLayoutPanelSideList.Controls
                Dim tempPanel = DirectCast(ctrl, Panel)
                If tempPanel.BackColor = Color.Aqua Then
                    For Each tic In AllTickets
                        If tic.TicketPanel Is tempPanel Then
                            tic.TicketStatus = "Complete"
                            Dim lbl As Label = DirectCast(Controls.Find("TicketStatus_" & tic.TicketNum, True)(0), Label)
                            lbl.Text = "Complete"
                            TicketDetailsSubject.Text = ""
                            TicketDetailsRequestor.Text = ""
                            TicketDetailsDate.Text = ""
                            TicketDetailsType.Text = ""
                            TicketDetailsPriority.Text = ""
                            TicketDetailsDescription.Text = ""
                            TicketDetails.Visible = False
                            tempPanel.BackColor = SystemColors.Control
                            UpdateStatusInDB(tic.TicketNum, tic.TicketStatus)
                            FilterByStatus()
                            Dim row As Long = InsertIntoDB("Comments", {LoginForm.Username, Now.ToString(), "Marked as Complete"}, tic.Id)
                            Dim Comm As New Comment(row, tic.Id, LoginForm.Username, Now.ToString(), "Marked as Complete")
                            tic.TicketComments.Add(Comm)
                            Return
                        End If
                    Next
                End If
            Next
        End If
    End Sub

#End Region

#Region "Comments"
    ' Submits Comment to DB and draws new label for it
    Private Sub CommentSubmit_Click(sender As Object, e As EventArgs) Handles CommentSubmit.Click
        If Trim(CommentTextBox.Text) <> "" Then
            Dim row As Long = InsertIntoDB("Comments", {LoginForm.Username, Now.ToString(), CommentTextBox.Text}, CurrentTicket.Id)
            Dim Comm As New Comment(row, CurrentTicket.Id, LoginForm.Username, Now.ToString(), CommentTextBox.Text)
            CurrentTicket.TicketComments.Add(Comm)
            CreateCommentLabel(Comm)
            CommentTextBox.Text = ""
        End If
    End Sub

    ' catches enter from textbox to send comment
    Private Sub CommentTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles CommentTextBox.KeyDown
        If (e.KeyCode = Keys.Return Or e.KeyCode = Keys.Enter) Then
            e.SuppressKeyPress = True
            CommentSubmit_Click(sender, e)
        End If
    End Sub
#End Region

    ' exits app if exit is pressed
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    ' Return to login screen
    Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoutToolStripMenuItem.Click
        loggingOut = True
        Me.Close()
    End Sub

    ' exits app if exit is pressed in window
    Private Sub TicketForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not loggingOut Then
            Application.Exit()
        End If
    End Sub
End Class
