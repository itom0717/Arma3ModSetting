Imports System.ComponentModel
''' <summary>
''' メインフォーム
''' </summary>
Public Class MainForm

  ''' <summary>
  ''' ショートカット作成済みオプション
  ''' </summary>
  Private Const CreatedShortCutArguments As String = "/s"

  ''' <summary>
  ''' LogSeparator
  ''' </summary>
  Private Const LogSeparator As String = "--------------------------------------------"

  ''' <summary>
  ''' 設定情報
  ''' </summary>
  Private SettingData As New SettingData


  ''' <summary>
  ''' MOd情報
  ''' </summary>
  Private ModsInfoList As List(Of ModInfo)


  ''' <summary>
  ''' Form_Load
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles Me.Load

    Try


      'タイトル設定
      Me.Text = My.Application.Info.Title

      '各コントロールの初期化
      Me.LogListBox.Items.Clear()
      Me.ModTreeView.Nodes.Clear()
      Me.OKButton.Text = My.Resources.TextResource.OKButton
      Me.GetModInfoButton.Text = My.Resources.TextResource.GetModInfoButton
      Me.CloseButton.Text = My.Resources.TextResource.CloseButton
      Me.ResetButton.Text = My.Resources.TextResource.ResetButton
      Me.CreateShortCutCheckBox.Text = My.Resources.TextResource.CreateShortCutCheckBox


      'とりあえずショートカット作成をチェック
      Me.CreateShortCutCheckBox.Checked = True
      'コマンドライン取得
      If My.Application.CommandLineArgs.Count >= 1 Then
        For Each cmd As String In My.Application.CommandLineArgs
          If cmd.Equals(CreatedShortCutArguments, StringComparison.CurrentCultureIgnoreCase) Then
            'ショートカットから呼ばれたため、チェックを外す
            Me.CreateShortCutCheckBox.Checked = False
          End If
        Next
      End If


      Me.LoadingPictureBox.Visible = False
      Me.LoadingPictureBox.Top = Me.ModTreeView.Top
      Me.LoadingPictureBox.Left = Me.ModTreeView.Left
      Me.LoadingPictureBox.Height = Me.ModTreeView.Height
      Me.LoadingPictureBox.Width = Me.ModTreeView.Width

    Catch ex As Exception
      MessageBox.Show(ex.Message)
      End
    End Try
  End Sub


  ''' <summary>
  ''' Cancel Button
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
    Me.Close()
  End Sub

  ''' <summary>
  ''' Form_Shown
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  ''' <remarks>
  ''' 初回表示時に実行
  ''' </remarks>
  Private Sub MainForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

    Try

      '設定データファイル名
      Dim settingDataFilename As String = Common.File.CombinePath(Common.File.GetApplicationDirectory,
                                                                      My.Application.Info.AssemblyName & ".setting")
      If Not Common.File.ExistsFile(settingDataFilename) Then
        '設定ファイルが見つかりません。
        Throw New Exception(My.Resources.TextResource.ErrMsgSettingFilesNotFound)
      End If

      '設定データ取得
      Me.ModsInfoList = Me.SettingData.GetSetting(settingDataFilename)

      'MOD情報更新
      Me.UpdateModTreeView()

    Catch ex As Exception

      MessageBox.Show(ex.Message,
                    My.Application.Info.AssemblyName,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error)
      Me.Close()

    End Try

  End Sub

  ''' <summary>
  ''' MOD情報更新
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub GetModInfoButton_Click(sender As Object, e As EventArgs) Handles GetModInfoButton.Click
    'MOD情報更新
    Me.UpdateModTreeView()
  End Sub

  ''' <summary>
  ''' OK Button
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub OKButton_Click(sender As Object, e As EventArgs) Handles OKButton.Click

    '実行確認
    If MessageBox.Show(My.Resources.TextResource.ConfirmationMessageGo,
                           My.Application.Info.AssemblyName,
                           MessageBoxButtons.OKCancel,
                           MessageBoxIcon.Question) <> DialogResult.OK Then
      Return
    End If

    'ボタン類を無効にする
    Me.EnableButtons(False)

    'ログエリアクリア
    Me.LogListBox.Items.Clear()

    'バックグラウンド処理を開始する
    Me.SetBackgroundWorker.RunWorkerAsync()

  End Sub

  ''' <summary>
  ''' Reset
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub ResetButton_Click(sender As Object, e As EventArgs) Handles ResetButton.Click

    '実行確認
    If MessageBox.Show(My.Resources.TextResource.ConfirmationMessageReset,
                           My.Application.Info.AssemblyName,
                           MessageBoxButtons.OKCancel,
                           MessageBoxIcon.Question) <> DialogResult.OK Then
      Return
    End If

    'ボタン類を無効にする
    Me.EnableButtons(False)

    'ログエリアクリア
    Me.LogListBox.Items.Clear()


    'バックグラウンド処理を開始する
    Me.ResetBackgroundWorker.RunWorkerAsync()
  End Sub



  ''' <summary>
  ''' MOD情報更新
  ''' </summary>
  Private Sub UpdateModTreeView()

    Try
      'ボタン類を無効にする
      Me.EnableButtons(False)

      Me.ModTreeView.Nodes.Clear()


      Dim serverNode As New TreeNode
      serverNode.Text = Me.SettingData.ServerInfo
      serverNode.ImageIndex = 6
      Me.ModTreeView.Nodes.Add(serverNode)


      'MODの情報をTreeViewに表示
      For Each modInfo As ModInfo In Me.ModsInfoList

        '各MODの情報取得
        modInfo.GetModInfo()

        Dim modNode As New TreeNode
        modNode.Text = modInfo.ModSetting.ModName
        modNode.ImageIndex = 0

        '追加情報
        Dim addNode As New TreeNode
        addNode.ImageIndex = 1
        addNode.Text = My.Resources.TextResource.AddText

        'nodeに追加
        For Each pbo As String In modInfo.ModSetting.AddFile
          Dim node As New TreeNode(pbo)
          addNode.Nodes.Add(node)

          If modInfo.AddonsPathInfo.ExistsPbo(pbo) Then
            '存在する
            node.ImageIndex = 3
          Else
            '存在しない
            node.ImageIndex = 4
          End If
        Next

        '1件以上あれば追加する
        If addNode.Nodes.Count >= 1 Then
          modNode.Nodes.Add(addNode)
        End If


        '削除情報
        Dim disableNode As New TreeNode
        disableNode.ImageIndex = 2
        disableNode.Text = My.Resources.TextResource.DelText

        'nodeに追加
        For Each pbo As String In modInfo.ModSetting.DelFile
          Dim node As New TreeNode(pbo)
          disableNode.Nodes.Add(node)

          If modInfo.AddonsPathInfo.ExistsPbo(pbo) Then
            '存在する
            node.ImageIndex = 5
          Else
            '存在しない
            node.ImageIndex = 3
          End If

        Next

        '1件以上あれば追加する
        If disableNode.Nodes.Count >= 1 Then
          modNode.Nodes.Add(disableNode)
        End If


        '1件以上あれば追加する
        If modNode.Nodes.Count >= 1 Then
          serverNode.Nodes.Add(modNode)
        End If
      Next


      serverNode.ExpandAll()


    Catch ex As Exception

      MessageBox.Show(ex.Message,
                          My.Application.Info.AssemblyName,
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error)
      Me.Close()

    Finally
      'ボタン類を有効にする
      Me.EnableButtons(True)
    End Try

  End Sub

  ''' <summary>
  ''' ログテキスト表示
  ''' </summary>
  ''' <param name="text"></param>
  Private Sub AddLogText(Optional text As String = "")
    Me.LogListBox.Items.Add(text)
    Me.LogListBox.SelectedIndex = Me.LogListBox.Items.Count - 1
  End Sub


  ''' <summary>
  ''' ボタン類のDisable/Enable切り替え
  ''' </summary>
  Private Sub EnableButtons(isEnable As Boolean)

    '処理中表示
    Me.LoadingPictureBox.Visible = Not isEnable

    '各ボタンの操作を無効にする
    Me.OKButton.Enabled = isEnable
    Me.GetModInfoButton.Enabled = isEnable
    Me.CreateShortCutCheckBox.Enabled = isEnable
    Me.CloseButton.Enabled = isEnable

    If Me.ModTreeView.Nodes.Count <= 0 Then
      '0件の場合は処理実行ボタンを無効にする
      Me.OKButton.Enabled = False
    End If
  End Sub




  ''' <summary>
  ''' バックグラウンド処理完了時の処理
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub SetBackgroundWorker_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles SetBackgroundWorker.RunWorkerCompleted, ResetBackgroundWorker.RunWorkerCompleted

    If Not (e.Error Is Nothing) Then
      MessageBox.Show(e.Error.Message,
                        My.Application.Info.AssemblyName,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error)
    ElseIf e.Cancelled Then
      'キャンセルされた（このプログラムでは存在しない）
    Else
      '正常終了
      'MOD情報更新
      Me.UpdateModTreeView()
    End If

    'ボタン類を有効にする
    Me.EnableButtons(True)
  End Sub

  ''' <summary>
  ''' 設定処理
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub SetBackgroundWorker_DoWork(sender As Object, e As DoWorkEventArgs) Handles SetBackgroundWorker.DoWork

    Try
      Dim addLog As New Action(Of String)(AddressOf AddLogText)

      Me.Invoke(addLog, LogSeparator)
      Me.Invoke(addLog, My.Resources.TextResource.LogTextStart) '処理を開始
      Me.Invoke(addLog, LogSeparator)
      Me.Invoke(addLog, "")

      'mod数分ループ
      For Each modinfo As ModInfo In Me.ModsInfoList

        Me.Invoke(addLog, LogSeparator)
        Me.Invoke(addLog, "[" & modinfo.ModSetting.ModName & "]")
        Me.Invoke(addLog, "")

        'addファイルを処理
        For Each tgtFile As String In modinfo.ModSetting.AddFile
          'ファイルをコピー
          For Each file As String In Common.File.GetFileList(modinfo.OptionalPathInfo.Path, tgtFile & "*", False)

            Me.Invoke(addLog, My.Resources.TextResource.LogTextAddFile & My.Computer.FileSystem.GetName(file))

            'コピー処理
            Common.File.CopyFile(file, Common.File.CombinePath(modinfo.AddonsPathInfo.Path, Common.File.GetFileName(file)), True)
          Next
        Next

        Me.Invoke(addLog, "")

        'delファイルを処理
        For Each tgtFile As String In modinfo.ModSetting.DelFile

          For Each file As String In Common.File.GetFileList(modinfo.AddonsPathInfo.Path, tgtFile & "*", False)

            Me.Invoke(addLog, My.Resources.TextResource.LogTextDelFile & My.Computer.FileSystem.GetName(file))

            'disableへコピーして削除
            Common.File.CopyFile(file, Common.File.CombinePath(modinfo.DisablePathInfo.Path, Common.File.GetFileName(file)), True)

            '削除
            Common.File.DeleteFile(file)
          Next
        Next

        Me.Invoke(addLog, "")
        Me.Invoke(addLog, "")
      Next

      'ショートカット作成
      If Me.CreateShortCutCheckBox.Checked Then
        Me.Invoke(addLog, My.Resources.TextResource.LogTextCreateShortCut) 'ショートカット作成

        '作成するショートカットのパス
        Dim shortcutPath As String = Common.File.GetDesktopDirectory & My.Application.Info.Title & ".lnk"

        'ショートカットのリンク先
        Dim targetPath As String = Application.ExecutablePath

        '作成
        Common.File.CreateShortcut(shortcutPath, targetPath,,,, CreatedShortCutArguments)

        Me.Invoke(addLog, "")
      End If

      Me.Invoke(addLog, My.Resources.TextResource.LogTextFinish) '処理が終了しました。


    Catch ex As Exception
      Throw
    End Try

  End Sub

  ''' <summary>
  ''' リセット処理
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub ResetBackgroundWorker_DoWork(sender As Object, e As DoWorkEventArgs) Handles ResetBackgroundWorker.DoWork


    Try
      Dim addLog As New Action(Of String)(AddressOf AddLogText)

      Me.Invoke(addLog, LogSeparator)
      Me.Invoke(addLog, My.Resources.TextResource.LogTextStart) '処理を開始
      Me.Invoke(addLog, LogSeparator)
      Me.Invoke(addLog, "")

      'mod数分ループ
      For Each modinfo As ModInfo In Me.ModsInfoList

        Me.Invoke(addLog, LogSeparator)
        Me.Invoke(addLog, "[" & modinfo.ModSetting.ModName & "]")
        Me.Invoke(addLog, "")

        'disable からaddon へ移動
        For Each file As String In Common.File.GetFileList(modinfo.DisablePathInfo.Path, "*.*", False)
          Me.Invoke(addLog, My.Resources.TextResource.LogTextResetFile & My.Computer.FileSystem.GetName(file))

          'コピー処理
          Common.File.CopyFile(file, Common.File.CombinePath(modinfo.AddonsPathInfo.Path, Common.File.GetFileName(file)), True)

          '削除
          Common.File.DeleteFile(file)
        Next

        'Ontionに存在したら削除
        For Each optFile As String In Common.File.GetFileList(modinfo.OptionalPathInfo.Path, "*.pbo", False)
          For Each file As String In Common.File.GetFileList(modinfo.AddonsPathInfo.Path, Common.File.GetFileName(optFile) & "*", False)

            Me.Invoke(addLog, My.Resources.TextResource.LogTextResetFile & My.Computer.FileSystem.GetName(file))

            '削除
            Common.File.DeleteFile(file)
          Next
        Next


        Me.Invoke(addLog, "")
        Me.Invoke(addLog, "")
      Next

      Me.Invoke(addLog, My.Resources.TextResource.LogTextFinish) '処理が終了しました。

    Catch ex As Exception
      Throw
    End Try

  End Sub





End Class
