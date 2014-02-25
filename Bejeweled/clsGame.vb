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

' Important for allowing drawing
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Threading
Imports System.Runtime.Serialization

<System.Serializable()> Public Class Game
    Implements ISerializable

    ' Contains the different game modes
    Public Enum GameModes
        Normal = 0
        Timed = 1
    End Enum

    ' Called when the game require the form to redraw the buffer
    Friend Event BufferRedrawing()
    Friend Event GameCreated()
    Friend Event SequenceDestroyed(ByVal Bonus As Integer, ByRef Cancel As Boolean)

    ' Whether or not to disable animations
    Public IgnoreAnimations As Boolean
    Public IgnoreRedraw As Boolean

    ' Old values
    Private oldAnimations As Boolean
    Private oldRedraw As Boolean

    ' Whether or not to disable mouse clicks
    Public DisableInput As Boolean
    Public Mode As GameModes

    ' Contains different settings
    Public EnableSound As Boolean
    Public SpeedDestruction As Integer
    Public SpeedShift As Integer
    Public SpeedSwap As Integer

    ' The amount of points we'll decrease with
    Public Interval As Integer
    Public IntervalDecrease As Double
    Public IntervalMultiplicator As Double

    ' Used to store the current amount of points
    Public Points As Integer

    ' The current level
    Public Level As Integer

    ' Whether or not the game is currently running
    Public Running As Boolean

    ' The amount of bonus one can get when a sequence is destroyed
    Public Bonus As Double

    ' The board to use when painting
    Public Board As New Board

    ' Bitmap that holds the picture of the form
    Public Buffer As Drawing.Bitmap

    ' Graphics object (printing buffer)
    Public GraphicsObject As Graphics

    ' The different sounds we can play
    Public Sounds As New Collection

    Public Sub Ignore(ByVal All As Boolean)

        ' Set values
        Ignore(All, All)

    End Sub

    ' Used to set the ignore variables
    Public Sub Ignore(ByVal Animations As Boolean, ByVal Redraw As Boolean)

        ' Save the old values
        oldAnimations = IgnoreAnimations
        oldRedraw = IgnoreRedraw

        ' Set the variables
        IgnoreAnimations = Animations
        IgnoreRedraw = Redraw

    End Sub

    Public Sub UndoIgnore()

        ' Reset using the old values
        Ignore(oldAnimations, oldRedraw)

    End Sub

    Public Sub NewGame(ByVal Width As Integer, ByVal Height As Integer)

        ' The game is now currently running
        Running = True

        ' Use the current board
        With Board

            ' Allocate the cells
            .Allocate(Width, Height, True)

            ' Make sure we don't have three cells somewhere
            Ignore(True)
            TestBoard(3)
            UndoIgnore()

        End With

        ' Redraw the buffer
        RedrawBoard()

        ' Inform that a new game has been created
        RaiseEvent GameCreated()

    End Sub

    Private Sub Append(ByVal refList As List(Of List(Of Cell)), ByRef newList As List(Of List(Of Cell)))

        Dim List As List(Of Cell)

        ' Go through all the lists in the reference list
        For Each List In newList
            ' Append them all to the list.
            refList.Add(List)
        Next

    End Sub

    ' Returns all valid moves
    Public Function FindValidMoves() As List(Of Move)

        ' NOTE: This method went through a whole lot of versions. My first attempt consisted of
        ' simply "brute forcing" a solution, whereby I tested every possible move to see if they
        ' were valid. Problem is, that method require far too much resources, and I was forced to
        ' find a more efficient algorithm. The following is the result of that effort.
        Dim oCells As New List(Of List(Of Cell)), List As List(Of Cell), iPiece As Integer
        Dim firstX As Integer, firstY As Integer, secondX As Integer, secondY As Integer

        ' Create a new object
        FindValidMoves = New List(Of Move)

        ' Find the cells that follow the pattern -*-*- (that just require one more cell)
        Append(oCells, Board.FindSequence(2, New Axis(0, Board.Height), New Axis(0, Board.Width, 2), True, True, -1))
        Append(oCells, Board.FindSequence(2, New Axis(1, Board.Height), New Axis(0, Board.Width, 2), True, True, -1))
        Append(oCells, Board.FindSequence(2, New Axis(0, Board.Width), New Axis(0, Board.Height, 2), True, False, -1))
        Append(oCells, Board.FindSequence(2, New Axis(0, Board.Width), New Axis(1, Board.Height, 2), True, False, -1))

        ' Go through all these lists
        For Each List In oCells

            ' Retrieve the piece type
            iPiece = List(0).PieceIndex

            ' Save coordinates
            firstX = List(0).X : firstY = List(0).Y
            secondX = List(1).X : secondY = List(1).Y

            With FindValidMoves

                ' Find the orientation
                Select Case firstY <> secondY
                    Case False ' Horizontal

                        ' See if this list is valid
                        If iPiece = GetIndex(firstX - 1, firstY) Then _
                         .Add(New Move(List(1).Coordinates, New Point(firstX + 1, firstY)))
                        If iPiece = GetIndex(secondX + 1, secondY) Then _
                         .Add(New Move(List(0).Coordinates, New Point(secondX - 1, secondY)))
                        If iPiece = GetIndex(firstX + 1, firstY - 1) Then _
                         .Add(New Move(New Point(firstX + 1, firstY - 1), New Point(firstX + 1, firstY)))
                        If iPiece = GetIndex(firstX + 1, firstY + 1) Then _
                         .Add(New Move(New Point(firstX + 1, firstY + 1), New Point(firstX + 1, firstY)))

                    Case True ' Vertical

                        ' See if this list is valid
                        If iPiece = GetIndex(firstX, firstY - 1) Then _
                         .Add(New Move(List(1).Coordinates, New Point(firstX, firstY + 1)))
                        If iPiece = GetIndex(secondX, secondY + 1) Then _
                         .Add(New Move(List(0).Coordinates, New Point(secondX, secondY - 1)))
                        If iPiece = GetIndex(firstX - 1, firstY + 1) Then _
                         .Add(New Move(New Point(firstX - 1, firstY + 1), New Point(firstX, firstY + 1)))
                        If iPiece = GetIndex(firstX + 1, firstY + 1) Then _
                         .Add(New Move(New Point(firstX + 1, firstY + 1), New Point(firstX, firstY + 1)))

                End Select

            End With

        Next

        ' Clear the list
        oCells = New List(Of List(Of Cell))

        ' Finally, find the remaining possibilities (-**-)
        Append(oCells, Board.FindSequence(2, New Axis(0, Board.Height), New Axis(0, Board.Width), True, True, -1))
        Append(oCells, Board.FindSequence(2, New Axis(0, Board.Width), New Axis(0, Board.Height), True, False, -1))

        ' Go through all these lists
        For Each List In oCells

            ' Retrieve the piece type
            iPiece = List(0).PieceIndex

            ' Save coordinates
            firstX = List(0).X : firstY = List(0).Y
            secondX = List(1).X : secondY = List(1).Y

            With FindValidMoves

                ' Find the orientation
                Select Case firstY <> secondY
                    Case False ' Horizontal

                        ' See if this list is valid
                        If iPiece = GetIndex(firstX - 1, firstY - 1) Then _
                         .Add(New Move(New Point(firstX - 1, firstY - 1), New Point(firstX - 1, firstY)))
                        If iPiece = GetIndex(firstX - 1, firstY + 1) Then _
                         .Add(New Move(New Point(firstX - 1, firstY + 1), New Point(firstX - 1, firstY)))
                        If iPiece = GetIndex(secondX + 1, secondY + 1) Then _
                         .Add(New Move(New Point(secondX + 1, secondY + 1), New Point(secondX + 1, secondY)))
                        If iPiece = GetIndex(secondX + 1, secondY - 1) Then _
                         .Add(New Move(New Point(secondX + 1, secondY - 1), New Point(secondX + 1, secondY)))

                    Case True ' Vertical

                        ' See if this list is valid
                        If iPiece = GetIndex(firstX - 1, firstY - 1) Then _
                         .Add(New Move(New Point(firstX - 1, firstY - 1), New Point(firstX, firstY - 1)))
                        If iPiece = GetIndex(firstX + 1, firstY - 1) Then _
                         .Add(New Move(New Point(firstX + 1, firstY - 1), New Point(firstX, firstY - 1)))
                        If iPiece = GetIndex(secondX + 1, secondY + 1) Then _
                         .Add(New Move(New Point(secondX + 1, secondY - 1), New Point(secondX, secondY + 1)))
                        If iPiece = GetIndex(secondX + 1, firstY + 1) Then _
                         .Add(New Move(New Point(secondX + 1, secondY + 1), New Point(secondX, secondY + 1)))

                End Select

            End With

        Next

    End Function

    Private Function GetIndex(ByVal X As Integer, ByVal Y As Integer) As Integer

        Try
            ' Return the piece index
            Return Board.Cells(X, Y).PieceIndex
        Catch ex As Exception
            ' If we couldn't get it, return minus.
            Return -1
        End Try

    End Function

    Public Function TestBoard(ByVal Lenght As Integer) As Boolean

        Dim oVertical As List(Of Cell), oHorizontal As List(Of Cell), Tell As Long

        ' Loop until everything is fixed (limit loop to 100 times)
        For Tell = 1 To 100

            ' Find the vertical cells to remove and fix.
            oVertical = Board.FindSequence(Lenght, New Axis(0, Board.Height), New Axis(0, Board.Width), _
             True, True)

            If Not SequenceFound(oVertical, Tell - 1) Then
                Return True
            End If

            ' Then, find the horizontal cells to remove and fix.
            oHorizontal = Board.FindSequence(Lenght, New Axis(0, Board.Width), New Axis(0, Board.Height), _
             True, False)

            If Not SequenceFound(oHorizontal, Tell - 1) Then
                Return True
            End If

            ' See if we can just exit this procedure
            If oVertical.Count = 0 And oHorizontal.Count = 0 Then
                TestBoard = (Tell > 1)
                Exit For
            End If

            ' Wait for a while
            Thread.Sleep(10)
            Application.DoEvents()

        Next

    End Function

    Private Function SequenceFound(ByVal List As List(Of Cell), ByVal Tree As Integer) As Boolean

        Dim Cell As Cell, Random As New Random, bVertical As Boolean, Cancel As Boolean

        ' Make sure the list is not empty
        If List.Count <= 0 Then
            Return True
        End If

        ' Inform that the sequence was found
        RaiseEvent SequenceDestroyed(Tree, Cancel)

        ' Stop the procedure if we're supposed to cancel
        If Cancel Then
            Exit Function
        End If

        ' Make sure we're supposed to animate
        If Not IgnoreAnimations Then

            ' Destroy these cells
            AnimateDestruction(List, SpeedDestruction)

        End If

        ' Find out if this row is a vertical row
        bVertical = List(0).Y <> List(2).Y

        ' Go through all the cells
        For Each Cell In List

            ' Use this cell
            With Cell

                ' Show the cell
                .Visible = True

                ' Randomize the cell
                .PieceIndex = Random.NextDouble * (Cell.Parent.Pieces.Count - 1)

                ' Shift its row one step down
                .Parent.ShiftColumn(Cell.X, New Axis(0, Cell.Y - 1), 1)

                ' Make sure this is correct
                If Not IgnoreAnimations Then

                    ' Animate the shift
                    AnimateShift(Cell, SpeedShift, IIf(bVertical, Cell Is List(2), True))

                End If

            End With

        Next

        ' All is OK
        Return True

    End Function

    Public Sub AnimateDestruction(ByVal Cells As List(Of Cell), ByVal Frames As Integer, _
     Optional ByVal Visible As Boolean = False, Optional ByVal Inverse As Boolean = False)

        Dim Cell As Cell, Frame As Integer

        ' Draw the given amount of times
        For Frame = IIf(Inverse, Frames - 1, 1) To IIf(Inverse, 1, Frames) Step IIf(Inverse, -1, 1)

            ' Decrease the visibility of the cell, until hiding it completely.
            For Each Cell In Cells
                If IIf(Inverse, Frame <= 1, Frame >= Frames) Then
                    Cell.Visible = Visible
                    Cell.ImageAttributes.ClearGamma()
                    Cell.ImageAttributes.ClearColorMatrix()
                Else
                    Cell.ImageAttributes.SetGamma((Frames - Frame) / Frames)
                    Cell.ImageAttributes.SetColorMatrix(AlphaBlendingMatrix((Frames - Frame) / Frames))
                End If
            Next

            ' Draw this state
            RedrawBoard()
            Thread.Sleep(10)

        Next

    End Sub

    Private Function AlphaBlendingMatrix(ByVal Amount As Single) As Imaging.ColorMatrix

        ' Create the matrix
        Return New Imaging.ColorMatrix(New Single()() _
            {New Single() {1, 0, 0, 0, 0}, _
            New Single() {0, 1, 0, 0, 0}, _
            New Single() {0, 0, 1, 0, 0}, _
            New Single() {0, 0, 0, Amount, 0}, _
            New Single() {0, 0, 0, 0, 1}})

    End Function

    Public Sub AnimateShift(ByVal Cell As Cell, ByVal Frames As Integer, ByVal RowFinished As Boolean)

        Dim Row As Integer, iY As Double, Tell As Integer, BeginY As Integer, EndY As Integer

        ' First, move all above it one step up
        For Row = 0 To Cell.Y
            With Cell.Siblings(Cell.X, Row)
                .Offset.Y = -.Piece.Sprite.Height
            End With
        Next

        ' The amount of pixels to move with
        iY = Cell.Piece.Sprite.Height / Frames

        ' Then ... move each cell back to zero again
        For Tell = 1 To Frames

            ' Set the offset
            For Row = 0 To Cell.Y
                With Cell.Siblings(Cell.X, Row)
                    If Tell <> Frames Then
                        .Offset.Y += iY
                    Else
                        .Offset.Y = 0
                    End If
                End With
            Next

            ' Calculate positions
            BeginY = Cell.Siblings(Cell.X, 0).Position.Y - Cell.Piece.Sprite.Height
            EndY = Cell.Siblings(Cell.X, Cell.Parent.Height).Position.Y

            ' Clear the content of the column
            Board.DrawBackground(GraphicsObject, New RectangleF(Cell.Position.X, BeginY, Cell.Piece.Sprite.Width, _
             EndY + Cell.Piece.Sprite.Height - BeginY))

            ' Draw the column only
            Board.DrawColumn(GraphicsObject, Board.Location.Y, Cell.X, Cell.Position.X)
            RaiseEvent BufferRedrawing()

            ' Wait for a while
            Thread.Sleep(10)

        Next

        ' Play sound, if not disabled
        If EnableSound AndAlso RowFinished Then
            Sounds.Item("Marble").PlaySound(True)
        End If

    End Sub

    Public Sub AnimateSwap(ByVal Cell1 As Cell, ByVal Cell2 As Cell, ByVal Frames As Integer)

        Dim iX As Double, iY As Double, iWidth As Integer, iHeight As Integer, Tell As Integer

        ' Make sure this is enabled
        If IgnoreAnimations Then
            Exit Sub
        End If

        ' Calculate the amount we'll have to move these cells with
        With Cell1.DistXY(Cell2)
            iWidth = Cell1.Piece.Sprite.Width
            iHeight = Cell1.Piece.Sprite.Height
            iX = (.X / Frames) * iWidth
            iY = (.Y / Frames) * iHeight
        End With

        ' Animate swap
        For Tell = 1 To Frames

            ' Change the offset of the cells
            Cell1.Offset.X -= iX
            Cell1.Offset.Y -= iY
            Cell2.Offset.X += iX
            Cell2.Offset.Y += iY

            ' Draw the two cells
            Board.DrawCell(GraphicsObject, Cell1, True)
            Board.DrawCell(GraphicsObject, Cell2, True)
            Board.DrawCell(GraphicsObject, Cell1, False)
            Board.DrawCell(GraphicsObject, Cell2, False)
            RaiseEvent BufferRedrawing()

            ' Wait for the given amount of time
            Thread.Sleep(10)

        Next

        ' Clear offsets.
        Cell1.Offset = New Point
        Cell2.Offset = New Point

    End Sub

    Public Function ClickCell(ByVal Cell As Cell) As Boolean

        ' If anything was clicked, ...
        If Not (Cell Is Nothing) Then

            ' See if any cell has been selected
            If Not (Board.SelectedCell Is Nothing) Then

                ' Remove gamma from the previous cell
                Board.SelectedCell.ImageAttributes.ClearGamma()

                ' Swap cells if the distance (distance X + distance Y) is just one cell
                If Cell.Distance(Board.SelectedCell) = 1 Then

                    ' Swap the cells
                    AnimateSwap(Cell, Board.SelectedCell, SpeedSwap)
                    Cell.Swap(Board.SelectedCell)

                    ' See if anything happened
                    If Not TestBoard(3) Then

                        ' Play sound, if not disabled
                        If EnableSound Then
                            Sounds.Item("Buzz").PlaySound(True)
                        End If

                        ' If nothing happened, swap back.
                        AnimateSwap(Cell, Board.SelectedCell, SpeedSwap)
                        Cell.Swap(Board.SelectedCell)

                        ' Redraw the cells
                        Board.DrawCell(GraphicsObject, Board.SelectedCell)
                        Board.DrawCell(GraphicsObject, Cell)
                        RaiseEvent BufferRedrawing()

                    Else

                        ' Otherwise, inform about this.
                        ClickCell = True

                    End If

                Else
                    ' Clear the selection
                    Board.DrawCell(GraphicsObject, Board.SelectedCell)
                    RaiseEvent BufferRedrawing()
                End If

                ' Remove selection
                Board.SelectedCell = Nothing

            Else

                ' Play sound, if not disabled
                If EnableSound Then
                    Sounds.Item("Click").PlaySound(True)
                End If

                ' ... select the new cell.
                Board.SelectCell(Cell.X, Cell.Y).ImageAttributes.SetGamma(0.4)

                ' Redraw the cell
                Board.DrawCell(GraphicsObject, Board.SelectedCell)
                RaiseEvent BufferRedrawing()

            End If

        End If

    End Function

    Public Sub RedrawBoard()

        ' Ignore this, if said to
        If IgnoreRedraw Then
            Exit Sub
        End If

        Try

            ' Clear the buffer
            Board.DrawBackground(GraphicsObject, Buffer.GetBounds(GraphicsUnit.Pixel))

            ' Then, redraw using the board object
            Board.DrawAll(GraphicsObject)

            ' Request the form to update itself
            RaiseEvent BufferRedrawing()

        Catch
        End Try

    End Sub

    ' Used to make this class serializable
    Public Sub GetObjectData(ByVal Info As SerializationInfo, ByVal Context As StreamingContext) Implements ISerializable.GetObjectData
        With Info
            .FullTypeName = "Bejeweled.Game"
            .AddValue("IntervalMultiplicator", IntervalMultiplicator)
            .AddValue("IgnoreAnimations", IgnoreAnimations)
            .AddValue("IntervalDecrease", IntervalDecrease)
            .AddValue("IgnoreRedraw", IgnoreRedraw)
            .AddValue("DisableInput", DisableInput)
            .AddValue("EnableSound", EnableSound)
            .AddValue("SpeedDestruction", SpeedDestruction)
            .AddValue("SpeedShift", SpeedShift)
            .AddValue("SpeedSwap", SpeedSwap)
            .AddValue("Interval", Interval)
            .AddValue("Points", Points)
            .AddValue("Level", Level)
            .AddValue("Running", Running)
            .AddValue("Bonus", Bonus)
            .AddValue("Board", Board)
        End With
    End Sub

    ' Normal constructor
    Public Sub New()
        ' Normally we don't have to do anything.
    End Sub

    Public Sub New(ByVal Info As SerializationInfo, ByVal Context As StreamingContext)
        With Info
            IntervalMultiplicator = .GetDouble("IntervalMultiplicator")
            IntervalDecrease = .GetDouble("IntervalDecrease")
            IgnoreAnimations = .GetBoolean("IgnoreAnimations")
            IgnoreRedraw = .GetBoolean("IgnoreRedraw")
            DisableInput = .GetBoolean("DisableInput")
            EnableSound = .GetBoolean("EnableSound")
            SpeedDestruction = .GetInt32("SpeedDestruction")
            SpeedShift = .GetInt32("SpeedShift")
            SpeedSwap = .GetInt32("SpeedSwap")
            Interval = .GetInt32("Interval")
            Points = .GetInt32("Points")
            Level = .GetInt32("Level")
            Running = .GetBoolean("Running")
            Bonus = .GetDouble("Bonus")
            Board = CType(.GetValue("Board", GetType(Board)), Board)
        End With
    End Sub

End Class

Public Class Move

    ' Contains the source and destination position of the move
    Public Source As Point
    Public Destination As Point

    ' Used to create the cless
    Public Sub New(ByVal Source As Point, ByVal Destination As Point)
        With Me
            .Source = Source
            .Destination = Destination
        End With
    End Sub

End Class