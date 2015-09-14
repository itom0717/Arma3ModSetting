'namespace Common
Namespace Common

  ''' <summary>
  ''' ファイル処理共有関数
  ''' </summary>
  Public NotInheritable Class File
    ''' <summary>
    ''' コンストラクタ（プライベートとして宣言しNewできないようにする）
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub New()
      'Nop
    End Sub

    ''' <summary>
    ''' パスの最後に\を付ける
    ''' </summary>
    ''' <param name="srcPath">対象パス</param>
    ''' <returns>対象パスの最後に\を付けた文字列</returns>
    ''' <remarks>最後に\が着いていたら対象パスをそのまま返す</remarks>
    Public Shared Function AddDirectorySeparator(ByVal srcPath As String) As String
      If IsNothing(srcPath) OrElse srcPath.Equals("") Then
        Return srcPath
      End If
      '一旦削除して追加する
      Return srcPath.TrimEnd(System.IO.Path.DirectorySeparatorChar) & System.IO.Path.DirectorySeparatorChar
    End Function

    ''' <summary>
    ''' パスの最後の\を取り除く
    ''' </summary>
    ''' <param name="srcPath">対象パス</param>
    ''' <returns>\を取り除いたパス</returns>
    ''' <remarks>最後が\出ない場合は、対象パスをそのまま返す</remarks>
    Public Shared Function DeleteDirectorySeparator(ByVal srcPath As String) As String
      If IsNothing(srcPath) OrElse srcPath.Equals("") Then
        Return srcPath
      End If
      Return srcPath.TrimEnd(System.IO.Path.DirectorySeparatorChar)
    End Function

    ''' <summary>
    ''' パスからファイル名のみ取得する。
    ''' </summary>
    ''' <param name="srcPath">対象パス</param>
    ''' <returns>対象パスから取得したファイル名</returns>
    ''' <remarks></remarks>
    Public Shared Function GetFileName(ByVal srcPath As String) As String
      If srcPath.Equals("") Then
        Return ""
      End If
      Return IO.Path.GetFileName(srcPath)
    End Function

    ''' <summary>
    ''' パスからパス名のみ取得する。
    ''' </summary>
    ''' <param name="srcPath">対象パス</param>
    ''' <returns>対象パスから取得したパス名</returns>
    ''' <remarks></remarks>
    Public Shared Function GetDirectoryName(ByVal srcPath As String) As String
      If srcPath.Equals("") Then
        Return ""
      End If
      srcPath = IO.Path.GetDirectoryName(srcPath)
      If Not srcPath.Equals("") Then
        srcPath = AddDirectorySeparator(srcPath)
      End If
      Return srcPath
    End Function

    ''' <summary>
    ''' 拡張子を取り除いたパスを取得する
    ''' </summary>
    ''' <param name="srcPath">対象パス</param>
    ''' <returns>対象パスから拡張子を取り除いたパス</returns>
    ''' <remarks></remarks>
    Public Shared Function GetWithoutExtension(ByVal srcPath As String) As String
      If srcPath.Equals("") Then
        Return ""
      End If
      'IO.Path.GetFileNameWithoutExtensionはファイル名しか返さないので、パスを付ける
      Return GetDirectoryName(srcPath) & IO.Path.GetFileNameWithoutExtension(srcPath)
    End Function

    ''' <summary>
    ''' パスから拡張子のみを取得する
    ''' </summary>
    ''' <param name="srcPath">対象パス</param>
    ''' <returns>取得した拡張子</returns>
    ''' <remarks>ピリオドは付かない</remarks>
    Public Shared Function GetExtension(ByVal srcPath As String) As String
      If srcPath.Equals("") Then
        Return ""
      End If
      'IO.Path.GetExtensionはピリオドが付くので取り除く
      srcPath = IO.Path.GetExtension(srcPath)
      If srcPath.Equals("") Then
        Return ""
      End If
      If srcPath.Substring(0, 1).Equals(".") Then
        srcPath = srcPath.Substring(1) 'ピリオド以降の文字を取得
      End If
      Return srcPath
    End Function

    ''' <summary>
    ''' ファイルが存在するか確認
    ''' </summary>
    ''' <param name="srcPath">対象パス</param>
    ''' <returns>存在すればTrueを返す</returns>
    ''' <remarks></remarks>
    Public Shared Function ExistsFile(ByVal srcPath As String) As Boolean
      If srcPath.Equals("") Then
        Return False
      End If
      Try
        Return IO.File.Exists(srcPath)
      Catch
        ' アクセス権がないなどの場合
        Return False
      End Try
    End Function

    ''' <summary>
    ''' ディレクトリが存在するか確認
    ''' </summary>
    ''' <param name="srcPath">対象パス</param>
    ''' <returns>存在すればTrueを返す</returns>
    ''' <remarks></remarks>
    Public Shared Function ExistsDirectory(ByVal srcPath As String) As Boolean
      If srcPath.Equals("") Then
        Return False
      End If
      Try
        Return IO.Directory.Exists(srcPath)
      Catch
        ' アクセス権がないなどの場合
        Return False
      End Try
    End Function

    ''' <summary>
    ''' ディレクトリが空かチェック
    ''' </summary>
    ''' <param name="srcPath">チェックするパス</param>
    ''' <returns>空の場合はTrueを返す</returns>
    ''' <remarks></remarks>
    Public Shared Function IsEmptyDirectory(ByVal srcPath As String) As Boolean

      If Not ExistsDirectory(srcPath) Then
        ' ディレクトリが存在しなければ空でないとする
        Return False
      End If

      Try
        Dim entries() As String = IO.Directory.GetFileSystemEntries(srcPath)
        If entries.Length() = 0 Then
          Return True
        Else
          Return False
        End If
      Catch
        ' アクセス権がないなどの場合
        Return False
      End Try

    End Function

    ''' <summary>
    ''' ファイルをコピー
    ''' </summary>
    ''' <param name="srcFName"></param>
    ''' <param name="dstFName"></param>
    ''' <remarks></remarks>
    Public Shared Sub CopyFile(ByVal srcFName As String, ByVal dstFName As String, Optional isOverwrite As Boolean = False)
      IO.File.Copy(srcFName, dstFName, isOverwrite)
    End Sub

    ''' <summary>
    ''' ファイルの移動、名前変更
    ''' </summary>
    ''' <param name="srcFName"></param>
    ''' <param name="dstFName"></param>
    ''' <remarks></remarks>
    Public Shared Sub MoveFile(ByVal srcFName As String, ByVal dstFName As String)
      IO.File.Move(srcFName, dstFName)
    End Sub

    ''' <summary>
    ''' ファイルを削除
    ''' </summary>
    ''' <param name="srcFName">削除するファイルのフルパス</param>
    ''' <param name="useRecycleBox" >削除時にゴミ箱に入れるか？</param>
    ''' <returns>成功したらTrueを返す。ファイルが存在しない場合もTrueを返す</returns>
    ''' <remarks></remarks>
    Public Shared Function DeleteFile(ByVal srcFName As String, Optional ByVal useRecycleBox As Boolean = False) As Boolean
      If srcFName.Equals("") Then
        Return False
      End If

      Try
        If ExistsFile(srcFName) Then
          'ファイルが存在すればファイルを消去
          If useRecycleBox Then
            'ゴミ箱へ入れる
            My.Computer.FileSystem.DeleteFile(srcFName, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin)
          Else
            '直接削除
            My.Computer.FileSystem.DeleteFile(srcFName, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
          End If
        End If
        Return True

      Catch ex As Exception
        '削除失敗
        Return False
      End Try

    End Function


    ''' <summary>
    ''' ディレクトリ作成
    ''' </summary>
    ''' <param name="srcPath">作成するディレクトリ名</param>
    ''' <remarks></remarks>
    Public Shared Function CreateDirectory(ByVal srcPath As String) As Boolean
      If srcPath.Equals("") Then
        Return False
      End If
      Try
        IO.Directory.CreateDirectory(srcPath)
        Return True
      Catch ex As Exception
        '作成失敗
        Return False
      End Try
    End Function

    ''' <summary>
    ''' ディレクトリを削除
    ''' </summary>
    ''' <param name="srcPath">削除するディレクトリ</param>
    ''' <param name="useRecycleBox" >削除時にゴミ箱に入れるか？</param>
    ''' <returns>成功したらTrueを返す</returns>
    ''' <remarks></remarks>
    Public Shared Function DeleteDirectry(ByVal srcPath As String,
                                          Optional ByVal useRecycleBox As Boolean = False) As Boolean
      If srcPath.Equals("") Then
        Return False
      End If

      Try
        If useRecycleBox Then
          'ゴミ箱へ入れる
          My.Computer.FileSystem.DeleteDirectory(srcPath,
                                                 FileIO.UIOption.OnlyErrorDialogs,
                                                 FileIO.RecycleOption.SendToRecycleBin)
        Else
          '直接削除
          My.Computer.FileSystem.DeleteDirectory(srcPath,
                                                 FileIO.UIOption.OnlyErrorDialogs,
                                                 FileIO.RecycleOption.DeletePermanently)
        End If
        Return True
      Catch ex As Exception
        '削除失敗
        Return False
      End Try

    End Function


    ''' <summary>
    ''' ファイル一覧を取得
    ''' </summary>
    ''' <param name="srcPath">検索パス</param>
    ''' <param name="wildcards">ワイルドカード</param>
    ''' <param name="finedSubDir">サブディレクトリも検索するか？</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetFileList(ByVal srcPath As String,
                                       ByVal wildcards As String,
                                       ByVal finedSubDir As Boolean) As List(Of String)

      Dim searchType As FileIO.SearchOption = FileIO.SearchOption.SearchTopLevelOnly
      If finedSubDir Then
        searchType = FileIO.SearchOption.SearchAllSubDirectories
      End If

      'ファイル一覧取得
      'System.Collections.ObjectModel.ReadOnlyCollection(Of String)では使いにくいので、List(Of String)に変換して戻す
      Return New List(Of String)(My.Computer.FileSystem.GetFiles(srcPath, searchType, wildcards))

    End Function


    ''' <summary>
    ''' フォルダ一覧を取得
    ''' </summary>
    ''' <param name="srcPath">検索パス</param>
    ''' <param name="wildcards">ワイルドカード</param>
    ''' <param name="finedSubDir">サブディレクトリも検索するか？</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetFolderList(ByVal srcPath As String,
                                         ByVal wildcards As String,
                                         ByVal finedSubDir As Boolean) As List(Of String)

      Dim searchType As System.IO.SearchOption = System.IO.SearchOption.TopDirectoryOnly
      If finedSubDir Then
        searchType = System.IO.SearchOption.AllDirectories
      End If

      'ファイル一覧取得
      'String()では使いにくいので、List(Of String)に変換して戻す
      Return New List(Of String)(System.IO.Directory.GetDirectories(srcPath, wildcards, searchType))

    End Function


    ''' <summary>
    ''' パスにスペースが含まれている場合は、前後にダブルクオートをつける
    ''' </summary>
    ''' <param name="srcPath">対象パス</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function AddDblQt(ByVal srcPath As String) As String

      If srcPath.IndexOf(" "c) = -1 Then
        'ついていないので、そのまま返す
        Return srcPath
      Else
        '前後に"をつける
        Return """" & srcPath & """"
      End If

    End Function



    ''' <summary>
    ''' ファイルのサイズ
    ''' ファイルが無ければ-1を返す
    ''' </summary>
    ''' <param name="sPath"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetFilesize(ByVal sPath As String) As Long
      Try
        Dim fi As New System.IO.FileInfo(sPath)
        Return fi.Length
      Catch ex As Exception
        Return Nothing
      End Try
    End Function

    ''' <summary>
    ''' ファイルの作成日時を取得する
    ''' ファイルが無ければNothingを返す
    ''' </summary>
    ''' <param name="sPath"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetCreatedDate(ByVal sPath As String) As DateTime
      Try
        Return IO.File.GetCreationTime(sPath)
      Catch ex As Exception
        Return Nothing
      End Try
    End Function


    ''' <summary>
    ''' ファイルの更新日時を取得する
    ''' ファイルが無ければNothingを返す
    ''' </summary>
    ''' <param name="sPath"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetLastModifiedDate(ByVal sPath As String) As DateTime
      Try
        Return IO.File.GetLastWriteTime(sPath)
      Catch ex As Exception
        Return Nothing
      End Try
    End Function

    ''' <summary>
    ''' 現在のユーザーのデスクトップのパスを返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetDesktopDirectory() As String
      Return AddDirectorySeparator(System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory).ToString())
    End Function

    ''' <summary>
    ''' 現在のユーザーのマイドキュメントのパスを返す
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetMyDocumentsDirectory() As String
      Return AddDirectorySeparator(System.Environment.GetFolderPath(Environment.SpecialFolder.Personal).ToString())
    End Function



    ''' <summary>
    ''' ファイルロック中か判定
    ''' </summary>
    ''' <param name="filePath"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function IsLocked(filePath As String) As Boolean
      Try
        Using stream As System.IO.Stream = System.IO.File.OpenRead(filePath)
          'NOP
        End Using
        Return False
      Catch ex As Exception
        Return True
      End Try
    End Function




    ''' <summary>
    ''' ファイルの内容を比較する
    ''' </summary>
    ''' <param name="isRetry">エラー時のリトライか？</param>
    ''' <returns>同じ場合はTrueを返す</returns>
    ''' <remarks>
    ''' md5Hash値で比較する
    ''' </remarks>
    Public Shared Function IsSameFile(fileName1 As String,
                                      fileName2 As String,
                                      Optional isRetry As Boolean = False) As Boolean

      Try

        ' File.OpenReadではロック中のファイルを開くとエラーになる
        ' そのため、 FileStream でオプションを指定して開く

        If ExistsFile(fileName1) AndAlso ExistsFile(fileName2) Then
          Dim md5HashAlgorithm As System.Security.Cryptography.MD5 = System.Security.Cryptography.MD5.Create()
          Dim file1md5 As String = ""
          Dim file2md5 As String = ""

          'Using stream As Stream = File.OpenRead(fileName1)
          Using stream As System.IO.Stream = New System.IO.FileStream(fileName1,
                                                                      System.IO.FileMode.Open,
                                                                      System.IO.FileAccess.Read,
                                                                      System.IO.FileShare.ReadWrite)
            file1md5 = String.Concat(md5HashAlgorithm.ComputeHash(stream).Select(Function(x) String.Format("{0:X2}", x)))
          End Using

          'Using stream As Stream = File.OpenRead(fileName2)
          Using stream As System.IO.Stream = New System.IO.FileStream(fileName2,
                                                                      System.IO.FileMode.Open,
                                                                      System.IO.FileAccess.Read,
                                                                      System.IO.FileShare.ReadWrite)
            file2md5 = String.Concat(md5HashAlgorithm.ComputeHash(stream).Select(Function(x) String.Format("{0:X2}", x)))
          End Using

          If file1md5.Equals(file2md5) Then
            '同じ
            Return True
          Else
            Return False
          End If

        Else
          'どちらかのファイルが存在しない
          Return False
        End If

      Catch ex As Exception
        'エラー
        If Not isRetry Then
          '初回時のエラーのみ
          System.Threading.Thread.Sleep(3000) '数秒待つ
          Return IsSameFile(fileName1, fileName2, True)
        Else
          Return False
        End If
      End Try

    End Function

    ''' <summary>
    ''' ファイル名に使用禁止の文字がれば、その文字を置換する
    ''' </summary>
    ''' <param name="filename">ファイル名</param>
    ''' <param name="toChar">置換する文字</param>
    ''' <returns>
    ''' URLにも使用不可文字も対応
    ''' </returns>
    Public Shared Function ChangeInvalidFileName(filename As String,
                                                 toChar As Char) As String
      Dim newFilename As String = filename

      'ファイル名に使用できない文字を取得
      Dim invalidChars As Char() = System.IO.Path.GetInvalidFileNameChars()

      '使用禁止文字を置換
      For Each c As Char In invalidChars
        newFilename = newFilename.Replace(c, toChar)
      Next

      '追加の文字
      newFilename = newFilename.Replace("&", toChar)
      newFilename = newFilename.Replace(" ", toChar)
      newFilename = newFilename.Replace("?", toChar)
      newFilename = newFilename.Replace("+", toChar)
      newFilename = newFilename.Replace("#", toChar)
      newFilename = newFilename.Replace("!", toChar)
      newFilename = newFilename.Replace("%", toChar)

      Return newFilename
    End Function






    ''' <summary>
    ''' ショートカット作成
    ''' </summary>
    ''' <param name="shortcutPath">作成するショートカットのフルパス</param>
    ''' <param name="targetPath">ショートカットのリンク先</param>
    ''' <param name="iocnPath">アイコンのファイル</param>
    ''' <param name="iconIndex">アイコンのインデックス番号</param>
    ''' <param name="workingDirectory">作業フォルダ </param>
    ''' <param name="arguments">コマンドパラメータ 「リンク先」の後ろに付く </param>
    ''' <param name="description">コメント</param>
    ''' <param name="hotkey">ホットキー</param>
    Public Shared Sub CreateShortcut(shortcutPath As String,
                                     targetPath As String,
                                     Optional iocnPath As String = "",
                                     Optional iconIndex As Integer = 0,
                                     Optional workingDirectory As String = "",
                                     Optional arguments As String = "",
                                     Optional description As String = "",
                                     Optional hotkey As String = "")

      'WshShellを作成
      Dim t As Type = Type.GetTypeFromCLSID(New Guid("72C24DD5-D70A-438B-8A42-98424B88AFB8"))
      Dim shell = Activator.CreateInstance(t)


      'WshShortcutを作成
      Dim shortcut = shell.CreateShortcut(shortcutPath)

      'リンク先
      shortcut.TargetPath = targetPath

      'アイコンのパス
      If iocnPath.Equals("") Then
        shortcut.IconLocation = targetPath & "," & iconIndex.ToString()
      Else
        shortcut.IconLocation = iocnPath & "," & iconIndex.ToString()
      End If

      '作業フォルダ 
      If Not workingDirectory.Equals("") Then
        shortcut.WorkingDirectory = workingDirectory
      End If

      'コマンドパラメータ 「リンク先」の後ろに付く 
      If Not arguments.Equals("") Then
        shortcut.Arguments = arguments
      End If

      'ショートカットキー（ホットキー） 
      'ex "Ctrl+Alt+Shift+F12"
      If Not hotkey.Equals("") Then
        shortcut.Hotkey = hotkey
      End If

      '実行時の大きさ 1が通常、3が最大化、7が最小化 
      shortcut.WindowStyle = 1

      'コメント 
      If Not description.Equals("") Then
        shortcut.Description = description
      End If

      'ショートカットを作成
      shortcut.Save()

      '後始末
      System.Runtime.InteropServices.Marshal.FinalReleaseComObject(shortcut)
      System.Runtime.InteropServices.Marshal.FinalReleaseComObject(shell)

    End Sub

    ''' <summary>
    ''' ディレクトリ パスやファイル名を結合して１つのパスにする
    ''' </summary>
    ''' <param name="path1"></param>
    ''' <param name="path2"></param>
    ''' <returns></returns>
    Public Shared Function CombinePath(path1 As String,
                                       path2 As String) As String
      Return My.Computer.FileSystem.CombinePath(AddDirectorySeparator(path1), AddDirectorySeparator(path2))
    End Function

    ''' <summary>
    ''' 自分自身のアプリケーションディレクトリを取得する
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function GetApplicationDirectory() As String
      Return AddDirectorySeparator(My.Application.Info.DirectoryPath)
    End Function


  End Class
End Namespace
