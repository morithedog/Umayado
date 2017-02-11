Public Class TestController
    Inherits System.Web.Mvc.Controller

    Function Article() As ActionResult
        ViewData("Title") = "テストタイトル"
        '      Public Property Body As Integer
        'Public Property CreationDate As Date

        ViewData("Body") = "テスト本文"
        ViewData("CreationDate") = #2017/2/11#


        Return View()
    End Function

    'Function About() As ActionResult
    '    ViewData("Message") = "Your application description page."

    '    Return View()
    'End Function

    'Function Contact() As ActionResult
    '    ViewData("Message") = "Your contact page."

    '    Return View()
    'End Function
End Class
