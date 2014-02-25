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

' Simple class that represents a "sprite" - a segment of a larger image that gets drawn.
Public Class Sprite

    ' The different properties this segment can hold.
    Public Left As Int32
    Public Top As Int32
    Public Width As Int32
    Public Height As Int32
    Public Index As String
    Public Image As Drawing.Bitmap
    Public ImageAttributes As Imaging.ImageAttributes

    ' Used when creating a sprite
    Public Sub New(ByVal Image As Drawing.Bitmap, ByVal Left As Integer, ByVal Top As Integer, _
     ByVal Width As Integer, ByVal Height As Integer, ByVal Index As String)

        ' Set the properties
        With Me
            .Left = Left
            .Top = Top
            .Width = Width
            .Height = Height
            .Image = Image
            .Index = Index
        End With

    End Sub

    ' Alternative version:
    Public Sub DrawSprite(ByVal Destination As Graphics, ByVal X As Int32, ByVal Y As Int32)

        ' Just call the first one
        DrawSprite(Destination, X, Y, Width, Height)

    End Sub

    ' Draws the segment of the image to this destination, using the given position.
    Public Sub DrawSprite(ByVal Destination As Graphics, ByVal X As Int32, ByVal Y As Int32, _
     ByVal destWidth As Int32, ByVal destHeight As Int32)

        ' Draws the image.
        Destination.DrawImage(Image, New Rectangle(X, Y, Width, Height), Left, Top, Width, Height, GraphicsUnit.Pixel, ImageAttributes)

    End Sub

End Class
