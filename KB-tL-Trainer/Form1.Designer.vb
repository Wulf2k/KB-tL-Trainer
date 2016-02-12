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
        Me.txtGold = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtLeadership = New System.Windows.Forms.TextBox()
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
        'txtGold
        '
        Me.txtGold.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGold.Location = New System.Drawing.Point(85, 101)
        Me.txtGold.Name = "txtGold"
        Me.txtGold.Size = New System.Drawing.Size(100, 22)
        Me.txtGold.TabIndex = 51
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(42, 104)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 16)
        Me.Label1.TabIndex = 52
        Me.Label1.Text = "Gold"
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(451, 383)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 53
        Me.btnUpdate.Text = "Update"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 132)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 16)
        Me.Label2.TabIndex = 55
        Me.Label2.Text = "Leadership"
        '
        'txtLeadership
        '
        Me.txtLeadership.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLeadership.Location = New System.Drawing.Point(85, 129)
        Me.txtLeadership.Name = "txtLeadership"
        Me.txtLeadership.Size = New System.Drawing.Size(100, 22)
        Me.txtLeadership.TabIndex = 54
        '
        'frmKBTL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(538, 418)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtLeadership)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtGold)
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
    Friend WithEvents txtGold As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnUpdate As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents txtLeadership As TextBox
End Class
