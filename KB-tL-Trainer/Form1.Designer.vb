<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKBTL
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
        Me.chkMouseMove = New System.Windows.Forms.CheckBox()
        Me.lblXpos = New System.Windows.Forms.Label()
        Me.lblYPos = New System.Windows.Forms.Label()
        Me.lblZPos = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'chkMouseMove
        '
        Me.chkMouseMove.AutoSize = True
        Me.chkMouseMove.BackColor = System.Drawing.Color.LightGray
        Me.chkMouseMove.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMouseMove.Location = New System.Drawing.Point(12, 369)
        Me.chkMouseMove.Name = "chkMouseMove"
        Me.chkMouseMove.Size = New System.Drawing.Size(121, 20)
        Me.chkMouseMove.TabIndex = 47
        Me.chkMouseMove.Text = "CtrlMouseMove"
        Me.chkMouseMove.UseVisualStyleBackColor = False
        '
        'lblXpos
        '
        Me.lblXpos.AutoSize = True
        Me.lblXpos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblXpos.Location = New System.Drawing.Point(12, 24)
        Me.lblXpos.Name = "lblXpos"
        Me.lblXpos.Size = New System.Drawing.Size(45, 16)
        Me.lblXpos.TabIndex = 48
        Me.lblXpos.Text = "X pos:"
        '
        'lblYPos
        '
        Me.lblYPos.AutoSize = True
        Me.lblYPos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblYPos.Location = New System.Drawing.Point(12, 40)
        Me.lblYPos.Name = "lblYPos"
        Me.lblYPos.Size = New System.Drawing.Size(46, 16)
        Me.lblYPos.TabIndex = 49
        Me.lblYPos.Text = "Y pos:"
        '
        'lblZPos
        '
        Me.lblZPos.AutoSize = True
        Me.lblZPos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblZPos.Location = New System.Drawing.Point(12, 56)
        Me.lblZPos.Name = "lblZPos"
        Me.lblZPos.Size = New System.Drawing.Size(45, 16)
        Me.lblZPos.TabIndex = 50
        Me.lblZPos.Text = "Z pos:"
        '
        'frmKBTL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(538, 418)
        Me.Controls.Add(Me.lblZPos)
        Me.Controls.Add(Me.lblYPos)
        Me.Controls.Add(Me.lblXpos)
        Me.Controls.Add(Me.chkMouseMove)
        Me.Name = "frmKBTL"
        Me.Text = "Wulf's King's Bounty - The Legend Trainer"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkMouseMove As System.Windows.Forms.CheckBox
    Friend WithEvents lblXpos As System.Windows.Forms.Label
    Friend WithEvents lblYPos As System.Windows.Forms.Label
    Friend WithEvents lblZPos As System.Windows.Forms.Label

End Class
