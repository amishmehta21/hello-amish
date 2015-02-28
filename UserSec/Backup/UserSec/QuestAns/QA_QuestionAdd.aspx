<%@ Page Title="&#956Lessons - Add Query" Language="C#" MasterPageFile="~/UserMaint/LoggedIn.Master"
    AutoEventWireup="true" CodeBehind="QA_QuestionAdd.aspx.cs" Inherits="UserSec.Quest_Ans.QA_QuestionAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .uptxt
        {
            text-transform: uppercase;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainPage" runat="server">
    <div class="page-heading">
        Add Query</div>
    <div class="form-data">
        <div class="content" id="divAddOuery" runat="server">
            <table cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td>
                        Subject
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlSubject" runat="server" CssClass="dropdownfield" AutoPostBack="true" OnSelectedIndexChanged ="ddlSubjectChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr runat="server" id ="divotherSub" visible="false">
                    <td>
                        Other Subject
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtOtherSub" runat="server" CssClass="textfield"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Short Description
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtShortDesc" runat="server" CssClass="textfield"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Detail Query
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtDetailQuestion" runat="server" TextMode="MultiLine" CssClass="textarea"></asp:TextBox>
                    </td>         <%--am--%>
                </tr>
                <tr style="display: none">
                    <td>
                        Personal Classification
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtClass" runat="server" CssClass="textfield">dummy</asp:TextBox>
                    </td>
                </tr>
           <%--     <tr>
                    <td>
                        Study Stream
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlStudyStream" runat="server" CssClass="dropdownfield">
                        </asp:DropDownList>
                    </td>                           //am
                </tr>
                <tr>
                    <td>
                        Years of Study Experience
                    </td>
                    <td>
                        :                            //am
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlExp" runat="server" CssClass="dropdownfield">
                        </asp:DropDownList>
                    </td>
                </tr>--%>
                <tr>
                    <td>
                        Tag
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtTag" runat="server" CssClass="textfield"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                    <td>
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Onclick"
                            CssClass="button" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
