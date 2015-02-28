﻿<%@ Page Title="&#956Lessons - My Replies" Language="C#" MasterPageFile="~/UserMaint/LoggedIn.Master" AutoEventWireup="true" CodeBehind="QA_MyAnswers.aspx.cs" Inherits="UserSec.QuestAns.QA_MyAnswers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../JavaScript/CommonJSDataPagertxtValidation/DataPagerTxtValidation.js"
        type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainPage" runat="server">
<div class="page-heading">My Replies</div>

        	<div id="Div1" class="pagination clearfix" runat="server">
        	<div id="Div2" class="left" runat="server">
            	<table>

                	<tr>
                    	<td>Select No. of Record per page : 
                        
        <asp:DropDownList ID="ddlPageSize" runat="server" OnSelectedIndexChanged="OnPageSizeChange"
            AutoPostBack="true">
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
            <asp:ListItem>20</asp:ListItem>
            <asp:ListItem>50</asp:ListItem>
            <asp:ListItem>100</asp:ListItem>
        </asp:DropDownList>

                        </td>
                    </tr>
                </table>
            </div>
        	<div class="right">
            	<table>
                	<tr>

                        <td>
                          <asp:DataPager runat="server" ID="MyAnsDataPager" PageSize="10" PagedControlID="LvMyAns">  <%--am--%>
        <Fields>
            <asp:TemplatePagerField>
                <PagerTemplate>
                Record &nbsp
                    <asp:TextBox ID="CurrentRowTextBox" runat="server" AutoPostBack="true" Text="<%# Container.StartRowIndex + 1%>"
                        Columns="2" OnTextChanged="CurrentRowTextBox_OnTextChanged" onkeypress="return blockNonNumbers(this, event, false, false);" />
                         <asp:CompareValidator ID="cmpCurrentRowTextBox" runat="server"
    Operator="DataTypeCheck" Type="Integer" ControlToValidate="CurrentRowTextBox"  Text="*"  ForeColor="Red"/>
                   &nbsp to &nbsp
                    <asp:Label ID="PageSizeLabel" runat="server" Font-Bold="true" Text="<%# Container.StartRowIndex + Container.PageSize > Container.TotalRowCount ? Container.TotalRowCount : Container.StartRowIndex + Container.PageSize %>" />
                  &nbsp  of &nbsp
                    <asp:Label ID="TotalRowsLabel" runat="server" Font-Bold="true" Text="<%# Container.TotalRowCount %>" />
                    ... &nbsp &nbsp
                    Page &nbsp
                    <asp:DropDownList ID="ddlPageJump" runat="server" AutoPostBack="true" OnSelectedIndexChanged="PageJump_SelectedIndexChanged">
                    </asp:DropDownList>&nbsp
                    of &nbsp
                    <asp:Label ID="TotalPageNoLabel" runat="server" Text="<%#(int) Math.Ceiling(Convert.ToDecimal(MyAnsDataPager.TotalRowCount) / Convert.ToDecimal(MyAnsDataPager.PageSize)) %>">
                    </asp:Label> &nbsp
                </PagerTemplate>
            </asp:TemplatePagerField>
            <%--<asp:NextPreviousPagerField ShowFirstPageButton="true" ShowLastPageButton="true" ShowNextPageButton="true" ShowPreviousPageButton="true" ButtonType="Link"
                PreviousPageText="<" LastPageText=">|" NextPageText=">"  FirstPageText="|<"  />--%>
                <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="true"   FirstPageText="" RenderDisabledButtonsAsLabels="true"   ButtonCssClass="backward"  ShowNextPageButton="false" ShowPreviousPageButton="false"/>
                   <asp:NextPreviousPagerField ButtonType="Link"  PreviousPageText="" ButtonCssClass="prev"  ShowNextPageButton="false" RenderDisabledButtonsAsLabels="true" />
                      <asp:NextPreviousPagerField ButtonType="Link" NextPageText=""  ButtonCssClass="next" ShowPreviousPageButton="false" RenderDisabledButtonsAsLabels="true"  />
                      <asp:NextPreviousPagerField ButtonType="Link"  ShowLastPageButton="true"  LastPageText="" ButtonCssClass="forward"  ShowNextPageButton="false"  ShowPreviousPageButton="false" RenderDisabledButtonsAsLabels="true"  />
        </Fields>
    </asp:DataPager>

                        </td>
                    </tr>
                </table>            
            </div>

        </div>
        
 <div class="table-view clearfix"   style="overflow:scroll ;">
    <asp:ListView ID="LvMyAns" runat="server" ItemPlaceholderID="layoutTemplate" 
        DataKeyNames="QId" OnItemEditing="LvMyAns_ItemEditing"
        OnPagePropertiesChanging="lvUserList_PagePropertiesChanging"
        >
        <ItemTemplate>
            <div>
                <tr class="row" id="trItemTemplate" runat="server">
                    <td class="hidden">
                        
                            <%# Eval("AId")%>
                    </td>
                    <td class="hidden">
                        
                            <%# Eval("QId")%>
                    </td>
                    <td>
                        <%# Eval("AnsText")%>
                    </td>
                    <td>
                        <%# Eval("TotalLikes")%>
                    </td>
                    <td>
                    <%# Eval("TotalDislikes")%>
                    </td>
                    
                    <td>
                        <%# Eval("LastModifiedAt")%>
                    </td>
                    <td>
                        <%# Eval("LastModifiedBy")%>
                    </td>
                    
                     <td class="hidden">
                        <asp:Button runat="server" ID="btndefault" />
                       </td>
                     <td id="Td1" runat="server">
                        <!-- ModalPopupExtenders for the following buttons are located further below -->
                        <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CssClass="edit" CausesValidation="false" ToolTip="View"
                         CommandArgument='<%# Eval("QId")%>' />
                </td>
                </tr>
            </div>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <div >
                <tr class="row-alt" id="trAltItemTemplate" runat="server">
                      <td class="hidden">
                        
                            <%# Eval("AId")%>
                    </td>
                    <td class="hidden">
                        
                            <%# Eval("QId")%>
                    </td>
                    <td>
                        <%# Eval("AnsText")%>
                    </td>
                    <td>
                        <%# Eval("TotalLikes")%>
                    </td>
                    <td>
                    <%# Eval("TotalDislikes")%>
                    </td>
                    
                    <td>
                        <%# Eval("LastModifiedAt")%>
                    </td>
                    <td>
                        <%# Eval("LastModifiedBy")%>
                    </td>
                    <td class="hidden">
                        <asp:Button runat="server" ID="btndefault" />
                       </td>
                    <td id="Td1" runat="server">
                        <!-- ModalPopupExtenders for the following buttons are located further below -->
                        <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CssClass="edit" CausesValidation="false" ToolTip="View"
                         CommandArgument='<%# Eval("QId")%>' />
                </td>
                </tr>
            </div>
        </AlternatingItemTemplate>
        <EditItemTemplate>
           
        </EditItemTemplate>
        <InsertItemTemplate>
          
        </InsertItemTemplate>
        <LayoutTemplate>
            <table id="itemPlaceholderContainer" width="100%" cellpadding="0" cellspacing="1" border="0" runat="server" class="scrollTable">
            <thead class="fixedHeader"></thead>
                            <tr id="Tr2" runat="server" class="header">
                                <th id="Th1" runat="server" class="hidden">
                                    Reply Id
                                </th>
                                <th id="Th2" runat="server" class="hidden">
                                    Query Id
                                </th>
                                <th id="Th3" runat="server">
                                    Reply
                                </th>
                                <th id="Th4" runat="server">
                                    Total Likes
                                </th>
                                <th>
                                Total DisLikes
                                </th>
                                <th id="Th5" runat="server">
                                    Last Modified At
                                </th>
                                <th id="Th6" runat="server">
                                   Last Modified By
                                </th>
                                <th id="Th20" runat="server">
                                    View
                                </th>
                                
                            </tr>
                            <tr id="layoutTemplate" runat="server">
                            </tr>
            </table>
        </LayoutTemplate>
    </asp:ListView>
    </div>
</asp:Content>

