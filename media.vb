Public MustInherit Class media

    Enum MediaType
        CD
        K7
        LP
        DVD
        VHS
    End Enum


    Private mTitle, mAdditionalInfo As String
    Private mBorrowDate, mMaxReturnDate As Date
    Private mBorrower As member
    Private mType As String
    Private mAvailable = True

    Public MustOverride ReadOnly Property AdditionalInfo() As String

    Public MustOverride ReadOnly Property BorrowingDays() As Integer

    Public ReadOnly Property Available() As Boolean
        Get
            Return mAvailable
        End Get
    End Property

    Public ReadOnly Property borrower() As member
        Get
            Return mBorrower
        End Get
    End Property

    Public ReadOnly Property Title() As String
        Get
            Return mTitle
        End Get
    End Property

    Public ReadOnly Property type() As String
        Get
            Return mType
        End Get
    End Property

    Public ReadOnly Property BorrowDate() As Date
        Get
            Return mBorrowDate
        End Get
    End Property

    Public ReadOnly Property MaxReturnDate() As Date
        Get
            Return mMaxReturnDate
        End Get
    End Property

    Public Sub New(ByVal Title As String, ByVal type As String)
        mTitle = Title
        mType = type

    End Sub

    Public Sub BorrowMedia(ByVal BorrowDate As Date)
        If mAvailable = True Then
            mAvailable = False
            mBorrowDate = BorrowDate
            mMaxReturnDate = mBorrowDate.AddDays(BorrowingDays)
        Else
            Throw New Exception("The wanted media is currently not available!")
        End If
    End Sub

    Public Sub returnMedia()
        If mAvailable = False Then
            mAvailable = True
            mBorrower = Nothing
        Else
            Throw New Exception("The media has not been borrowed so it cannot be returned.")
        End If
    End Sub
    Public Overrides Function toString() As String
        Return type & " - " & Title & vbCrLf & AdditionalInfo & vbCrLf & "Available: " & mAvailable
    End Function

End Class

