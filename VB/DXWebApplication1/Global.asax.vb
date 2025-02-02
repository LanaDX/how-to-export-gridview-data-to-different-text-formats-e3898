' Note: For instructions on enabling IIS6 or IIS7 classic mode, 
' visit http://go.microsoft.com/?LinkId=9394802
Imports System.Web.Http

Public Class MvcApplication
    Inherits System.Web.HttpApplication

    Sub Application_Start()
        AreaRegistration.RegisterAllAreas()
   
        WebApiConfig.Register(GlobalConfiguration.Configuration)
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        AuthConfig.RegisterAuth()
        
        ModelBinders.Binders.DefaultBinder = new DevExpress.Web.Mvc.DevExpressEditorsBinder()

        AddHandler DevExpress.Web.ASPxWebControl.CallbackError, AddressOf Application_Error
    End Sub

    Protected Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        Dim exception As Exception = System.Web.HttpContext.Current.Server.GetLastError()
        'TODO: Handle Exception
    End Sub
End Class