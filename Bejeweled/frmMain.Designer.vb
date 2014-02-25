<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.gameProgress = New System.Windows.Forms.ProgressBar
        Me.statusBar = New System.Windows.Forms.StatusStrip
        Me.lblScore = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblLevel = New System.Windows.Forms.ToolStripStatusLabel
        Me.lblMoves = New System.Windows.Forms.ToolStripStatusLabel
        Me.mnuMain = New System.Windows.Forms.MenuStrip
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuNewGame = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuNormal = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuTimed = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuLoadGame = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuSaveGame = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuLine4 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuSettings = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuLine1 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuHint = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuLine2 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuHighscore = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuHelp = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuHowTo = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuLine3 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuAbout = New System.Windows.Forms.ToolStripMenuItem
        Me.tmrDecrease = New System.Windows.Forms.Timer(Me.components)
        Me.dialogSave = New System.Windows.Forms.SaveFileDialog
        Me.dialogOpen = New System.Windows.Forms.OpenFileDialog
        Me.statusBar.SuspendLayout()
        Me.mnuMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'gameProgress
        '
        Me.gameProgress.Location = New System.Drawing.Point(12, 368)
        Me.gameProgress.Name = "gameProgress"
        Me.gameProgress.Size = New System.Drawing.Size(306, 20)
        Me.gameProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.gameProgress.TabIndex = 0
        '
        'statusBar
        '
        Me.statusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblScore, Me.lblLevel, Me.lblMoves})
        Me.statusBar.Location = New System.Drawing.Point(0, 397)
        Me.statusBar.Name = "statusBar"
        Me.statusBar.Size = New System.Drawing.Size(392, 22)
        Me.statusBar.SizingGrip = False
        Me.statusBar.TabIndex = 1
        Me.statusBar.Text = "StatusStrip1"
        '
        'lblScore
        '
        Me.lblScore.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.lblScore.Name = "lblScore"
        Me.lblScore.Size = New System.Drawing.Size(125, 17)
        Me.lblScore.Spring = True
        Me.lblScore.Text = "Score: 0"
        '
        'lblLevel
        '
        Me.lblLevel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.lblLevel.Name = "lblLevel"
        Me.lblLevel.Size = New System.Drawing.Size(125, 17)
        Me.lblLevel.Spring = True
        Me.lblLevel.Text = "Level: 0"
        '
        'lblMoves
        '
        Me.lblMoves.Name = "lblMoves"
        Me.lblMoves.Size = New System.Drawing.Size(125, 17)
        Me.lblMoves.Spring = True
        Me.lblMoves.Text = "Valid moves: 0"
        '
        'mnuMain
        '
        Me.mnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuHelp})
        Me.mnuMain.Location = New System.Drawing.Point(0, 0)
        Me.mnuMain.Name = "mnuMain"
        Me.mnuMain.Size = New System.Drawing.Size(392, 24)
        Me.mnuMain.TabIndex = 2
        Me.mnuMain.Text = "MenuStrip1"
        '
        'mnuFile
        '
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuNewGame, Me.mnuLoadGame, Me.mnuSaveGame, Me.mnuLine4, Me.mnuSettings, Me.mnuHighscore, Me.mnuLine1, Me.mnuHint, Me.mnuLine2, Me.mnuExit})
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.Size = New System.Drawing.Size(46, 20)
        Me.mnuFile.Text = "&Game"
        '
        'mnuNewGame
        '
        Me.mnuNewGame.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuNormal, Me.mnuTimed})
        Me.mnuNewGame.Name = "mnuNewGame"
        Me.mnuNewGame.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.mnuNewGame.Size = New System.Drawing.Size(165, 22)
        Me.mnuNewGame.Text = "&New game"
        '
        'mnuNormal
        '
        Me.mnuNormal.Name = "mnuNormal"
        Me.mnuNormal.Size = New System.Drawing.Size(107, 22)
        Me.mnuNormal.Text = "&Normal"
        '
        'mnuTimed
        '
        Me.mnuTimed.Name = "mnuTimed"
        Me.mnuTimed.Size = New System.Drawing.Size(107, 22)
        Me.mnuTimed.Text = "&Timed"
        '
        'mnuLoadGame
        '
        Me.mnuLoadGame.Name = "mnuLoadGame"
        Me.mnuLoadGame.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
        Me.mnuLoadGame.Size = New System.Drawing.Size(165, 22)
        Me.mnuLoadGame.Text = "Load game"
        '
        'mnuSaveGame
        '
        Me.mnuSaveGame.Name = "mnuSaveGame"
        Me.mnuSaveGame.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.mnuSaveGame.Size = New System.Drawing.Size(165, 22)
        Me.mnuSaveGame.Text = "Save game"
        '
        'mnuLine4
        '
        Me.mnuLine4.Name = "mnuLine4"
        Me.mnuLine4.Size = New System.Drawing.Size(162, 6)
        '
        'mnuSettings
        '
        Me.mnuSettings.Name = "mnuSettings"
        Me.mnuSettings.Size = New System.Drawing.Size(165, 22)
        Me.mnuSettings.Text = "Settings"
        '
        'mnuLine1
        '
        Me.mnuLine1.Name = "mnuLine1"
        Me.mnuLine1.Size = New System.Drawing.Size(162, 6)
        '
        'mnuHint
        '
        Me.mnuHint.Name = "mnuHint"
        Me.mnuHint.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.mnuHint.Size = New System.Drawing.Size(165, 22)
        Me.mnuHint.Text = "Hint"
        '
        'mnuLine2
        '
        Me.mnuLine2.Name = "mnuLine2"
        Me.mnuLine2.Size = New System.Drawing.Size(162, 6)
        '
        'mnuExit
        '
        Me.mnuExit.Name = "mnuExit"
        Me.mnuExit.Size = New System.Drawing.Size(165, 22)
        Me.mnuExit.Text = "&Exit"
        '
        'mnuHighscore
        '
        Me.mnuHighscore.Name = "mnuHighscore"
        Me.mnuHighscore.Size = New System.Drawing.Size(165, 22)
        Me.mnuHighscore.Text = "Highscore"
        '
        'mnuHelp
        '
        Me.mnuHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuHowTo, Me.mnuLine3, Me.mnuAbout})
        Me.mnuHelp.Name = "mnuHelp"
        Me.mnuHelp.Size = New System.Drawing.Size(40, 20)
        Me.mnuHelp.Text = "Help"
        '
        'mnuHowTo
        '
        Me.mnuHowTo.Name = "mnuHowTo"
        Me.mnuHowTo.Size = New System.Drawing.Size(131, 22)
        Me.mnuHowTo.Text = "How to play"
        '
        'mnuLine3
        '
        Me.mnuLine3.Name = "mnuLine3"
        Me.mnuLine3.Size = New System.Drawing.Size(128, 6)
        '
        'mnuAbout
        '
        Me.mnuAbout.Name = "mnuAbout"
        Me.mnuAbout.Size = New System.Drawing.Size(131, 22)
        Me.mnuAbout.Text = "About"
        '
        'tmrDecrease
        '
        Me.tmrDecrease.Interval = 2000
        '
        'dialogSave
        '
        Me.dialogSave.Filter = "Save-files (*.bws)|*.bws|All files (*.*)|*.*"
        '
        'dialogOpen
        '
        Me.dialogOpen.FileName = "OpenFileDialog1"
        Me.dialogOpen.Filter = "Save-files (*.bws)|*.bws|All files (*.*)|*.*"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(392, 419)
        Me.Controls.Add(Me.statusBar)
        Me.Controls.Add(Me.mnuMain)
        Me.Controls.Add(Me.gameProgress)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.mnuMain
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.Text = "Bejeweled"
        Me.statusBar.ResumeLayout(False)
        Me.statusBar.PerformLayout()
        Me.mnuMain.ResumeLayout(False)
        Me.mnuMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gameProgress As System.Windows.Forms.ProgressBar
    Friend WithEvents statusBar As System.Windows.Forms.StatusStrip
    Friend WithEvents lblScore As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblLevel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents mnuMain As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuNewGame As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuNormal As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuTimed As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLine1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmrDecrease As System.Windows.Forms.Timer
    Friend WithEvents lblMoves As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents mnuHint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLine2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuSettings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuHowTo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLine3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuAbout As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLoadGame As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuLine4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuSaveGame As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dialogSave As System.Windows.Forms.SaveFileDialog
    Friend WithEvents dialogOpen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents mnuHighscore As System.Windows.Forms.ToolStripMenuItem

End Class
