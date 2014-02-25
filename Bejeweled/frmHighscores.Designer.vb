<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHighscores
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.tabHighscores = New System.Windows.Forms.TabControl
        Me.pageNormal = New System.Windows.Forms.TabPage
        Me.lstNormal = New System.Windows.Forms.ListView
        Me.clmNormalRank = New System.Windows.Forms.ColumnHeader
        Me.clmNormalName = New System.Windows.Forms.ColumnHeader
        Me.clmNormalLevel = New System.Windows.Forms.ColumnHeader
        Me.pageTimed = New System.Windows.Forms.TabPage
        Me.lstTimed = New System.Windows.Forms.ListView
        Me.clmTimedRank = New System.Windows.Forms.ColumnHeader
        Me.clmTimedName = New System.Windows.Forms.ColumnHeader
        Me.clmTmedLevel = New System.Windows.Forms.ColumnHeader
        Me.tblControls = New System.Windows.Forms.TableLayoutPanel
        Me.cmdReset = New System.Windows.Forms.Button
        Me.cmdOk = New System.Windows.Forms.Button
        Me.tabHighscores.SuspendLayout()
        Me.pageNormal.SuspendLayout()
        Me.pageTimed.SuspendLayout()
        Me.tblControls.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabHighscores
        '
        Me.tabHighscores.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabHighscores.Controls.Add(Me.pageNormal)
        Me.tabHighscores.Controls.Add(Me.pageTimed)
        Me.tabHighscores.Location = New System.Drawing.Point(12, 12)
        Me.tabHighscores.Name = "tabHighscores"
        Me.tabHighscores.SelectedIndex = 0
        Me.tabHighscores.Size = New System.Drawing.Size(442, 398)
        Me.tabHighscores.TabIndex = 0
        '
        'pageNormal
        '
        Me.pageNormal.Controls.Add(Me.lstNormal)
        Me.pageNormal.Location = New System.Drawing.Point(4, 22)
        Me.pageNormal.Name = "pageNormal"
        Me.pageNormal.Padding = New System.Windows.Forms.Padding(3)
        Me.pageNormal.Size = New System.Drawing.Size(434, 372)
        Me.pageNormal.TabIndex = 0
        Me.pageNormal.Text = "Normal"
        Me.pageNormal.UseVisualStyleBackColor = True
        '
        'lstNormal
        '
        Me.lstNormal.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.clmNormalRank, Me.clmNormalName, Me.clmNormalLevel})
        Me.lstNormal.Location = New System.Drawing.Point(6, 6)
        Me.lstNormal.Name = "lstNormal"
        Me.lstNormal.Size = New System.Drawing.Size(422, 360)
        Me.lstNormal.TabIndex = 0
        Me.lstNormal.UseCompatibleStateImageBehavior = False
        Me.lstNormal.View = System.Windows.Forms.View.Details
        '
        'clmNormalRank
        '
        Me.clmNormalRank.Text = "Rank:"
        '
        'clmNormalName
        '
        Me.clmNormalName.Text = "Name:"
        Me.clmNormalName.Width = 229
        '
        'clmNormalLevel
        '
        Me.clmNormalLevel.Text = "Level:"
        Me.clmNormalLevel.Width = 99
        '
        'pageTimed
        '
        Me.pageTimed.Controls.Add(Me.lstTimed)
        Me.pageTimed.Location = New System.Drawing.Point(4, 22)
        Me.pageTimed.Name = "pageTimed"
        Me.pageTimed.Padding = New System.Windows.Forms.Padding(3)
        Me.pageTimed.Size = New System.Drawing.Size(434, 372)
        Me.pageTimed.TabIndex = 1
        Me.pageTimed.Text = "Timed"
        Me.pageTimed.UseVisualStyleBackColor = True
        '
        'lstTimed
        '
        Me.lstTimed.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.clmTimedRank, Me.clmTimedName, Me.clmTmedLevel})
        Me.lstTimed.Location = New System.Drawing.Point(6, 6)
        Me.lstTimed.Name = "lstTimed"
        Me.lstTimed.Size = New System.Drawing.Size(422, 360)
        Me.lstTimed.TabIndex = 1
        Me.lstTimed.UseCompatibleStateImageBehavior = False
        Me.lstTimed.View = System.Windows.Forms.View.Details
        '
        'clmTimedRank
        '
        Me.clmTimedRank.Text = "Rank:"
        '
        'clmTimedName
        '
        Me.clmTimedName.Text = "Name:"
        Me.clmTimedName.Width = 229
        '
        'clmTmedLevel
        '
        Me.clmTmedLevel.Text = "Level:"
        Me.clmTmedLevel.Width = 99
        '
        'tblControls
        '
        Me.tblControls.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tblControls.ColumnCount = 2
        Me.tblControls.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblControls.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblControls.Controls.Add(Me.cmdReset, 0, 0)
        Me.tblControls.Controls.Add(Me.cmdOk, 1, 0)
        Me.tblControls.Location = New System.Drawing.Point(257, 434)
        Me.tblControls.Name = "tblControls"
        Me.tblControls.RowCount = 1
        Me.tblControls.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tblControls.Size = New System.Drawing.Size(193, 33)
        Me.tblControls.TabIndex = 7
        '
        'cmdReset
        '
        Me.cmdReset.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdReset.Location = New System.Drawing.Point(3, 3)
        Me.cmdReset.Name = "cmdReset"
        Me.cmdReset.Size = New System.Drawing.Size(90, 27)
        Me.cmdReset.TabIndex = 5
        Me.cmdReset.Text = "&Reset scores"
        Me.cmdReset.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdOk.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdOk.Location = New System.Drawing.Point(99, 3)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(91, 27)
        Me.cmdOk.TabIndex = 4
        Me.cmdOk.Text = "&Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'frmHighscores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(466, 479)
        Me.Controls.Add(Me.tblControls)
        Me.Controls.Add(Me.tabHighscores)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "frmHighscores"
        Me.Text = "Highscores"
        Me.tabHighscores.ResumeLayout(False)
        Me.pageNormal.ResumeLayout(False)
        Me.pageTimed.ResumeLayout(False)
        Me.tblControls.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabHighscores As System.Windows.Forms.TabControl
    Friend WithEvents pageNormal As System.Windows.Forms.TabPage
    Friend WithEvents pageTimed As System.Windows.Forms.TabPage
    Friend WithEvents tblControls As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cmdReset As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents lstNormal As System.Windows.Forms.ListView
    Friend WithEvents clmNormalRank As System.Windows.Forms.ColumnHeader
    Friend WithEvents clmNormalName As System.Windows.Forms.ColumnHeader
    Friend WithEvents clmNormalLevel As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstTimed As System.Windows.Forms.ListView
    Friend WithEvents clmTimedRank As System.Windows.Forms.ColumnHeader
    Friend WithEvents clmTimedName As System.Windows.Forms.ColumnHeader
    Friend WithEvents clmTmedLevel As System.Windows.Forms.ColumnHeader
End Class
