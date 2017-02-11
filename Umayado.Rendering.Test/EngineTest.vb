Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()>
Public Class EngineTest

    <TestMethod()>
    Public Sub Textが1つ()

        Dim target As New Engine
        Dim result = target.Analyse("ABC")

        Assert.AreEqual(1, result.Count, "A1000")
        Assert.IsInstanceOfType(result(0), GetType(TextElement), "A2000")

        Dim element As TextElement = result(0)
        Assert.AreEqual("ABC", element.Text, "A3000")

    End Sub

    <TestMethod()>
    Public Sub Textが2つ()

        Dim target As New Engine
        Dim result = target.Analyse("ABC" & vbNewLine & "あいう")

        Assert.AreEqual(2, result.Count, "A1000")

        Assert.IsInstanceOfType(result(0), GetType(TextElement), "A2000")
        Dim element As TextElement = result(0)
        Assert.AreEqual("ABC", element.Text, "A3000")

        Assert.IsInstanceOfType(result(1), GetType(TextElement), "A4000")
        element = result(1)
        Assert.AreEqual("あいう", element.Text, "A5000")

    End Sub

    <TestMethod>
    Public Sub H1が1つ()

        Dim target As New Engine
        Dim result = target.Analyse("==タイトル==")

        Assert.AreEqual(1, result.Count, "A1000")
        Assert.IsInstanceOfType(result(0), GetType(H1Element), "A2000")

        Dim h1 As H1Element = result(0)
        Assert.AreEqual(1, h1.ChildElements.Count, "A3000")

        Assert.IsInstanceOfType(h1.ChildElements(0), GetType(TextElement))
        Dim text As TextElement = h1.ChildElements(0)
        Assert.AreEqual("タイトル", text.Text, "A4000")

    End Sub

    <TestMethod>
    Public Sub H1とTextが改行なしで連続()
        Dim target As New Engine
        Dim result = target.Analyse("== We are happy ==本文です。")

        Assert.AreEqual(2, result.Count, "A1000")
        Assert.IsInstanceOfType(result(0), GetType(H1Element), "A2000")

        Dim h1 As H1Element = result(0)
        Assert.AreEqual(1, h1.ChildElements.Count, "A3000")

        Assert.IsInstanceOfType(h1.ChildElements(0), GetType(TextElement))
        Dim text As TextElement = h1.ChildElements(0)
        Assert.AreEqual(" We are happy ", text.Text, "A4000")

        text = result(1)
        Assert.AreEqual("本文です。", text.Text, "A5000")

    End Sub

    <TestMethod>
    Public Sub H1とTextが改行付きで連続()
        Dim target As New Engine
        Dim result = target.Analyse("== We are happy ==" & vbNewLine & "本文です。")

        Assert.AreEqual(2, result.Count, "A1000")
        Assert.IsInstanceOfType(result(0), GetType(H1Element), "A2000")

        Dim h1 As H1Element = result(0)
        Assert.AreEqual(1, h1.ChildElements.Count, "A3000")

        Assert.IsInstanceOfType(h1.ChildElements(0), GetType(TextElement))
        Dim text As TextElement = h1.ChildElements(0)
        Assert.AreEqual(" We are happy ", text.Text, "A4000")

        text = result(1)
        Assert.AreEqual("本文です。", text.Text, "A5000")
    End Sub

    <TestMethod>
    Public Sub TextとH1が改行なしで連続()
        Dim target As New Engine
        Dim result = target.Analyse("今度はTextが先行する== We are so happy ==")

        Assert.AreEqual(2, result.Count, "A1000")

        Assert.IsInstanceOfType(result(0), GetType(TextElement))
        Dim textA As TextElement = result(0)
        Assert.AreEqual("今度はTextが先行する", textA.Text, "A4000")


        Assert.IsInstanceOfType(result(1), GetType(H1Element), "A2000")
        Dim h1 As H1Element = result(1)
        Assert.AreEqual(1, h1.ChildElements.Count, "A3000")

        Assert.IsInstanceOfType(h1.ChildElements(0), GetType(TextElement), "A2000")
        Dim textB As TextElement = h1.ChildElements(0)
        Assert.AreEqual(" We are so happy ", textB.Text, "A5000")

    End Sub

    <TestMethod>
    Public Sub H1とText改行Text()

        Dim target As New Engine
        Dim result = target.Analyse("==あいうえお==１行目です" & vbNewLine & "２行目です。")

        Assert.AreEqual(3, result.Count, "A1000")
        Assert.IsInstanceOfType(result(0), GetType(H1Element), "A2000")

        Dim h1 As H1Element = result(0)
        Assert.AreEqual(1, h1.ChildElements.Count, "A3000")

        Assert.IsInstanceOfType(h1.ChildElements(0), GetType(TextElement))
        Dim text As TextElement = h1.ChildElements(0)
        Assert.AreEqual("あいうえお", text.Text, "A4000")

        text = result(1)
        Assert.AreEqual("１行目です", text.Text, "A5000")

        text = result(2)
        Assert.AreEqual("２行目です。", text.Text, "A6000")
    End Sub

    <TestMethod>
    Public Sub H1が2つ()
        Dim target As New Engine
        Dim result = target.Analyse("==あいうえお====Second level1 header==")

        Assert.AreEqual(2, result.Count, "A1000")

        Assert.IsInstanceOfType(result(0), GetType(H1Element), "A2000")
        Dim h1A As H1Element = result(0)
        Assert.AreEqual(1, h1A.ChildElements.Count, "A3000")

        Assert.IsInstanceOfType(h1A.ChildElements(0), GetType(TextElement))
        Dim textA As TextElement = h1A.ChildElements(0)
        Assert.AreEqual("あいうえお", textA.Text, "A4000")


        Assert.IsInstanceOfType(result(1), GetType(H1Element), "A5000")
        Dim h1B As H1Element = result(1)
        Assert.AreEqual(1, h1B.ChildElements.Count, "A6000")

        Assert.IsInstanceOfType(h1B.ChildElements(0), GetType(TextElement))
        Dim textB As TextElement = h1B.ChildElements(0)
        Assert.AreEqual("Second level1 header", textB.Text, "A7000")
    End Sub

    <TestMethod>
    Public Sub H1が改行をはさんで2つ()
        Dim target As New Engine
        Dim result = target.Analyse("==あいうえお==" & vbNewLine & "==Second level1 header==")

        Assert.AreEqual(2, result.Count, "A1000")

        Assert.IsInstanceOfType(result(0), GetType(H1Element), "A2000")
        Dim h1A As H1Element = result(0)
        Assert.AreEqual(1, h1A.ChildElements.Count, "A3000")

        Assert.IsInstanceOfType(h1A.ChildElements(0), GetType(TextElement))
        Dim textA As TextElement = h1A.ChildElements(0)
        Assert.AreEqual("あいうえお", textA.Text, "A4000")


        Assert.IsInstanceOfType(result(1), GetType(H1Element), "A5000")
        Dim h1B As H1Element = result(1)
        Assert.AreEqual(1, h1B.ChildElements.Count, "A6000")

        Assert.IsInstanceOfType(h1B.ChildElements(0), GetType(TextElement))
        Dim textB As TextElement = h1B.ChildElements(0)
        Assert.AreEqual("Second level1 header", textB.Text, "A7000")


    End Sub

    <TestMethod>
    Public Sub 未整理()

        Dim target As New Engine
        Dim result = target.Analyse("===あいうえお===")

        result = target.Analyse("こんにちは==タイトル==です。")
        'result = target.Analyse

        'ネスト
        '多段階ネスト

    End Sub
End Class