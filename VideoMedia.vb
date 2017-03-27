Public Class VideoMedia
    Inherits media
    Private mStarring As String
    Private mDirector As String
    Private Const MBORROWINGDAYS As Integer = 3

    Public Overrides ReadOnly Property BorrowingDays() As Integer
        Get
            Return MBORROWINGDAYS
        End Get
    End Property


    Public Property Starring()
        Get
            Return mStarring
        End Get
        Set(ByVal value)
            mStarring = value
        End Set
    End Property

    Public Property Director()
        Get
            Return mDirector
        End Get
        Set(ByVal value)
            mDirector = value
        End Set
    End Property

    Public Overrides ReadOnly Property AdditionalInfo() As String
        Get
            Return mStarring & " - " & mDirector
        End Get
    End Property

    Public Sub New(ByVal Title As String, ByVal Starring As String, ByVal Director As String, ByVal Type As String)
        MyBase.New(Title, Type)
        Select Case Type
            Case "VHS", "DVD"
                mDirector = Director
                mStarring = Starring
            Case Else
                Throw New Exception("Not a valid Video Media Type.")
        End Select
    End Sub
End Class
