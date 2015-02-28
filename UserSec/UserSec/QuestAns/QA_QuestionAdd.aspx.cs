using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserSecBE;
using UserSecBAL;
using System.Data;

namespace UserSec.Quest_Ans
{
    public partial class QA_QuestionAdd : System.Web.UI.Page
    {
        CommonBAL commonBAL = new CommonBAL();
        UserBE LoggedInUser = new UserBE();
        string thisPageName = "~/QuestAns/QA_QuestionAdd.aspx";

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
                //  master.ShowMessage("You are not authorised to access this page. Please contact system administrator.", false);
                //  Server.Transfer("UM_BlankPage.aspx"); //?? send Message through Query String to the BlankPage
                string msg = Request.QueryString["Message"];
                Server.Transfer("LoggedInHome.aspx?Message=You are not authorised to access this page. Please contact system administrator.");
                return;

            }
            else
            {
                if (!IsPostBack)
                {
                    bindSubjectDropDown();
                    bindExpDropDown();
                    bindStudyStreamDropDown();
                    setBreadCrumb();
                }
            }

        }

        public void bindSubjectDropDown()
        {
            QuestAnsBAL QnABAL = new QuestAnsBAL();
            DataTable dt = new DataTable();
            LoggedIn master = (LoggedIn)this.Master;

            if (QnABAL.GetAllSubjects(ref dt))
            {
                ddlSubject.DataSource = dt;
                ddlSubject.DataTextField = "ShortDesc";
                ddlSubject.DataValueField = "SubId";
                ddlSubject.DataBind();
                ddlSubject.Items.Insert(0, new ListItem("-Select-", "-Select-"));

            }
            else
            {
                master.ShowMessage("Unsuccessful", false);
            }
        }

        public void bindExpDropDown()
        {
            QuestAnsBAL QnABAL = new QuestAnsBAL();
            DataTable dt = new DataTable();
            LoggedIn master = (LoggedIn)this.Master;

            if (QnABAL.GetAllExp(ref dt))
            {
                //ddlExp.DataSource = dt;
                //ddlExp.DataTextField = "YrOfExp";
                //ddlExp.DataValueField = "ExpId";
                //ddlExp.DataBind();
                //ddlExp.Items.Insert(0, new ListItem("-Select-", "-Select-"));
            }
            else
            {
                master.ShowMessage("Unsuccessful", false);
            }
        }

        public void bindStudyStreamDropDown()
        {
            QuestAnsBAL QnABAL = new QuestAnsBAL();
            DataTable dt = new DataTable();
            LoggedIn master = (LoggedIn)this.Master;

            if (QnABAL.GetAllStudyStream(ref dt))
            {
                //ddlStudyStream.DataSource = dt;
                //ddlStudyStream.DataTextField = "ShortDesc";
                //ddlStudyStream.DataValueField = "SSId";
                //ddlStudyStream.DataBind();
                //ddlStudyStream.Items.Insert(0, new ListItem("-Select-", "-Select-"));
            }
            else
            {
                master.ShowMessage("Unsuccessful", false);
            }
        }

        private bool ValidData()
        {
            LoggedIn master = (LoggedIn)this.Master;
            //commented validation for hidden field
            if (txtTag.Text.Trim() == "" || txtDetailQuestion.Text.Trim() == "" || txtShortDesc.Text.Trim() == "" || ddlSubject.SelectedIndex == 0) //|| ddlStudyStream.SelectedIndex == 0) 
            {                                                                        //am
               // LoggedIn master = (LoggedIn)this.Master;
                master.ShowMessage("Every Field must be filled.", false);
                return true;
            }
            else if (ddlSubject.SelectedItem.Text.Equals("Other") && txtOtherSub.Text.Trim() == string.Empty)
            {
                
                master.ShowMessage("Every Field must be filled.", false);
                return true;
          }
            else
            {
                return false;
            }
        }

        protected void btnSubmit_Onclick(object sender, EventArgs e)
        {
            LoggedIn master = (LoggedIn)this.Master;
            QuestAnsBAL QuestBAL = new QuestAnsBAL();
            QuestAnsBE QuestBE = new QuestAnsBE();
            //if (!commonBAL.isUserAuthorisedForPageFunc(LoggedInUser.UserId, thisPageName, "add"))
            //{

    //am        //    master.ShowMessage("You are not authorised to Perform any operation on this page. Please contact system administrator.", false);
            //    //   Server.Transfer("UM_BlankPage.aspx"); //?? send Message through Query String to the BlankPage
            //    //  string cat = Request.QueryString["Message"];
            //    //  Response.Redirect("UM_BlankPage.aspx?Message=You are not authorised to Perform any operation on this page. Please contact system administrator.");
            //    return;

            //}
            if (ValidData())
            {
                return;
            }
            
            
                //QuestAnsBAL QuestBAL = new QuestAnsBAL();  //am
                //QuestAnsBE QuestBE = new QuestAnsBE();     //am
            QuestBE.Subject = ddlSubject.SelectedItem.Text;
                if (ddlSubject.SelectedItem.Text.Equals("Other"))
                    QuestBE.OtherSubject = txtOtherSub.Text.Trim();
                else
                    QuestBE.OtherSubject = "";
         
                QuestBE.ShortDesc = txtShortDesc.Text;
                QuestBE.DetailQuestion = txtDetailQuestion.Text.Replace(Environment.NewLine, "<br />"); //am
            
            QuestBE.PersClass = txtClass.Text;
                QuestBE.StudyStream = "-Select-";
              QuestBE.YrsOfStudyStream = "0";  
                QuestBE.Tag = txtTag.Text;

                QuestBE.LastModifiedBy = ((UserBE)(Session["LoggedInUser"])).UserId;

                if (QuestBAL.AddQuestion(QuestBE))
                {
                    if (ddlSubject.SelectedItem.Text.Equals("Other"))
                        divotherSub.Visible = false;
                    foreach (Control txt in divAddOuery.Controls)
                    {
                        if (txt is TextBox)
                            ((TextBox)(txt)).Text = string.Empty;
                        else if (txt is DropDownList)
                            ((DropDownList)(txt)).SelectedIndex = 0;
                    }
                    
                    master.ShowMessage("Your Question has been Submitted Successfully", true);
                }
                else
                {
                    master.ShowMessage("Unsuccessful", false);
                }

            }


        

        protected void setBreadCrumb()
        {
            LoggedIn li = (LoggedIn)this.Master;
            li.setBreadCrumb(1, "Queries & Replies", "");
            li.setBreadCrumb(2, "Add Query", "QA_QuestionAdd.aspx");
        }

        protected void ddlSubjectChanged(object sender, EventArgs e)
        {
            divotherSub.Visible = ddlSubject.SelectedItem.Text.Equals("Other");
            txtOtherSub.Text = string.Empty;
        }
    }
}