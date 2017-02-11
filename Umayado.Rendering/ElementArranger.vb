Public Class ElementArranger

    Public Property Elements As New List(Of Element)

    Public Sub New()
        'Elements.Add(New TextElement(""))
        Elements.Add(New H1Element)
    End Sub

    Public Function Generate(encodedText As String) As Element

        Dim result As Element = Nothing

        For Each element In Elements
            If element.IsOpen(encodedText) Then
                result = element
                Exit For
            End If
        Next

        If result Is Nothing Then
            Return Nothing
        End If

        Elements.Remove(result)
        Elements.Add(result.Clone)

        Return result

    End Function

End Class