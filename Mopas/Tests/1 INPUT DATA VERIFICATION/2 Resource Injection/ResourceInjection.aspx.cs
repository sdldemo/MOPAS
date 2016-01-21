using System;
using System.IO;

namespace Mopas.Tests
{
    public partial class ResourceInjection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string fileName = Request.Params["report"];

            if (fileName != null)
            {
                // TODO: AI issue #2, High, Arbitrary File Deletion, https://github.com/sdldemo/MOPAS/issues/2
                // GET /Tests/1 INPUT DATA VERIFICATION/2 Resource Injection/ResourceInjection.aspx?report=Default.aspx HTTP/1.1
                // Host:localhost
                File.Delete("D:\\AI\\Reports\\" + fileName);
            }
        }
    }
}