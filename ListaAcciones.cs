using System;
using System.Collections.Generic;

namespace patos_estructuras
{
    public class ListaAcciones
    {
        private List<string> acciones = new List<string>();

        // INSERTAR
        public void AgregarAccion(string accion)
        {
            acciones.Add(accion);
        }

        // MOSTRAR
        public void MostrarAcciones()
        {
            Console.WriteLine("\n=== ACCIONES DEL PATO ===");

            foreach (string accion in acciones)
            {
                Console.WriteLine("- " + accion);
            }
        }

        // BUSCAR
        public bool BuscarAccion(string accion)
        {
            return acciones.Contains(accion);
        }

        // ELIMINAR
        public void EliminarAccion(string accion)
        {
            acciones.Remove(accion);
        }

        // DEMOSTRACIÓN
        public static void Demo()
        {
            ListaAcciones lista = new ListaAcciones();

            // Acciones del escape room
            lista.AgregarAccion("Explorar escenario");
            lista.AgregarAccion("Buscar pistas escondidas");
            lista.AgregarAccion("Recoger objetos");
            lista.AgregarAccion("Resolver acertijos");
            lista.AgregarAccion("Utilizar inventario");
            lista.AgregarAccion("Desbloquear puertas");
            lista.AgregarAccion("Activar mecanismos secretos");
            lista.AgregarAccion("Escapar de la casa");

            Console.WriteLine("LISTA ORIGINAL:");
            lista.MostrarAcciones();

            Console.WriteLine();

            // Buscar
            if (lista.BuscarAccion("Resolver acertijos"))
            {
                Console.WriteLine("✓ La acción 'Resolver acertijos' existe.");
            }

            Console.WriteLine();

            // Eliminar
            lista.EliminarAccion("Utilizar inventario");

            Console.WriteLine("LISTA DESPUÉS DE ELIMINAR:");
            lista.MostrarAcciones();
        }
    }
}