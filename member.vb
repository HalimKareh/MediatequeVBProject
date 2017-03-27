Public Class member


    Private Shared counter As Integer
    Private mLastName, mFirstName, mPhoneNumber, mID As String
    Private mMaxNbrOfBorrowings = 3, mNbrOfCurrentBorrowings As Integer


    Public ReadOnly Property LastName() As String
        Get
            Return mLastName
        End Get
    End Property


    Public ReadOnly Property FirstName() As String
        Get
            Return mFirstName
        End Get
    End Property


    Public ReadOnly Property PhoneNumber() As String
        Get
            Return mPhoneNumber
        End Get
    End Property


    Public ReadOnly Property MaxNbrOfBrrowings() As Integer
        Get
            Return mMaxNbrOfBorrowings
        End Get
    End Property


    Public ReadOnly Property NbrOfCurrentBorrowings() As Integer
        Get
            Return mNbrOfCurrentBorrowings
        End Get
    End Property


    Public ReadOnly Property ID() As String
        Get
            Return mID
        End Get
    End Property


    Public Sub New(ByRef LastName As String, _
                   ByRef FirstName As String, _
                   ByRef PhoneNumber As String)
        mLastName = LastName
        mFirstName = FirstName
        mPhoneNumber = PhoneNumber
        counter += 1
        mID = CStr(counter)
    End Sub


    Public Sub BorrowMedia()
        canBorrow()
        mNbrOfCurrentBorrowings += 1
    End Sub


    Public Sub returnMedia()
        If mNbrOfCurrentBorrowings = 0 Then
            Throw New Exception("You do not have items to return!")
        End If
        mNbrOfCurrentBorrowings -= 1
    End Sub


    Public Function getFullName() As String
        Return mLastName & ", " & mFirstName
    End Function


    Public Function canBorrow() As Boolean
        If mMaxNbrOfBorrowings < mNbrOfCurrentBorrowings + 1 Then
            Throw New Exception("You may not exceed your maximum number of borrowing!")
        Else
            Return True
        End If
    End Function

    Public Overrides Function ToString() As String
        Return mID & "- " & getFullName() & " - " & mPhoneNumber
    End Function

End Class