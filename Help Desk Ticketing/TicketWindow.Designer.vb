<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TicketForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
        MenuBar = New MenuStrip()
        FileToolStripMenuItem = New ToolStripMenuItem()
        NewTicketToolStripMenuItem = New ToolStripMenuItem()
        LogoutToolStripMenuItem = New ToolStripMenuItem()
        ExitToolStripMenuItem = New ToolStripMenuItem()
        SplitContainerTickets = New SplitContainer()
        FlowLayoutPanelSideList = New FlowLayoutPanel()
        MasterSidePanel = New FlowLayoutPanel()
        StatusPanel = New Panel()
        CompleteCheck = New CheckBox()
        StatusBorder = New Panel()
        PendingCheck = New CheckBox()
        TicketDetails = New Panel()
        CancelTicket = New LinkLabel()
        TicketDetailsDate = New Label()
        TicketDetailsType = New ComboBox()
        TicketDetailsSubject = New TextBox()
        TicketDetailsRequestor = New TextBox()
        TicketDetailsDesciptionTicketsTable = New TableLayoutPanel()
        TicketDetailsDescription = New TextBox()
        CommentsPanel = New Panel()
        CommentsInputPanel = New Panel()
        CommentSubmit = New Button()
        CommentTextBox = New TextBox()
        CommentsFlowLayout = New FlowLayoutPanel()
        CommentsBottomBorder = New Panel()
        CommentTopBorder = New Panel()
        CompleteOrAddTicketButton = New Button()
        TicketDetailsDescriptionLabel = New Label()
        TicketDetailsPriorityLabel = New Label()
        TicketDetailsPriority = New ComboBox()
        TicketDetailsTypeLabel = New Label()
        TicketDetailsDateLabel = New Label()
        TicketDetailsRequestorLabel = New Label()
        TicketDetailsSubjectLabel = New Label()
        TicketDetailsStatus = New Label()
        dashLabel = New Label()
        TicketDetailsNum = New Label()
        MainBorder = New Panel()
        MenuBar.SuspendLayout()
        CType(SplitContainerTickets, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainerTickets.Panel1.SuspendLayout()
        SplitContainerTickets.Panel2.SuspendLayout()
        SplitContainerTickets.SuspendLayout()
        MasterSidePanel.SuspendLayout()
        StatusPanel.SuspendLayout()
        TicketDetails.SuspendLayout()
        TicketDetailsDesciptionTicketsTable.SuspendLayout()
        CommentsPanel.SuspendLayout()
        CommentsInputPanel.SuspendLayout()
        SuspendLayout()
        ' 
        ' MenuBar
        ' 
        MenuBar.ImageScalingSize = New Size(20, 20)
        MenuBar.Items.AddRange(New ToolStripItem() {FileToolStripMenuItem})
        MenuBar.Location = New Point(0, 0)
        MenuBar.Name = "MenuBar"
        MenuBar.Size = New Size(982, 28)
        MenuBar.TabIndex = 0
        MenuBar.Text = "MenuStrip1"
        ' 
        ' FileToolStripMenuItem
        ' 
        FileToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {NewTicketToolStripMenuItem, LogoutToolStripMenuItem, ExitToolStripMenuItem})
        FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        FileToolStripMenuItem.Size = New Size(46, 24)
        FileToolStripMenuItem.Text = "File"
        ' 
        ' NewTicketToolStripMenuItem
        ' 
        NewTicketToolStripMenuItem.Name = "NewTicketToolStripMenuItem"
        NewTicketToolStripMenuItem.Size = New Size(165, 26)
        NewTicketToolStripMenuItem.Text = "New Ticket"
        ' 
        ' LogoutToolStripMenuItem
        ' 
        LogoutToolStripMenuItem.Name = "LogoutToolStripMenuItem"
        LogoutToolStripMenuItem.Size = New Size(165, 26)
        LogoutToolStripMenuItem.Text = "Logout"
        ' 
        ' ExitToolStripMenuItem
        ' 
        ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        ExitToolStripMenuItem.Size = New Size(165, 26)
        ExitToolStripMenuItem.Text = "Exit"
        ' 
        ' SplitContainerTickets
        ' 
        SplitContainerTickets.Dock = DockStyle.Fill
        SplitContainerTickets.Location = New Point(0, 28)
        SplitContainerTickets.Name = "SplitContainerTickets"
        ' 
        ' SplitContainerTickets.Panel1
        ' 
        SplitContainerTickets.Panel1.Controls.Add(FlowLayoutPanelSideList)
        SplitContainerTickets.Panel1.Controls.Add(MasterSidePanel)
        ' 
        ' SplitContainerTickets.Panel2
        ' 
        SplitContainerTickets.Panel2.Controls.Add(TicketDetails)
        SplitContainerTickets.Panel2.Controls.Add(MainBorder)
        SplitContainerTickets.Size = New Size(982, 675)
        SplitContainerTickets.SplitterDistance = 375
        SplitContainerTickets.TabIndex = 1
        ' 
        ' FlowLayoutPanelSideList
        ' 
        FlowLayoutPanelSideList.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        FlowLayoutPanelSideList.AutoScroll = True
        FlowLayoutPanelSideList.FlowDirection = FlowDirection.TopDown
        FlowLayoutPanelSideList.Location = New Point(1, 54)
        FlowLayoutPanelSideList.Name = "FlowLayoutPanelSideList"
        FlowLayoutPanelSideList.Size = New Size(347, 608)
        FlowLayoutPanelSideList.TabIndex = 0
        FlowLayoutPanelSideList.WrapContents = False
        ' 
        ' MasterSidePanel
        ' 
        MasterSidePanel.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        MasterSidePanel.AutoScroll = True
        MasterSidePanel.Controls.Add(StatusPanel)
        MasterSidePanel.FlowDirection = FlowDirection.TopDown
        MasterSidePanel.Location = New Point(3, 3)
        MasterSidePanel.Name = "MasterSidePanel"
        MasterSidePanel.Size = New Size(369, 659)
        MasterSidePanel.TabIndex = 2
        MasterSidePanel.WrapContents = False
        ' 
        ' StatusPanel
        ' 
        StatusPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink
        StatusPanel.Controls.Add(CompleteCheck)
        StatusPanel.Controls.Add(StatusBorder)
        StatusPanel.Controls.Add(PendingCheck)
        StatusPanel.Location = New Point(3, 3)
        StatusPanel.Name = "StatusPanel"
        StatusPanel.Size = New Size(342, 46)
        StatusPanel.TabIndex = 1
        ' 
        ' CompleteCheck
        ' 
        CompleteCheck.Anchor = AnchorStyles.None
        CompleteCheck.AutoSize = True
        CompleteCheck.Location = New Point(168, 11)
        CompleteCheck.Name = "CompleteCheck"
        CompleteCheck.Size = New Size(96, 24)
        CompleteCheck.TabIndex = 1
        CompleteCheck.Text = "Complete"
        CompleteCheck.UseVisualStyleBackColor = True
        ' 
        ' StatusBorder
        ' 
        StatusBorder.BackColor = SystemColors.ActiveCaptionText
        StatusBorder.Dock = DockStyle.Bottom
        StatusBorder.Location = New Point(0, 45)
        StatusBorder.Name = "StatusBorder"
        StatusBorder.Size = New Size(342, 1)
        StatusBorder.TabIndex = 1
        ' 
        ' PendingCheck
        ' 
        PendingCheck.Anchor = AnchorStyles.None
        PendingCheck.AutoSize = True
        PendingCheck.Checked = True
        PendingCheck.CheckState = CheckState.Checked
        PendingCheck.Location = New Point(78, 11)
        PendingCheck.Name = "PendingCheck"
        PendingCheck.Size = New Size(84, 24)
        PendingCheck.TabIndex = 0
        PendingCheck.Text = "Pending"
        PendingCheck.UseVisualStyleBackColor = True
        ' 
        ' TicketDetails
        ' 
        TicketDetails.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        TicketDetails.Controls.Add(CancelTicket)
        TicketDetails.Controls.Add(TicketDetailsDate)
        TicketDetails.Controls.Add(TicketDetailsType)
        TicketDetails.Controls.Add(TicketDetailsSubject)
        TicketDetails.Controls.Add(TicketDetailsRequestor)
        TicketDetails.Controls.Add(TicketDetailsDesciptionTicketsTable)
        TicketDetails.Controls.Add(CompleteOrAddTicketButton)
        TicketDetails.Controls.Add(TicketDetailsDescriptionLabel)
        TicketDetails.Controls.Add(TicketDetailsPriorityLabel)
        TicketDetails.Controls.Add(TicketDetailsPriority)
        TicketDetails.Controls.Add(TicketDetailsTypeLabel)
        TicketDetails.Controls.Add(TicketDetailsDateLabel)
        TicketDetails.Controls.Add(TicketDetailsRequestorLabel)
        TicketDetails.Controls.Add(TicketDetailsSubjectLabel)
        TicketDetails.Controls.Add(TicketDetailsStatus)
        TicketDetails.Controls.Add(dashLabel)
        TicketDetails.Controls.Add(TicketDetailsNum)
        TicketDetails.Location = New Point(3, 3)
        TicketDetails.Name = "TicketDetails"
        TicketDetails.Size = New Size(597, 660)
        TicketDetails.TabIndex = 1
        ' 
        ' CancelTicket
        ' 
        CancelTicket.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        CancelTicket.AutoSize = True
        CancelTicket.Location = New Point(495, 616)
        CancelTicket.Name = "CancelTicket"
        CancelTicket.Size = New Size(53, 20)
        CancelTicket.TabIndex = 29
        CancelTicket.TabStop = True
        CancelTicket.Text = "Cancel"
        ' 
        ' TicketDetailsDate
        ' 
        TicketDetailsDate.Anchor = AnchorStyles.Top
        TicketDetailsDate.AutoSize = True
        TicketDetailsDate.Location = New Point(420, 140)
        TicketDetailsDate.Name = "TicketDetailsDate"
        TicketDetailsDate.Size = New Size(69, 20)
        TicketDetailsDate.TabIndex = 28
        TicketDetailsDate.Text = "03/03/26"
        ' 
        ' TicketDetailsType
        ' 
        TicketDetailsType.Anchor = AnchorStyles.Top
        TicketDetailsType.FlatStyle = FlatStyle.System
        TicketDetailsType.FormattingEnabled = True
        TicketDetailsType.Items.AddRange(New Object() {"Request", "Incident"})
        TicketDetailsType.Location = New Point(70, 200)
        TicketDetailsType.Name = "TicketDetailsType"
        TicketDetailsType.Size = New Size(90, 28)
        TicketDetailsType.TabIndex = 2
        TicketDetailsType.Text = "Request"
        ' 
        ' TicketDetailsSubject
        ' 
        TicketDetailsSubject.Anchor = AnchorStyles.Top
        TicketDetailsSubject.BackColor = SystemColors.Control
        TicketDetailsSubject.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold)
        TicketDetailsSubject.Location = New Point(158, 61)
        TicketDetailsSubject.Name = "TicketDetailsSubject"
        TicketDetailsSubject.Size = New Size(366, 34)
        TicketDetailsSubject.TabIndex = 0
        ' 
        ' TicketDetailsRequestor
        ' 
        TicketDetailsRequestor.Anchor = AnchorStyles.Top
        TicketDetailsRequestor.BackColor = SystemColors.Control
        TicketDetailsRequestor.BorderStyle = BorderStyle.None
        TicketDetailsRequestor.Location = New Point(154, 140)
        TicketDetailsRequestor.Name = "TicketDetailsRequestor"
        TicketDetailsRequestor.ReadOnly = True
        TicketDetailsRequestor.Size = New Size(132, 20)
        TicketDetailsRequestor.TabIndex = 1
        ' 
        ' TicketDetailsDesciptionTicketsTable
        ' 
        TicketDetailsDesciptionTicketsTable.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        TicketDetailsDesciptionTicketsTable.ColumnCount = 1
        TicketDetailsDesciptionTicketsTable.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0F))
        TicketDetailsDesciptionTicketsTable.Controls.Add(TicketDetailsDescription, 0, 0)
        TicketDetailsDesciptionTicketsTable.Controls.Add(CommentsPanel, 0, 1)
        TicketDetailsDesciptionTicketsTable.Location = New Point(73, 272)
        TicketDetailsDesciptionTicketsTable.Name = "TicketDetailsDesciptionTicketsTable"
        TicketDetailsDesciptionTicketsTable.RowCount = 2
        TicketDetailsDesciptionTicketsTable.RowStyles.Add(New RowStyle(SizeType.Percent, 35.0F))
        TicketDetailsDesciptionTicketsTable.RowStyles.Add(New RowStyle(SizeType.Percent, 65.0F))
        TicketDetailsDesciptionTicketsTable.Size = New Size(451, 321)
        TicketDetailsDesciptionTicketsTable.TabIndex = 4
        ' 
        ' TicketDetailsDescription
        ' 
        TicketDetailsDescription.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        TicketDetailsDescription.BackColor = SystemColors.InactiveBorder
        TicketDetailsDescription.Location = New Point(3, 3)
        TicketDetailsDescription.Multiline = True
        TicketDetailsDescription.Name = "TicketDetailsDescription"
        TicketDetailsDescription.Size = New Size(445, 106)
        TicketDetailsDescription.TabIndex = 6
        ' 
        ' CommentsPanel
        ' 
        CommentsPanel.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        CommentsPanel.Controls.Add(CommentsInputPanel)
        CommentsPanel.Controls.Add(CommentsFlowLayout)
        CommentsPanel.Controls.Add(CommentsBottomBorder)
        CommentsPanel.Controls.Add(CommentTopBorder)
        CommentsPanel.Location = New Point(3, 115)
        CommentsPanel.Name = "CommentsPanel"
        CommentsPanel.Padding = New Padding(0, 0, 0, 5)
        CommentsPanel.Size = New Size(445, 203)
        CommentsPanel.TabIndex = 16
        ' 
        ' CommentsInputPanel
        ' 
        CommentsInputPanel.Controls.Add(CommentSubmit)
        CommentsInputPanel.Controls.Add(CommentTextBox)
        CommentsInputPanel.Dock = DockStyle.Bottom
        CommentsInputPanel.Location = New Point(0, 149)
        CommentsInputPanel.Name = "CommentsInputPanel"
        CommentsInputPanel.Padding = New Padding(2, 5, 3, 5)
        CommentsInputPanel.Size = New Size(445, 48)
        CommentsInputPanel.TabIndex = 22
        ' 
        ' CommentSubmit
        ' 
        CommentSubmit.Dock = DockStyle.Right
        CommentSubmit.Font = New Font("Segoe UI", 10.0F)
        CommentSubmit.Location = New Point(344, 5)
        CommentSubmit.Name = "CommentSubmit"
        CommentSubmit.Size = New Size(98, 38)
        CommentSubmit.TabIndex = 20
        CommentSubmit.Text = "Comment"
        CommentSubmit.UseVisualStyleBackColor = True
        ' 
        ' CommentTextBox
        ' 
        CommentTextBox.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        CommentTextBox.Font = New Font("Segoe UI", 10.0F)
        CommentTextBox.Location = New Point(2, 7)
        CommentTextBox.Margin = New Padding(3, 15, 3, 3)
        CommentTextBox.Name = "CommentTextBox"
        CommentTextBox.Size = New Size(343, 30)
        CommentTextBox.TabIndex = 19
        ' 
        ' CommentsFlowLayout
        ' 
        CommentsFlowLayout.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        CommentsFlowLayout.AutoScroll = True
        CommentsFlowLayout.BackColor = SystemColors.ControlLight
        CommentsFlowLayout.FlowDirection = FlowDirection.TopDown
        CommentsFlowLayout.Location = New Point(0, 8)
        CommentsFlowLayout.Name = "CommentsFlowLayout"
        CommentsFlowLayout.Padding = New Padding(10, 10, 30, 30)
        CommentsFlowLayout.Size = New Size(445, 135)
        CommentsFlowLayout.TabIndex = 21
        CommentsFlowLayout.WrapContents = False
        ' 
        ' CommentsBottomBorder
        ' 
        CommentsBottomBorder.BackColor = SystemColors.ActiveCaptionText
        CommentsBottomBorder.Dock = DockStyle.Bottom
        CommentsBottomBorder.Location = New Point(0, 197)
        CommentsBottomBorder.Name = "CommentsBottomBorder"
        CommentsBottomBorder.Size = New Size(445, 1)
        CommentsBottomBorder.TabIndex = 18
        ' 
        ' CommentTopBorder
        ' 
        CommentTopBorder.BackColor = SystemColors.ActiveCaptionText
        CommentTopBorder.Dock = DockStyle.Top
        CommentTopBorder.Location = New Point(0, 0)
        CommentTopBorder.Name = "CommentTopBorder"
        CommentTopBorder.Size = New Size(445, 1)
        CommentTopBorder.TabIndex = 17
        ' 
        ' CompleteOrAddTicketButton
        ' 
        CompleteOrAddTicketButton.Anchor = AnchorStyles.Bottom
        CompleteOrAddTicketButton.Font = New Font("Segoe UI", 12.0F)
        CompleteOrAddTicketButton.Location = New Point(205, 603)
        CompleteOrAddTicketButton.Name = "CompleteOrAddTicketButton"
        CompleteOrAddTicketButton.Size = New Size(187, 41)
        CompleteOrAddTicketButton.TabIndex = 5
        CompleteOrAddTicketButton.Text = "Add Ticket"
        CompleteOrAddTicketButton.UseVisualStyleBackColor = True
        ' 
        ' TicketDetailsDescriptionLabel
        ' 
        TicketDetailsDescriptionLabel.AutoSize = True
        TicketDetailsDescriptionLabel.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold)
        TicketDetailsDescriptionLabel.Location = New Point(76, 241)
        TicketDetailsDescriptionLabel.Name = "TicketDetailsDescriptionLabel"
        TicketDetailsDescriptionLabel.Size = New Size(121, 28)
        TicketDetailsDescriptionLabel.TabIndex = 15
        TicketDetailsDescriptionLabel.Text = "Description"
        ' 
        ' TicketDetailsPriorityLabel
        ' 
        TicketDetailsPriorityLabel.Anchor = AnchorStyles.Top
        TicketDetailsPriorityLabel.AutoSize = True
        TicketDetailsPriorityLabel.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold)
        TicketDetailsPriorityLabel.Location = New Point(309, 160)
        TicketDetailsPriorityLabel.Name = "TicketDetailsPriorityLabel"
        TicketDetailsPriorityLabel.Size = New Size(83, 28)
        TicketDetailsPriorityLabel.TabIndex = 14
        TicketDetailsPriorityLabel.Text = "Priority"
        ' 
        ' TicketDetailsPriority
        ' 
        TicketDetailsPriority.Anchor = AnchorStyles.Top
        TicketDetailsPriority.FlatStyle = FlatStyle.System
        TicketDetailsPriority.FormattingEnabled = True
        TicketDetailsPriority.Items.AddRange(New Object() {"High", "Low", "Medium"})
        TicketDetailsPriority.Location = New Point(309, 200)
        TicketDetailsPriority.Name = "TicketDetailsPriority"
        TicketDetailsPriority.Size = New Size(90, 28)
        TicketDetailsPriority.Sorted = True
        TicketDetailsPriority.TabIndex = 3
        TicketDetailsPriority.Text = "Low"
        ' 
        ' TicketDetailsTypeLabel
        ' 
        TicketDetailsTypeLabel.Anchor = AnchorStyles.Top
        TicketDetailsTypeLabel.AutoSize = True
        TicketDetailsTypeLabel.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold)
        TicketDetailsTypeLabel.Location = New Point(62, 160)
        TicketDetailsTypeLabel.Name = "TicketDetailsTypeLabel"
        TicketDetailsTypeLabel.Size = New Size(57, 28)
        TicketDetailsTypeLabel.TabIndex = 8
        TicketDetailsTypeLabel.Text = "Type"
        ' 
        ' TicketDetailsDateLabel
        ' 
        TicketDetailsDateLabel.Anchor = AnchorStyles.Top
        TicketDetailsDateLabel.AutoSize = True
        TicketDetailsDateLabel.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold)
        TicketDetailsDateLabel.Location = New Point(420, 100)
        TicketDetailsDateLabel.Name = "TicketDetailsDateLabel"
        TicketDetailsDateLabel.Size = New Size(57, 28)
        TicketDetailsDateLabel.TabIndex = 6
        TicketDetailsDateLabel.Text = "Date"
        ' 
        ' TicketDetailsRequestorLabel
        ' 
        TicketDetailsRequestorLabel.Anchor = AnchorStyles.Top
        TicketDetailsRequestorLabel.AutoSize = True
        TicketDetailsRequestorLabel.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold)
        TicketDetailsRequestorLabel.Location = New Point(152, 100)
        TicketDetailsRequestorLabel.Name = "TicketDetailsRequestorLabel"
        TicketDetailsRequestorLabel.Size = New Size(108, 28)
        TicketDetailsRequestorLabel.TabIndex = 4
        TicketDetailsRequestorLabel.Text = "Requestor"
        ' 
        ' TicketDetailsSubjectLabel
        ' 
        TicketDetailsSubjectLabel.Anchor = AnchorStyles.Top
        TicketDetailsSubjectLabel.AutoSize = True
        TicketDetailsSubjectLabel.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold)
        TicketDetailsSubjectLabel.Location = New Point(65, 60)
        TicketDetailsSubjectLabel.Name = "TicketDetailsSubjectLabel"
        TicketDetailsSubjectLabel.Size = New Size(87, 28)
        TicketDetailsSubjectLabel.TabIndex = 3
        TicketDetailsSubjectLabel.Text = "Subject:"
        ' 
        ' TicketDetailsStatus
        ' 
        TicketDetailsStatus.Anchor = AnchorStyles.Top
        TicketDetailsStatus.AutoSize = True
        TicketDetailsStatus.Font = New Font("Segoe UI", 16.0F, FontStyle.Bold)
        TicketDetailsStatus.Location = New Point(297, 14)
        TicketDetailsStatus.Name = "TicketDetailsStatus"
        TicketDetailsStatus.Size = New Size(0, 37)
        TicketDetailsStatus.TabIndex = 2
        ' 
        ' dashLabel
        ' 
        dashLabel.Anchor = AnchorStyles.Top
        dashLabel.AutoSize = True
        dashLabel.Font = New Font("Segoe UI", 16.0F, FontStyle.Bold)
        dashLabel.Location = New Point(263, 14)
        dashLabel.Name = "dashLabel"
        dashLabel.Size = New Size(0, 37)
        dashLabel.TabIndex = 1
        ' 
        ' TicketDetailsNum
        ' 
        TicketDetailsNum.Anchor = AnchorStyles.Top
        TicketDetailsNum.AutoSize = True
        TicketDetailsNum.Font = New Font("Segoe UI", 16.0F, FontStyle.Bold)
        TicketDetailsNum.Location = New Point(65, 14)
        TicketDetailsNum.Name = "TicketDetailsNum"
        TicketDetailsNum.Size = New Size(0, 37)
        TicketDetailsNum.TabIndex = 0
        ' 
        ' MainBorder
        ' 
        MainBorder.BackColor = SystemColors.ActiveCaptionText
        MainBorder.Dock = DockStyle.Left
        MainBorder.Location = New Point(0, 0)
        MainBorder.Name = "MainBorder"
        MainBorder.Size = New Size(1, 675)
        MainBorder.TabIndex = 0
        ' 
        ' TicketForm
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(982, 703)
        Controls.Add(SplitContainerTickets)
        Controls.Add(MenuBar)
        MainMenuStrip = MenuBar
        MinimumSize = New Size(1000, 750)
        Name = "TicketForm"
        Text = "Ticket Window"
        MenuBar.ResumeLayout(False)
        MenuBar.PerformLayout()
        SplitContainerTickets.Panel1.ResumeLayout(False)
        SplitContainerTickets.Panel2.ResumeLayout(False)
        CType(SplitContainerTickets, ComponentModel.ISupportInitialize).EndInit()
        SplitContainerTickets.ResumeLayout(False)
        MasterSidePanel.ResumeLayout(False)
        StatusPanel.ResumeLayout(False)
        StatusPanel.PerformLayout()
        TicketDetails.ResumeLayout(False)
        TicketDetails.PerformLayout()
        TicketDetailsDesciptionTicketsTable.ResumeLayout(False)
        TicketDetailsDesciptionTicketsTable.PerformLayout()
        CommentsPanel.ResumeLayout(False)
        CommentsInputPanel.ResumeLayout(False)
        CommentsInputPanel.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents MenuBar As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SplitContainerTickets As SplitContainer
    Friend WithEvents FlowLayoutPanelSideList As FlowLayoutPanel
    Friend WithEvents MasterSidePanel As FlowLayoutPanel
    Friend WithEvents StatusPanel As Panel
    Friend WithEvents CompleteCheck As CheckBox
    Friend WithEvents StatusBorder As Panel
    Friend WithEvents PendingCheck As CheckBox
    Friend WithEvents MainBorder As Panel
    Friend WithEvents TicketDetails As Panel
    Friend WithEvents dashLabel As Label
    Friend WithEvents TicketDetailsNum As Label
    Friend WithEvents TicketDetailsStatus As Label
    Friend WithEvents TicketDetailsSubjectLabel As Label
    Friend WithEvents TicketDetailsRequestorLabel As Label
    Friend WithEvents TicketDetailsDescription As TextBox
    Friend WithEvents TicketDetailsPriority As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TicketDetailsTypeLabel As Label
    Friend WithEvents TicketDetailsDateLabel As Label
    Friend WithEvents TicketDetailsPriorityLabel As Label
    Friend WithEvents TicketDetailsDescriptionLabel As Label
    Friend WithEvents CommentsPanel As Panel
    Friend WithEvents CommentTopBorder As Panel
    Friend WithEvents CompleteOrAddTicketButton As Button
    Friend WithEvents CommentsBottomBorder As Panel
    Friend WithEvents CommentsFlowLayout As FlowLayoutPanel
    Friend WithEvents CommentSubmit As Button
    Friend WithEvents CommentTextBox As TextBox
    Friend WithEvents TicketDetailsDesciptionTicketsTable As TableLayoutPanel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents TicketDetailsRequestor As TextBox
    Friend WithEvents TicketDetailsSubject As TextBox
    Friend WithEvents CommentsInputPanel As Panel
    Friend WithEvents TicketDetailsType As ComboBox
    Friend WithEvents TicketDetailsDate As Label
    Friend WithEvents NewTicketToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CancelTicket As LinkLabel
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LogoutToolStripMenuItem As ToolStripMenuItem

End Class
