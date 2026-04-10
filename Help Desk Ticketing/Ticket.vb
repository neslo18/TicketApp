Imports Microsoft.VisualBasic

Public Class Ticket

    Public Property Id() As Long
    Public Property TicketNum() As String
    Public Property TicketStatus() As String
    Public Property TicketDate() As String
    Public Property TicketType() As String
    Public Property TicketSubject() As String
    Public Property TicketPriority() As String
    Public Property TicketDescription() As String
    Public Property TicketRequestor() As String
    Public Property TicketComments() As New List(Of Comment)
    Public Property TicketPanel() As Panel

    Public Sub New(Id As Long, TicketNum As String, TicketSubject As String, TicketRequestor As String, TicketDate As String, TicketType As String, TicketPriority As String, TicketDescription As String, TicketStatus As String)
        Me.Id = Id
        Me.TicketNum = TicketNum
        Me.TicketStatus = TicketStatus
        Me.TicketDate = TicketDate
        Me.TicketType = TicketType
        Me.TicketSubject = TicketSubject
        Me.TicketDescription = TicketDescription
        Me.TicketPriority = TicketPriority
        Me.TicketRequestor = TicketRequestor
    End Sub

End Class

Public Class Comment
    Public Property Id() As Long
    Private Property TicketId As Long
    Private Property User() As String
    Private Property Timestamp As String
    Private Property CommentText() As String

    Public Sub New(Id As Long, TicketId As Long, User As String, Timestamp As String, CommentText As String)
        Me.Id = Id
        Me.User = User
        Me.TicketId = TicketId
        Me.Timestamp = Timestamp
        Me.CommentText = CommentText
    End Sub

    Public Function GetText() As String
        Return $"{Timestamp} - [{User}]: {CommentText}"
    End Function
End Class
