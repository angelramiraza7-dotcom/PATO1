
using System;
using System.Collections.Generic;
using System.Threading;

namespace patos_estructuras
{
    class Programp
       {
        const int Ancho = 40;
        static readonly Random random = new Random();

        // Lista de posiciones de los objetos
        static readonly List<int> objetos = new List<int>();

        // Tipo de objeto en cada posición: P = pan, L = llave
        static readonly Dictionary<int, char> tiposObjetos =
            new Dictionary<int, char>();

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.Clear();

            int patoX = Ancho / 2;
            bool haciaDerecha = true;

            int panes = 0;
            int llaves = 0;

            GenerarObjetos();

            while (true)
            {
                // Entrada del teclado
                while (Console.KeyAvailable)
                {
                    ConsoleKey tecla = Console.ReadKey(true).Key;

                    if (tecla == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        Console.WriteLine("¡Juego terminado!");
                        Console.WriteLine($"Panes recogidos: {panes}");
                        Console.WriteLine($"Llaves recogidas: {llaves}");
                        Console.WriteLine($"Total de objetos: {panes + llaves}");

                        Console.CursorVisible = true;
                        return;
                    }

                    if (tecla == ConsoleKey.LeftArrow ||
                        tecla == ConsoleKey.A)
                    {
                        patoX--;
                        haciaDerecha = false;
                    }
                    else if (tecla == ConsoleKey.RightArrow ||
                             tecla == ConsoleKey.D)
                    {
                        patoX++;
                        haciaDerecha = true;
                    }
                }

                // Limitar el movimiento del pato
                patoX = Math.Clamp(patoX, 0, Ancho - 3);

                // Revisar si el pato recoge objetos
                for (int i = objetos.Count - 1; i >= 0; i--)
                {
                    int posicion = objetos[i];

                    if (posicion >= patoX && posicion < patoX + 3)
                    {
                        char tipo = tiposObjetos[posicion];

                        if (tipo == 'P')
                        {
                            panes++;
                        }
                        else if (tipo == 'L')
                        {
                            llaves++;
                        }

                        tiposObjetos.Remove(posicion);
                        objetos.RemoveAt(i);
                    }
                }

                // Mantener cinco objetos en pantalla
                GenerarObjetos();

                // Dibujar escenario
                char[] linea = new char[Ancho];
                Array.Fill(linea, '.');

                foreach (int posicion in objetos)
                {
                    linea[posicion] = tiposObjetos[posicion];
                }

                // Dibujar pato
                string pato = haciaDerecha ? "(o>" : "<o)";

                for (int i = 0; i < 3; i++)
                {
                    linea[patoX + i] = pato[i];
                }

                // Mostrar información
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("======= JUEGO DEL PATO =======");
                Console.WriteLine("Mover: Flechas o A/D | Salir: Esc");
                Console.WriteLine("P = Pan | L = Llave");
                Console.WriteLine();

                Console.WriteLine(new string(linea));

                Console.WriteLine();
                Console.WriteLine($"Panes recogidos: {panes}     ");
                Console.WriteLine($"Llaves recogidas: {llaves}   ");
                Console.WriteLine($"Total de objetos: {panes + llaves}   ");

                Thread.Sleep(50);
            }
        }

        static void GenerarObjetos()
        {
            while (objetos.Count < 5)
            {
                int posicion = random.Next(0, Ancho);

                if (!objetos.Contains(posicion))
                {
                    char tipo = random.Next(0, 2) == 0 ? 'P' : 'L';

                    objetos.Add(posicion);
                    tiposObjetos.Add(posicion, tipo);
                }
            }
        }
    }
}
