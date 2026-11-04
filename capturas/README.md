Capturas del proyecto Cooperativa Ahorro Seguro.

Cooperativa Ahorro Seguro

Asignatura: Algoritmos Computacionales  
Actividad: Estructuras de control  
Profesor: Gamalier Reyes del Carmen  
Lenguaje:C#
1. Integrantes
Jhesmi Malvelis Alcántara Dipre | 26-2-EISN-021 
Alexander Rodriguez | 26-EISN-2-010 
Genny Yunior Sánchez Tavarez | 26-EISN-2-030 
Jonathan Sanchez | 26-EISN-2-041 
Oreily Esther Daniel Ramos | 26-EISN-2-029 

2. Descripción

Cooperativa Ahorro Seguro es una aplicación de consola desarrollada en C# que simula dos servicios financieros mediante un menú principal.

Ejercicio 1 — Cajero automático: permite consultar saldo, depositar y retirar dinero mediante un PIN de cuatro dígitos. Cuenta con tres intentos de acceso, saldo inicial de RD$10,000 y validaciones para evitar operaciones incorrectas.

Ejercicio 2 — Simulador de préstamo: permite calcular préstamos de RD$5,000 a RD$500,000, con plazos de 6 a 60 meses y tasas anuales del 12%, 15% o 18%, según la categoría del socio. Genera una tabla de amortización y muestra los totales pagados.

3. Datos de entrada

Cajero automático:

- PIN de cuatro dígitos.
- Opción del menú.
- Monto a depositar o retirar.

Simulador de préstamo:

- Monto solicitado.
- Plazo en meses.
- Categoría del socio (A, B o C).
- Respuesta para realizar otra simulación (S/N).

4. Datos que procesa

Cajero automático: valida el PIN y los montos ingresados, actualiza el saldo, verifica que los retiros sean múltiplos de RD$100 y contabiliza las operaciones válidas de cada sesión.

Simulador de préstamo: valida los datos, asigna la tasa de interés correspondiente y calcula la cuota mensual fija mediante la fórmula:

Cuota = Monto × [i × (1 + i)^n] / [(1 + i)^n − 1]

Donde i representa la tasa mensual y n la cantidad de meses.

Posteriormente calcula los intereses, abonos a capital y saldo pendiente de cada mes.

5. Datos de salida

Cajero automático:

Confirmación de acceso o bloqueo.
Saldo disponible.
Confirmación de depósitos y retiros.
Mensajes de error.
Cantidad de depósitos, retiros y saldo final.

Simulador de préstamo:

Cuota mensual.
Tabla de amortización.
Total pagado e intereses.
Saldo final.
Mensajes de validación.

6. Tecnología utilizada

C#: lenguaje de programación.
.NET 10:plataforma de ejecución.
Visual Studio Community: entorno de desarrollo.
Git y GitHub:control de versiones y repositorio.

Estructuras utilizadas:if, else if, else, switch, for,while, do-while y TryParse.

7. Capturas de pantalla

Ejercicio 1 — Cajero automático

Captura 1: Depósito y retiro exitosos

Se realiza un depósito de RD$2,000 y un retiro de RD$1,000, obteniendo un saldo final de RD$11,000.

Nombre del archivo:cajero-exitoso.png

![Cajero automático - Depósito y retiro exitosos](capturas/cajero-exitoso.png)

Captura 2: Validación de errores

Se muestran intentos de PIN incorrectos y un retiro rechazado por saldo insuficiente.

Nombre del archivo:cajero-error.png

![Cajero automático - Validación de errores](capturas/cajero-error.png)

Ejercicio 2 — Simulador de préstamo

Captura 3: Simulación exitosa

Préstamo de RD$10,000 a 6 meses, categoría A, con cuota mensual aproximada de RD$1,725.48 y tabla de amortización.

Nombre del archivo:prestamo-exitoso.png

![Simulador de préstamo - Simulación exitosa](capturas/prestamo-exitoso.png)

Captura 4: Validación de errores

Se muestran errores al introducir un monto inferior al mínimo, un plazo inválido y una categoría no permitida.

Nombre del archivo:prestamo-error.png

![Simulador de préstamo - Validación de errores](capturas/prestamo-error.png)

8. Cómo ejecutar el programa

1. Descargar o clonar el repositorio.
2. Abrir el proyecto en Visual Studio Community.
3. Ejecutar con Ctrl + F5.

También se puede ejecutar desde la carpeta del proyecto mediante:

bash
dotnet run


PIN de prueba:1234.
