﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserSec.QuestAns
{
    public partial class QA_HowItWorks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

       // btnSignUpNow_Click
        protected void btnSignUpNow_Click(object sender, EventArgs e)
        {
            Response.Redirect("../SignUp.aspx");
        }


    }
}