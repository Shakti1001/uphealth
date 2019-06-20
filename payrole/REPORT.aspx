<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/admin.Master" AutoEventWireup="true" CodeBehind="REPORT.aspx.cs" Inherits="NewWebApp.payrole.REPORT" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
<table class="table table-responsive-sm table-active" style="width: 100%">
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:uphsdpConnectionString %>" 
                    SelectCommand="SELECT DistrictName, Endocrinology, CommunityDentistry, DentalScience, Endodontics, Orthodontics, Prothodontics, Pedodontics, Periodontics, Physiology, OralPathology, OralMedecinRadiology, Jurisprudence FROM SP3">
                </asp:SqlDataSource>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:uphsdpConnectionString %>" 
                    
                    SelectCommand="SELECT DistrictName, MBBS, Medicine, Anaesthesia, GynObs, Gynaecology, Paediatrics, Radiology, Surgery, Orthopedics, ENT, Opthalmology, SkinVD, TBChestDis, Pathology, ChestDis, PublicHealth, SPM FROM SPECILITYVIEW">
                </asp:SqlDataSource>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:uphsdpConnectionString %>" 
                    
                    SelectCommand="SELECT DistrictName, Anatomy, Cardiology, CardiacSurgery, ChestSurgery, Nephrology, Neurology, NeuroSurgery, PlasticSurgery, Psychiatry, PsychiatricMedicine, TropicalMedHeal, Urology, IndustrialHealth, Radiotherapy, Pharmacology, MedicalVirology FROM SP2">
                </asp:SqlDataSource>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="sp1" runat="server" onclick="Button2_Click" 
                    style="font-weight: bold" Text="Sheet-1" />
                <asp:Button ID="sp2" runat="server" onclick="Button1_Click1" 
                    style="font-weight: bold" Text="Sheet-2" />
                <strong>
                <asp:Button ID="sp3" runat="server" onclick="Button3_Click" 
                    style="font-weight: bold" Text="Sheet-3" />
                </strong></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:GridView ID="GridView2" runat="server" Width="100%">
                </asp:GridView>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <%--           <asp:GridView ID="GridView1" runat="server" Width="100%" 
                    AutoGenerateColumns="False">
                <Columns>
                  <asp:TemplateField HeaderText="S.No."><ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate></asp:TemplateField>
                  <asp:BoundField DataField="name" HeaderText="Doctor's Name" />
                  <asp:BoundField DataField="did" HeaderText="Degree" />
                  <asp:BoundField DataField="spname" HeaderText="Specialization" />
                     <asp:BoundField DataField="hname" HeaderText="Hospital Name" /> 
                       <asp:BoundField DataField="newpostname" HeaderText="Post Name" />
                          <asp:BoundField DataField="districtname" HeaderText="District Name" />
                             <asp:BoundField DataField="quaname" HeaderText="Qualification" />
                              <asp:BoundField DataField="sid" HeaderText="Specialization" />
       </Columns>
                </asp:GridView>--%>
                <asp:GridView ID="GridView1" runat="server" Width="100%">
                </asp:GridView>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</div>
</asp:Content>
