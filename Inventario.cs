using System;
using System.Collections.Generic;

namespace patos_estructuras
{
    // Clase que define las propiedades de un objeto del juego
    public class Item
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public char Simbolo { get; set; }

        public Item(string nombre, string descripcion, char simbolo)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            Simbolo = simbolo;
        }
    }

    // Gestor estático que administra el inventario del jugador
    public static class GestorInventario
    {
        public static List<Item> InventarioJugador = new List<Item>();
        private static int indiceSeleccionado = 0;

        // Catálogo de objetos posibles que pueden aparecer en el mapa
        private static readonly List<Item> CatalogoObjetos = new List<Item>
        {
            new Item("Pan Doradito", "Un trozo crujiente de pan ideal para alimentar patos.", '*'),
            new Item("Pluma Brillante", "Una pluma mítica que brilla con la luz del sol.", 'f'),
            new Item("Trébol de la Suerte", "Se dice que otorga fortuna y velocidad al pato.", '♣'),
            new Item("Guisante Mágico", "Pequeño pero con una energía extraña y nutritiva.", 'o')
        };

        // Devuelve un objeto aleatorio del catálogo
        public static Item ObtenerItemAleatorio()
        {
            Random rnd = new Random();
            int index = rnd.Next(CatalogoObjetos.Count);
            return CatalogoObjetos[index];
        }

        // Añade un objeto al inventario
        public static void AgregarItem(Item item)
        {
            InventarioJugador.Add(item);
        }

        // Muestra la interfaz gráfica del inventario con scroll y descripciones
        public static void MostrarInventario()
        {
            bool enInventario = true;
            
            while (enInventario)
            {
                indiceSeleccionado = Math.Clamp(indiceSeleccionado, 0, Math.Max(0, InventarioJugador.Count - 1));
                
                Console.Clear();
                Console.WriteLine("=== INVENTARIO DEL PATO ===");
                Console.WriteLine("Navega: W/S o Flechas Arriba/Abajo | Salir: ESC o 'I'");
                Console.WriteLine(new string('-', 50));

                if (InventarioJugador.Count == 0)
                {
                    Console.WriteLine("\n¡Tu inventario está vacío! Sal a recolectar objetos en el mapa.");
                }
                else
                {
                    // Listar los objetos almacenados
                    for (int i = 0; i < InventarioJugador.Count; i++)
                    {
                        if (i == indiceSeleccionado)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($" > [{InventarioJugador[i].Simbolo}] {InventarioJugador[i].Nombre} <");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.WriteLine($"   [{InventarioJugador[i].Simbolo}] {InventarioJugador[i].Nombre}");
                        }
                    }

                    Console.WriteLine(new string('-', 50));
                    Console.WriteLine("--- DESCRIPCIÓN ---");
                    Console.WriteLine($"Objeto: {InventarioJugador[indiceSeleccionado].Nombre}");
                    Console.WriteLine($"Detalle: {InventarioJugador[indiceSeleccionado].Descripcion}");
                }

                // Controles dentro del menú de inventario
                var tecla = Console.ReadKey(true).Key;
                if (tecla == ConsoleKey.Escape || tecla == ConsoleKey.I)
                {
                    enInventario = false;
                }
                else if (tecla == ConsoleKey.UpArrow || tecla == ConsoleKey.W)
                {
                    if (indiceSeleccionado > 0) indiceSeleccionado--;
                }
                else if (tecla == ConsoleKey.DownArrow || tecla == ConsoleKey.S)
                {
                    if (indiceSeleccionado < InventarioJugador.Count - 1) indiceSeleccionado++;
                }
            }
            Console.Clear();
        }
    }
}