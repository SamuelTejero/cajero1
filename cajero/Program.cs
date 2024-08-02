using System;
using System.IO;

class Program
{
    static void Main()
    {
        string[,] cuentas = new string[3, 3]
        {
             { "52232367", "4525", "5000" },
             { "1022334968", "3658", "10000" },
             { "3450689", "4558", "15000" }
        };

        while (true)
        {
            Console.WriteLine("Ingrese su usuario:");
            string usuario = Console.ReadLine();
            Console.WriteLine("Ingrese su contraseña:");
            string contrasena = Console.ReadLine();

            int indiceCuenta = -1;
   
            for (int i = 0; i < cuentas.GetLength(0); i++)
            {
                if (cuentas[i, 0] == usuario && cuentas[i, 1] == contrasena)
                {
                    indiceCuenta = i;
                    break;
                }
            }

            if (indiceCuenta != -1) 
            {
                while (true)
                {
                    Console.WriteLine("1. Retirar dinero");
                    Console.WriteLine("2. Consignar dinero");
                    Console.WriteLine("3. Consultar saldo");
                    Console.WriteLine("4. Cambiar contraseña");
                    Console.WriteLine("5. Imprimir recibo");
                    Console.WriteLine("6. Salir");
                    string opcion = Console.ReadLine();

                    switch (opcion)
                    {
                        case "1":
                            Console.WriteLine("Ingrese la cantidad a retirar:");
                            decimal retiro = decimal.Parse(Console.ReadLine());
                            if (retiro <= decimal.Parse(cuentas[indiceCuenta, 2]))
                            {
                                cuentas[indiceCuenta, 2] = (decimal.Parse(cuentas[indiceCuenta, 2]) - retiro).ToString();
                                Console.WriteLine("Retiro exitoso.");
                            }
                            else
                            {
                                Console.WriteLine("Saldo insuficiente.");
                            }
                            break;
                        case "2":
                            Console.WriteLine("Ingrese la cantidad a consignar:");
                            decimal consignacion = decimal.Parse(Console.ReadLine());
                            cuentas[indiceCuenta, 2] = (decimal.Parse(cuentas[indiceCuenta, 2]) - consignacion).ToString();
                            Console.WriteLine("Consignación exitosa.");
                            break;
                        case "3":
                            Console.WriteLine($"Su saldo es: {cuentas[indiceCuenta, 2]}");
                            break;
                        case "4":
                            Console.WriteLine("Ingrese su nueva contraseña:");
                            cuentas[indiceCuenta, 1] = Console.ReadLine();
                            Console.WriteLine("Contraseña cambiada exitosamente.");
                            break;
                        case "5":
                            string path = "C:\\Users\\Samuel\\Desktop\\prueba.txt";
                            try
                            {
                                StreamWriter sw = new StreamWriter(path);
                                sw.WriteLine($"Usuario: {usuario}");
                                sw.WriteLine($"Saldo: {cuentas[indiceCuenta, 2]}");
                                sw.Close();
                                Console.WriteLine("Recibo impreso exitosamente.");
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Exception: " + e.Message);
                            }
                            finally
                            {
                                Console.WriteLine("Ejecutando bloque finally.");
                            }
                            break;
                        case "6":
                            return;
                        default:
                            Console.WriteLine("Opción inválida.");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Credenciales incorrectas.");
            }
        }

    }
}