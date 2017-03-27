Public Class AudioMedia
    Inherits media
    Private mArtist As String
    Private Const MBORROWINGDAYS As Integer = 2

    Public Overrides ReadOnly Property BorrowingDays() As Integer
        Get
            Return MBORROWINGDAYS
        End Get
    End Property

    Public ReadOnly Property Artist() As String
        Get
            Return mArtist
        End Get
    End Property
    Public Overrides ReadOnly Property AdditionalInfo() As String
        Get
            Return mArtist
        End Get
    End Property

    Public Sub New(ByVal Title As String, ByVal Artist As String, ByVal Type As String)
        MyBase.New(Title, Type.ToUpper)
        Type = Type.ToUpper
        Select Case Type
            Case "CD", "K7", "LP"
                mArtist = Artist
            Case Else
                Throw New Exception("Not an audio type.")
        End Select
    End Sub


End Class
