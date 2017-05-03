Imports System.Net
Imports System.Web.Configuration
Imports System.Web.Http

Namespace Controllers
    Public Class TokenController
        Inherits ApiController

        ' GET: api/Token
        Public Function GetValues() As IEnumerable(Of String)
            Return New String() {"value1", "value2"}
        End Function

        ' GET: api/Token/5
        Public Function GetValue(<FromUri> ByVal state As String, <FromUri> code As String) As String

            Dim client_id = WebConfigurationManager.AppSettings("client_id")
            Dim client_secret = WebConfigurationManager.AppSettings("client_secret")

            Dim client = New WebClient()
            Dim requestParams = New NameValueCollection()
            requestParams.Add("client_id", client_id)
            requestParams.Add("client_secret", client_secret)
            requestParams.Add("code", code)
            Dim responseBody = client.UploadValues("https://www.strava.com/oauth/token", "POST", requestParams)
            Dim responseText = Encoding.UTF8.GetString(responseBody)

        End Function

        ' POST: api/Token
        Public Sub PostValue(<FromBody()> ByVal value As String)



        End Sub

        ' PUT: api/Token/5
        Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

        End Sub

        ' DELETE: api/Token/5
        Public Sub DeleteValue(ByVal id As Integer)

        End Sub
    End Class
End Namespace