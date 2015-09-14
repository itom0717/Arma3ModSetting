''' <summary>
''' 設定データ
''' </summary>
Public Class SettingData

  ''' <summary>
  ''' Server情報
  ''' </summary>
  ''' <returns></returns>
  Public Property ServerInfo As String = ""


  ''' <summary>
  ''' 設定情報取得
  ''' </summary>
  ''' <param name="settingFilename">設定ファイル名</param>
  ''' <return>List(Of ModInfo)</return>
  Public Function GetSetting(settingFilename As String) As List(Of ModInfo)

    Dim modsInfo As New List(Of ModInfo)
    Dim modInfo As ModInfo = Nothing

    Try


      '設定ファイルを開いて解析する
      Using sr As New System.IO.StreamReader(settingFilename,
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

          '解析
          'ServerInfo
          'ServerInfo
          With Nothing
            Dim r As New System.Text.RegularExpressions.Regex("^ServerInfo\s*=\s*(.+)",
                                                              System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            Dim m As System.Text.RegularExpressions.Match = r.Match(line)
            If m.Success Then
              Me.ServerInfo = m.Groups(1).ToString()
            End If
          End With



          'MOD名
          With Nothing
            Dim r As New System.Text.RegularExpressions.Regex("^\[(.+)\]$")
            Dim m As System.Text.RegularExpressions.Match = r.Match(line)
            If m.Success Then
              modInfo = New ModInfo
              modsInfo.Add(modInfo)

              modInfo.ModSetting.ModName = m.Groups(1).ToString()
            End If
          End With

          'MODが出てきてなければ次の行へ
          If IsNothing(modInfo) Then
            Continue While
          End If

          'optional を解析
          With Nothing
            Dim r As New System.Text.RegularExpressions.Regex("^optionalsPath\s*=\s*(.+)",
                                                              System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            Dim m As System.Text.RegularExpressions.Match = r.Match(line)
            If m.Success Then
              modInfo.ModSetting.OptionalsPath = m.Groups(1).ToString()
            End If
          End With

          '追加するファイルを解析
          With Nothing
            Dim r As New System.Text.RegularExpressions.Regex("^add\s*(.+)",
                                                              System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            Dim m As System.Text.RegularExpressions.Match = r.Match(line)
            If m.Success Then
              modInfo.ModSetting.AddFile.Add(m.Groups(1).ToString())
            End If
          End With


          '削除するファイルを解析
          With Nothing
            Dim r As New System.Text.RegularExpressions.Regex("^del\s*(.+)",
                                                              System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            Dim m As System.Text.RegularExpressions.Match = r.Match(line)
            If m.Success Then
              modInfo.ModSetting.DelFile.Add(m.Groups(1).ToString())
            End If
          End With

        End While
        '閉じる
        sr.Close()
      End Using

      Return modsInfo

    Catch ex As Exception
      Throw
    End Try

  End Function

End Class
