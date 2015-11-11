''' <summary>
''' 設定ファイルリスト
''' </summary>
Public Class ServerList
  Inherits List(Of ServerInfo)

  ''' <summary>
  ''' サーバー用設定ファイル
  ''' </summary>
  Public Class ServerInfo
    ''' <summary>
    ''' New
    ''' </summary>
    Public Sub New(serverName As String, settingConfigUrl As String)
      Me.ServerName = serverName
      Me.SettingConfigUrl = settingConfigUrl
    End Sub

    ''' <summary>
    ''' サーバー名
    ''' </summary>
    ''' <returns></returns>
    Public Property ServerName As String = ""


    ''' <summary>
    ''' 設定ファイルのURL
    ''' </summary>
    ''' <returns></returns>
    Public Property SettingConfigUrl As String = ""


    ''' <summary>
    ''' 設定ファイルのPath(exeと同じ場所のローカル読み込み)
    ''' </summary>
    ''' <returns></returns>
    Public Property SettingConfigFilename As String = ""


    ''' <summary>
    ''' サーバー表示名
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property ServerDisplayName As String
      Get
        Return Me.ServerName
        'Return Me.ServerName & " (" & Me.SettingConfigUrl & ")"
      End Get
    End Property




  End Class


  ''' <summary>
  ''' 設定情報取得
  ''' </summary>
  ''' <param name="serverListFilename">サーバーリスト設定ファイル名</param>
  ''' <return>List(Of ModInfo)</return>
  Public Sub GetServerList(serverListFilename As String)


    Try
      '設定ファイルを開いて解析する
      Using sr As New System.IO.StreamReader(serverListFilename,
                                             System.Text.Encoding.UTF8)

        Dim serverInfo As ServerInfo = Nothing

        '内容を一行ずつ読み込む
        While sr.Peek() > -1
          Dim line As String = sr.ReadLine()

          ';以降を取り除く
          With Nothing
            Dim r As New System.Text.RegularExpressions.Regex(";.*")
            line = r.Replace(line, "")
          End With

          '先頭と最後の空白を取り除く
          line = line.Trim()

          If line.Equals("") Then
            Continue While
          End If


          '解析
          If True Then
            Dim r As New System.Text.RegularExpressions.Regex("^ServerName\s*=\s*(.+)",
                                                              System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            Dim m As System.Text.RegularExpressions.Match = r.Match(line)
            If m.Success Then
              serverInfo = New ServerInfo("", "")
              serverInfo.ServerName = m.Groups(1).ToString()
            End If
          End If

          If Not IsNothing(serverInfo) AndAlso Not serverInfo.ServerName.Equals("") Then
            Dim r As New System.Text.RegularExpressions.Regex("^URL\s*=\s*(.+)",
                                                              System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            Dim m As System.Text.RegularExpressions.Match = r.Match(line)
            If m.Success Then
              serverInfo.SettingConfigUrl = m.Groups(1).ToString()
              serverInfo.SettingConfigFilename = ""
              Me.Add(serverInfo)
              serverInfo = Nothing
            End If
          End If

          If Not IsNothing(serverInfo) AndAlso Not serverInfo.ServerName.Equals("") Then
            Dim r As New System.Text.RegularExpressions.Regex("^FILE\s*=\s*(.+)",
                                                              System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            Dim m As System.Text.RegularExpressions.Match = r.Match(line)
            If m.Success Then
              serverInfo.SettingConfigFilename = m.Groups(1).ToString()
              serverInfo.SettingConfigUrl = ""
              Me.Add(serverInfo)
              serverInfo = Nothing
            End If
          End If


        End While
        '閉じる
        sr.Close()
      End Using


    Catch ex As Exception
      Throw
    End Try

  End Sub


End Class
