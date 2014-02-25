Imports System.Runtime.Serialization
Imports System.IO

<System.Serializable()> _
Public Class HighscoreTable

    ' Contains ALL the entries in the highscore list, regardless of category
    Public Entries As New List(Of Entry)

    ' Contains default values
    Public MaxEntries As Integer = 10
    Public Category As String

    Public Sub New()
        ' Normal creation
    End Sub

    Public Sub New(ByVal Category As String, Optional ByVal MaxEntries As Integer = 10, _
     Optional ByVal Entries As List(Of Entry) = Nothing)

        ' Set the default value
        If Entries Is Nothing Then
            Entries = New List(Of Entry)
        End If

        ' Set these values
        With Me
            .Category = Category
            .Entries = Entries
            .MaxEntries = MaxEntries
        End With

    End Sub

    ' Returns whether or not the given points is enough to be added to the list
    Public Function IsHighscore(ByVal Points As Double) As Boolean

        Dim iIndex As Integer = 1

        ' See if there is a highscore that is worse than this
        For Each oEntry As Entry In Entries

            ' Check the points
            If oEntry.Points > Points Then
                Exit For
            End If

            ' Increase the index
            iIndex += 1

        Next

        ' Return what we found
        Return iIndex <= MaxEntries

    End Function

    ' Uses the above method
    Public Function IsHighscore(ByVal Entry As Entry) As Boolean
        Return IsHighscore(Entry.Points)
    End Function

    ' Simplifies appending of new entries to the highscore
    Public Function AddEntry(ByVal newEntry As Entry) As Entry

        ' Add the entry to the list
        Entries.Add(newEntry)

        ' Sort the list again
        Entries.Sort()

        ' Remove excessive entries
        If Entries.Count > MaxEntries Then
            Entries.RemoveRange(MaxEntries - 1, Entries.Count - MaxEntries)
        End If

        ' Set the parent
        newEntry.Parent = Me

        ' And finally, return the entry
        Return newEntry

    End Function

End Class

<Serializable()> _
Public Structure Entry
    Implements IComparable

    ' Contains the name and amount of points of this entry
    Public Name As String
    Public Points As Double

    ' The parent highscore-table
    <System.NonSerialized()> _
    Public Parent As HighscoreTable

    Public Sub New(ByVal Name As String, ByVal Points As Double)
        ' Initialize the values
        With Me
            .Name = Name
            .Points = Points
        End With
    End Sub

    Public Function CompareTo(ByVal Other As Object) As Integer _
     Implements System.IComparable.CompareTo

        ' Just compare the points
        If TypeOf Other Is Entry Then
            Return Points.CompareTo(Other.Points)
        Else
            ' If the object is a double, compare it directly.
            If TypeOf Other Is Double Then
                Return Points.CompareTo(Other)
            End If
        End If

    End Function

End Structure