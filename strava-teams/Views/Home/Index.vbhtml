<div class="jumbotron">
    <h1>Strava Teams</h1>
    <p class="lead">Strava Teams is application that allows you to create team runs and manage run leaderboards</p>
</div>
<div Class="row">
    @Code

        Dim host = HttpContext.Current.Request.Url.Host

        If HttpContext.Current.Request.Url.Port <> 80 Then
            host += ":" + HttpContext.Current.Request.Url.Port.ToString()
        End If

        Dim client_id = System.Web.Configuration.WebConfigurationManager.AppSettings("client_id")
        Dim token = HttpContext.Current.Session("token")

    End Code

    @If (token Is Nothing) Then
        @<p><a href="https://www.strava.com/oauth/authorize?client_id=@client_id&response_type=code&redirect_uri=http://@host/token/create&approval_prompt=force&state=login" Class="btn btn-primary btn-lg">Login To Strava</a></p>
    Else
        @<p>@token</p>
    End If
</div>
