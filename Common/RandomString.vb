'namespace Common
Namespace Common

  ''' <summary>
  ''' ランダムな文字列の生成
  ''' </summary>
  Public Class RandomString


    ''' <summary>
    ''' ランダムな文字列の生成(数字のみ)
    ''' </summary>
    ''' <param name="keyLen">文字数</param>
    ''' <returns>ランダムな文字列（0～9の組み合わせ）</returns>
    Public Shared Function CreateRandomStringNumOnly(ByVal keyLen As Integer) As String

      '指定の文字数になるまでランダムな文字を生成
      Dim key As String = ""
      Do Until Len(key) >= keyLen
        'ランダムな文字を生成
        Dim keyChar As String = Chr(RollDice(122 - 47) + 47)
        '数字・英字の範囲かチェック
        Select Case keyChar
          Case "0" To "9"
            key &= keyChar
        End Select
      Loop

      Return key
    End Function


    ''' <summary>
    ''' ランダムな文字列の生成
    ''' </summary>
    ''' <param name="keyLen">文字数</param>
    ''' <returns>ランダムな文字列（0～9、A～Z、a～zの組み合わせ）</returns>
    Public Shared Function CreateRandomString(ByVal keyLen As Integer) As String

      '指定の文字数になるまでランダムな文字を生成
      Dim key As String = ""
      Do Until Len(key) >= keyLen
        'ランダムな文字を生成
        Dim keyChar As String = Chr(RollDice(122 - 47) + 47)
        '数字・英字の範囲かチェック
        Select Case keyChar
          Case "0" To "9", "A" To "Z", "a" To "z"
            key &= keyChar
        End Select
      Loop

      Return key
    End Function

    ''' <summary>
    ''' 暗号サービス プロバイダの暗号乱数ジェネレータを使っての乱数の生成（MSのヘルプから引用）
    ''' </summary>
    ''' <param name="NumSides">出力値の最大値</param>
    ''' <returns>乱数（1～指定した最大値）</returns>
    Private Shared Function RollDice(ByVal NumSides As Integer) As Integer
      ' Create a byte array to hold the random value.
      Dim randomNumber(0) As Byte

      ' Create a new instance of the RNGCryptoServiceProvider. 
      Dim Gen As New System.Security.Cryptography.RNGCryptoServiceProvider()

      ' Fill the array with a random value.
      Gen.GetBytes(randomNumber)

      ' Convert the byte to an integer value to make the modulus operation easier.
      Dim rand As Integer = Convert.ToInt32(randomNumber(0))

      ' Return the random number mod the number
      ' of sides.  The possible values are zero-
      ' based, so we add one.
      Return rand Mod NumSides + 1
    End Function 'RollDice


  End Class


End Namespace
