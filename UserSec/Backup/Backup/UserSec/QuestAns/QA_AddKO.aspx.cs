using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserSecBE;
using UserSecBAL;

namespace UserSec.QuestAns
{
    public partial class QA_AddKO : System.Web.UI.Page
    {
        CommonBAL commonBAL = new CommonBAL();
        UserBE LoggedInUser = new UserBE();
        LoggedIn LIPg = new LoggedIn();
        string thisPageName = "~/QuestAns/QA_AddKO.aspx";

        protected void Page_Load(object sender, EventArgs e)
        {
            LoggedInUser = (UserBE)Session["LoggedInUser"];

            if (LoggedInUser == null)
            {
                // return to login page because user has not loggedin or session has timedout...
                Response.Redirect("~/Login.aspx");
            }
            if (!commonBAL.isPageAccessibleToUser(LoggedInUser.UserId, thisPageName))
            {
                LoggedIn master = (LoggedIn)this.Master;
                string msg = Request.QueryString["Message"];
                Server.Transfer("LoggedInHome.aspx?Message=You are not authorised to access this page. Please contact system administrator."); //?? Message through Query String
                return;

            }
            else
            {
                if (!IsPostBack)
                {
                    setBreadCrumb();
                }
            }
        }

        protected void setBreadCrumb()
        {
            LoggedIn li = (LoggedIn)this.Master;
            li.setBreadCrumb(1, "References", "");
            li.setBreadCrumb(2, "Add Reference", "QA_AddKO.aspx");
        }

        private bool ValidData()
        {
            LoggedIn master = (LoggedIn)this.Master;
            if (txtSubject.Text.Trim() == "" || txtDelDesc.Text.Trim() == "" || txtKOText.Text.Trim() == "" ||
                txtNote.Text.Trim() == "" || txtShortDesc.Text.Trim() == "" || txtTag.Text.Trim() == "")
            {
                master.ShowMessage("Every field must be filled",false);
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            LoggedIn master = (LoggedIn)this.Master;
            QuestAnsBE Ko = new QuestAnsBE();
            QuestAnsBAL KoBAL = new QuestAnsBAL();
            if (ValidData())
            {
                return;
            }

            Ko.Subject = txtSubject.Text;
            Ko.Tag = txtTag.Text;
            Ko.ShortDesc = txtShortDesc.Text;
            Ko.DelDesc = txtDelDesc.Text.Replace(Environment.NewLine,"<br/>");
            Ko.Note = txtNote.Text.Replace(Environment.NewLine, "<br/>");
            Ko.KOText = txtKOText.Text;
            Ko.KOType = ddlKOType.SelectedItem.Text;
            Ko.LastModifiedBy = ((UserBE)Session["LoggedInUser"]).UserId;

            if (KoBAL.AddKO(Ko))
            {
                foreach (Control txt in divAddKO.Controls)
                {
                    if (txt is TextBox)
                        ((TextBox)(txt)).Text = string.Empty;
                    else if (txt is DropDownList)
                        ((DropDownList)(txt)).SelectedIndex = 0;
                }
                master.ShowMessage("Record Added Successfully", true);
            }
            else
            {
                master.ShowMessage("Unsuccessful", false);
            }
        }
    }
}