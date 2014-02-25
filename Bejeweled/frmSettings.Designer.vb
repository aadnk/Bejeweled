<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettings
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
        Me.frameBoard = New System.Windows.Forms.GroupBox
        Me.tblBoard = New System.Windows.Forms.TableLayoutPanel
        Me.lblWidth = New System.Windows.Forms.Label
        Me.txtHeight = New System.Windows.Forms.TextBox
        Me.lblHeight = New System.Windows.Forms.Label
        Me.txtWidth = New System.Windows.Forms.TextBox
        Me.frameGame = New System.Windows.Forms.GroupBox
        Me.tblDefaultValues = New System.Windows.Forms.TableLayoutPanel
        Me.lblLevel = New System.Windows.Forms.Label
        Me.txtBonusValue = New System.Windows.Forms.TextBox
        Me.txtIntervalMilliseconds = New System.Windows.Forms.TextBox
        Me.lblBonus = New System.Windows.Forms.Label
        Me.txtStartLevel = New System.Windows.Forms.TextBox
        Me.lblIntervalMilliseconds = New System.Windows.Forms.Label
        Me.lblToNextLevel = New System.Windows.Forms.Label
        Me.txtToNextLevel = New System.Windows.Forms.TextBox
        Me.lblntervalDecrease = New System.Windows.Forms.Label
        Me.txtIntervalDecrease = New System.Windows.Forms.TextBox
        Me.toolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtToNextIncrease = New System.Windows.Forms.TextBox
        Me.txtIntervalMultiplicator = New System.Windows.Forms.TextBox
        Me.txtBonusMultiplicator = New System.Windows.Forms.TextBox
        Me.txtSpeedDestruction = New System.Windows.Forms.TextBox
        Me.txtSpeedSwap = New System.Windows.Forms.TextBox
        Me.txtSpeedShift = New System.Windows.Forms.TextBox
        Me.chkEnableAnimations = New System.Windows.Forms.CheckBox
        Me.chkEnableSound = New System.Windows.Forms.CheckBox
        Me.frameMultiplyers = New System.Windows.Forms.GroupBox
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.lblToNextIncrease = New System.Windows.Forms.Label
        Me.lblBonusMultiplicator = New System.Windows.Forms.Label
        Me.lblIntervalMultiplicator = New System.Windows.Forms.Label
        Me.frameAnimation = New System.Windows.Forms.GroupBox
        Me.tblAnimation = New System.Windows.Forms.TableLayoutPanel
        Me.lblSpeedDestruction = New System.Windows.Forms.Label
        Me.lblSpeedSwap = New System.Windows.Forms.Label
        Me.lblSpeedShift = New System.Windows.Forms.Label
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOK = New System.Windows.Forms.Button
        Me.tblControls = New System.Windows.Forms.TableLayoutPanel
        Me.tblFrames = New System.Windows.Forms.TableLayoutPanel
        Me.frameBoard.SuspendLayout()
        Me.tblBoard.SuspendLayout()
        Me.frameGame.SuspendLayout()
        Me.tblDefaultValues.SuspendLayout()
        Me.frameMultiplyers.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.frameAnimation.SuspendLayout()
        Me.tblAnimation.SuspendLayout()
        Me.tblControls.SuspendLayout()
        Me.tblFrames.SuspendLayout()
        Me.SuspendLayout()
        '
        'frameBoard
        '
        Me.frameBoard.Controls.Add(Me.tblBoard)
        Me.frameBoard.Dock = System.Windows.Forms.DockStyle.Fill
        Me.frameBoard.Location = New System.Drawing.Point(3, 3)
        Me.frameBoard.Name = "frameBoard"
        Me.frameBoard.Size = New System.Drawing.Size(346, 118)
        Me.frameBoard.TabIndex = 0
        Me.frameBoard.TabStop = False
        Me.frameBoard.Text = "Board:"
        '
        'tblBoard
        '
        Me.tblBoard.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tblBoard.ColumnCount = 2
        Me.tblBoard.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblBoard.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblBoard.Controls.Add(Me.lblWidth, 0, 0)
        Me.tblBoard.Controls.Add(Me.txtHeight, 1, 1)
        Me.tblBoard.Controls.Add(Me.lblHeight, 0, 1)
        Me.tblBoard.Controls.Add(Me.txtWidth, 1, 0)
        Me.tblBoard.Location = New System.Drawing.Point(6, 19)
        Me.tblBoard.Name = "tblBoard"
        Me.tblBoard.RowCount = 2
        Me.tblBoard.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblBoard.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblBoard.Size = New System.Drawing.Size(334, 93)
        Me.tblBoard.TabIndex = 4
        '
        'lblWidth
        '
        Me.lblWidth.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblWidth.AutoSize = True
        Me.lblWidth.Location = New System.Drawing.Point(3, 16)
        Me.lblWidth.Name = "lblWidth"
        Me.lblWidth.Size = New System.Drawing.Size(161, 13)
        Me.lblWidth.TabIndex = 0
        Me.lblWidth.Text = "&Width:"
        '
        'txtHeight
        '
        Me.txtHeight.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtHeight.Location = New System.Drawing.Point(170, 59)
        Me.txtHeight.Name = "txtHeight"
        Me.txtHeight.Size = New System.Drawing.Size(161, 20)
        Me.txtHeight.TabIndex = 3
        Me.toolTip.SetToolTip(Me.txtHeight, "Contains the amount of rows to use when creating the game board.")
        '
        'lblHeight
        '
        Me.lblHeight.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblHeight.AutoSize = True
        Me.lblHeight.Location = New System.Drawing.Point(3, 63)
        Me.lblHeight.Name = "lblHeight"
        Me.lblHeight.Size = New System.Drawing.Size(161, 13)
        Me.lblHeight.TabIndex = 2
        Me.lblHeight.Text = "&Height:"
        '
        'txtWidth
        '
        Me.txtWidth.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtWidth.Location = New System.Drawing.Point(170, 13)
        Me.txtWidth.Name = "txtWidth"
        Me.txtWidth.Size = New System.Drawing.Size(161, 20)
        Me.txtWidth.TabIndex = 1
        Me.toolTip.SetToolTip(Me.txtWidth, "Contains the amount of columns to be used when creating the game board.")
        '
        'frameGame
        '
        Me.frameGame.Controls.Add(Me.tblDefaultValues)
        Me.frameGame.Dock = System.Windows.Forms.DockStyle.Fill
        Me.frameGame.Location = New System.Drawing.Point(3, 127)
        Me.frameGame.Name = "frameGame"
        Me.frameGame.Size = New System.Drawing.Size(346, 245)
        Me.frameGame.TabIndex = 1
        Me.frameGame.TabStop = False
        Me.frameGame.Text = "Default values:"
        '
        'tblDefaultValues
        '
        Me.tblDefaultValues.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tblDefaultValues.ColumnCount = 2
        Me.tblDefaultValues.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblDefaultValues.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblDefaultValues.Controls.Add(Me.lblLevel, 0, 0)
        Me.tblDefaultValues.Controls.Add(Me.txtBonusValue, 1, 4)
        Me.tblDefaultValues.Controls.Add(Me.txtIntervalMilliseconds, 1, 3)
        Me.tblDefaultValues.Controls.Add(Me.lblBonus, 0, 4)
        Me.tblDefaultValues.Controls.Add(Me.txtStartLevel, 1, 0)
        Me.tblDefaultValues.Controls.Add(Me.lblIntervalMilliseconds, 0, 3)
        Me.tblDefaultValues.Controls.Add(Me.lblToNextLevel, 0, 1)
        Me.tblDefaultValues.Controls.Add(Me.txtToNextLevel, 1, 1)
        Me.tblDefaultValues.Controls.Add(Me.lblntervalDecrease, 0, 2)
        Me.tblDefaultValues.Controls.Add(Me.txtIntervalDecrease, 1, 2)
        Me.tblDefaultValues.Location = New System.Drawing.Point(6, 20)
        Me.tblDefaultValues.Name = "tblDefaultValues"
        Me.tblDefaultValues.RowCount = 5
        Me.tblDefaultValues.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tblDefaultValues.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tblDefaultValues.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tblDefaultValues.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tblDefaultValues.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tblDefaultValues.Size = New System.Drawing.Size(334, 219)
        Me.tblDefaultValues.TabIndex = 12
        '
        'lblLevel
        '
        Me.lblLevel.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLevel.AutoSize = True
        Me.lblLevel.Location = New System.Drawing.Point(3, 15)
        Me.lblLevel.Name = "lblLevel"
        Me.lblLevel.Size = New System.Drawing.Size(161, 13)
        Me.lblLevel.TabIndex = 4
        Me.lblLevel.Text = "&Level:"
        '
        'txtBonusValue
        '
        Me.txtBonusValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBonusValue.Location = New System.Drawing.Point(170, 185)
        Me.txtBonusValue.Name = "txtBonusValue"
        Me.txtBonusValue.Size = New System.Drawing.Size(161, 20)
        Me.txtBonusValue.TabIndex = 9
        Me.toolTip.SetToolTip(Me.txtBonusValue, "Set to change the default bonus.")
        '
        'txtIntervalMilliseconds
        '
        Me.txtIntervalMilliseconds.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtIntervalMilliseconds.Location = New System.Drawing.Point(170, 140)
        Me.txtIntervalMilliseconds.Name = "txtIntervalMilliseconds"
        Me.txtIntervalMilliseconds.Size = New System.Drawing.Size(161, 20)
        Me.txtIntervalMilliseconds.TabIndex = 11
        Me.toolTip.SetToolTip(Me.txtIntervalMilliseconds, "Set to change the interval (in milliseconds) of which to decrease the points in t" & _
                "imed mode.")
        '
        'lblBonus
        '
        Me.lblBonus.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBonus.AutoSize = True
        Me.lblBonus.Location = New System.Drawing.Point(3, 189)
        Me.lblBonus.Name = "lblBonus"
        Me.lblBonus.Size = New System.Drawing.Size(161, 13)
        Me.lblBonus.TabIndex = 8
        Me.lblBonus.Text = "&Bonus:"
        '
        'txtStartLevel
        '
        Me.txtStartLevel.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtStartLevel.Location = New System.Drawing.Point(170, 11)
        Me.txtStartLevel.Name = "txtStartLevel"
        Me.txtStartLevel.Size = New System.Drawing.Size(161, 20)
        Me.txtStartLevel.TabIndex = 3
        Me.toolTip.SetToolTip(Me.txtStartLevel, "Contains the level to start at.")
        '
        'lblIntervalMilliseconds
        '
        Me.lblIntervalMilliseconds.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblIntervalMilliseconds.AutoSize = True
        Me.lblIntervalMilliseconds.Location = New System.Drawing.Point(3, 144)
        Me.lblIntervalMilliseconds.Name = "lblIntervalMilliseconds"
        Me.lblIntervalMilliseconds.Size = New System.Drawing.Size(161, 13)
        Me.lblIntervalMilliseconds.TabIndex = 10
        Me.lblIntervalMilliseconds.Text = "&Interval (ms):"
        '
        'lblToNextLevel
        '
        Me.lblToNextLevel.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblToNextLevel.AutoSize = True
        Me.lblToNextLevel.Location = New System.Drawing.Point(3, 58)
        Me.lblToNextLevel.Name = "lblToNextLevel"
        Me.lblToNextLevel.Size = New System.Drawing.Size(161, 13)
        Me.lblToNextLevel.TabIndex = 2
        Me.lblToNextLevel.Text = "&Points to next level:"
        '
        'txtToNextLevel
        '
        Me.txtToNextLevel.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtToNextLevel.Location = New System.Drawing.Point(170, 54)
        Me.txtToNextLevel.Name = "txtToNextLevel"
        Me.txtToNextLevel.Size = New System.Drawing.Size(161, 20)
        Me.txtToNextLevel.TabIndex = 5
        Me.toolTip.SetToolTip(Me.txtToNextLevel, "Contains the amount of points that at the first level is required to level up.")
        '
        'lblntervalDecrease
        '
        Me.lblntervalDecrease.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblntervalDecrease.AutoSize = True
        Me.lblntervalDecrease.Location = New System.Drawing.Point(3, 101)
        Me.lblntervalDecrease.Name = "lblntervalDecrease"
        Me.lblntervalDecrease.Size = New System.Drawing.Size(161, 13)
        Me.lblntervalDecrease.TabIndex = 6
        Me.lblntervalDecrease.Text = "&Timed decrease:"
        '
        'txtIntervalDecrease
        '
        Me.txtIntervalDecrease.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtIntervalDecrease.Location = New System.Drawing.Point(170, 97)
        Me.txtIntervalDecrease.Name = "txtIntervalDecrease"
        Me.txtIntervalDecrease.Size = New System.Drawing.Size(161, 20)
        Me.txtIntervalDecrease.TabIndex = 7
        Me.toolTip.SetToolTip(Me.txtIntervalDecrease, "In timed mode, sets the amount of points to decrease at each interval.")
        '
        'txtToNextIncrease
        '
        Me.txtToNextIncrease.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtToNextIncrease.Location = New System.Drawing.Point(167, 5)
        Me.txtToNextIncrease.Name = "txtToNextIncrease"
        Me.txtToNextIncrease.Size = New System.Drawing.Size(158, 20)
        Me.txtToNextIncrease.TabIndex = 5
        Me.toolTip.SetToolTip(Me.txtToNextIncrease, "Set to change the number that is multiplied with the required amount of points to" & _
                " reach the next level (upon reaching a new level).")
        '
        'txtIntervalMultiplicator
        '
        Me.txtIntervalMultiplicator.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtIntervalMultiplicator.Location = New System.Drawing.Point(167, 35)
        Me.txtIntervalMultiplicator.Name = "txtIntervalMultiplicator"
        Me.txtIntervalMultiplicator.Size = New System.Drawing.Size(158, 20)
        Me.txtIntervalMultiplicator.TabIndex = 7
        Me.toolTip.SetToolTip(Me.txtIntervalMultiplicator, "Set to change the factor to increase the interval at which to remove points with." & _
                "")
        '
        'txtBonusMultiplicator
        '
        Me.txtBonusMultiplicator.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBonusMultiplicator.Location = New System.Drawing.Point(167, 66)
        Me.txtBonusMultiplicator.Name = "txtBonusMultiplicator"
        Me.txtBonusMultiplicator.Size = New System.Drawing.Size(158, 20)
        Me.txtBonusMultiplicator.TabIndex = 9
        Me.toolTip.SetToolTip(Me.txtBonusMultiplicator, "Cells that are removed as a consequence of another row of cells being removed wil" & _
                "l have its bonus increased by this factor.")
        '
        'txtSpeedDestruction
        '
        Me.txtSpeedDestruction.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSpeedDestruction.Location = New System.Drawing.Point(170, 12)
        Me.txtSpeedDestruction.Name = "txtSpeedDestruction"
        Me.txtSpeedDestruction.Size = New System.Drawing.Size(161, 20)
        Me.txtSpeedDestruction.TabIndex = 7
        Me.toolTip.SetToolTip(Me.txtSpeedDestruction, "Contains the amount of frames to use when drawing the destruction of cells.")
        '
        'txtSpeedSwap
        '
        Me.txtSpeedSwap.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSpeedSwap.Location = New System.Drawing.Point(170, 56)
        Me.txtSpeedSwap.Name = "txtSpeedSwap"
        Me.txtSpeedSwap.Size = New System.Drawing.Size(161, 20)
        Me.txtSpeedSwap.TabIndex = 9
        Me.toolTip.SetToolTip(Me.txtSpeedSwap, "Sets the amount of frames to use when drawing a swap between two cells.")
        '
        'txtSpeedShift
        '
        Me.txtSpeedShift.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSpeedShift.Location = New System.Drawing.Point(170, 100)
        Me.txtSpeedShift.Name = "txtSpeedShift"
        Me.txtSpeedShift.Size = New System.Drawing.Size(161, 20)
        Me.txtSpeedShift.TabIndex = 11
        Me.toolTip.SetToolTip(Me.txtSpeedShift, "Sets the amount of frames to use when moving a column one row down.")
        '
        'chkEnableAnimations
        '
        Me.chkEnableAnimations.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkEnableAnimations.AutoSize = True
        Me.chkEnableAnimations.Location = New System.Drawing.Point(3, 145)
        Me.chkEnableAnimations.Name = "chkEnableAnimations"
        Me.chkEnableAnimations.Size = New System.Drawing.Size(161, 17)
        Me.chkEnableAnimations.TabIndex = 13
        Me.chkEnableAnimations.Text = "Enable animations:"
        Me.toolTip.SetToolTip(Me.chkEnableAnimations, "Check to enable the usage of animations.")
        Me.chkEnableAnimations.UseVisualStyleBackColor = True
        '
        'chkEnableSound
        '
        Me.chkEnableSound.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkEnableSound.AutoSize = True
        Me.chkEnableSound.Location = New System.Drawing.Point(3, 189)
        Me.chkEnableSound.Name = "chkEnableSound"
        Me.chkEnableSound.Size = New System.Drawing.Size(161, 17)
        Me.chkEnableSound.TabIndex = 14
        Me.chkEnableSound.Text = "Enable sound"
        Me.toolTip.SetToolTip(Me.chkEnableSound, "Check to enable sounds.")
        Me.chkEnableSound.UseVisualStyleBackColor = True
        '
        'frameMultiplyers
        '
        Me.frameMultiplyers.Controls.Add(Me.TableLayoutPanel1)
        Me.frameMultiplyers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.frameMultiplyers.Location = New System.Drawing.Point(355, 3)
        Me.frameMultiplyers.Name = "frameMultiplyers"
        Me.frameMultiplyers.Size = New System.Drawing.Size(346, 118)
        Me.frameMultiplyers.TabIndex = 2
        Me.frameMultiplyers.TabStop = False
        Me.frameMultiplyers.Text = "Multiplyers:"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblToNextIncrease, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtBonusMultiplicator, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.lblBonusMultiplicator, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.txtToNextIncrease, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblIntervalMultiplicator, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtIntervalMultiplicator, 1, 1)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(9, 19)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(328, 93)
        Me.TableLayoutPanel1.TabIndex = 11
        '
        'lblToNextIncrease
        '
        Me.lblToNextIncrease.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblToNextIncrease.AutoSize = True
        Me.lblToNextIncrease.Location = New System.Drawing.Point(3, 8)
        Me.lblToNextIncrease.Name = "lblToNextIncrease"
        Me.lblToNextIncrease.Size = New System.Drawing.Size(158, 13)
        Me.lblToNextIncrease.TabIndex = 6
        Me.lblToNextIncrease.Text = "&Requirements factor:"
        '
        'lblBonusMultiplicator
        '
        Me.lblBonusMultiplicator.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBonusMultiplicator.AutoSize = True
        Me.lblBonusMultiplicator.Location = New System.Drawing.Point(3, 70)
        Me.lblBonusMultiplicator.Name = "lblBonusMultiplicator"
        Me.lblBonusMultiplicator.Size = New System.Drawing.Size(158, 13)
        Me.lblBonusMultiplicator.TabIndex = 10
        Me.lblBonusMultiplicator.Text = "Bonus factor:"
        '
        'lblIntervalMultiplicator
        '
        Me.lblIntervalMultiplicator.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblIntervalMultiplicator.AutoSize = True
        Me.lblIntervalMultiplicator.Location = New System.Drawing.Point(3, 38)
        Me.lblIntervalMultiplicator.Name = "lblIntervalMultiplicator"
        Me.lblIntervalMultiplicator.Size = New System.Drawing.Size(158, 13)
        Me.lblIntervalMultiplicator.TabIndex = 8
        Me.lblIntervalMultiplicator.Text = "Decrease factor:"
        '
        'frameAnimation
        '
        Me.frameAnimation.Controls.Add(Me.tblAnimation)
        Me.frameAnimation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.frameAnimation.Location = New System.Drawing.Point(355, 127)
        Me.frameAnimation.Name = "frameAnimation"
        Me.frameAnimation.Size = New System.Drawing.Size(346, 245)
        Me.frameAnimation.TabIndex = 3
        Me.frameAnimation.TabStop = False
        Me.frameAnimation.Text = "Animation:"
        '
        'tblAnimation
        '
        Me.tblAnimation.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tblAnimation.ColumnCount = 2
        Me.tblAnimation.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblAnimation.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblAnimation.Controls.Add(Me.lblSpeedDestruction, 0, 0)
        Me.tblAnimation.Controls.Add(Me.chkEnableSound, 0, 4)
        Me.tblAnimation.Controls.Add(Me.txtSpeedDestruction, 1, 0)
        Me.tblAnimation.Controls.Add(Me.chkEnableAnimations, 0, 3)
        Me.tblAnimation.Controls.Add(Me.lblSpeedSwap, 0, 1)
        Me.tblAnimation.Controls.Add(Me.txtSpeedShift, 1, 2)
        Me.tblAnimation.Controls.Add(Me.lblSpeedShift, 0, 2)
        Me.tblAnimation.Controls.Add(Me.txtSpeedSwap, 1, 1)
        Me.tblAnimation.Location = New System.Drawing.Point(6, 19)
        Me.tblAnimation.Name = "tblAnimation"
        Me.tblAnimation.RowCount = 5
        Me.tblAnimation.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tblAnimation.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tblAnimation.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tblAnimation.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tblAnimation.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.tblAnimation.Size = New System.Drawing.Size(334, 220)
        Me.tblAnimation.TabIndex = 15
        '
        'lblSpeedDestruction
        '
        Me.lblSpeedDestruction.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSpeedDestruction.AutoSize = True
        Me.lblSpeedDestruction.Location = New System.Drawing.Point(3, 15)
        Me.lblSpeedDestruction.Name = "lblSpeedDestruction"
        Me.lblSpeedDestruction.Size = New System.Drawing.Size(161, 13)
        Me.lblSpeedDestruction.TabIndex = 8
        Me.lblSpeedDestruction.Text = "&Cell destruction (frames)."
        '
        'lblSpeedSwap
        '
        Me.lblSpeedSwap.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSpeedSwap.AutoSize = True
        Me.lblSpeedSwap.Location = New System.Drawing.Point(3, 59)
        Me.lblSpeedSwap.Name = "lblSpeedSwap"
        Me.lblSpeedSwap.Size = New System.Drawing.Size(161, 13)
        Me.lblSpeedSwap.TabIndex = 10
        Me.lblSpeedSwap.Text = "&Cell swap:"
        '
        'lblSpeedShift
        '
        Me.lblSpeedShift.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSpeedShift.AutoSize = True
        Me.lblSpeedShift.Location = New System.Drawing.Point(3, 103)
        Me.lblSpeedShift.Name = "lblSpeedShift"
        Me.lblSpeedShift.Size = New System.Drawing.Size(161, 13)
        Me.lblSpeedShift.TabIndex = 12
        Me.lblSpeedShift.Text = "&Row remove:"
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdCancel.Location = New System.Drawing.Point(91, 3)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(82, 27)
        Me.cmdCancel.TabIndex = 4
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdOK.Location = New System.Drawing.Point(3, 3)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(82, 27)
        Me.cmdOK.TabIndex = 5
        Me.cmdOK.Text = "&Ok"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'tblControls
        '
        Me.tblControls.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tblControls.ColumnCount = 2
        Me.tblControls.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblControls.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblControls.Controls.Add(Me.cmdOK, 0, 0)
        Me.tblControls.Controls.Add(Me.cmdCancel, 1, 0)
        Me.tblControls.Location = New System.Drawing.Point(545, 411)
        Me.tblControls.Name = "tblControls"
        Me.tblControls.RowCount = 1
        Me.tblControls.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblControls.Size = New System.Drawing.Size(176, 33)
        Me.tblControls.TabIndex = 6
        '
        'tblFrames
        '
        Me.tblFrames.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tblFrames.ColumnCount = 2
        Me.tblFrames.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblFrames.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblFrames.Controls.Add(Me.frameBoard, 0, 0)
        Me.tblFrames.Controls.Add(Me.frameMultiplyers, 1, 0)
        Me.tblFrames.Controls.Add(Me.frameGame, 0, 1)
        Me.tblFrames.Controls.Add(Me.frameAnimation, 1, 1)
        Me.tblFrames.Location = New System.Drawing.Point(12, 12)
        Me.tblFrames.Name = "tblFrames"
        Me.tblFrames.RowCount = 2
        Me.tblFrames.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tblFrames.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.66666!))
        Me.tblFrames.Size = New System.Drawing.Size(704, 375)
        Me.tblFrames.TabIndex = 7
        '
        'frmSettings
        '
        Me.AcceptButton = Me.cmdOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(733, 456)
        Me.Controls.Add(Me.tblFrames)
        Me.Controls.Add(Me.tblControls)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(640, 480)
        Me.Name = "frmSettings"
        Me.Text = "Settings"
        Me.frameBoard.ResumeLayout(False)
        Me.tblBoard.ResumeLayout(False)
        Me.tblBoard.PerformLayout()
        Me.frameGame.ResumeLayout(False)
        Me.tblDefaultValues.ResumeLayout(False)
        Me.tblDefaultValues.PerformLayout()
        Me.frameMultiplyers.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.frameAnimation.ResumeLayout(False)
        Me.tblAnimation.ResumeLayout(False)
        Me.tblAnimation.PerformLayout()
        Me.tblControls.ResumeLayout(False)
        Me.tblFrames.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents frameBoard As System.Windows.Forms.GroupBox
    Friend WithEvents txtWidth As System.Windows.Forms.TextBox
    Friend WithEvents lblWidth As System.Windows.Forms.Label
    Friend WithEvents txtHeight As System.Windows.Forms.TextBox
    Friend WithEvents lblHeight As System.Windows.Forms.Label
    Friend WithEvents frameGame As System.Windows.Forms.GroupBox
    Friend WithEvents lblToNextLevel As System.Windows.Forms.Label
    Friend WithEvents lblLevel As System.Windows.Forms.Label
    Friend WithEvents lblntervalDecrease As System.Windows.Forms.Label
    Friend WithEvents lblBonus As System.Windows.Forms.Label
    Friend WithEvents toolTip As System.Windows.Forms.ToolTip
    Friend WithEvents lblIntervalMilliseconds As System.Windows.Forms.Label
    Friend WithEvents frameMultiplyers As System.Windows.Forms.GroupBox
    Friend WithEvents lblToNextIncrease As System.Windows.Forms.Label
    Friend WithEvents txtToNextIncrease As System.Windows.Forms.TextBox
    Friend WithEvents lblBonusMultiplicator As System.Windows.Forms.Label
    Friend WithEvents txtBonusMultiplicator As System.Windows.Forms.TextBox
    Friend WithEvents lblIntervalMultiplicator As System.Windows.Forms.Label
    Friend WithEvents txtIntervalMultiplicator As System.Windows.Forms.TextBox
    Friend WithEvents frameAnimation As System.Windows.Forms.GroupBox
    Friend WithEvents lblSpeedDestruction As System.Windows.Forms.Label
    Friend WithEvents txtSpeedDestruction As System.Windows.Forms.TextBox
    Friend WithEvents lblSpeedSwap As System.Windows.Forms.Label
    Friend WithEvents txtSpeedSwap As System.Windows.Forms.TextBox
    Friend WithEvents lblSpeedShift As System.Windows.Forms.Label
    Friend WithEvents txtSpeedShift As System.Windows.Forms.TextBox
    Friend WithEvents chkEnableAnimations As System.Windows.Forms.CheckBox
    Friend WithEvents chkEnableSound As System.Windows.Forms.CheckBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents tblControls As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tblDefaultValues As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tblFrames As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents txtBonusValue As System.Windows.Forms.TextBox
    Friend WithEvents txtIntervalMilliseconds As System.Windows.Forms.TextBox
    Friend WithEvents txtStartLevel As System.Windows.Forms.TextBox
    Friend WithEvents txtToNextLevel As System.Windows.Forms.TextBox
    Friend WithEvents txtIntervalDecrease As System.Windows.Forms.TextBox
    Friend WithEvents tblBoard As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tblAnimation As System.Windows.Forms.TableLayoutPanel
End Class
