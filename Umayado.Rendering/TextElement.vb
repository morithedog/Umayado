''' <summary>
''' TextElementは特殊な要素なので、他とは少しルールが違うことになる。
''' </summary>
Public Class TextElement
    Inherits Element

    Public Property Text As String

    Public Overrides Function CanNest(element As Element) As Boolean
        'TextElementには何もネストできない。
        Return False
    End Function

    Public Overrides Function IsOpen(encodedText As String) As Boolean
        'TextElementは他の要素でない場合に開始される。能動的な開始判断は行わない。
        Throw New InvalidOperationException
    End Function

    Public Overrides Function IsClose(encodedText As String) As Boolean

        If Len(encodedText) > 1 Then
            Dim tail = Right(encodedText, 1)

            Select Case tail
                Case ControlChars.Cr
                    Return True
                Case ControlChars.Lf
                    Return True
            End Select
        End If

        Return False

    End Function

    Public Overrides Function IsInline() As Boolean
        Return True
    End Function

    Public Overrides Function Clone() As Object
        Return New TextElement
    End Function

    Public Overrides Sub Close(encodedText As String)
        Me.EncodedText = encodedText
        Me.Text = encodedText
    End Sub
End Class