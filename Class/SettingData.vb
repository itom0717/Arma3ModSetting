''' <summary>
''' 設定データ
''' </summary>
Public Class SettingData

    ''' <summary>
    ''' ModSetting List
    ''' </summary>
    ''' <returns></returns>
    Public Property ModSettingList As New List(Of ModSetting)


    ''' <summary>
    ''' New
    ''' </summary>
    Public Sub New(settingFilename As String)
        'ModSetting
        Dim modSetting As ModSetting = Nothing

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
                'MOD名
                With Nothing
                    Dim r As New System.Text.RegularExpressions.Regex("^\[(.+)\]$")
                    Dim m As System.Text.RegularExpressions.Match = r.Match(line)
                    If m.Success Then
                        modSetting = New ModSetting
                        ModSettingList.Add(modSetting)

                        modSetting.ModName = m.Groups(1).ToString()
                    End If
                End With

                'MODが出てきてなkれば次の行へ
                If IsNothing(modSetting) Then
                    Continue While
                End If

                'optional を解析
                With Nothing
                    Dim r As New System.Text.RegularExpressions.Regex("^optionalsPath\s*=\s*(.+)", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                    Dim m As System.Text.RegularExpressions.Match = r.Match(line)
                    If m.Success Then
                        modSetting.OptionalsPath = m.Groups(1).ToString()
                    End If
                End With

                '追加するファイルを解析
                With Nothing
                    Dim r As New System.Text.RegularExpressions.Regex("^add\s*(.+)", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                    Dim m As System.Text.RegularExpressions.Match = r.Match(line)
                    If m.Success Then
                        modSetting.AddFile.Add(m.Groups(1).ToString())
                    End If
                End With


                '削除するファイルを解析
                With Nothing
                    Dim r As New System.Text.RegularExpressions.Regex("^del\s*(.+)", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
                    Dim m As System.Text.RegularExpressions.Match = r.Match(line)
                    If m.Success Then
                        modSetting.DelFile.Add(m.Groups(1).ToString())
                    End If
                End With

            End While
            '閉じる
            sr.Close()
        End Using

    End Sub
End Class
