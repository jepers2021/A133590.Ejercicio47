using System;
using System.Collections.Generic;

namespace A133590.Ejercicio47
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ejercicio 47");
            Queue<string> cola = new Queue<string>();
            string[] cajas = new string[3];
            cajas[0] = cajas[1] = cajas[2] = null;

            while (true)
            {
                Console.Write("> ");
                string comando = Console.ReadLine().Trim();
                if (comando.Length == 0)
                {
                    Console.WriteLine("Comando inválido.");
                    continue;
                }
                string[] cadenasComando = comando.Split(":");



                switch (cadenasComando[0])
                {
                    case "afiliado":
                        if (cadenasComando.Length < 2)
                        {
                            Console.WriteLine("Comando correcto, error de sintaxis.");
                            break;
                        }

                        bool exito = true;
                        foreach (char c in cadenasComando[1]) exito &= Char.IsLetter(c);

                        if (exito)
                        {

                            for(int i = 0; i < 4; i++)
                            {
                                if(i == 3)
                                {
                                    Console.WriteLine("No hay caja disponible, encolando..");
                                    cola.Enqueue(cadenasComando[1]);
                                    break;
                                }
                                if (cajas[i] == null)
                                {
                                    cajas[i] = cadenasComando[1];
                                    Console.WriteLine($"Asignado a caja {i + 1}.");
                                    break;
                                }
                            }
                        }
                        else Console.WriteLine("No se admiten caracteres especiales o dígitos en los nombres.");
                        break;
                    case "caja":
                        if (cadenasComando.Length < 2)
                        {
                            Console.WriteLine("Comando correcto, error de sintaxis.");
                            break;
                        }
                        int indice = -1;
                        if (Int32.TryParse(cadenasComando[1], out indice))
                        {
                            if (indice >= 1 && indice <= 3)
                            {
                                cajas[indice - 1] = null;
                                if(cola.Count == 0)
                                {
                                    Console.WriteLine($"Se liberó la caja {indice}, pero la cola está vacía.");
                                }
                                else
                                {
                                    string nombre = cola.Dequeue();
                                    Console.WriteLine($"Se liberó la caja {indice}, asignando a {nombre}");
                                    cajas[indice - 1] = nombre;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Error: Número fuera del rango. Ingrese un número entre 1 y 3.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error de sintaxis. caja:[n] donde n debe ser un número entre 1 y 3.");
                        }
                        break;
                    case "fin":
                        Console.WriteLine("Presione cualquier tecla para continuar..");
                        Console.ReadKey();
                        return;
                    default:
                        Console.WriteLine("Comando inválido. Comandos disponibles: ");
                        Console.WriteLine("afliado:[Nombre]");
                        Console.WriteLine("caja:[n]");
                        Console.WriteLine("fin");
                        continue;
                }

                
                Console.WriteLine("Status:");
                Console.WriteLine(" Cola:");
                if (cola.Count == 0) Console.WriteLine(" Vacía");
                foreach(string s in cola)
                {
                    Console.WriteLine($"    {s}");
                }
                Console.WriteLine(" Cajas:");
                for(int i = 0; i < 3; i++)
                {
                    string statusCaja = cajas[i] == null ? "Libre" : cajas[i];
                    Console.WriteLine($"    Caja {i + 1} {statusCaja}");
                }


            }

        }
    }
}
