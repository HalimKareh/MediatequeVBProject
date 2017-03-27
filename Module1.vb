Module Module1

    Sub Main()
        'create random users 
        Dim users As New ArrayList()
        users.Add(New member("Kareh", "Halim", "70/681070"))
        users.Add(New member("Hanna", "Marc", "70/098765"))
        users.Add(New member("Hakim", "Maya", "70/101587"))
        users.Add(New member("Chammas", "Carol", "70/123123"))
        users.Add(New member("DeLa Bergerie", "Jean-Jaques", "70/990011"))

        'Create a random Library
        Dim mediaLibrary As New ArrayList()
        mediaLibrary.Add(New AudioMedia("Power", "Marcus Miller", "CD"))
        mediaLibrary.Add(New AudioMedia("Watermelon Man", "Herbie Hancock", "CD"))
        mediaLibrary.Add(New VideoMedia("Lord Of the Rings", "Liv Tyler, Ian McKellen, Elijah Woods", "J. R. R. Tolkien", "DVD"))
        mediaLibrary.Add(New AudioMedia("Hail to the King", "Avenged SevenFold", "LP"))
        mediaLibrary.Add(New AudioMedia("Conte partiro", "Andrea Boccelli", "K7"))
        mediaLibrary.Add(New VideoMedia("The Avengers", "Scarlett Johanson, Samuel Jackson, Marc Ruffalo", "Marvel Studios", "VHS"))
        mediaLibrary.Add(New AudioMedia("Dark Side of the Moon", "Pink Floyd", "LP"))
        mediaLibrary.Add(New AudioMedia("Give me one reason", "Tracy Chapman", "K7"))
        mediaLibrary.Add(New VideoMedia("Liar Liar", "Jim Carrey", "John Doe", "VHS"))
        mediaLibrary.Add(New AudioMedia("Giant Step", "John Coltrane", "CD"))
        mediaLibrary.Add(New AudioMedia("Bous el WAWA", "Haifa Wehbe", "K7"))
        mediaLibrary.Add(New VideoMedia("The Prophet", "Liam Neeson, Salma Hayek", "John Doe", "CD"))
        mediaLibrary.Add(New AudioMedia("Wicked Games", "Ib Lug", "CD"))

        'Users media
        Dim userMedia As New ArrayList()

        Console.WriteLine("      -----    Mediatech    -----")
        Console.WriteLine("Welcome to your mediatech application, please enter your following coordinates to create a new user: ")

        Dim Mem As member = NewUser()

        '(P)rint the mediatech,(S)how what you have in your possesion, (B)orrow some media , (R)eturn some media, or nothing to exit. ")
        Dim input As Integer
        Dim user As member
        While True
            Try
                Console.WriteLine(" Please Choose a member(By ID):")
                printList(users)
                input = CInt(Console.ReadLine())
                user = users(input)
                Select Case input
                    Case ""
                        Exit While
                    Case "p"
                        printList(mediaLibrary)
                    Case "s"
                        printList(userMedia)
                    Case "b"
                        Mem.BorrowMedia()
                        Console.WriteLine("Please indicate the index of the media you like to borrow: ")
                        printList(mediaLibrary)
                        Dim index As Integer = CInt(Console.ReadLine)
                        mediaLibrary(index - 1).borrowMedia(DateAndTime.Today)
                        userMedia.Add(mediaLibrary(index - 1))
                        Console.WriteLine("Media Borrowed")
                    Case "r"
                        If userMedia.Count = 0 Then
                            Throw New Exception("You have nothing to return.")
                        End If
                        Console.WriteLine("Please indicate the index of the media you like to return: ")
                        printList(userMedia)
                        Dim index As Integer = CInt(Console.ReadLine)

                        mediaLibrary(mediaLibrary.IndexOf(userMedia(index - 1))).returnMedia()
                        userMedia.RemoveAt(index - 1)
                        Console.WriteLine("Media Return Succesfull.")
                    Case Else
                        Throw New Exception("Ivalid command.")
                End Select

            Catch ex As Exception
                Console.BackgroundColor = ConsoleColor.DarkRed
                Console.WriteLine(ex.Message)
                Console.Beep()
                Console.ResetColor()
            End Try
            Console.WriteLine("What would you like to do?(P)rint the mediatech,(S)how what you have in your possesion, (B)orrow some media , (R)eturn some media, or nothing to exit. ")
        End While


    End Sub

    'In case of multiple users
    Public Function NewUser() As member
        Console.Write("Last Name: ")
        Dim LastName As String = Console.ReadLine()
        Console.Write("First Name: ")
        Dim FirstName As String = Console.ReadLine()
        Console.Write("Phone Number: ")
        Dim phoneNumber As String = Console.ReadLine()
        
        Return New member(LastName, FirstName, phoneNumber)
    End Function


    'For later use
    Public Function newMedia() As media
        Console.Write("Type: (CD, K7,LP,DVD,VHS)")
        Dim type As String = Console.ReadLine()
        Console.Write("Title: ")
        Dim title As String = Console.ReadLine()
        Select Case type
            Case "CD", "K7", "LP"
                Console.Write("Artist: ")
                Dim artist As String = Console.ReadLine()
                Return New AudioMedia(title, artist, type)
            Case "DVD", "VHS"
                Console.Write("Starring: ")
                Dim starring As String = Console.ReadLine
                Console.Write("Director: ")
                Dim director As String = Console.ReadLine
                Return New VideoMedia(title, starring, director, type)
            Case Else
                Throw New Exception("Incorrect type. Please select CD, K7,LP,DVD or VHS")

        End Select        
    End Function

    Public Sub printList(ByVal list As ArrayList)
        Console.BackgroundColor = ConsoleColor.DarkYellow
        If list.Count = 0 Then
            Console.WriteLine("You currently posses no media.")
        End If
        Dim index As Integer = 1
        For Each element As media In list
            Console.WriteLine(index & ". " & element.toString & vbCrLf)
            index += 1
        Next
        Console.ResetColor()
    End Sub
End Module