'namespace Common
Namespace Common


  ''' <summary>
  ''' Hashtable拡張クラス
  ''' </summary>
  ''' <remarks></remarks>
  Public Class HashtableEx
    Inherits Hashtable

    ''' <summary>
    ''' 値を返す
    ''' </summary>
    ''' <param name="key"></param>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>Keyが存在しない場合は ""(長さゼロの文字列)を返す</remarks>
    Default Public Overloads Property [Item](key As String) As Object
      Get
        If key.Equals("") Then
          'keyが空白の場合は空白を返す
          Return ""
        End If
        If Me.ContainsKey(key) Then
          '存在した場合は値を返す


          Return MyBase.Item(key)
        Else
          'keyの値がない場合は空白を返す()
          Return ""
        End If

      End Get
      Set(value As Object)

        If Not key.Equals("") Then
          If Me.ContainsKey(key) Then
            '一旦消す
            Me.Remove(key)
          End If
          Me.Add(key, value)
        End If

      End Set
    End Property

  End Class

End Namespace
