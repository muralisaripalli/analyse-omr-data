<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EvaluateOMR
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.statusMsg = New System.Windows.Forms.Label()
        Me.btnAnalyse = New System.Windows.Forms.Button()
        Me.fromOMR = New System.Windows.Forms.TextBox()
        Me.toOMR = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rangeSelection = New System.Windows.Forms.GroupBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.rangeSelection.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnBrowse
        '
        Me.btnBrowse.AccessibleName = ""
        Me.btnBrowse.Location = New System.Drawing.Point(8, 105)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowse.TabIndex = 0
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'statusMsg
        '
        Me.statusMsg.AutoEllipsis = True
        Me.statusMsg.Location = New System.Drawing.Point(8, 9)
        Me.statusMsg.Name = "statusMsg"
        Me.statusMsg.Size = New System.Drawing.Size(472, 84)
        Me.statusMsg.TabIndex = 1
        Me.statusMsg.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'btnAnalyse
        '
        Me.btnAnalyse.AccessibleName = ""
        Me.btnAnalyse.Location = New System.Drawing.Point(8, 105)
        Me.btnAnalyse.Name = "btnAnalyse"
        Me.btnAnalyse.Size = New System.Drawing.Size(75, 23)
        Me.btnAnalyse.TabIndex = 2
        Me.btnAnalyse.Text = "Evaluate"
        Me.btnAnalyse.UseVisualStyleBackColor = True
        '
        'fromOMR
        '
        Me.fromOMR.Location = New System.Drawing.Point(71, 12)
        Me.fromOMR.Name = "fromOMR"
        Me.fromOMR.Size = New System.Drawing.Size(56, 20)
        Me.fromOMR.TabIndex = 3
        '
        'toOMR
        '
        Me.toOMR.Location = New System.Drawing.Point(199, 12)
        Me.toOMR.Name = "toOMR"
        Me.toOMR.Size = New System.Drawing.Size(56, 20)
        Me.toOMR.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "From OMR"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(145, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "To OMR"
        '
        'rangeSelection
        '
        Me.rangeSelection.Controls.Add(Me.toOMR)
        Me.rangeSelection.Controls.Add(Me.Label1)
        Me.rangeSelection.Controls.Add(Me.Label2)
        Me.rangeSelection.Controls.Add(Me.fromOMR)
        Me.rangeSelection.Location = New System.Drawing.Point(100, 96)
        Me.rangeSelection.Name = "rangeSelection"
        Me.rangeSelection.Size = New System.Drawing.Size(263, 38)
        Me.rangeSelection.TabIndex = 7
        Me.rangeSelection.TabStop = False
        '
        'Timer1
        '
        '
        'EvaluateOMR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CausesValidation = False
        Me.ClientSize = New System.Drawing.Size(488, 138)
        Me.Controls.Add(Me.rangeSelection)
        Me.Controls.Add(Me.statusMsg)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.btnAnalyse)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "EvaluateOMR"
        Me.Text = "Evaluate OMR Results"
        Me.rangeSelection.ResumeLayout(False)
        Me.rangeSelection.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnBrowse As Button
    Friend WithEvents statusMsg As Label
    Friend WithEvents btnAnalyse As Button
    Friend WithEvents fromOMR As TextBox
    Friend WithEvents toOMR As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents rangeSelection As GroupBox
    Friend WithEvents Timer1 As Timer
End Class
