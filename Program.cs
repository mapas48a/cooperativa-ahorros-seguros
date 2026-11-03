
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
