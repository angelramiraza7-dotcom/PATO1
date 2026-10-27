using System;
using System.Collections.Generic;
using System.Threading;

namespace patos_estructuras
{
    class Program
    {
        const int Ancho = 40;
        static readonly Random random = new Random();
        static readonly List<int> objetos = new List<int>();

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.Clear();

            int patoX = Ancho / 2;
            bool haciaDerecha = true;
            int puntos = 0;

            GenerarObjetos();

            while (true)
            {
                // Entrada del teclado
                while (Console.KeyAvailable)
                {
                    var tecla = Console.ReadKey(true).Key;

                    if (tecla == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        Console.WriteLine($"¡Juego terminado! Objetos recogidos: {puntos}");
                        Console.CursorVisible = true;
                        return;
                    }
                    if (tecla == ConsoleKey.LeftArrow || tecla == ConsoleKey.A)
                    {
                        patoX--;
                        haciaDerecha = false;
                    }
                    if (tecla == ConsoleKey.RightArrow || tecla == ConsoleKey.D)
                    {
                        patoX++;
                        haciaDerecha = true;
                    }
                }

                // Limitar el movimiento a la pantalla
                patoX = Math.Clamp(patoX, 0, Ancho - 3);

                // Recoger objetos (el pato ocupa 3 caracteres)
                int recogidos = objetos.RemoveAll(x => x >= patoX && x < patoX + 3);
                if (recogidos > 0)
                {
                    puntos += recogidos;
                    GenerarObjetos();
                }

                // Dibujar
                char[] linea = new char[Ancho];
                Array.Fill(linea, '.');

                foreach (int x in objetos)
                    linea[x] = '*';

                string pato = haciaDerecha ? "(o>" : "<o)";
                for (int i = 0; i < 3; i++)
                    linea[patoX + i] = pato[i];

                Console.SetCursorPosition(0, 0);
                Console.WriteLine("=== JUEGO DEL PATO ===");
                Console.WriteLine("Mover: flechas o A/D | Salir: Esc");
                Console.WriteLine();
                Console.WriteLine(new string(linea));
                Console.WriteLine();
                Console.WriteLine($"Objetos recogidos: {puntos}   ");

                Thread.Sleep(50);
            }
        }

        static void GenerarObjetos()
        {
            while (objetos.Count < 5)
            {
                int pos = random.Next(0, Ancho);
                if (!objetos.Contains(pos))
                    objetos.Add(pos);
            }
        }
    }
}