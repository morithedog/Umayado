Imports Umayado.Rendering

Public Class Engine

    Public Function Analyse(encodedText As String) As List(Of Element)

        Dim result As New List(Of Element)
        Dim reader As New IO.StringReader(encodedText)

        Dim codePoint As Char
        Dim bufferedText As String = ""
        Dim currentElement As Element = Nothing
        Dim arranger As New ElementArranger

        Do
            Dim readResult As Integer = reader.Read

            '文末
            If readResult = -1 Then
                If currentElement Is Nothing Then
                    If Len(bufferedText) > 0 Then
                        Dim text As New TextElement
                        text.Close(bufferedText)
                        result.Add(text)
                    End If
                Else
                    currentElement.Close(bufferedText)
                    result.Add(currentElement)
                End If

                Return result
            End If

            'StringReaderはサロゲートペアに対応しておらずUnicodeコードポイントを返す模様。
            codePoint = ChrW(readResult)

            '▼改行
            If codePoint = ControlChars.Cr OrElse codePoint = ControlChars.Lf Then
                If Len(bufferedText) > 0 Then
                    Dim text As New TextElement()
                    text.Close(bufferedText)
                    result.Add(text)

                    bufferedText = ""

                End If

                Continue Do
            End If

            bufferedText &= Convert.ToChar(codePoint)

            If currentElement Is Nothing Then
                '●ObjectElementの開始であるかの判定
                currentElement = arranger.Generate(bufferedText)

                If currentElement IsNot Nothing Then
                    If currentElement.OpenPosition > 0 Then
                        Dim text As New TextElement()
                        text.Close(Left(bufferedText, currentElement.OpenPosition))
                        result.Add(text)

                        bufferedText = bufferedText.Substring(currentElement.OpenPosition)
                    End If
                End If

            ElseIf currentElement IsNot Nothing Then
                '●ObjectElementの終了であるかの判定
                If currentElement.IsClose(bufferedText) Then
                    currentElement.Close(bufferedText)
                    result.Add(currentElement)
                    currentElement = Nothing
                    bufferedText = ""
                End If

            End If

        Loop

    End Function

End Class