using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DOANTD
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas(); // Đăng ký các area
            RouteConfig.RegisterRoutes(RouteTable.Routes); // Đăng ký routing
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            // Mã chạy khi phiên mới bắt đầu
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            // Mã chạy khi bắt đầu yêu cầu
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            // Mã chạy khi xác thực yêu cầu
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            // Xử lý lỗi
        }

        protected void Session_End(object sender, EventArgs e)
        {
            // Mã chạy khi phiên kết thúc
        }

        protected void Application_End(object sender, EventArgs e)
        {
            // Mã chạy khi ứng dụng kết thúc
        }
    }
}