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
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
    Me.CloseButton = New System.Windows.Forms.Button()
    Me.OKButton = New System.Windows.Forms.Button()
    Me.CreateShortCutCheckBox = New System.Windows.Forms.CheckBox()
    Me.LogListBox = New System.Windows.Forms.ListBox()
    Me.ModTreeView = New System.Windows.Forms.TreeView()
    Me.TreeViewImageList = New System.Windows.Forms.ImageList(Me.components)
    Me.GetModInfoButton = New System.Windows.Forms.Button()
    Me.LoadingPictureBox = New System.Windows.Forms.PictureBox()
    Me.ResetButton = New System.Windows.Forms.Button()
    Me.SetBackgroundWorker = New System.ComponentModel.BackgroundWorker()
    Me.ResetBackgroundWorker = New System.ComponentModel.BackgroundWorker()
    Me.ServerListComboBox = New System.Windows.Forms.ComboBox()
    CType(Me.LoadingPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'CloseButton
    '
    Me.CloseButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.CloseButton.Location = New System.Drawing.Point(527, 376)
    Me.CloseButton.Name = "CloseButton"
    Me.CloseButton.Size = New System.Drawing.Size(75, 23)
    Me.CloseButton.TabIndex = 6
    Me.CloseButton.Text = "Close"
    Me.CloseButton.UseVisualStyleBackColor = True
    '
    'OKButton
    '
    Me.OKButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.OKButton.Location = New System.Drawing.Point(12, 376)
    Me.OKButton.Name = "OKButton"
    Me.OKButton.Size = New System.Drawing.Size(75, 23)
    Me.OKButton.TabIndex = 2
    Me.OKButton.Text = "Go"
    Me.OKButton.UseVisualStyleBackColor = True
    '
    'CreateShortCutCheckBox
    '
    Me.CreateShortCutCheckBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.CreateShortCutCheckBox.AutoSize = True
    Me.CreateShortCutCheckBox.Location = New System.Drawing.Point(115, 380)
    Me.CreateShortCutCheckBox.Name = "CreateShortCutCheckBox"
    Me.CreateShortCutCheckBox.Size = New System.Drawing.Size(156, 16)
    Me.CreateShortCutCheckBox.TabIndex = 3
    Me.CreateShortCutCheckBox.Text = "Create desktop shortcuts."
    Me.CreateShortCutCheckBox.UseVisualStyleBackColor = True
    '
    'LogListBox
    '
    Me.LogListBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.LogListBox.FormattingEnabled = True
    Me.LogListBox.ItemHeight = 12
    Me.LogListBox.Location = New System.Drawing.Point(12, 265)
    Me.LogListBox.Name = "LogListBox"
    Me.LogListBox.Size = New System.Drawing.Size(590, 100)
    Me.LogListBox.TabIndex = 1
    '
    'ModTreeView
    '
    Me.ModTreeView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.ModTreeView.ImageIndex = 0
    Me.ModTreeView.ImageList = Me.TreeViewImageList
    Me.ModTreeView.Location = New System.Drawing.Point(12, 42)
    Me.ModTreeView.Name = "ModTreeView"
    Me.ModTreeView.SelectedImageIndex = 0
    Me.ModTreeView.Size = New System.Drawing.Size(590, 217)
    Me.ModTreeView.TabIndex = 0
    '
    'TreeViewImageList
    '
    Me.TreeViewImageList.ImageStream = CType(resources.GetObject("TreeViewImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
    Me.TreeViewImageList.TransparentColor = System.Drawing.Color.Fuchsia
    Me.TreeViewImageList.Images.SetKeyName(0, "OpenFolder.bmp")
    Me.TreeViewImageList.Images.SetKeyName(1, "AddTable.bmp")
    Me.TreeViewImageList.Images.SetKeyName(2, "DeleteTable.bmp")
    Me.TreeViewImageList.Images.SetKeyName(3, "Task.bmp")
    Me.TreeViewImageList.Images.SetKeyName(4, "NewDocument.bmp")
    Me.TreeViewImageList.Images.SetKeyName(5, "Refresh_Cancel.bmp")
    Me.TreeViewImageList.Images.SetKeyName(6, "DatabaseProject_7342.ico")
    '
    'GetModInfoButton
    '
    Me.GetModInfoButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.GetModInfoButton.Location = New System.Drawing.Point(413, 376)
    Me.GetModInfoButton.Name = "GetModInfoButton"
    Me.GetModInfoButton.Size = New System.Drawing.Size(108, 23)
    Me.GetModInfoButton.TabIndex = 5
    Me.GetModInfoButton.Text = "Update Mod Info"
    Me.GetModInfoButton.UseVisualStyleBackColor = True
    '
    'LoadingPictureBox
    '
    Me.LoadingPictureBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.LoadingPictureBox.BackColor = System.Drawing.Color.White
    Me.LoadingPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LoadingPictureBox.Image = CType(resources.GetObject("LoadingPictureBox.Image"), System.Drawing.Image)
    Me.LoadingPictureBox.Location = New System.Drawing.Point(220, 75)
    Me.LoadingPictureBox.Name = "LoadingPictureBox"
    Me.LoadingPictureBox.Size = New System.Drawing.Size(361, 249)
    Me.LoadingPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
    Me.LoadingPictureBox.TabIndex = 6
    Me.LoadingPictureBox.TabStop = False
    '
    'ResetButton
    '
    Me.ResetButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.ResetButton.Location = New System.Drawing.Point(336, 376)
    Me.ResetButton.Name = "ResetButton"
    Me.ResetButton.Size = New System.Drawing.Size(71, 23)
    Me.ResetButton.TabIndex = 4
    Me.ResetButton.Text = "Reset"
    Me.ResetButton.UseVisualStyleBackColor = True
    Me.ResetButton.Visible = False
    '
    'SetBackgroundWorker
    '
    '
    'ResetBackgroundWorker
    '
    '
    'ServerListComboBox
    '
    Me.ServerListComboBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.ServerListComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.ServerListComboBox.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
    Me.ServerListComboBox.FormattingEnabled = True
    Me.ServerListComboBox.Location = New System.Drawing.Point(12, 12)
    Me.ServerListComboBox.Name = "ServerListComboBox"
    Me.ServerListComboBox.Size = New System.Drawing.Size(590, 23)
    Me.ServerListComboBox.TabIndex = 7
    '
    'MainForm
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(614, 413)
    Me.Controls.Add(Me.ServerListComboBox)
    Me.Controls.Add(Me.ResetButton)
    Me.Controls.Add(Me.LoadingPictureBox)
    Me.Controls.Add(Me.GetModInfoButton)
    Me.Controls.Add(Me.ModTreeView)
    Me.Controls.Add(Me.LogListBox)
    Me.Controls.Add(Me.CreateShortCutCheckBox)
    Me.Controls.Add(Me.OKButton)
    Me.Controls.Add(Me.CloseButton)
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.MinimumSize = New System.Drawing.Size(580, 350)
    Me.Name = "MainForm"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "MainForm"
    CType(Me.LoadingPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

  Friend WithEvents CloseButton As Button
    Friend WithEvents OKButton As Button
    Friend WithEvents CreateShortCutCheckBox As CheckBox
    Friend WithEvents LogListBox As ListBox
  Friend WithEvents ModTreeView As TreeView
  Friend WithEvents GetModInfoButton As Button
  Friend WithEvents LoadingPictureBox As PictureBox
  Friend WithEvents TreeViewImageList As ImageList
  Friend WithEvents ResetButton As Button
  Friend WithEvents SetBackgroundWorker As System.ComponentModel.BackgroundWorker
  Friend WithEvents ResetBackgroundWorker As System.ComponentModel.BackgroundWorker
  Friend WithEvents ServerListComboBox As ComboBox
End Class
