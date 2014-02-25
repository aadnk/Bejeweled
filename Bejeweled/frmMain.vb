' Copyright (C) 2006 Kristian S. Stangeland

' This program is free software; you can redistribute it and/or
' modify it under the terms of the GNU General Public License
' as published by the Free Software Foundation; either version 2
' of the License, or (at your option) any later version.

' This program is distributed in the hope that it will be useful,
' but WITHOUT ANY WARRANTY; without even the implied warranty of
' MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
' GNU General Public License for more details.

' You should have received a copy of the GNU General Public License
' along with this program; if not, write to the Free Software
' Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.

' Allow saving streams
Imports System.IO
Imports System.Xml.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Drawing.Drawing2D

Public Class frmMain

    ' The amount of moves that has been perfomed since the level started
    Public MovesCount As Integer

    ' Contains the list of all valid moves
    Public Moves As New List(Of Move)
    Public MoveIndex As Integer

    ' Contains the start directory
    Public StartDir As String

    ' Reference to the game class
    Public WithEvents Game As Game

    ' Contains the list of highscores
    Public Highscores As New List(Of HighscoreTable)

    ' Current rotation in degrees
    Private Rotation As Double

    Private Sub frmMain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        ' Save highscores
        SaveHighscores(Path.Combine(StartDir, "Highscores.dat"))

        ' Clean up
        Game.Buffer.Dispose()
        Game.GraphicsObject = Nothing
        Game.Buffer = Nothing
        Game.Sounds = Nothing
        Game.Board.Pieces = Nothing

    End Sub

    Private Sub GameBoard_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown

        ' Make sure we clicked the form
        If e.Button = Windows.Forms.MouseButtons.Left AndAlso Not Game.DisableInput Then

            ' Disable mouse input
            Game.DisableInput = True

            ' Increase the amount of moves
            MovesCount += 1

            ' Reverse transform
            Dim point As PointF = InvertPoint(New PointF(e.X, e.Y))

            ' Find the cell we clicked
            If Game.ClickCell(Game.Board.HitCell(point.X, point.Y)) Then

                ' Count all the available moves.
                Moves = Game.FindValidMoves
                MoveIndex = 0

                ' Update the statusbar
                UpdateStatusbar()

                ' If the amount of moves is zero, we have lost
                If Moves.Count = 0 Then
                    MessageBox.Show("Game over. No more moves!", "Game over", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    CheckPoints()
                    Game.Running = False
                    Game.Ignore(True)
                    Exit Sub
                End If

            End If

            ' Stop disabling input
            Game.DisableInput = False

        End If

    End Sub

    Private Function InvertPoint(Point As PointF) As PointF
        Dim matrix As Matrix = CreateTransform(Game.Buffer, -Rotation)
        Dim points() As PointF = {Point}

        matrix.TransformPoints(points)
        Return points(0)

    End Function

    Private Sub GameBoard_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint

        ' Draw the content of the board
        If Not (Game Is Nothing) Then
            ' Copy the bitmap to the form
            e.Graphics.Transform = CreateTransform(Game.Buffer, Rotation)
            e.Graphics.DrawImage(Game.Buffer, 0, 0)
        End If

    End Sub

    Private Sub Game_BufferRedrawing() Handles Game.BufferRedrawing

        ' Redraw the buffer to the form
        Dim g As Graphics = Me.CreateGraphics()

        g.Transform = CreateTransform(Game.Buffer, Rotation)
        g.DrawImage(Game.Buffer, 0, 0)

        ' Let events be executed
        Application.DoEvents()

    End Sub

    Private Function CreateTransform(Buffer As Bitmap, Rotation As Double) As Matrix

        Dim matrix As New Drawing2D.Matrix()

        matrix.RotateAt(Rotation, New Point(Buffer.Width / 2, Buffer.Height / 2))
        Return matrix

    End Function

    Private Sub CheckPoints()

        Dim oHighscore As HighscoreTable = Highscores(Game.Mode), sName As String

        ' See if the score qualifies as a highscore
        If oHighscore.IsHighscore(Game.Level) Then

            ' Let the user state his/hers name
            sName = InputBox("Congratulations. You've got an highscore. Please state your name:", _
             "Highscore", My.Settings.DefaultName)

            ' Make sure the user accepted the highscore
            If sName.Length <> 0 Then

                ' Add this highscore
                oHighscore.AddEntry(New Entry(sName, Game.Level))

                ' Save the stated name
                My.Settings.DefaultName = sName

            End If

        End If

    End Sub

    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Set the icon
        Me.Icon = My.Resources.Icon

        ' Get the start directory
        StartDir = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath)

        ' Load highscores
        LoadHighscores(Path.Combine(StartDir, "Highscores.dat"))

        ' Set the start directiory
        dialogSave.InitialDirectory = StartDir
        dialogOpen.InitialDirectory = StartDir

        ' Initialize the game instance
        Game = New Game

        ' Load resources
        Dim oSprite As System.Drawing.Bitmap

        ' Retrieve the image to use
        oSprite = My.Resources.Sprites

        ' Append sounds
        With Game.Sounds
            .Add(New Sound(My.Resources.Click, True), "Click")
            .Add(New Sound(My.Resources.Marble, True), "Marble")
            .Add(New Sound(My.Resources.Buzz, True), "Buzz")
        End With

        ' Edit the board itself
        With Game.Board

            ' Set the backcolor
            .BackColor = Me.BackColor

            ' Set the start location
            .Location = New Point(My.Settings.BoardX, My.Settings.BoardY)

            ' Add the pieces
            .AddPiece(New Sprite(oSprite, 0, 0, 36, 36, "Circle"))
            .AddPiece(New Sprite(oSprite, 37, 0, 36, 36, "Triangle"))
            .AddPiece(New Sprite(oSprite, 74, 0, 36, 36, "Square"))
            .AddPiece(New Sprite(oSprite, 111, 0, 36, 36, "Pentagon"))
            .AddPiece(New Sprite(oSprite, 148, 0, 36, 36, "Hexagon"))
            .AddPiece(New Sprite(oSprite, 185, 0, 36, 36, "Heptagon"))
            .AddPiece(New Sprite(oSprite, 222, 0, 36, 36, "Octagon"))

        End With

        ' Now ... create the new game.
        NewGame()

    End Sub

    Private Sub NewGame()

        ' Use this class
        With Game

            ' Initialize settings
            .EnableSound = My.Settings.EnableSound
            .SpeedDestruction = My.Settings.SpeedDestruction
            .SpeedShift = My.Settings.SpeedShift
            .SpeedSwap = My.Settings.SpeedSwap

            ' Create a new temporary buffer
            .Buffer = New Bitmap(1, 1, Me.CreateGraphics())
            .GraphicsObject = Graphics.FromImage(.Buffer)

            ' Start a new game automatically
            .NewGame(My.Settings.BoardWidth, My.Settings.BoardHeight)

            ' Resize the buffer
            ResizeBuffer(Game)

            ' Reposition controls
            ResizeControls()

            ' Redraw the board
            .RedrawBoard()

        End With

    End Sub

    Private Sub ResizeBuffer(ByVal oGame As Game)

        With oGame

            ' Then, resize the buffer to make it fit perfectly
            .Buffer = New Bitmap(.Board.Size.Width + .Board.Location.X, _
             .Board.Size.Height + .Board.Location.Y, Me.CreateGraphics())
            .GraphicsObject = Graphics.FromImage(.Buffer)

        End With

    End Sub

    Public Sub UpdateProgress(ByVal Level As Integer, Optional ByVal Value As Integer = 0)

        ' Set the max value
        gameProgress.Maximum = My.Settings.ToNextLevel * Level * My.Settings.ToNextIncrease
        gameProgress.Value = Value

        ' Update the statusbar
        UpdateStatusbar()

    End Sub

    Public Sub ResizeControls()

        ' Firstly, set the size of the window
        Me.Width = Game.Buffer.Width + 9
        Me.Height = Game.Buffer.Height + gameProgress.Size.Height + 48
        Me.gameProgress.Top = Game.Buffer.Height - 18
        Me.gameProgress.Width = Game.Buffer.Width - 18

    End Sub

    Public Sub NextLevel()

        Dim Cells As List(Of Cell), Cell As Cell

        ' Reset the amount of moves
        MovesCount = 0

        ' Get all cells
        Cells = Game.Board.Range

        ' Animate the removal of all the cells
        Game.AnimateDestruction(Cells, Game.SpeedDestruction)

        ' Wait a bit
        Threading.Thread.Sleep(50)

        ' Randomize the board
        Game.Board.RandomizeCells()

        ' Remove cells that yeild any points
        Game.Ignore(True)
        Game.TestBoard(3)
        Game.UndoIgnore()

        ' Show the cells again
        For Each Cell In Cells
            Cell.Visible = True
        Next

        ' Let the cells reemerge
        Game.AnimateDestruction(Cells, Game.SpeedDestruction, True, True)

        ' Count the amount of valid moves
        Moves = Game.FindValidMoves
        MoveIndex = 0

        ' Increase the level
        Game.Level += 1

        ' Increase the decremetor
        Game.IntervalDecrease *= Game.IntervalMultiplicator

        ' Set the progress
        UpdateProgress(Game.Level)

    End Sub

    Private Sub UpdateStatusbar()

        ' Set the labels
        lblScore.Text = "Score: " & gameProgress.Value & " \ " & gameProgress.Maximum
        lblLevel.Text = "Level: " & Game.Level
        lblMoves.Text = "Valid moves: " & Moves.Count

    End Sub

    Private Sub Game_GameCreated() Handles Game.GameCreated

        ' Reset variables
        Game.DisableInput = False
        MovesCount = 0

        ' Use the current game
        With Game

            ' Set the ignore variables
            .Ignore(Not My.Settings.EnableAnimations, False)

            ' Set the level we're in
            .Level = My.Settings.StartLevel
            .Bonus = My.Settings.BonusValue

            Do

                ' Count the amount of moves
                Moves = Game.FindValidMoves

                ' Update the progress and statusbar
                UpdateProgress(.Level)

                ' Make sure we begin with at least one move
            Loop While Moves.Count = 0

        End With

    End Sub

    Private Sub Game_SequenceDestroyed(ByVal Bonus As Integer, ByRef Cancel As Boolean) Handles Game.SequenceDestroyed

        ' If we're not redrawing, then we're most likely not supposed to count this.
        If Not Game.IgnoreRedraw Then

            ' Rotate the board
            Rotation += If(Rnd() < 0.5, 90, -90)

            ' Increase the progress
            gameProgress.Increment(Game.Bonus * (My.Settings.BonusMuliplicator ^ Bonus))

            ' Save the progress' value
            Game.Points = gameProgress.Value

            ' If we've reached the end, ...
            If gameProgress.Value >= gameProgress.Maximum Then
                NextLevel()
                Cancel = True
            Else

                ' Update the staturbar
                UpdateStatusbar()

            End If

        End If

    End Sub

    Private Sub mnuExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuExit.Click

        ' Close the game
        Me.Close()

    End Sub

    Private Sub mnuNormal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuNormal.Click

        ' Check the highscore list
        CheckPoints()

        ' Do not enable the timer
        tmrDecrease.Enabled = False

        ' Set that this is not a timed game
        Game.Interval = 0
        Game.Mode = Bejeweled.Game.GameModes.Normal

        ' Start a new game
        NewGame()

    End Sub

    Private Sub mnuTimed_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuTimed.Click

        ' See if we need to check the highscore
        CheckPoints()

        ' Enable the timer
        tmrDecrease.Enabled = True
        tmrDecrease.Interval = My.Settings.IntervalMilliseconds

        ' Set properties
        Game.Interval = tmrDecrease.Interval
        Game.IntervalDecrease = My.Settings.IntervalDecrease
        Game.IntervalMultiplicator = My.Settings.IntervalMultiplicator
        Game.Mode = Bejeweled.Game.GameModes.Timed

        ' Start a new game
        NewGame()

    End Sub

    Private Sub tmrDecrease_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrDecrease.Tick

        ' Ignore this if the game is over
        If (Not Game.Running) Or (MovesCount < 3) Then
            Exit Sub
        End If

        ' Decrease the progress
        gameProgress.Increment(-Game.IntervalDecrease)

        ' Update the statusbar
        UpdateStatusbar()

        ' If we've reached the end, the game is over
        If gameProgress.Value <= gameProgress.Minimum Then
            tmrDecrease.Enabled = False
            Game.Running = False
            Game.DisableInput = True
            Game.Ignore(True)
            MessageBox.Show("The time ran out. Game over!", "Game over", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

    End Sub

    Private Sub mnuHint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuHint.Click

        ' Remove the current selection
        If Not (Game.Board.SelectedCell Is Nothing) Then
            Game.Board.SelectedCell.ImageAttributes.ClearGamma()
            Game.Board.DrawCell(Game.GraphicsObject, Game.Board.SelectedCell)
            Game.Board.SelectedCell = Nothing
        End If

        ' Select the first possible move
        Game.ClickCell(Game.Board.Cells(Moves(MoveIndex).Source))
        MoveIndex += 1

        ' Used to cycle through all the current valid moves
        If MoveIndex >= Moves.Count Then
            MoveIndex = 0
        End If

    End Sub

    Private Sub mnuSettings_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuSettings.Click

        Dim Settings As New frmSettings

        ' Show a settings dialog
        Settings.ShowDialog(Me)

    End Sub

    Private Sub mnuAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAbout.Click

        ' Show the author
        MessageBox.Show("Made by Kristian S. Stangeland.", "About", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub mnuHowTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuHowTo.Click

        ' Show the how-to form:
        MessageBox.Show(My.Resources.HowTo, "How to play", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub SaveGame(ByVal sFile As String)

        ' Open the given file
        Dim oFile As New FileStream(sFile, FileMode.Create), oGame As Game, oWriter As Object
        Dim oCompress As New Compression.GZipStream(oFile, Compression.CompressionMode.Compress)

        ' Retrieve the class
        oGame = Me.Game

        ' Serialize (depending on the file type)
        Select Case Path.GetExtension(sFile).ToLower
            Case ".bws"

                ' Use a binary wrtier
                oWriter = New BinaryFormatter

            Case Else
                Exit Sub
        End Select

        ' Write the data
        oWriter.Serialize(oCompress, oGame)
        oCompress.Close()
        oFile.Close()

    End Sub

    Private Sub LoadGame(ByVal sFile As String)

        Dim oGame As Game, oReader As Object, Cell As Cell
        Dim oFile As Stream = New FileStream(sFile, FileMode.Open)
        Dim oCompress As New Compression.GZipStream(oFile, Compression.CompressionMode.Decompress)

        ' Check the file type
        Select Case Path.GetExtension(sFile).ToLower
            Case ".bws"

                ' Use a binary reader
                oReader = New BinaryFormatter()

            Case Else

                ' Cancel
                Exit Sub

        End Select

        ' Retrieve the class
        oGame = CType(oReader.Deserialize(oCompress), Bejeweled.Game)
        oCompress.Close()
        oFile.Close()

        ' Load different classes
        oGame.Board.Pieces = Game.Board.Pieces
        oGame.Board.Picture = Game.Board.Picture
        oGame.Sounds = Game.Sounds

        ' Initialize all cells
        For Each Cell In oGame.Board.Cells
            Cell.Parent = oGame.Board
            Cell.ImageAttributes = New Imaging.ImageAttributes
        Next

        ' Initialize moves
        Moves = Game.FindValidMoves
        MoveIndex = 0

        ' Initialize the buffer
        ResizeBuffer(oGame)

        ' Replace object
        Me.Game = oGame
        oGame = Nothing

        ' Update the game
        ResizeControls()
        UpdateProgress(Game.Level, Game.Points)
        Game.RedrawBoard()

    End Sub

    Private Sub LoadHighscores(ByVal Path As String)

        Dim oFile As Stream, oExtract As Compression.GZipStream
        Dim oFormater As New BinaryFormatter

        ' Clear the list of highscores
        Highscores.Clear()

        ' Create empty highscore elements if the file dosesn't exists
        If File.Exists(Path) Then

            Try
                ' Open the given file
                oFile = New FileStream(Path, FileMode.Open)
                oExtract = New Compression.GZipStream(oFile, Compression.CompressionMode.Decompress)

                ' Load the highscore tables
                Highscores = CType(oFormater.Deserialize(oExtract), List(Of HighscoreTable))

            Catch ex As Exception

                ' An error has occured
                MessageBox.Show("Error in loading highscores:" & vbNewLine & ex.ToString, "Error")

            Finally

                ' Close the loaded file
                If oExtract IsNot Nothing Then
                    oExtract.Close()
                End If

            End Try

        End If

        ' If the list is still empty, ...
        If Highscores.Count = 0 Then
            ' ... add default elements insted.
            Highscores.Add(New HighscoreTable("Normal"))
            Highscores.Add(New HighscoreTable("TImed"))
        End If

    End Sub

    Private Sub SaveHighscores(ByVal Path As String)

        Dim oFile As Stream, oCompress As Compression.GZipStream
        Dim oFormater As New BinaryFormatter

        ' Clear the list of highscores
        Highscores.Clear()

        ' Overwrite the file completely
        If File.Exists(Path) Then
            File.Delete(Path)
        End If

        Try
            ' Open the given file
            oFile = New FileStream(Path, FileMode.Create)
            oCompress = New Compression.GZipStream(oFile, Compression.CompressionMode.Compress)

            ' Save the highscore tables
            oFormater.Serialize(oCompress, Highscores)

        Catch ex As Exception

            ' An error has occured
            MessageBox.Show("Error in saving highscores:" & vbNewLine & ex.ToString, "Error")

        Finally

            ' Close the loaded file
            If oCompress IsNot Nothing Then
                oCompress.Close()
            End If

        End Try

    End Sub

    Private Sub mnuSaveGame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSaveGame.Click

        ' Show the dialog and see if the user saved a file
        If dialogSave.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            ' Save this game
            SaveGame(dialogSave.FileName)
        End If

    End Sub

    Private Sub mnuLoadGame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLoadGame.Click

        ' Show the dialog and see if the user opened a file
        If dialogOpen.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            ' Load this game
            LoadGame(dialogOpen.FileName)
        End If

    End Sub

    Private Sub mnuHighscore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuHighscore.Click

        ' Initialize highscore list
        frmHighscores.LoadHighscores(Highscores)

        ' Show the form
        frmHighscores.Show()

    End Sub
End Class