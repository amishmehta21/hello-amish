﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using UserSecBAL;
using System.Data;
using System.Diagnostics;

namespace UserSec
{
    public class UM_Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
           
            //CompanySetupBAL setupBAL = new CompanySetupBAL();
            //DataTable dtEmailCredentials = new DataTable();

            //if (setupBAL.GetEmailCredentials(ref dtEmailCredentials))
            //{
            //    Session["ComapnySetup"] = dtEmailCredentials;
            //}
            
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            Response.Redirect("/Login.aspx");
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}