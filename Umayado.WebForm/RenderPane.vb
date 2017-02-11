Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Text
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls


<DefaultProperty("Text"), ToolboxData("<{0}:RenderPane runat=server></{0}:RenderPane>")> _
Public Class RenderPane
    Inherits WebControl

    Public Sub New()
        MyBase.New("div")
    End Sub

    '<Bindable(True), Category("Appearance"), DefaultValue(""), Localizable(True)>
    'Property Html() As String
    '    Get
    '        Dim s As String = CStr(ViewState("Text"))
    '        If s Is Nothing Then
    '            Return String.Empty
    '        Else
    '            Return s
    '        End If
    '    End Get

    '    Set(ByVal Value As String)
    '        ViewState("Text") = Value
    '    End Set
    'End Property

    Protected Overrides Sub RenderContents(ByVal writer As HtmlTextWriter)
        Dim html As String = Me.GenerateHtml
        'Context.Server.HtmlEncode(html)
        writer.Write(html)
    End Sub

    Public Overridable Function GenerateHtml() As String

        Return "<h1>Hello!</h1><div>test</div>"

    End Function

    'Public Overrides Sub RenderBeginTag(writer As HtmlTextWriter)
    '    'Dim tag As New HtmlTextWriterTag


    '    'writer.RenderBeginTag(HtmlTextWriterTag.Div)
    '    'writer.AddAttribute("id", "RenderPane")
    '    'writer.AddAttribute("class", "RenderPage")
    '    'writer.RenderEndTag()
    '    'Me.TagKey = HtmlTextWriterTag.Div
    '    'MyBase.RenderBeginTag(writer)
    'End Sub
End Class
