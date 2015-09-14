''' <summary>
''' MOD情報
''' </summary>
Public Class ModInfo

  ''' <summary>
  ''' Mod設定情報
  ''' </summary>
  ''' <returns></returns>
  Public Property ModSetting As New ModSetting

  ''' <summary>
  ''' MODのフルパス
  ''' </summary>
  ''' <returns></returns>
  Public Property ModPath As String = ""



  ''' <summary>
  ''' 各フォルダの情報
  ''' </summary>
  Public Class PathInfo

    ''' <summary>
    ''' 絶対パス
    ''' </summary>
    ''' <returns></returns>
    Public Property Path As String = ""

    ''' <summary>
    ''' パス内の*.pbo
    ''' </summary>
    ''' <returns></returns>
    Public Property PboFiles As List(Of String)

    ''' <summary>
    ''' 各フォルダのPBOファイルを調査
    ''' </summary>
    Public Sub SearchPboFile()
      'ファイル一覧取得
      Me.PboFiles = Common.File.GetFileList(Me.Path, "*.pbo", False)
    End Sub


    ''' <summary>
    ''' PBOファイルがフォルダ内に存在するか調べる
    ''' </summary>
    ''' <param name="pboFile"></param>
    ''' <returns></returns>
    Public Function ExistsPbo(pboFile As String) As Boolean
      Dim returnValue As Boolean = False

      For Each pbo As String In Me.PboFiles
        Dim baseFile As String = Common.File.GetFileName(pbo)
        If baseFile.Equals(pboFile, StringComparison.CurrentCultureIgnoreCase) Then
          '存在する
          returnValue = True
          Exit For
        End If
      Next

      Return returnValue
    End Function

  End Class


  ''' <summary>
  ''' addons パス情報
  ''' </summary>
  ''' <returns></returns>
  Public Property AddonsPathInfo As New PathInfo

  ''' <summary>
  ''' optionals パス情報
  ''' </summary>
  ''' <returns></returns>
  Public Property OptionalPathInfo As New PathInfo

  ''' <summary>
  '''  Disable パス情報
  ''' </summary>
  ''' <returns></returns>
  Public Property DisablePathInfo As New PathInfo


  ''' <summary>
  ''' MOD情報取得
  ''' </summary>
  Public Sub GetModInfo()

    Try

      ' MODのフルパス
      Me.ModPath = Common.File.CombinePath(Common.File.GetApplicationDirectory & "..", Me.ModSetting.ModName)
      If Not Common.File.ExistsDirectory(Me.ModPath) Then
        'パスが見つからない
        Throw New Exception(String.Format(My.Resources.TextResource.ErrMsgNotFoundModPath, Me.ModSetting.ModName))
      End If

      ' addonsのフルパス
      Me.AddonsPathInfo.Path = Common.File.CombinePath(Me.ModPath, "addons")
      If Not Common.File.ExistsDirectory(Me.AddonsPathInfo.Path) Then
        'パスが見つからない
        Throw New Exception(String.Format(My.Resources.TextResource.ErrMsgNotFoundModAddonsPath, Me.ModSetting.ModName))
      End If

      ' addonsのフルパス
      Me.OptionalPathInfo.Path = Common.File.CombinePath(Me.ModPath, Me.ModSetting.OptionalsPath)
      If Not Common.File.ExistsDirectory(Me.OptionalPathInfo.Path) Then
        'パスが見つからない
        Throw New Exception(String.Format(My.Resources.TextResource.ErrMsgNotFoundModOptionalsPath, Me.ModSetting.ModName, Me.ModSetting.OptionalsPath))
      End If

      'Disableパス
      Me.DisablePathInfo.Path = Common.File.CombinePath(Me.ModPath, "_disable")
      If Not Common.File.ExistsDirectory(Me.DisablePathInfo.Path) Then
        'ない場合は作成しておく
        Common.File.CreateDirectory(Me.DisablePathInfo.Path)
      End If

      '各フォルダ内のファイルを調査しておく
      Me.AddonsPathInfo.SearchPboFile()
      Me.OptionalPathInfo.SearchPboFile()
      Me.DisablePathInfo.SearchPboFile()


    Catch ex As Exception
      Throw
    End Try

  End Sub















End Class
