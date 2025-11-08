<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="presentacionWebForm.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="dashboard">
        <div class="row g-4">
            <div class="col">
                <div class="card">

                    <!-- TÍTULO -->
                    <div class="calendario-header">
                        <h2>Inversión Plazo Fijo</h2>
                    </div>

                    <!-- BANCO / AÑOS / MONTO -->
                    <div class="calendario-scroll">
                        <div class="calendario-grid">
                            <!-- Años -->
                            <div class="calendario-cabecera-dias"></div>
                            <asp:Label ID="lbl2025" runat="server" CssClass="calendario-cabecera-dias" Text="2025"></asp:Label>
                            <asp:Label ID="lbl2024" runat="server" CssClass="calendario-cabecera-dias" Text="2024"></asp:Label>
                            <asp:Label ID="lbl2023" runat="server" CssClass="calendario-cabecera-dias" Text="2023"></asp:Label>

                            <%-- Banco Provincia --%>
                            <asp:Label ID="lblProvincia" runat="server" CssClass="calendario-hora text-end text-secondary font-monospace pe-2" Text="Banco Provincia"></asp:Label>

                            <asp:TextBox ID="btnProvincia2025" runat="server" CssClass="calendario-turno" Text="$" />
                            <asp:TextBox ID="btnProvincia2024" runat="server" CssClass="calendario-turno" Text="$" />
                            <asp:TextBox ID="btnProvincia2023" runat="server" CssClass="calendario-turno" Text="$" />


                            <%-- Banco Nación --%>
                            <asp:Label ID="lblNacion" runat="server" CssClass="calendario-hora text-end text-secondary font-monospace pe-2" Text="Banco Nación"></asp:Label>
                            <%-- Turnos de la hora por día--%>
                            <asp:TextBox ID="btnNacion2025" runat="server" CssClass="calendario-turno" Text="$" />
                            <asp:TextBox ID="btnNacion2024" runat="server" CssClass="calendario-turno" Text="$" />
                            <asp:TextBox ID="btnNacion2023" runat="server" CssClass="calendario-turno" Text="$" />

                            <%-- Banco Hipotecario --%>
                            <asp:Label ID="lblHipotecario" runat="server" CssClass="calendario-hora text-end text-secondary font-monospace pe-2" Text="Banco Hipotecario"></asp:Label>
                            <%-- Turnos de la hora por día--%>
                            <asp:TextBox ID="btnHipotecario2025" runat="server" CssClass="calendario-turno" Text="$" />
                            <asp:TextBox ID="btnHipotecario2024" runat="server" CssClass="calendario-turno" Text="$" />
                            <asp:TextBox ID="btnHipotecario2023" runat="server" CssClass="calendario-turno" Text="$" />
                        </div>
                    </div>

                    <!-- BOTON CALCULAR -->
                    <div class="footer-calendario">
                        <button type="button" class="boton-principal" data-bs-toggle="modal" data-bs-target="#modalEditarTurno">
                            Calcular
                        </button>
                    </div>

                </div>
            </div>
        </div>

    </div>
</asp:Content>
