<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.AppPoolUserText = New System.Windows.Forms.TextBox()
        Me.label4 = New System.Windows.Forms.Label()
        Me.AppPoolText = New System.Windows.Forms.TextBox()
        Me.label3 = New System.Windows.Forms.Label()
        Me.AppsCombo = New System.Windows.Forms.ComboBox()
        Me.label2 = New System.Windows.Forms.Label()
        Me.SitesCombo = New System.Windows.Forms.ComboBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'AppPoolUserText
        '
        Me.AppPoolUserText.BackColor = System.Drawing.Color.White
        Me.AppPoolUserText.Location = New System.Drawing.Point(12, 284)
        Me.AppPoolUserText.Name = "AppPoolUserText"
        Me.AppPoolUserText.ReadOnly = True
        Me.AppPoolUserText.Size = New System.Drawing.Size(348, 30)
        Me.AppPoolUserText.TabIndex = 17
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(8, 258)
        Me.label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(100, 23)
        Me.label4.TabIndex = 16
        Me.label4.Text = "実行ユーザー"
        '
        'AppPoolText
        '
        Me.AppPoolText.BackColor = System.Drawing.Color.White
        Me.AppPoolText.Location = New System.Drawing.Point(12, 202)
        Me.AppPoolText.Name = "AppPoolText"
        Me.AppPoolText.ReadOnly = True
        Me.AppPoolText.Size = New System.Drawing.Size(348, 30)
        Me.AppPoolText.TabIndex = 15
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(8, 176)
        Me.label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(190, 23)
        Me.label3.TabIndex = 14
        Me.label3.Text = "アプリケーションプール名"
        '
        'AppsCombo
        '
        Me.AppsCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.AppsCombo.FormattingEnabled = True
        Me.AppsCombo.Location = New System.Drawing.Point(12, 110)
        Me.AppsCombo.Name = "AppsCombo"
        Me.AppsCombo.Size = New System.Drawing.Size(348, 31)
        Me.AppsCombo.TabIndex = 13
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(13, 84)
        Me.label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(145, 23)
        Me.label2.TabIndex = 12
        Me.label2.Text = "アプリケーション名"
        '
        'SitesCombo
        '
        Me.SitesCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SitesCombo.FormattingEnabled = True
        Me.SitesCombo.Location = New System.Drawing.Point(12, 34)
        Me.SitesCombo.Name = "SitesCombo"
        Me.SitesCombo.Size = New System.Drawing.Size(292, 31)
        Me.SitesCombo.TabIndex = 11
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(13, 9)
        Me.label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(70, 23)
        Me.label1.TabIndex = 10
        Me.label1.Text = "サイト名"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 23.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(734, 365)
        Me.Controls.Add(Me.AppPoolUserText)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.AppPoolText)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.AppsCombo)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.SitesCombo)
        Me.Controls.Add(Me.label1)
        Me.Font = New System.Drawing.Font("メイリオ", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 6, 4, 6)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents AppPoolUserText As TextBox
    Private WithEvents label4 As Label
    Private WithEvents AppPoolText As TextBox
    Private WithEvents label3 As Label
    Private WithEvents AppsCombo As ComboBox
    Private WithEvents label2 As Label
    Private WithEvents SitesCombo As ComboBox
    Private WithEvents label1 As Label
End Class
