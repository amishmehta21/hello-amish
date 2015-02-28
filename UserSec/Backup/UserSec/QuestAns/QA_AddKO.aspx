<%@ Page Title="&#956Lessons - Add Query" Language="C#" MasterPageFile="~/UserMaint/LoggedIn.Master"
    AutoEventWireup="true" CodeBehind="QA_AddKO.aspx.cs" Inherits="UserSec.QuestAns.QA_AddKO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainPage" runat="server">
    <div class="page-heading">
        Add Reference</div>
    <div class="form-data">
        <div class="content" id="divAddKO" runat="server">
            <table cellpadding="0" cellspacing="0" border="0" >
                <tr>
                    <td>
                        Subject
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtSubject" runat="server" CssClass="textfield"></asp:TextBox>
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
                        Detail Description
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtDelDesc" runat="server" TextMode="MultiLine" CssClass="textfield"
                            Height="200px" Width="450px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Reference Text
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtKOText" runat="server" CssClass="textfield"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Reference Type
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlKOType" runat="server" CssClass="dropdownfield">
                            <asp:ListItem Value="0">-Select-</asp:ListItem>
                            <asp:ListItem Value="1">Link</asp:ListItem>
                            <asp:ListItem Value="2">Audio</asp:ListItem>
                            <asp:ListItem Value="3">Video</asp:ListItem>
                            <asp:ListItem Value="4">eBooks</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
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
                    <td>
                        Note
                    </td>
                    <td>
                        :
                    </td>
                    <td>
                        <asp:TextBox ID="txtNote" runat="server" TextMode="MultiLine" CssClass="textfield"
                            Height="200px" Width="450px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    </td>
                    <td>
                        <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" CssClass="button" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
