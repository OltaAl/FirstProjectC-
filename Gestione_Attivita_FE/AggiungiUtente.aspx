<%@ Page Title="Aggiungi Utente" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AggiungiUtente.aspx.cs" Inherits="Gestione_Attivita_FE.Contact" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<link href="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
<script src="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>
<script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>

<!-- Boostrap Forms -->
<!DOCTYPE html>
    <%--<header>
        <link rel="stylesheet" href="Style.css" />
    </header>--%>
    <br /><br /><br /><br />
    <div class="container register-form">
        <div class="form">
            <div class="note">
                <p>Aggiungi Un Nuovo Utente.</p>
            </div>
            <div class="form-content">
                <div class ="row">
                    <div class="col-md-10">
                        <asp:TextBox ID="searchForUser" runat="server" class="form-control" OnTextChanged="searchForUser_TextChanged" autocomplelete ="off" placeholder ="Controlla Nome Cognome" AutoPostBack="true" AutoCompleteType="Disabled"></asp:TextBox>
                        <asp:Label ID="popUpBallon" runat="server" class="form-control" Text="Controlla se un utente e registrato !!" BackColor="White" BorderColor="White" BorderStyle="None" ForeColor="#0066FF" Font-Bold="True" Font-Names="Arial Rounded MT Bold" Font-Size="Medium" Font-Strikeout="False" EnableTheming="False"></asp:Label>
                        <ajaxToolkit:BalloonPopupExtender ID="BalloonPopupExtender1" runat="server" BalloonPopupControlID ="popUpBallon" TargetControlID="searchForUser"></ajaxToolkit:BalloonPopupExtender>
                        <asp:Image ID="Image1" runat="server" ImageUrl="Images/info.png" /> <asp:Label ID="checkUser" runat="server">
                            </asp:Label>
                    </div>
                </div><br /><br />
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group">
                            <input type="text" ID="nome" runat="server" class="form-control" autocomplete="off" placeholder="Scrivi Nome *" value=""/>
                        </div>
                        <div class="form-group">
                            <input type="text" ID="cognome" runat="server" class="form-control" autocomplete="off" placeholder="Scrivi Cognome *" value=""/>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                            <input type="text" ID="aggiuntoDa" runat="server" class="form-control" value="" disabled/>
                        </div>
                        <div class="form-group">
                            <asp:DropDownList type="text" class="form-control" ID="livelloDiAccesso" runat="server">
                                <asp:ListItem Value="">Livello di accesso *</asp:ListItem>
                                <asp:ListItem Value="Operatore">Operatore</asp:ListItem>
                                <asp:ListItem Value="Admin">Admin</asp:ListItem>  
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <asp:Button runat="server" ID="aggiungi_utente" Text="Aggiungi Utente" class="btn btn-success" OnClick="aggiungi_utente_Click" />
                <asp:Button runat="server" ID="modifica_utente" Text="Modifica Utente" class="btn btn-primary" OnClick="modifica_utente_Click" />
            </div>
        </div>
    </div>

</asp:Content>
