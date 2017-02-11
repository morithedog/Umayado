Public MustInherit Class Element
    Implements ICloneable

    'Public Property Type As ElementType
    Public Property EncodedText As String

    Public Property ChildElements As New List(Of Element)

    Public Property OpenPosition As Integer

    Public MustOverride Function CanNest(element As Element) As Boolean

    Public MustOverride Function IsOpen(encodedText As String) As Boolean


    Public MustOverride Function IsClose(encodedText As String) As Boolean

    Public MustOverride Function IsInline() As Boolean

    Public MustOverride Function Clone() As Object Implements ICloneable.Clone

    Public MustOverride Sub Close(encodedText As String)

End Class