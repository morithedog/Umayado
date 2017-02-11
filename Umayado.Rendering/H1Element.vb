Public Class H1Element
    Inherits Element

    'Public Const OpenTag = "=="
    'Public Const EndTag = "=="

    Public Overrides Function CanNest(element As Element) As Boolean

        If element.IsInline Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Overrides Function IsOpen(encodedText As String) As Boolean

        Const BeginingTagLength As Integer = 2

        If Len(encodedText) > BeginingTagLength Then
            Dim head As String = encodedText.Substring(encodedText.Length - BeginingTagLength - 1, BeginingTagLength)
            Dim tail As String = Right(encodedText, 1)

            If head = "==" AndAlso tail <> "=" Then
                Me.OpenPosition = Len(encodedText) - BeginingTagLength - 1
                Return True
            End If
        End If

        Return False

    End Function

    Public Overrides Function IsClose(encodedText As String) As Boolean

        ''最低５文字あるはず ==A==。文字数チェックしないと「==」だけで開いて閉じたことになってしまう
        'If Len(encodedText) >= 5 Then

        'End If

        If encodedText.EndsWith("==") Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Overrides Function IsInline() As Boolean
        Return False
    End Function

    Public Overrides Function Clone() As Object
        Return New H1Element
    End Function

    Public Overrides Sub Close(encodedText As String)

        Me.EncodedText = encodedText

        Dim innerText As String
        '先頭の == と末尾の == をのぞいた中身をinnerTextに設定
        innerText = encodedText.Substring(2, encodedText.Length - 4)

        'TODO:ここでEngineをインスタンスかするのは効率が悪い。
        Dim engine As New Engine
        Dim elements = engine.Analyse(innerText)

        If elements.Count > 0 Then
            Me.ChildElements = elements
        End If
    End Sub
End Class