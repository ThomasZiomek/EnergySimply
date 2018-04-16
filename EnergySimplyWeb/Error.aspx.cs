using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EnergySimplyWeb
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // TODO: Fix this!
            Exception ex = Server.GetLastError();
            lblErrorMessage.Text = ex?.Message ?? "Error details not available.";
            Server.ClearError();
        }

    }
}