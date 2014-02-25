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

Imports System.Runtime.InteropServices

Public Class Sound

#Region "Declarations"
    ' The API function that can play sounds
    Private Declare Function PlaySoundA Lib "winmm.dll" Alias "PlaySoundA" (ByVal lpszName As String, _
     ByVal hModule As IntPtr, ByVal dwFlags As Integer) As Integer
    Private Declare Function PlaySoundM Lib "winmm.dll" Alias "PlaySoundA" (ByVal lpData() As Byte, _
     ByVal hModule As IntPtr, ByVal dwFlags As Integer) As Integer

    ' Different flags
    Private Enum SoundFlags
        SND_ALIAS = &H10000
        SND_ALIAS_ID = &H110000
        SND_APPLICATION = &H80
        SND_ASYNC = &H1
        SND_FILENAME = &H20000
        SND_LOOP = &H8
        SND_MEMORY = &H4
        SND_NODEFAULT = &H2
        SND_NOSTOP = &H10
        SND_NOWAIT = &H2000
        SND_PURGE = &H40
        SND_RESOURCE = &H40004
    End Enum

#End Region
#Region "Variables"

    ' Different flags
    Public Async As Boolean
    Public LoopSound As Boolean
    Public NoStop As Boolean
    Public NoDefault As Boolean
    Public NoWait As Boolean

    ' Pointer and array used when playing a resource
    Private bData() As Byte

#End Region
#Region "Constructs"
    Public Sub New(ByVal Async As Boolean)

        ' Save values
        With Me
            .Async = Async
        End With

    End Sub

    Public Sub New(ByVal Sound As System.IO.UnmanagedMemoryStream, ByVal Async As Boolean)

        ' Load this resource
        LoadResource(Sound)

        ' Save values
        With Me
            .Async = Async
        End With

    End Sub

#End Region

    ' Retrieves the current flags
    Private Function GetFlags() As Integer
        Return IIf(Async, SoundFlags.SND_ASYNC, 0) Or IIf(LoopSound, SoundFlags.SND_LOOP, 0) _
                Or IIf(NoStop, SoundFlags.SND_NOSTOP, 0) Or IIf(NoWait, SoundFlags.SND_NOWAIT, 0)
    End Function

    ' Used to load the content of a resource file
    Private Sub LoadResource(ByVal Sound As System.IO.UnmanagedMemoryStream)

        ' Allocate the receieving array
        ReDim bData(Sound.Length)

        ' Retrieve the sound array
        Sound.Read(bData, 0, Sound.Length)

    End Sub

    ' Plays a sound using a memory location
    Public Function PlaySound(ByVal Purge As Boolean) As Boolean
        Return (PlaySoundM(bData, IntPtr.Zero, GetFlags() Or SoundFlags.SND_MEMORY Or _
         IIf(Purge, SoundFlags.SND_PURGE, 0)))
    End Function

    ' Plays a sound using a file name
    Public Function PlaySound(ByVal FileName As String, ByVal Purge As Boolean) As Boolean
        Return (PlaySoundA(FileName, IntPtr.Zero, GetFlags() Or SoundFlags.SND_FILENAME Or _
         IIf(Purge, SoundFlags.SND_PURGE, 0)) = 0)
    End Function

    Public Function PlaySound(ByVal Recource As String, ByVal AppPath As String) As Boolean
        Return (PlaySoundA(Recource, IntPtr.Zero, GetFlags() Or SoundFlags.SND_APPLICATION) = 0)
    End Function

    ' Plays a sound using an application related event
    Public Function PlaySound(ByVal AppEvent As String) As Boolean
        Return (PlaySoundA(AppEvent, IntPtr.Zero, GetFlags() Or SoundFlags.SND_APPLICATION) = 0)
    End Function

End Class
