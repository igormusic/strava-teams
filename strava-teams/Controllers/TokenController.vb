Imports System.Net
Imports System.Web.Configuration
Imports System.Web.Http
Imports Newtonsoft.Json.Linq

Namespace Controllers
    <SessionState(SessionStateBehavior.Required)>
    Public Class TokenController
        Inherits System.Web.Mvc.Controller


        ' GET: api/Token/5
        Public Function Create(<FromUri> ByVal state As String, <FromUri> code As String) As RedirectToRouteResult

            Dim client_id = WebConfigurationManager.AppSettings("client_id")
            Dim client_secret = WebConfigurationManager.AppSettings("client_secret")

            Dim client = New WebClient()
            Dim requestParams = New NameValueCollection()
            requestParams.Add("client_id", client_id)
            requestParams.Add("client_secret", client_secret)
            requestParams.Add("code", code)
            Dim responseBody = client.UploadValues("https://www.strava.com/oauth/token", "POST", requestParams)
            Dim responseText = Encoding.UTF8.GetString(responseBody)
            Dim token = JObject.Parse(responseText)

            HttpContext.Session("token") = token

            Return Me.RedirectToAction("index", "Home")
        End Function

    End Class
End Namespace