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

' Contains information about a certain cell
<System.Serializable()> Public Class Cell

    Public X As Integer
    Public Y As Integer
    Public PieceIndex As Integer
    Public Visible As Boolean
    Public Position As New Point
    Public Offset As New Point()
    Public Margin As New System.Windows.Forms.Padding(0)

    ' The parent of this cell
    <System.NonSerialized()> _
    Public Parent As Board

    ' Image attributes (do not serialize)
    <System.NonSerialized()> _
    Public ImageAttributes As New Imaging.ImageAttributes

    ' Calculates the distance between two cells
    Public Function Distance(ByVal Reference As Cell) As Integer
        Return Math.Abs(X - Reference.X) + Math.Abs(Y - Reference.Y)
    End Function

    Public Function IsEqual(ByVal Cell As Cell) As Boolean
        ' Return whether or not this cell is the same as the given
        Return (Cell.X = X) And (Cell.Y = Y) And (Cell.Parent Is Parent)
    End Function

    ' Calculates the XY-distance
    Public Function DistXY(ByVal Reference As Cell) As Point
        Return New Point(X - Reference.X, Y - Reference.Y)
    End Function

    Public ReadOnly Property Piece() As Piece
        Get
            Return Parent.Pieces(PieceIndex)
        End Get
    End Property

    ' Returns the cell's coordinates as a point
    Public ReadOnly Property Coordinates() As Point
        Get
            Return New Point(X, Y)
        End Get
    End Property

    Public ReadOnly Property Siblings(ByVal iX As Integer, ByVal iY As Integer) As Cell
        Get
            ' Return the corresponding cell
            Return Parent.Cells(iX, iY)
        End Get
    End Property

    ' Swaps the content (except the coordinates) with a cell
    Public Sub Swap(ByVal Reference As Cell)

        Dim oTemp As New Cell(0, 0, Parent)

        ' Firstly, save the reference's content
        With oTemp
            .PieceIndex = Reference.PieceIndex
            .Visible = Reference.Visible
            .Offset = Reference.Offset
            .Margin = Reference.Margin
            .ImageAttributes = Reference.ImageAttributes
        End With

        ' Then copy the first data
        With Reference
            .PieceIndex = Me.PieceIndex
            .Visible = Me.Visible
            .Offset = Me.Offset
            .Margin = Me.Margin
            .ImageAttributes = Me.ImageAttributes
        End With

        ' And copy its content to our object
        With oTemp
            Me.PieceIndex = .PieceIndex
            Me.Visible = .Visible
            Me.Offset = .Offset
            Me.Margin = .Margin
            Me.ImageAttributes = .ImageAttributes
        End With

    End Sub

    ' Used just to initialize the class
    Public Sub New(ByVal X As Integer, ByVal Y As Integer, ByVal oParent As Board)

        ' Use the current class
        With Me
            .X = X
            .Y = Y
            .Parent = oParent
            .Visible = True
        End With

    End Sub

End Class