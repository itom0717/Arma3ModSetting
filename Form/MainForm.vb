''' <summary>
''' メインフォーム
''' </summary>
Public Class MainForm

  ''' <summary>
  ''' 設定データ
  ''' </summary>
  ''' <returns></returns>
  Private Property SettingData As SettingData


    ''' <summary>
    ''' Form_Load
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            'タイトル設定
            Me.Text = My.Application.Info.AssemblyName

            'リストボックス初期化
            Me.LogListBox.Items.Clear()

        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Form_Shown
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub MainForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Try

            '設定データファイル名
            Dim settingDataFilename As String =
                My.Computer.FileSystem.CombinePath(My.Application.Info.DirectoryPath,
                                                   My.Application.Info.AssemblyName & ".setting")
            If Not My.Computer.FileSystem.FileExists(settingDataFilename) Then
                Throw New Exception("設定ファイルが見つかりません。")
            End If

            '設定データ取得
            Me.SettingData = New SettingData(settingDataFilename)

            '画面更新

            Me.LogListBox.Items.Add("--------------------------------------------")
            Me.LogListBox.Items.Add("各MODの設定を行います。")
            Me.LogListBox.Items.Add("MOD Path")
            Me.LogListBox.Items.Add("  " & My.Computer.FileSystem.CombinePath(My.Application.Info.DirectoryPath, ".."))
            Me.LogListBox.Items.Add("--------------------------------------------")

            For Each modSetting As ModSetting In Me.SettingData.ModSettingList
                Me.LogListBox.Items.Add(modSetting.ModName)
                For Each tgtFile As String In modSetting.AddFile
                    Me.LogListBox.Items.Add("  追加 : " & My.Computer.FileSystem.GetName(tgtFile))
                Next
                For Each tgtFile As String In modSetting.DelFile
                    Me.LogListBox.Items.Add("  削除 : " & My.Computer.FileSystem.GetName(tgtFile))
                Next
                Me.LogListBox.Items.Add("")
            Next







        Catch ex As Exception
            MessageBox.Show(ex.Message,
                            My.Application.Info.AssemblyName,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
            Me.Close()
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
    ''' OK Button
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub OKButton_Click(sender As Object, e As EventArgs) Handles OKButton.Click

        '実行確認
        If MessageBox.Show("実行しますか？",
                           My.Application.Info.AssemblyName,
                           MessageBoxButtons.OKCancel,
                           MessageBoxIcon.Question) <> DialogResult.OK Then
            Return
        End If


        Me.OKButton.Enabled = False
        Me.CloseButton.Enabled = False
        Me.CreateShortCutCheckBox.Enabled = False

        Me.LogListBox.Items.Add("--------------------------------------------")
        Me.LogListBox.Items.Add("処理を開始")
        Me.LogListBox.Items.Add("--------------------------------------------")


        '処理実行
        Try
            Dim modRootPath As String = My.Computer.FileSystem.CombinePath(My.Application.Info.DirectoryPath, "..")

            For Each modSetting As ModSetting In Me.SettingData.ModSettingList
                'MODのパス
                Me.LogListBox.Items.Add("--------------------------------------------")
                Me.LogListBox.Items.Add(modSetting.ModName)
                Me.LogListBox.Items.Add("--------------------------------------------")
                Me.LogListBox.SelectedIndex = Me.LogListBox.Items.Count - 1

                Dim modPath As String =
                   My.Computer.FileSystem.CombinePath(modRootPath, modSetting.ModName)

                Dim optionalPath As String =
                   My.Computer.FileSystem.CombinePath(modPath, modSetting.OptionalsPath)

                Dim addonsPath As String =
                   My.Computer.FileSystem.CombinePath(modPath, "addons")

                If Not My.Computer.FileSystem.DirectoryExists(modPath) Then
                    'MODフォルダが見つからない
                    Continue For
                End If
                If Not My.Computer.FileSystem.DirectoryExists(optionalPath) Then
                    'optionalフォルダ名が見つからない
                    Continue For
                End If
                If Not My.Computer.FileSystem.DirectoryExists(addonsPath) Then
                    'addonsフォルダ名が見つからない
                    Continue For
                End If

                'addファイルを処理
                For Each tgtFile As String In modSetting.AddFile

                    'ファイルをコピー
                    For Each file As String In
                        My.Computer.FileSystem.GetFiles(optionalPath,
                                                        Microsoft.VisualBasic.FileIO.SearchOption.SearchTopLevelOnly,
                                                        tgtFile & "*")

                        Me.LogListBox.Items.Add("  追加 : " & My.Computer.FileSystem.GetName(file))
                        Me.LogListBox.SelectedIndex = Me.LogListBox.Items.Count - 1

                        My.Computer.FileSystem.CopyFile(file,
                                                        My.Computer.FileSystem.CombinePath(addonsPath,
                                                                                           My.Computer.FileSystem.GetName(file)),
                                                        True)
                    Next
                Next



                'delファイルを処理
                For Each tgtFile As String In modSetting.DelFile


                    For Each file As String In
                        My.Computer.FileSystem.GetFiles(addonsPath,
                                                        Microsoft.VisualBasic.FileIO.SearchOption.SearchTopLevelOnly,
                                                        tgtFile & "*")

                        Me.LogListBox.Items.Add("  削除 : " & My.Computer.FileSystem.GetName(file))
                        Me.LogListBox.SelectedIndex = Me.LogListBox.Items.Count - 1


                        'optionalへ移動
                        My.Computer.FileSystem.CopyFile(file,
                                                        My.Computer.FileSystem.CombinePath(optionalPath,
                                                                                           My.Computer.FileSystem.GetName(file)),
                                                        True)
                        '削除
                        My.Computer.FileSystem.DeleteFile(file)

                    Next
                Next

                Me.LogListBox.Items.Add("")
                Me.LogListBox.Items.Add("")

            Next


            'ショートカット作成
            If Me.CreateShortCutCheckBox.Checked Then
                CreateShortcut()
            End If


            Me.OKButton.Enabled = True
            Me.CloseButton.Enabled = True
            Me.CreateShortCutCheckBox.Enabled = True

            Me.LogListBox.Items.Add("処理が終了しました。")
            Me.LogListBox.SelectedIndex = Me.LogListBox.Items.Count - 1


            'MessageBox.Show("処理が終了しました。",
            '    My.Application.Info.AssemblyName,
            '    MessageBoxButtons.OK,
            '    MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show(ex.Message,
                            My.Application.Info.AssemblyName,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
            Me.Close()

        End Try


    End Sub


    ''' <summary>
    ''' ショートカット作成
    ''' </summary>
    Private Sub CreateShortcut()

        '作成するショートカットのパス
        Dim shortcutPath As String = System.IO.Path.Combine(
            Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory),
            My.Application.Info.AssemblyName & ".lnk")

        'ショートカットのリンク先
        Dim targetPath As String = Application.ExecutablePath

        'WshShellを作成
        Dim t As Type =
            Type.GetTypeFromCLSID(New Guid("72C24DD5-D70A-438B-8A42-98424B88AFB8"))
        Dim shell = Activator.CreateInstance(t)

        'WshShortcutを作成
        Dim shortcut = shell.CreateShortcut(shortcutPath)

        'リンク先
        shortcut.TargetPath = targetPath
        'アイコンのパス
        shortcut.IconLocation = Application.ExecutablePath + ",0"
        'その他のプロパティも同様に設定できるため、省略

        'ショートカットを作成
        shortcut.Save()

        '後始末
        System.Runtime.InteropServices.Marshal.FinalReleaseComObject(shortcut)
        System.Runtime.InteropServices.Marshal.FinalReleaseComObject(shell)

    End Sub

End Class
