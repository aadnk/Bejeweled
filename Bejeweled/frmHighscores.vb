Public Class frmHighscores

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click

        ' Just exit the form
        Me.Close()

    End Sub

    Public Sub LoadHighscores(ByVal Highscores As List(Of HighscoreTable))

        ' Load both tables
        LoadTable(lstNormal, Highscores(0))
        LoadTable(lstTimed, Highscores(1))

    End Sub

    Public Sub LoadTable(ByVal ReferenceList As ListView, ByVal Highscore As HighscoreTable)

        Dim Rank As Integer

        ' Clear the given list
        ReferenceList.Items.Clear()

        ' Go through all the entries in the highscore, ...
        For Each oEntry As Entry In Highscore.Entries

            ' Used to keep track of the rank
            Rank += 1

            ' ... adding each item to the list
            With ReferenceList.Items.Add(Rank)
                .SubItems.Add(oEntry.Name)
                .SubItems.Add(oEntry.Points)
            End With

        Next

    End Sub
End Class