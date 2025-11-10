<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="presentacionWebForm.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="dashboard">
        <div class="row g-4">
            <!-- INGRESO DE INFORMACIÓN -->
            <div class="col">
                <div class="card">

                    <!-- TÍTULO -->
                    <div class="planilla-header">
                        <h2>Inversión Plazo Fijo</h2>
                    </div>

                    <!-- BANCO / AÑOS / MONTO -->
                    <div class="planilla-scroll">
                        <div class="planilla-grid">
                            <!-- Años -->
                            <div class="calendario-cabecera-dias"></div>
                            <asp:Label ID="lbl2025" runat="server" CssClass="planilla-cabecera-anios" Text="2025"></asp:Label>
                            <asp:Label ID="lbl2024" runat="server" CssClass="planilla-cabecera-anios" Text="2024"></asp:Label>
                            <asp:Label ID="lbl2023" runat="server" CssClass="planilla-cabecera-anios" Text="2023"></asp:Label>

                            <!-- Banco Provincia -->
                            <asp:Label ID="lblProvincia" runat="server" CssClass="calendario-hora text-end text-secondary font-monospace pe-2" Text="Banco Provincia"></asp:Label>
                            <asp:TextBox ID="btnProvincia2025" runat="server" CssClass="planilla-campo" Text="" />
                            <asp:TextBox ID="btnProvincia2024" runat="server" CssClass="planilla-campo" Text="" />
                            <asp:TextBox ID="btnProvincia2023" runat="server" CssClass="planilla-campo" Text="" />

                            <!-- Banco Nación -->
                            <asp:Label ID="lblNacion" runat="server" CssClass="calendario-hora text-end text-secondary font-monospace pe-2" Text="Banco Nación"></asp:Label>
                            <asp:TextBox ID="btnNacion2025" runat="server" CssClass="planilla-campo" Text="" />
                            <asp:TextBox ID="btnNacion2024" runat="server" CssClass="planilla-campo" Text="" />
                            <asp:TextBox ID="btnNacion2023" runat="server" CssClass="planilla-campo" Text="" />

                            <!-- Banco Hipotecario -->
                            <asp:Label ID="lblHipotecario" runat="server" CssClass="calendario-hora text-end text-secondary font-monospace pe-2" Text="Banco Hipotecario"></asp:Label>
                            <asp:TextBox ID="btnHipotecario2025" runat="server" CssClass="planilla-campo" Text="" />
                            <asp:TextBox ID="btnHipotecario2024" runat="server" CssClass="planilla-campo" Text="" />
                            <asp:TextBox ID="btnHipotecario2023" runat="server" CssClass="planilla-campo" Text="" />
                        </div>

                        <!-- Este Label muestra errores si el usuario ingresa texto en lugar de numeros -->
                        <asp:Label ID="lblError" runat="server" CssClass="text-danger" Visible="false"></asp:Label>
                    </div>
                    <!-- BOTON CALCULAR -->
                    <div class="footer-planilla">
                        <asp:Button ID="btnCalcular" runat="server" Text="Calcular" CssClass="boton-principal" OnClick="btnCalcular_Click" />
                    </div>
                </div>
            </div>

            <!-- MUESTRA DE RESULTADOS -->
            <asp:Panel ID="pnlResultados" runat="server" Visible="false">
                <div class="row g-3 mt-2">
                    <div class="col">
                        <div class="card">
                            <!-- TÍTULO RESULTADOS -->
                            <div class="planilla-header">
                                <h2>Resultados Obtenidos</h2>
                            </div>

                            <!-- TABLA DE RESULTADOS -->
                            <div class="planilla-scroll">
                                <div class="planilla-grid">
                                    <!-- Cabecera -->
                                    <div class="planilla-cabecera-anios"></div>
                                    <asp:Label ID="lblAnual" runat="server" CssClass="planilla-cabecera-anios" Text="Anual"></asp:Label>
                                    <asp:Label ID="lblTrimestral" runat="server" CssClass="planilla-cabecera-anios" Text="Trimestral"></asp:Label>
                                    <asp:Label ID="lblMensual" runat="server" CssClass="planilla-cabecera-anios" Text="Mensual"></asp:Label>

                                    <!-- Banco Provincia -->
                                    <asp:Label ID="lblProvinciaTitulo" runat="server" CssClass="planilla-banco text-end text-secondary font-monospace pe-2" Text="Banco Provincia"></asp:Label>
                                    <asp:Label ID="lblProvinciaAnual" runat="server" CssClass="planilla-campo" Text="" />
                                    <asp:Label ID="lblProvinciaTrimestral" runat="server" CssClass="planilla-campo" Text="" />
                                    <asp:Label ID="lblProvinciaMensual" runat="server" CssClass="planilla-campo" Text="" />

                                    <!-- Banco Nación -->
                                    <asp:Label ID="lblNacionTitulo" runat="server" CssClass="planilla-banco text-end text-secondary font-monospace pe-2" Text="Banco Nación"></asp:Label>
                                    <asp:Label ID="lblNacionAnual" runat="server" CssClass="planilla-campo" Text="" />
                                    <asp:Label ID="lblNacionTrimestral" runat="server" CssClass="planilla-campo" Text="" />
                                    <asp:Label ID="lblNacionMensual" runat="server" CssClass="planilla-campo" Text="" />

                                    <!-- Banco Hipotecario -->
                                    <asp:Label ID="lblHipotecarioTitulo" runat="server" CssClass="planilla-banco text-end text-secondary font-monospace pe-2" Text="Banco Hipotecario"></asp:Label>
                                    <asp:Label ID="lblHipotecarioAnual" runat="server" CssClass="planilla-campo" Text="" />
                                    <asp:Label ID="lblHipotecarioTrimestral" runat="server" CssClass="planilla-campo" Text="" />
                                    <asp:Label ID="lblHipotecarioMensual" runat="server" CssClass="planilla-campo" Text="" />
                                </div>
                            </div>

                            <!-- RESULTADO FINAL -->
                            <div class="footer-planilla">
                                <div>
                                    <h3>Mejor Opción Encontrada</h3>
                                    <asp:Label ID="lblMejorOpcion" runat="server" CssClass="fw fs-5"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
