<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Solicitud.aspx.cs" Inherits="Solicitud.Solicitud" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h1>Atención Cliente</h1>
    <br />
    <div>
        <asp:UpdatePanel ID="upTexto" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table>
                    <tr>
                        <th>Nombre</th>
                        <th></th>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <br />
    <div>
        <asp:UpdatePanel ID="upColas" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Timer ID="Timer1" runat="server" Interval="120000" OnTick="Timer1_Tick"></asp:Timer>
                <table>
                    <tr>
                        <th style="width: 100px; height: 20px;">Cola 1
                            <asp:Label ID="lblCola1" runat="server" Text="Inicio"></asp:Label></th>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gdCola1" runat="server">
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div>
            <asp:UpdatePanel ID="upCola2" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Timer ID="Timer2" runat="server" Interval="180000" OnTick="Timer2_Tick"></asp:Timer>
                    <table>
                        <tr>
                            <th style="width: 100px; height: 20px;">Cola 2
                            <asp:Label ID="lblCola2" runat="server" Text="Inicio"></asp:Label></th>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="gdCola2" runat="server">
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
