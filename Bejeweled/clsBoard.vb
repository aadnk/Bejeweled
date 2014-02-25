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

<System.Serializable()> Public Class Board

#Region "Events"
    ' Called when a cell is selected
    Public Event CellSelected(ByVal Cell As Cell)
    Public Event BoardDrawing(ByRef Cancel As Boolean)
    Public Event BoardDrawed()
#End Region

    ' Internal spacing
    Public Padding As New System.Windows.Forms.Padding(0)

    ' Used to save the current selected cell
    Public SelectedCell As Cell

    ' The background
    Public BackColor As Drawing.Color
    <System.NonSerialized()> Public Picture As Drawing.Bitmap

    ' Contains all the pieces
    <System.NonSerialized()> Public Pieces As New List(Of Piece)

    ' The location we'll draw the board to
    Public Location As New Point

    ' The size of the board
    Public Size As New Size(0, 0)

    ' The array that contains the different pieces
    Private aCells(0, 0) As Cell

#Region "Properties"

    ' Returns/sets the amount of columns in the board
    Public Property Width() As Integer
        Get
            Return aCells.GetUpperBound(0) ' 0 = first
        End Get
        Set(ByVal Value As Integer)
            ' Reallocate the array
            Allocate(Value, Height)
        End Set
    End Property

    ' Returns/sets the amount of rows in the board
    Public Property Height() As Integer
        Get
            Return aCells.GetUpperBound(1)
        End Get
        Set(ByVal Value As Integer)
            ' As the above
            Allocate(Width, Value)
        End Set
    End Property

    ' If nothing at all is specified, return a list of all the cells.
    Public Property Cells() As List(Of Cell)
        Get
            ' Return all the cells
            Return Range()
        End Get
        Set(ByVal oList As List(Of Cell))

            Dim X As Integer, Y As Integer, Index As Integer

            ' Go through all the cells in the array, ...
            For X = 0 To Width
                For Y = 0 To Height

                    ' ... moving the cells in the list into the array.
                    aCells(X, Y) = oList(Index)

                    ' Go to the next element
                    Index += 1

                Next
            Next

        End Set
    End Property

    ' Do likewise, except for a point insted of two variables.
    Public ReadOnly Property Cells(ByVal Coordinates As Point) As Cell
        Get
            ' Return this cell
            Return aCells(Coordinates.X, Coordinates.Y)
        End Get
    End Property

    ' Retrieves the value of a given cell
    Public ReadOnly Property Cells(ByVal X As Integer, ByVal Y As Integer) As Cell
        Get
            ' Return this cell
            Return aCells(X, Y)
        End Get
    End Property

#End Region
#Region "Delegates"
    Public Delegate Sub RequenceFound(ByVal Cells As List(Of Cell))
#End Region
#Region "Tests"
    Public Function IsRow(ByVal Index As Integer) As Boolean
        Return Index >= 0 And Index <= Height
    End Function

    Public Function IsColumn(ByVal Index As Integer) As Boolean
        Return Index >= 0 And Index <= Width
    End Function

    Public Function IsCell(ByVal Row As Integer, ByVal Column As Integer) As Boolean
        Return IsRow(Row) And IsColumn(Column)
    End Function
#End Region

    ' Draws the background in an particular area
    Public Function DrawBackground(ByVal Surface As Graphics, ByVal Area As RectangleF) As Boolean

        ' We'll just paint the background using the background color
        Surface.FillRectangle(New SolidBrush(BackColor), Area)

        ' Then, if set, draw the bitmap
        If Not (Picture Is Nothing) Then
            Try
                Surface.DrawImage(Picture, Area.Left, Area.Top, New RectangleF(Area.Left - Location.X, _
                 Area.Top - Location.Y, Area.Right - Location.X, Area.Bottom - Location.Y), _
                  GraphicsUnit.Pixel)
            Catch
                Exit Function
            End Try
        End If

        ' No errors
        Return True

    End Function

    Public Function Range() As List(Of Cell)
        Return Range(New Rectangle(0, 0, Width, Height))
    End Function

    Public Function Range(ByVal Area As Rectangle) As List(Of Cell)

        Dim X As Integer, Y As Integer

        ' Create a new list
        Range = New List(Of Cell)

        ' Go through the given area
        For X = Area.Left To Area.Right
            For Y = Area.Top To Area.Bottom
                ' Add this cell to the range
                Range.Add(aCells(X, Y))
            Next
        Next

    End Function

    ' Use this method to draw all pieces onto a given position
    Public Sub DrawAll(ByVal Surface As Graphics)

        ' indexX and indexY
        Dim iX As Integer, posX As Integer, Cancel As Boolean

        ' Let the parent know we're about to draw a board
        RaiseEvent BoardDrawing(Cancel)

        ' Cancel the draw if said tro
        If Cancel Then
            Exit Sub
        End If

        ' Set what position to start drawing from
        posX = Location.X + Padding.Left

        ' Go through all cells
        For iX = 0 To Width

            ' Add the left margin
            posX += aCells(iX, 0).Margin.Left

            ' Draw this column
            DrawColumn(Surface, Location.Y, iX, posX)

            ' Add the width and right margin
            With Pieces(Cells(iX, 0).PieceIndex)
                posX += .Sprite.Width + Cells(iX, 0).Margin.Right
            End With

        Next

        ' Save the width of the control
        Size.Width = posX

        ' Inform that a drawing has been compleded
        RaiseEvent BoardDrawed()

    End Sub

    Public Sub DrawColumn(ByVal Surface As Graphics, ByVal Y As Integer, ByVal ColumnIndex As Integer, ByVal PositionX As Integer)

        Dim iY As Integer, posY As Integer

        ' Set the starting Y-position
        posY = Y + Padding.Top

        ' Go through all cells vertically
        For iY = 0 To Height

            ' Use the current cell
            With aCells(ColumnIndex, iY)

                ' Add the top margin
                posY += .Margin.Top

                ' Save the position for this cell
                .Position.X = PositionX
                .Position.Y = posY

                ' Draw the cell
                DrawCell(Surface, aCells(ColumnIndex, iY))

                ' Include the height and bottom margin.
                posY += .Piece.Sprite.Height + .Margin.Bottom

            End With

        Next

        ' Save the height of the control
        Size.Height = posY

    End Sub

    ' Note that this function does NOT update the REAL postion of the cell. 
    Public Sub DrawCell(ByVal Surface As Graphics, ByVal Cell As Cell, _
     Optional ByVal Background As Boolean = True)

        ' Retrieve the piece
        With Pieces(Cell.PieceIndex)

            ' Draw its background
            If Background Then
                DrawBackground(Surface, New RectangleF(Cell.Position.X, Cell.Position.Y, _
                 Cell.Piece.Sprite.Width, Cell.Piece.Sprite.Height))
            End If

            ' Make sure the piece index is valid
            If Cell.Visible Then

                ' Draw the specific sprite onto an caculated area 
                With .Sprite
                    .ImageAttributes = Cell.ImageAttributes
                    .DrawSprite(Surface, Cell.Position.X + Cell.Offset.X, Cell.Position.Y + Cell.Offset.Y)
                End With

            End If

        End With

    End Sub

    Private Function Smallest(ByVal ParamArray Values() As Integer) As Integer

        Dim Value As Integer

        ' Make sure there's any values to return
        If Values.Length < 1 Then
            Exit Function
        End If

        ' Firstly, assume the first value is correct
        Smallest = Values(0)

        ' Then, go through all the values
        For Each Value In Values
            ' ... using it insted of the other if it is smaller.
            If Value < Smallest Then
                Smallest = Value
            End If
        Next

    End Function

    ' Alternative method
    Public Sub AddPiece(ByVal Sprite As Sprite)

        ' Add this piece using the below methid
        AddPiece(Sprite, New Padding(0))

    End Sub

    ' Use this method to add a new piece type to the board
    Public Sub AddPiece(ByVal Sprite As Sprite, ByVal Margin As System.Windows.Forms.Padding)

        ' Create a new piece
        Dim newPiece As New Piece

        ' Set its properties
        With newPiece
            .Index = Pieces.Count + 1
            .Sprite = Sprite
        End With

        ' Add a new piece to the collection
        Pieces.Add(newPiece)

    End Sub

    ' Use this method to save the selection of a cell
    Public Function SelectCell(ByVal X As Int32, ByVal Y As Int32) As Cell

        ' Simply save it
        SelectedCell = aCells(X, Y)

        ' Return this cell
        Return SelectedCell

        ' Inform about the selection
        RaiseEvent CellSelected(SelectedCell)

    End Function

    Public Sub ShiftColumn(ByVal ColumnIndex As Integer, ByVal Axis As Axis, ByVal Amount As Integer)

        Dim Row As Integer

        ' Go through all the cells in the column
        For Row = Axis.EndPos To Axis.StartPos Step -1

            ' Make sure the given index is valid
            If IsRow(Row) AndAlso IsRow(Row + Amount) Then

                ' Move cell in the right direction
                aCells(ColumnIndex, Row).Swap(aCells(ColumnIndex, Row + Amount))

            End If

        Next

    End Sub

    Public Function HitCell(ByVal X As Int32, ByVal Y As Int32) As Cell

        Dim iX As Int32, iY As Int32, oSprite As Sprite

        ' Calculate the position
        For iX = 0 To aCells.GetUpperBound(0)
            For iY = 0 To aCells.GetUpperBound(1)

                With aCells(iX, iY)

                    ' Retrieve the sprite
                    oSprite = Pieces(.PieceIndex).Sprite

                    ' See if we've clicked this cell
                    If .Position.X <= X AndAlso .Position.Y <= Y AndAlso .Position.X + oSprite.Width > X _
                     AndAlso .Position.Y + oSprite.Height > Y Then
                        Return aCells(iX, iY)
                    End If

                End With

            Next
        Next

        ' Return nothing otherwise
        Return Nothing

    End Function

    ' Used to reallocate a board
    Public Sub Allocate(ByVal Width As Long, ByVal Height As Long, Optional ByVal Randomize As Boolean = False)

        Dim iX As Integer, iY As Integer

        ' Simply reallocate the array
        ReDim aCells(Width, Height)

        ' Initialize classes
        For iX = 0 To Width
            For iY = 0 To Height
                aCells(iX, iY) = New Cell(iX, iY, Me)
            Next
        Next

        ' If we're supposed to randomize the board, ...
        If Randomize Then
            ' ... do so.
            RandomizeCells()
        End If

    End Sub

    Public Function FindSequence(ByVal Lenght As Integer, ByVal FirstAxis As Axis, ByVal SecondAxis As Axis, _
     ByVal StopAtEndOfAxis As Boolean, ByVal InvertAxis As Boolean) As List(Of Cell)

        ' Return the first found list
        Try
            Return FindSequence(Lenght, FirstAxis, SecondAxis, StopAtEndOfAxis, InvertAxis, 1).Item(0)
        Catch
            Return New List(Of Cell)
        End Try

    End Function

    ' Returns the first occurence of Lenght cells after each other in a given direction.
    Public Function FindSequence(ByVal Lenght As Integer, ByVal FirstAxis As Axis, ByVal SecondAxis As Axis, _
     ByVal StopAtEndOfAxis As Boolean, ByVal InvertAxis As Boolean, ByVal Limit As Integer) As List(Of List(Of Cell))

        Dim X As Integer, Y As Integer, curCell As Cell, oList As New List(Of Cell)
        Dim Tell As Long, oTemp As List(Of Cell)

        ' Create a new object
        FindSequence = New List(Of List(Of Cell))

        ' Run through all the cells
        For X = FirstAxis.StartPos To FirstAxis.EndPos Step FirstAxis.Distance
            For Y = SecondAxis.StartPos To SecondAxis.EndPos Step SecondAxis.Distance

                ' Retrieve the current cell
                If InvertAxis Then
                    curCell = aCells(Y, X)
                Else
                    curCell = aCells(X, Y)
                End If

                ' If this cell corresponds with that we've saved, ... 
                If oList.Count > 0 AndAlso _
                  curCell.PieceIndex = oList(0).PieceIndex Then

                    ' Add this cell to the list
                    oList.Add(curCell)

                    ' If the list is equal to the lenght we want, ...
                    If oList.Count >= Lenght Then

                        ' Add the element to the list
                        FindSequence.Add(oList)

                        ' Make a temporary copy of the list
                        oTemp = oList

                        ' Create a new list
                        oList = New List(Of Cell)

                        ' Add all but the first of the elements
                        For Tell = 1 To oTemp.Count - 1
                            oList.Add(oTemp(Tell))
                        Next

                        ' Clear the temp
                        oTemp = Nothing

                        ' See if we should return
                        If (FindSequence.Count >= Limit) And (Limit > 0) Then
                            Exit Function
                        End If

                    End If

                Else

                    ' Clear the list
                    oList.Clear()

                    ' Add this cell to it
                    oList.Add(curCell)

                End If

            Next

            ' Whether or not to clear the search when we've reached the end of the axis
            If StopAtEndOfAxis Then
                oList.Clear()
            End If

        Next

    End Function

    Public Sub RandomizeCells()

        ' Use the default values
        RandomizeCells(New Axis(0, Width), New Axis(0, Height), 0, Pieces.Count - 1)

    End Sub

    Public Sub RandomizeCells(ByVal FirstAxis As Axis, ByVal SecondAxis As Axis, _
     ByVal MinValue As Integer, ByVal MaxValue As Integer)

        Dim X As Integer, Y As Integer, oRandom As New Random

        ' Go through the given cells
        For X = FirstAxis.StartPos To FirstAxis.EndPos
            For Y = SecondAxis.StartPos To SecondAxis.EndPos
                ' ... set the value of the cell.
                aCells(X, Y).PieceIndex = (oRandom.NextDouble * (MaxValue - MinValue)) + MinValue
            Next
        Next

    End Sub

End Class

' Contains information about an particular piece
Public Class Piece
    Public Sprite As Sprite
    Public Index As Int32
    Public Tag As String
End Class

' Used to store the position of an axis when searching
Public Class Axis
    Public StartPos As Integer
    Public EndPos As Integer
    Public Distance As Integer = 1

    ' Initialize all variables
    Public Sub New(ByVal iStart As Integer, ByVal iEnd As Integer, ByVal Distance As Integer)
        With Me
            .StartPos = iStart
            .EndPos = iEnd
            .Distance = Distance
        End With
    End Sub

    ' Used when initializing this class
    Public Sub New(ByVal iStart As Integer, ByVal iEnd As Integer)
        With Me
            .StartPos = iStart
            .EndPos = iEnd
        End With
    End Sub

    ' Using only one paramenter initializes both variables
    Public Sub New(ByVal Both As Integer)
        With Me
            .StartPos = Both
            .EndPos = Both
        End With
    End Sub

    ' Whether or not a given number is within the axis range
    Public Function IsValid(ByVal Value As Integer) As Boolean
        Return (Value >= StartPos And Value <= EndPos)
    End Function

End Class
