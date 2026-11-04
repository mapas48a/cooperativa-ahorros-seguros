
using System.Globalization;

// El punto separa los decimales; los montos se introducen sin separadores de miles.
CultureInfo cultura = CultureInfo.InvariantCulture;
const string pinCorrecto = "1234";
decimal saldo = 10000m;
int intentosPin = 0;
bool cuentaBloqueada = false;
int opcionPrincipal;

do
{
    Console.WriteLine("\n========================================");
    Console.WriteLine("       COOPERATIVA AHORRO SEGURO");
    Console.WriteLine("========================================");
    Console.WriteLine("1. Cajero automático\n2. Simulador de préstamo\n3. Salir");
    Console.Write("Seleccione una opción: ");
    string? entradaPrincipal = Console.ReadLine();

    // Al terminar la entrada, salimos sin repetir errores.
    if (entradaPrincipal is null) break;

    if (!int.TryParse(entradaPrincipal, out opcionPrincipal))
    {
        Console.WriteLine("Error: introduzca una opción numérica del 1 al 3.");
        continue;
    }

    switch (opcionPrincipal)
    {
        case 1:
            if (cuentaBloqueada)
            {
                Console.WriteLine("Cuenta bloqueada. No se permiten operaciones del cajero.");
                break;
            }

            bool accesoPermitido = false;
            while (intentosPin < 3 && !accesoPermitido)
            {
                Console.Write("Introduzca su PIN de cuatro dígitos: ");
                string? pinIngresado = Console.ReadLine();
                if (pinIngresado is null) return;

                
                // Verificamos si el PIN ingresado es correcto.
                if (pinIngresado == pinCorrecto)
                {
                    accesoPermitido = true;
                    intentosPin = 0;
                }
                else
                {
                    // Contamos los intentos incorrectos.
                    intentosPin++;
                    Console.WriteLine($"PIN incorrecto. Intentos restantes: {3 - intentosPin}.");
                }
            }

            // Bloqueamos la cuenta si falla los tres intentos.
            if (!accesoPermitido)
            {
                cuentaBloqueada = true;
                Console.WriteLine("Cuenta bloqueada tras tres intentos fallidos.");
                break;
            }

            // Inicializamos los contadores de operaciones del cajero.
            int depositos = 0;
            int retiros = 0;
            int opcionCajero;

            // Mostramos el menú hasta que el usuario decida salir.
            do
            {
                Console.WriteLine("\n========== CAJERO AUTOMÁTICO ==========");
                Console.WriteLine("1. Consultar saldo\n2. Depositar dinero\n3. Retirar dinero\n4. Salir del cajero");
                Console.Write("Seleccione una opción: ");

                string? entradaCajero = Console.ReadLine();
                if (entradaCajero is null) return;

                // Validamos que la opción sea numérica.
                if (!int.TryParse(entradaCajero, out opcionCajero))
                {
                    Console.WriteLine("Error: introduzca una opción numérica del 1 al 4.");
                    continue;
                }

                switch (opcionCajero)
                {
                    // Consultamos el saldo disponible.
                    case 1:
                        Console.WriteLine($"Saldo actual: RD${saldo.ToString("N2", cultura)}");
                        break;

// Opción para depositar dinero.
                    case 2:
                        Console.Write("Monto a depositar (ejemplo: 1500.50): ");
                        string? entradaDeposito = Console.ReadLine();
                        if (entradaDeposito is null) return;

                        // Comprobamos que el depósito sea válido y mayor que cero.
                        if (!decimal.TryParse(entradaDeposito, NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite, cultura, out decimal deposito))
                            Console.WriteLine("Error: el depósito debe ser un número válido, sin separadores de miles.");
                        else if (deposito <= 0)
                            Console.WriteLine("Error: el depósito debe ser mayor que cero.");
                        else if (deposito > decimal.MaxValue - saldo)
                            Console.WriteLine("Error: el monto supera la capacidad del saldo.");
                        else
                        {
                            // Sumamos el depósito al saldo y actualizamos el contador.
                            saldo += deposito;
                            depositos++;
                            Console.WriteLine($"Depósito exitoso. Saldo actual: RD${saldo.ToString("N2", cultura)}");
                        }
                        break;

                    // Opción para retirar dinero.
                    case 3:
                        Console.Write("Monto a retirar (múltiplo de 100): ");
                        string? entradaRetiro = Console.ReadLine();
                        if (entradaRetiro is null) return;

                        // Validamos el monto, el saldo y los múltiplos de RD$100.
                        if (!decimal.TryParse(entradaRetiro, NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite, cultura, out decimal retiro))
                            Console.WriteLine("Error: el retiro debe ser un número válido, sin separadores de miles.");
                        else if (retiro <= 0)
                            Console.WriteLine("Error: el retiro debe ser mayor que cero.");
                        else if (retiro > saldo)
                            Console.WriteLine("Error: saldo insuficiente.");
                        else if (retiro % 100m != 0)
                            Console.WriteLine("Error: el retiro debe ser múltiplo exacto de RD$100.");
                        else
                        {
                            // Restamos el retiro del saldo y actualizamos el contador.
                            saldo -= retiro;
                            retiros++;
                            Console.WriteLine($"Retiro exitoso. Saldo actual: RD${saldo.ToString("N2", cultura)}");
                        }
                        break;

                    // Mostramos el resumen al salir del cajero.
                    case 4:
                        Console.WriteLine($"\nResumen del cajero\nDepósitos realizados: {depositos}\nRetiros realizados: {retiros}");
                        Console.WriteLine($"Saldo final: RD${saldo.ToString("N2", cultura)}");
                        break;

                    default:
                        Console.WriteLine("Error: seleccione una opción del 1 al 4.");
                        break;
                }

                
        // Iniciamos el simulador de préstamos.
        case 2:
            string repetir;

            do
            {
                decimal monto;
                bool montoValido;

                // Solicitamos el monto hasta recibir un valor permitido.
                do
                {
                    Console.Write("\nMonto del préstamo (5000 a 500000; use punto decimal y sin separadores de miles): ");
                    string? entradaMonto = Console.ReadLine();
                    if (entradaMonto is null) return;

                    montoValido = decimal.TryParse(entradaMonto, NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite, cultura, out monto)
                        && monto >= 5000m && monto <= 500000m;

                    if (!montoValido)
                        Console.WriteLine("Error: introduzca un monto entre RD$5,000 y RD$500,000.");
                } while (!montoValido);

                int plazo;
                bool plazoValido;

                // Validamos que el plazo esté entre 6 y 60 meses.
                do
                {
                    Console.Write("Plazo en meses (6 a 60): ");
                    string? entradaPlazo = Console.ReadLine();
                    if (entradaPlazo is null) return;

                    plazoValido = int.TryParse(entradaPlazo, out plazo)
                        && plazo >= 6 && plazo <= 60;

                    if (!plazoValido)
                        Console.WriteLine("Error: el plazo debe ser un entero entre 6 y 60.");
                } while (!plazoValido);

                decimal tasaAnual = 0m;
                string categoria;

                // Asignamos la tasa anual según la categoría del socio.
                do
                {
                    Console.Write("Categoría del socio (A: 12 %, B: 15 %, C: 18 %): ");
                    string? entradaCategoria = Console.ReadLine();
                    if (entradaCategoria is null) return;

                    categoria = entradaCategoria.Trim().ToUpperInvariant();

                    switch (categoria)
                    {
                        case "A": tasaAnual = 0.12m; break;
                        case "B": tasaAnual = 0.15m; break;
                        case "C": tasaAnual = 0.18m; break;
                        default:
                            Console.WriteLine("Error: categoría inválida. Use A, B o C.");
                            break;
                    }
                } while (tasaAnual == 0m);

            } while (opcionCajero != 4);
            break;

                // Convertimos la tasa anual a mensual.
                decimal tasaMensual = tasaAnual / 12m;

                // Calculamos la cuota fija del préstamo.
                decimal potencia = (decimal)Math.Pow((double)(1m + tasaMensual), plazo);
                decimal cuota = monto * (tasaMensual * potencia) / (potencia - 1m);

                // Inicializamos las variables de la amortización.
                decimal saldoPrestamo = monto;
                decimal totalPagado = 0m;
                decimal totalIntereses = 0m;

                Console.WriteLine("\n Mes |        Cuota |      Interés | Abono a capital |        Saldo");

                // Recorremos cada mes para calcular los pagos.
                for (int mes = 1; mes <= plazo; mes++)
                {
                    decimal interes = saldoPrestamo * tasaMensual;
                    decimal abonoCapital = cuota - interes;
                    decimal pagoMes = cuota;

                    // Ajustamos el último pago para dejar el saldo en cero.
                    if (mes == plazo)
                    {
                        abonoCapital = saldoPrestamo;
                        pagoMes = abonoCapital + interes;
                    }

                    // Actualizamos el saldo y acumulamos los totales.
                    saldoPrestamo -= abonoCapital;
                    totalPagado += pagoMes;
                    totalIntereses += interes;

                    Console.WriteLine($"{mes,4} | {pagoMes.ToString("N2", cultura),12} | {interes.ToString("N2", cultura),12} | {abonoCapital.ToString("N2", cultura),15} | {saldoPrestamo.ToString("N2", cultura),12}");
                }

                // Presentamos el resumen del préstamo.
                Console.WriteLine("\nResumen del préstamo (valores en RD$)");
                Console.WriteLine($"Monto solicitado: {monto.ToString("N2", cultura)}\nCategoría: {categoria}");
                Console.WriteLine($"Tasa anual: {(tasaAnual * 100m).ToString("0.##", cultura)} %\nPlazo: {plazo} meses");
                Console.WriteLine($"Cuota mensual: {cuota.ToString("N2", cultura)}\nTotal pagado: {totalPagado.ToString("N2", cultura)}");
                Console.WriteLine($"Total de intereses pagados: {totalIntereses.ToString("N2", cultura)}\nSaldo final: {saldoPrestamo.ToString("N2", cultura)}");

                // Preguntamos si desea realizar otra simulación.
                do
                {
                    Console.Write("¿Desea simular otro préstamo? (S/N): ");
                    string? entradaRepetir = Console.ReadLine();
                    if (entradaRepetir is null) return;

                    repetir = entradaRepetir.Trim().ToUpperInvariant();

                    if (repetir != "S" && repetir != "N")
                        Console.WriteLine("Error: responda S o N.");

                } while (repetir != "S" && repetir != "N");

            } while (repetir == "S");
            break;

        // Opción para finalizar el programa.
        case 3:
            Console.WriteLine("Gracias por utilizar Cooperativa Ahorro Seguro. ¡Hasta pronto!");
            break;

        // Controlamos las opciones inválidas del menú principal.
        default:
            Console.WriteLine("Error: seleccione una opción del 1 al 3.");
            break;
    }
} while (opcionPrincipal != 3);
