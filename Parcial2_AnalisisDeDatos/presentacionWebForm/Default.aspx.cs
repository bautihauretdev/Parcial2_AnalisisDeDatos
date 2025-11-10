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
            // Ocultamos el mensaje de error al cargar la página
            if (!IsPostBack)
            {
                LimpiarTodo();
            }
        }

        protected void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                // Cada vez que calculamos, primero ocultamos el mensaje de error.
                lblError.Visible = false;

                // Validamos que no haya campos vacíos
                if (string.IsNullOrWhiteSpace(btnProvincia2025.Text) ||
                    string.IsNullOrWhiteSpace(btnProvincia2024.Text) ||
                    string.IsNullOrWhiteSpace(btnProvincia2023.Text) ||
                    string.IsNullOrWhiteSpace(btnNacion2025.Text) ||
                    string.IsNullOrWhiteSpace(btnNacion2024.Text) ||
                    string.IsNullOrWhiteSpace(btnNacion2023.Text) ||
                    string.IsNullOrWhiteSpace(btnHipotecario2025.Text) ||
                    string.IsNullOrWhiteSpace(btnHipotecario2024.Text) ||
                    string.IsNullOrWhiteSpace(btnHipotecario2023.Text))
                {
                    lblError.Text = "Todos los campos deben estar completos.";
                    lblError.Visible = true;
                }
                else
                {
                    lblError.Visible = false;

                    // ----- (1) LEER Y VALIDAR DATOS DE LOS TEXTBOX -----
                    // Lee las tasas de los 9 TextBoxes.
                    // Usamos un metodo 'helper' (TryParseDecimal) que creamos más abajo
                    // para convertir el texto en numero y validar que no hayan puesto letras.

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



                    // ----- PASO 2: CALCULAR PROMEDIO DE LAS TASAS ANUAL DE CADA BANCO -----
                    decimal TNA_Provincia = tasasProvincia.Average(); // La f .Average() calcula el promedio.
                    decimal TNA_Nacion = tasasNacion.Average();
                    decimal TNA_Hipotecario = tasasHipotecario.Average();



                    // --- PASO 3: EVALUAR MODALIDADES ---
                    // Usaremos un diccionario para guardar todos los montos finales y encontrar el mejor.
                    // El string (clave) será el nombre (Ej: "Banco Provincia (Mensual)")
                    // El decimal (valor) será el monto final generado.
                    Dictionary<string, decimal> resultados = new Dictionary<string, decimal>();

                    // -- Banco Provincia --
                    decimal provAnual = CalcularRendimientoAnual(CAPITAL_INICIAL, TNA_Provincia);
                    decimal provTrim = CalcularRendimientoTrimestral(CAPITAL_INICIAL, TNA_Provincia);
                    decimal provMes = CalcularRendimientoMensual(CAPITAL_INICIAL, TNA_Provincia);
                    resultados.Add("Banco Provincia (Anual)", provAnual);
                    resultados.Add("Banco Provincia (Trimestral)", provTrim);
                    resultados.Add("Banco Provincia (Mensual)", provMes);

                    // -- Banco Nación --
                    decimal nacionAnual = CalcularRendimientoAnual(CAPITAL_INICIAL, TNA_Nacion);
                    decimal nacionTrim = CalcularRendimientoTrimestral(CAPITAL_INICIAL, TNA_Nacion);
                    decimal nacionMes = CalcularRendimientoMensual(CAPITAL_INICIAL, TNA_Nacion);
                    resultados.Add("Banco Nación (Anual)", nacionAnual);
                    resultados.Add("Banco Nación (Trimestral)", nacionTrim);
                    resultados.Add("Banco Nación (Mensual)", nacionMes);

                    // -- Banco Hipotecario --
                    decimal hipoAnual = CalcularRendimientoAnual(CAPITAL_INICIAL, TNA_Hipotecario);
                    decimal hipoTrim = CalcularRendimientoTrimestral(CAPITAL_INICIAL, TNA_Hipotecario);
                    decimal hipoMes = CalcularRendimientoMensual(CAPITAL_INICIAL, TNA_Hipotecario);
                    resultados.Add("Banco Hipotecario (Anual)", hipoAnual);
                    resultados.Add("Banco Hipotecario (Trimestral)", hipoTrim);
                    resultados.Add("Banco Hipotecario (Mensual)", hipoMes);



                    // ----- PASO 4: MOSTRAR RESULTADOS -----
                    // Mostramos los rendimientos (Ganancia = Monto Final - Capital Inicial)
                    // Usamos .ToString("C") para formatearlo como moneda (Ej: $150.000,00)

                    // Provincia
                    lblProvinciaAnual.Text = (provAnual - CAPITAL_INICIAL).ToString("C", new CultureInfo("es-AR"));
                    lblProvinciaTrimestral.Text = (provTrim - CAPITAL_INICIAL).ToString("C", new CultureInfo("es-AR"));
                    lblProvinciaMensual.Text = (provMes - CAPITAL_INICIAL).ToString("C", new CultureInfo("es-AR"));

                    // Nación
                    lblNacionAnual.Text = (nacionAnual - CAPITAL_INICIAL).ToString("C", new CultureInfo("es-AR"));
                    lblNacionTrimestral.Text = (nacionTrim - CAPITAL_INICIAL).ToString("C", new CultureInfo("es-AR"));
                    lblNacionMensual.Text = (nacionMes - CAPITAL_INICIAL).ToString("C", new CultureInfo("es-AR"));

                    // Hipotecario
                    lblHipotecarioAnual.Text = (hipoAnual - CAPITAL_INICIAL).ToString("C", new CultureInfo("es-AR"));
                    lblHipotecarioTrimestral.Text = (hipoTrim - CAPITAL_INICIAL).ToString("C", new CultureInfo("es-AR"));
                    lblHipotecarioMensual.Text = (hipoMes - CAPITAL_INICIAL).ToString("C", new CultureInfo("es-AR"));



                    // ----- PASO 5: MOSTRAR MEJOR OPCIÓN -----

                    // Buscamos el valor máximo en nuestro diccionario de resultados
                    decimal montoMaximo = resultados.Values.Max();

                    // Buscamos la clave (el nombre) que corresponde a ese valor máximo
                    string mejorOpcionNombre = resultados.First(kvp => kvp.Value == montoMaximo).Key;

                    // Calculamos la ganancia
                    decimal gananciaMaxima = montoMaximo - CAPITAL_INICIAL;

                    // Mostramos el mensaje final
                    lblMejorOpcion.Text = $"La opción más rentable es {mejorOpcionNombre}, " +
                                          $"con un rendimiento de {gananciaMaxima.ToString("C", new CultureInfo("es-AR"))} " +
                                          $"(Monto final: {montoMaximo.ToString("C", new CultureInfo("es-AR"))})";

                    pnlResultados.Visible = true; // Para mostrar el panel
                }
            }
            catch (FormatException ex)
            {
                // Si 'TryParseDecimal' falla, nos trae acá.
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



        // ----- MÉTODOS DE CÁLCULO DE INTERÉS -----

        // (1) Inversión por un año completo con la tasa anual promedio.
        // Fórmula: M = C * (1 + TNA)
        private decimal CalcularRendimientoAnual(decimal capital, decimal tnaPromedio)
        {
            // Convertimos la TNA (ej: 50%) a un valor decimal (ej: 0.50)
            decimal tasa = tnaPromedio / 100m;
            return capital * (1 + tasa);
        }

        // (2) Inversión por trimestres, reinvirtiendo capital. (Interés Compuesto)
        // Fórmula: M = C * (1 + TNA/4)^4
        private decimal CalcularRendimientoTrimestral(decimal capital, decimal tnaPromedio)
        {
            // Tasa Nominal Anual dividida en 4 trimestres
            decimal tasaTrimestral = (tnaPromedio / 100m) / 4m;
            // Aplicamos la fórmula de interés compuesto para 4 períodos
            // Math.Pow espera 'double', por eso convertimos (cast) y luego volvemos a 'decimal'
            return capital * (decimal)Math.Pow(1 + (double)tasaTrimestral, 4);
        }

        // (3) Inversión por meses, reinvirtiendo capital. (Interés Compuesto)
        // Fórmula: M = C * (1 + TNA/12)^12
        private decimal CalcularRendimientoMensual(decimal capital, decimal tnaPromedio)
        {
            // Tasa Nominal Anual dividida en 12 meses
            decimal tasaMensual = (tnaPromedio / 100m) / 12m;
            // Aplicamos la fórmula de interés compuesto para 12 períodos
            return capital * (decimal)Math.Pow(1 + (double)tasaMensual, 12);
        }



        // ----- METODOS HELPER  -----
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

        private void LimpiarTodo()
        {
            btnProvincia2025.Text = "";
            btnProvincia2024.Text = "";
            btnProvincia2023.Text = "";

            btnNacion2025.Text = "";
            btnNacion2024.Text = "";
            btnNacion2023.Text = "";

            btnHipotecario2025.Text = "";
            btnHipotecario2024.Text = "";
            btnHipotecario2023.Text = "";

            lblError.Visible = false;  // Oculta el texto de error
            pnlResultados.Visible = false; // Oculta el panel de resultados
        }

    }
}

