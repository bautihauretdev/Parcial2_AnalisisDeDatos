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

                            <asp:TextBox ID="btnProvincia2025" runat="server" CssClass="calendario-turno" Text="" />
                            <asp:TextBox ID="btnProvincia2024" runat="server" CssClass="calendario-turno" Text="" />
                            <asp:TextBox ID="btnProvincia2023" runat="server" CssClass="calendario-turno" Text="" />


                            <%-- Banco Nación --%>
                            <asp:Label ID="lblNacion" runat="server" CssClass="calendario-hora text-end text-secondary font-monospace pe-2" Text="Banco Nación"></asp:Label>
                            <%-- Turnos de la hora por día--%>
                            <asp:TextBox ID="btnNacion2025" runat="server" CssClass="calendario-turno" Text="" />
                            <asp:TextBox ID="btnNacion2024" runat="server" CssClass="calendario-turno" Text="" />
                            <asp:TextBox ID="btnNacion2023" runat="server" CssClass="calendario-turno" Text="" />

                            <%-- Banco Hipotecario --%>
                            <asp:Label ID="lblHipotecario" runat="server" CssClass="calendario-hora text-end text-secondary font-monospace pe-2" Text="Banco Hipotecario"></asp:Label>
                            <%-- Turnos de la hora por día--%>
                            <asp:TextBox ID="btnHipotecario2025" runat="server" CssClass="calendario-turno" Text="" />
                            <asp:TextBox ID="btnHipotecario2024" runat="server" CssClass="calendario-turno" Text="" />
                            <asp:TextBox ID="btnHipotecario2023" runat="server" CssClass="calendario-turno" Text="" />
                        </div>
                    </div>

                    <!-- BOTON CALCULAR -->
                    <div class="footer-calendario">
                        <asp:Button ID="btnCalcular" runat="server" Text="Calcular" CssClass="boton-principal" OnClick="btnCalcular_Click" />
                    </div>

                </div>
            </div>
        </div>

         <%-- Este Label muestra errores si el usuario ingresa texto en lugar de numeros --%>
         <asp:Label ID="lblError" runat="server" CssClass="text-danger" Visible="false"></asp:Label>

         <%-- LABEL PARA BANCO PROVINCIA (FALTA FRONT)--%>
        <div>
             <h4>BANCO PROVINCIA</h4>
         <asp:Label ID="lblProvinciaAnual" runat="server" Text="" />
         <asp:Label ID="lblProvinciaMensual" runat="server" Text="" />
         <asp:Label ID="lblProvinciaTrimestral" runat="server" Text="" />

        </div>

        <%-- LABEL PARA BANCO NACION (FALTA FRONT)--%>
        <div>   
         <h4>BANCO NACION</h4>
          <asp:Label ID="lblNacionAnual" runat="server" Text="" />
          <asp:Label ID="lblNacionMensual" runat="server" Text="" />
          <asp:Label ID="lblNacionTrimestral" runat="server" Text=""/>
        
        </div>
      
        
        <%-- LABEL PARA BANCO HIPOTECARIO (FALTA FRONT)--%>+
        <div>   
            <h4>BANCO HIPOTECARIO</h4>
        <asp:Label ID="lblHipotecarioAnual" runat="server" Text="" />
        <asp:Label ID="lblHipotecarioMensual" runat="server" Text="" />   
        <asp:Label ID="lblHipotecarioTrimestral" runat="server" Text=""></asp:Label>

        </div>

        <%-- LABEL DE RESULTADO FINAL--%>

        <h2>Mejor Opción Encontrada:</h2>
        <asp:Label ID="lblMejorOpcion" runat="server"></asp:Label>
        
        
    </div>
</asp:Content>
