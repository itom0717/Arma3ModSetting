''' <summary>
''' 各Modの設定
''' </summary>
Public Class ModSetting

  ''' <summary>
  ''' MOD名
  ''' </summary>
  ''' <returns></returns>
  Public Property ModName As String = ""

  ''' <summary>
  ''' optionalフォルダ名
  ''' </summary>
  ''' <returns></returns>
  Public Property OptionalsPath As String = "optionals"

  ''' <summary>
  ''' 追加ファイル
  ''' </summary>
  ''' <returns></returns>
  Public Property AddFile As New List(Of String)

  ''' <summary>
  ''' 削除ファイル
  ''' </summary>
  ''' <returns></returns>
  Public Property DelFile As New List(Of String)








End Class
