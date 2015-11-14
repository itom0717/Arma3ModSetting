''' <summary>
''' 設定ファイルリストDL処理
''' </summary>
Public Class ServerListUrl

  ''' <summary>
  ''' 設定情報DL
  ''' </summary>
  ''' <param name="serverListUrlConfigFilename">サーバーリストDL先の設定ファイル名</param>
  ''' <param name="serverListFilename">DLしたファイル名につけるサーバーリスト設定ファイル名</param>
  ''' <return>List(Of ModInfo)</return>
  Public Sub DownloadServerList(serverListUrlConfigFilename As String,
                                serverListFilename As String)

    Try
      Dim downloadUrl As String = ""

      '設定ファイルを開いて解析する
      Using sr As New System.IO.StreamReader(serverListUrlConfigFilename,
                                             System.Text.Encoding.UTF8)

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


          With Nothing
            Dim r As New System.Text.RegularExpressions.Regex("^URL\s*=\s*(.+)",
                                                            System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            Dim m As System.Text.RegularExpressions.Match = r.Match(line)
            If m.Success Then
              downloadUrl = m.Groups(1).ToString()
              Exit While
            End If
          End With


        End While
        '閉じる
        sr.Close()
      End Using

      If downloadUrl.Equals("") Then
        Throw New Exception(My.Resources.TextResource.ErrMsgSettingFilesNotDownload)
      End If

      'ファイルダウンロード
      Dim wc As New System.Net.WebClient()
      wc.DownloadFile(downloadUrl, serverListFilename)
      wc.Dispose()

      If Not Common.File.ExistsFile(serverListFilename) Then
        Throw New Exception(My.Resources.TextResource.ErrMsgSettingFilesNotDownload)
      End If

    Catch ex As Exception
      Throw
    End Try

  End Sub


End Class
