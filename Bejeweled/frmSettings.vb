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

Public Class frmSettings

    ' Used to make textboxes numberic
    Public Numberic As New NumbericTextbox

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Load all settings
        LoadSettings()

    End Sub

    Private Sub LoadSettings()

        ' Load all current settings
        txtWidth.Text = My.Settings.BoardWidth + 1
        txtHeight.Text = My.Settings.BoardHeight + 1
        txtStartLevel.Text = My.Settings.StartLevel
        txtToNextLevel.Text = My.Settings.ToNextLevel
        txtIntervalDecrease.Text = My.Settings.IntervalDecrease
        txtIntervalMilliseconds.Text = My.Settings.IntervalMilliseconds
        txtBonusValue.Text = My.Settings.BonusValue
        txtToNextIncrease.Text = My.Settings.ToNextIncrease
        txtIntervalMultiplicator.Text = My.Settings.IntervalMultiplicator
        txtBonusMultiplicator.Text = My.Settings.BonusMuliplicator
        txtSpeedDestruction.Text = My.Settings.SpeedDestruction
        txtSpeedSwap.Text = My.Settings.SpeedSwap
        txtSpeedShift.Text = My.Settings.SpeedShift
        chkEnableAnimations.Checked = My.Settings.EnableAnimations
        chkEnableSound.Checked = My.Settings.EnableSound

    End Sub

    Private Sub SaveSettings()

        ' Save all settings
        With My.Settings
            .BoardWidth = txtWidth.Text - 1
            .BoardHeight = txtHeight.Text - 1
            .StartLevel = txtStartLevel.Text
            .ToNextLevel = txtToNextLevel.Text
            .IntervalDecrease = txtIntervalDecrease.Text
            .IntervalMilliseconds = txtIntervalMilliseconds.Text
            .BonusValue = txtBonusValue.Text
            .ToNextIncrease = txtToNextIncrease.Text
            .IntervalMultiplicator = txtIntervalMultiplicator.Text
            .BonusMuliplicator = txtBonusMultiplicator.Text
            .SpeedDestruction = txtSpeedDestruction.Text
            .SpeedSwap = txtSpeedSwap.Text
            .SpeedShift = txtSpeedShift.Text
            .EnableAnimations = chkEnableAnimations.Checked
            .EnableSound = chkEnableSound.Checked
        End With

    End Sub

    Private Sub frmSettings_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Makes textboxes numberic
        Numberic.SetNumberic(txtWidth, True)
        Numberic.SetNumberic(txtHeight, True)
        Numberic.SetNumberic(txtStartLevel, True)
        Numberic.SetNumberic(txtToNextLevel, True)
        Numberic.SetNumberic(txtIntervalDecrease, True)
        Numberic.SetNumberic(txtIntervalMilliseconds, True)
        Numberic.SetNumberic(txtBonusValue, True)
        Numberic.SetNumberic(txtSpeedDestruction, True)
        Numberic.SetNumberic(txtSpeedSwap, True)
        Numberic.SetNumberic(txtSpeedShift, True)

    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click

        ' Save the settings
        SaveSettings()

        ' Close the form
        Me.Close()

    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click

        ' Close the form
        Me.Close()

    End Sub

End Class

Public Class NumbericTextbox

    ' API-calls
    Private Declare Function GetWindowLong Lib "user32" Alias "GetWindowLongA" _
     (ByVal hWnd As Integer, ByVal nIndex As Integer) As Integer
    Private Declare Function SetWindowLong Lib "user32" Alias "SetWindowLongA" _
     (ByVal hWnd As Integer, ByVal nIndex As Integer, ByVal dwNewInteger As Integer) As Integer

    ' Neeeded constants
    Private Const GWL_STYLE = (-16)
    Private Const ES_NUMBER = &H2000&

    ' Method that can change the state of a textbox
    Public Sub SetNumberic(ByVal NumberText As TextBox, ByVal Flag As Boolean)

        Dim curStyle As Integer

        ' Retrieve the window style
        curStyle = GetWindowLong(NumberText.Handle, GWL_STYLE)

        ' Append the flag
        If Flag Then
            curStyle = curStyle Or ES_NUMBER
        Else
            curStyle = curStyle And (Not ES_NUMBER)
        End If

        ' Set the new style
        SetWindowLong(NumberText.Handle, GWL_STYLE, curStyle)

        ' Refresh
        NumberText.Refresh()

    End Sub

End Class