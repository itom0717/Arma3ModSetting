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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
    Me.CloseButton = New System.Windows.Forms.Button()
    Me.OKButton = New System.Windows.Forms.Button()
    Me.CreateShortCutCheckBox = New System.Windows.Forms.CheckBox()
    Me.LogListBox = New System.Windows.Forms.ListBox()
    Me.SuspendLayout()
    '
    'CloseButton
    '
    Me.CloseButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.CloseButton.Location = New System.Drawing.Point(347, 226)
    Me.CloseButton.Name = "CloseButton"
    Me.CloseButton.Size = New System.Drawing.Size(75, 23)
    Me.CloseButton.TabIndex = 0
    Me.CloseButton.Text = "閉じる"
    Me.CloseButton.UseVisualStyleBackColor = True
    '
    'OKButton
    '
    Me.OKButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.OKButton.Location = New System.Drawing.Point(12, 226)
    Me.OKButton.Name = "OKButton"
    Me.OKButton.Size = New System.Drawing.Size(75, 23)
    Me.OKButton.TabIndex = 1
    Me.OKButton.Text = "処理実行"
    Me.OKButton.UseVisualStyleBackColor = True
    '
    'CreateShortCutCheckBox
    '
    Me.CreateShortCutCheckBox.AutoSize = True
    Me.CreateShortCutCheckBox.Location = New System.Drawing.Point(93, 232)
    Me.CreateShortCutCheckBox.Name = "CreateShortCutCheckBox"
    Me.CreateShortCutCheckBox.Size = New System.Drawing.Size(175, 16)
    Me.CreateShortCutCheckBox.TabIndex = 2
    Me.CreateShortCutCheckBox.Text = "デスクトップにショートカットを作成"
    Me.CreateShortCutCheckBox.UseVisualStyleBackColor = True
    '
    'LogListBox
    '
    Me.LogListBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.LogListBox.FormattingEnabled = True
    Me.LogListBox.ItemHeight = 12
    Me.LogListBox.Location = New System.Drawing.Point(12, 12)
    Me.LogListBox.Name = "LogListBox"
    Me.LogListBox.Size = New System.Drawing.Size(410, 208)
    Me.LogListBox.TabIndex = 3
    '
    'MainForm
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(434, 262)
    Me.Controls.Add(Me.LogListBox)
    Me.Controls.Add(Me.CreateShortCutCheckBox)
    Me.Controls.Add(Me.OKButton)
    Me.Controls.Add(Me.CloseButton)
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.MinimumSize = New System.Drawing.Size(450, 300)
    Me.Name = "MainForm"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "MainForm"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

  Friend WithEvents CloseButton As Button
    Friend WithEvents OKButton As Button
    Friend WithEvents CreateShortCutCheckBox As CheckBox
    Friend WithEvents LogListBox As ListBox
End Class
