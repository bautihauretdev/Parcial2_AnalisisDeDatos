using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace presentacionWebForm
{
    public partial class Default : System.Web.UI.Page
    {
        private const decimal CAPITAL_INICIAL = 850000m;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblError.Visible = false;
            }
        }

        protected void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. OCULTAR ERRORES ANTERIORES
                // Cada vez que calculamos, primero ocultamos el mensaje de error.
                lblError.Visible = false;

                // --- PASO 1: LEER Y VALIDAR DATOS DE LOS TEXTBOX ---
                // Lee las tasas de los 9 TextBoxes.
                // Usamos un metodo 'helper' (TryParseDecimal) que creamos mas abajo para convertir el texto en numero y validar que no hayan puesto letras.

                List<decimal> tasasProvincia = new List<decimal>
                {
                    TryParseDecimal(btnProvincia2025.Text),
                    TryParseDecimal(btnProvincia2024.Text),
                    TryParseDecimal(btnProvincia2023.Text)
                };

                List<decimal> tasasNacion = new List<decimal>
                {
                    TryParseDecimal(btnNacion2025.Text),
                    TryParseDecimal(btnNacion2024.Text),
                    TryParseDecimal(btnNacion2023.Text)
                };

                List<decimal> tasasHipotecario = new List<decimal>
                {
                    TryParseDecimal(btnHipotecario2025.Text),
                    TryParseDecimal(btnHipotecario2024.Text),
                    TryParseDecimal(btnHipotecario2023.Text)
                };

               

            }
            catch (FormatException ex)
            {
                // Si 'TryParseDecimal' falla (arrojo una FormatException), caemos aqui.
                // Mostramos el mensaje de error que definimos en esa funcion.
                lblError.Text = "Error: " + ex.Message;
                lblError.Visible = true;
                // Limpiamos los resultados anteriores porque el calculo fallo
                LimpiarResultados();
            }
            catch (Exception ex)
            {
                // Captura cualquier otro error inesperado (ej. division por cero, etc.)
                lblError.Text = "Ha ocurrido un error inesperado: " + ex.Message;
                lblError.Visible = true;
                LimpiarResultados();
            }
        }

             // --- METODOS HELPER  ---
        private decimal TryParseDecimal(string texto)
        {
            // Reemplazamos la coma (,) por un punto (.) para estandarizar
            string textoNormalizado = texto.Trim().Replace(",", ".");

            // Usamos CultureInfo.InvariantCulture para asegurar que el punto (.) 
            // sea reconocido como el separador decimal.
            if (decimal.TryParse(textoNormalizado, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal valor))
            {
                // Si tuvo exito, devolvemos el valor
                return valor;
            }
            else
            {
                // Si falla (ej. "abc" o "50%"), arrojamos una excepcion con un mensaje claro. Esta excepcion sera "atrapada" por el 'catch' en btnCalcular_Click.
                throw new FormatException($"El valor '{texto}' no es un número valido. " + "Ingrese solo números (ej: 50.5 o 50,5).");
            }
        }

        // Limpia todos los labels de resultados en caso de que ocurra un error.

        private void LimpiarResultados()
        {
            lblProvinciaAnual.Text = "-";
            lblProvinciaTrimestral.Text = "-";
            lblProvinciaMensual.Text = "-";
            lblNacionAnual.Text = "-";
            lblNacionTrimestral.Text = "-";
            lblNacionMensual.Text = "-";
            lblHipotecarioAnual.Text = "-";
            lblHipotecarioTrimestral.Text = "-";
            lblHipotecarioMensual.Text = "-";
            lblMejorOpcion.Text = "";
        }  
    }
}
