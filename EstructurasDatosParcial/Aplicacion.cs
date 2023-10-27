using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstructurasDatosParcial
{
    public class Aplicacion
    {
        private NodoInventario primerNodo;
        private NodoInventario ultimoNodo;

        public Aplicacion() 
        {
            while (true)
            {
                Console.WriteLine("\nMenú");
                Console.WriteLine("1. Registrar artículos");
                Console.WriteLine("2. Mostrar el listado de los elementos almacenados.");
                Console.WriteLine("3. Mostrar el promedio de cantidad de artículos.");
                Console.WriteLine("4. Mostrar el artículo más y menos costoso.");
                Console.WriteLine("5. Calcular el valor total recaudado.");
                Console.WriteLine("6. Salir");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        RegistrarArticulo();
                        break;
                    case "2":
                        if(!EsNulo())
                            MostrarListado();
                        break;
                    case "3":
                        if (!EsNulo())
                            MostrarPromedio();
                        break;
                    case "4":
                        if (!EsNulo())
                            ArticuloMasMenosCostoso();
                        break;
                    case "5":
                        if (!EsNulo())
                            CalcularValorTotal();
                        break;
                    case "6":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Elija una opción válida.");
                        break;
                }
            }

        }

        public void RegistrarArticulo()
        {
            Console.WriteLine("Ingrese el nombre del artículo");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el precio del artículo");
            decimal precio = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese la cantidad de artículos");
            int cant = int.Parse(Console.ReadLine());

            NodoInventario nuevoNodo = new NodoInventario(nombre, cant, precio);

            if (primerNodo == null)
            {
                primerNodo = nuevoNodo;
                ultimoNodo = nuevoNodo;
            }
            else
            {
                ultimoNodo.Siguiente = nuevoNodo;
                ultimoNodo = nuevoNodo;
            }
        }

        public void MostrarListado()
        {
            Console.WriteLine("Listado de elementos almacenados:");
            NodoInventario nodoActual = primerNodo;

            while (nodoActual != null)
            {
                Console.WriteLine($"Nombre: {nodoActual.Nombre}, Cantidad: {nodoActual.Cantidad}, Precio: $ {nodoActual.Precio}");
                nodoActual = nodoActual.Siguiente;
            }
        }

        public void MostrarPromedio()
        {
            if (primerNodo == null)
            {
                Console.WriteLine("No hay artículos en el inventario.");
                return;
            }

            int contador = 0;
            int sumaCantidad = 0;

            NodoInventario nodoActual = primerNodo;

            while (nodoActual != null)
            {
                sumaCantidad += nodoActual.Cantidad;
                contador++;
                nodoActual = nodoActual.Siguiente;
            }

            decimal promedio = sumaCantidad / contador;

            Console.WriteLine($"El promedio de las cantidades de los artículos es: {promedio}");
        }

        public void CalcularValorTotal()
        {
            NodoInventario nodoActual = primerNodo;

            decimal sumaTotal = 0;

            while (nodoActual != null)
            {
                sumaTotal = nodoActual.Cantidad * nodoActual.Precio;
                nodoActual = nodoActual.Siguiente;
            }

            Console.WriteLine($"La suma total de lo recaudado es: {sumaTotal}");
        }

        public void ArticuloMasMenosCostoso()
        {
            NodoInventario nodoActual = primerNodo;
            NodoInventario nodoCostoso = primerNodo;
            NodoInventario nodoMenosCostoso = primerNodo;

            while (nodoActual != null)
            {
                if (nodoActual.Precio > nodoCostoso.Precio)
                {
                    nodoCostoso = nodoActual;
                }
                if (nodoActual.Precio < nodoMenosCostoso.Precio)
                {
                    nodoMenosCostoso = nodoActual;
                }

                nodoActual = nodoActual.Siguiente;
            }

            Console.WriteLine($"El artículo más costoso es: ");
            Console.WriteLine($"Nombre: {nodoCostoso.Nombre}, Cantidad: {nodoCostoso.Cantidad}, Precio: $ {nodoCostoso.Precio} \n");

            Console.WriteLine($"El artículo menos costoso es: ");
            Console.WriteLine($"Nombre: {nodoMenosCostoso.Nombre}, Cantidad: {nodoMenosCostoso.Cantidad}, Precio: $ {nodoMenosCostoso.Precio} \n");
        }

        public bool EsNulo()
        {
            if (primerNodo == null)
            {
                Console.WriteLine("No hay artículos en el inventario.");
                return true;
            }
            else
            {
                return false;
            }
        }

    }

    class NodoInventario
    {
        public string Nombre { get; }
        public int Cantidad { get; }
        public decimal Precio { get; }
        public NodoInventario Siguiente { get; set; }

        public NodoInventario(string nombre, int cantidad, decimal precio)
        {
            Nombre = nombre;
            Cantidad = cantidad;
            Precio = precio;
            Siguiente = null;
        }
    }

}
