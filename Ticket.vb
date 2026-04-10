Imports Microsoft.VisualBasic

Public Class Ticket
    Dim Id As Long
    Dim TicketNum, TicketStatus, TicketDate, TicketType, TicketSubject As String
    Dim Requestor, Description As String
    Dim Priority As Integer
    Dim TicketComments As Comment()

    Public Sub New(Id As Long, TicketNum As String, TicketStatus As String, TicketDate As String, TicketType As String, TicketSubject As String, Comments As Comment()
        Me.Id = Id
        Me.TicketNum = TicketNum
        Me.TicketStatus = TicketStatus
        Me.TicketDate = TicketDate
        Me.TicketType = TicketType
        Me.TicketSubject = TicketSubject
        Me.TicketComments = Comments
    End Sub

    Public Property ID() As Long
        Get
            Return Me.Id
        End Get
        Set(value As Long)
            Me.Id = value
        End Set
    End Property


End Class

Public Class Comment
    Dim Id As Long
    Dim User, Timestamp, CommentText As String

    Public Sub New(Id, User, Timestamp, CommentText)
        Me.Id = Id
        Me.User = User
        Me.Timestamp = Timestamp
        Me.CommentText = CommentText
    End Sub
End Class
