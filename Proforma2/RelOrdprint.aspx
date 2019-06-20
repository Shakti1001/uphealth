<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RelOrdprint.aspx.cs" Inherits="NewWebApp.Proforma2.RelOrdprint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Relieving Order</title>
    <script src="../../js/disableprint.js" type="text/javascript" language="javascript">
</script>
</head>
<body style="font-size: 12pt">
    <form id="form1" runat="server">
    <div>
        <div style="text-align: center">
            &nbsp;<table style="width: 100%; height: 100%">
                <tr>
                    <td style="width: 100%; height: 5%; text-align: right">
                    
                     <a href="javascript:window.print()">Print</a>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100%; height: 95% ; ; text-align: center" valign="top">                        
                        <div style="text-align: center">
                            <table style="width: 700px; height: 85px; font-family: Times New Roman; left: -6px; position: relative; top: 0px;">
                                <tr>
                                    <td style="width: 100%; height: 5%; text-align: left">
                                        
                                            प्रमाण पत्र संख्या :- <asp:Label ID="Prnlbl" runat="server" Font-Bold="True" Font-Size="Small" Font-Italic="True"></asp:Label>
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 5%">
                                        <span><strong><span>
                                            <asp:Label ID="Label2" runat="server" Font-Size="Large" ForeColor="Black" Text="Label"
                                                Visible="False"></asp:Label><br />
                                            <span style="text-decoration: underline">कार्यभार प्रमाण पत्र</span></span></strong><span
                                                style="text-decoration: underline">
                                            <strong><span></span></strong></span></span></td>
                                </tr>
                               
                                <tr>
                                    <td style="width: 100%; height: 50%; text-align: left;" valign="top">
                                        <br />
                                        <br />
                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;प्रमाणित किया जाता है कि &nbsp;
                                        <asp:Label ID="Postt" runat="server" Font-Bold="True"></asp:Label>
                                        ,<asp:Label ID="placet" runat="server" Font-Bold="True"></asp:Label>&nbsp;&nbsp;
                                        के पद
                                        &nbsp;का 
                                        कार्यभार
                                        <asp:Label ID="orderbyt" runat="server" Font-Bold="True"></asp:Label>
                                        &nbsp;&nbsp;,&nbsp;उत्तर प्रदेश के &nbsp; &nbsp; आदेश संख्या &nbsp;
                                        <asp:Label ID="ordernot" runat="server"
                                            Font-Bold="True"></asp:Label>&nbsp; दिनाँक
                                        &nbsp;
                                        <asp:Label ID="orderdatet" runat="server" Font-Bold="True"></asp:Label>&nbsp;
                                        जैसा कि
                                        इसमे बताया गया है कि&nbsp;
                                        दिनाँक
                                        <asp:Label ID="curdatet" runat="server" Font-Bold="True"></asp:Label>
                                        को पूर्वान्ह / अपरान्ह मे हस्तान्तरित किया गया ।<br />
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100%; height: 50%" valign="top">
                                        <div style="text-align: center">
                                            <table style="width: 100%; height: 100%">
                                                <tr>
                                                    <td style="width: 50%; height: 10%; text-align: left" valign="top">
                                                        <span>अवमोचक अधिकारी<br />
                                                            <br />
                                                            <br />
                                                            हस्ताक्षर<br />
                                                            <asp:Label ID="replacername" runat="server" Font-Bold="True"></asp:Label></span></td>
                                                    <td style="width: 50%; height: 10%; text-align: right" valign="top">
                                                        <span>अवमुक्त अधिकारी
                                                        </span>
                                                        <br />
                                                        <br />
                                                        <br />
                                                        हस्ताक्षर&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;<br />
                                                        (<asp:Label ID="Relievename" runat="server" Font-Bold="True"></asp:Label>)
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="height: 10%; text-align: center" valign="top">
                                                        <br />
                                        प्रतिहस्ताक्षरित<br />
                                                        <br />
                                                        <br />
                                                        (सी.एम.ओ./ सी.एम.एस./अन्य)</td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="height: 100%; text-align: left" valign="top">
                                                        <br />
                                                        प्रतिलिपि:
                                                        निम्न लिखित को सूचनार्थ एवम आवश्यक कार्यवाही हेतु प्रेषित।<br />
                                                        <br />
                                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 1. महालेखकार,उत्तर प्रदेश, इलाहाबाद।<br />
                                                        <br />
                                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                                            2.<asp:Label ID="OBYL" runat="server" Font-Bold="True"></asp:Label>
                                                        , उत्तर प्रदेश ।<br />
                                                        <br />
                                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 3. महानिदेशक, चिकित्सा एव स्वास्थ, उत्तर प्रदेश ।<br />
                                                        <br />
                                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; 4. कोषाधिकारी ,<asp:Label ID="PLACE" runat="server" Font-Bold="True"></asp:Label>
                                                        ।<br />
                                                        <br />
                                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 5. सम्बन्धित अधिकारी ।<br />
                                                        <br />
                                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 6. कार्यालय प्रति ।<br />
                                                        <br />
                                                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; 7. गार्ड फाईल ।
                                                        <br />
                                                        <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label></td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    
    </div>
    </form>
</body>
</html>