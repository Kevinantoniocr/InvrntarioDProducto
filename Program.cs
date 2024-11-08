using System;
using System.Collections.Generic;
using System.Linq;
using InventarioDProductos;

namespace InventarioDProductos
{
    class Program
    {
        static void Main(string[] args)
        {
            Inventario inventaro = new Inventario();
            Console.WriteLine("Bienvenido a nuestro sistema de gestión de inventario");
            Console.WriteLine("¿Cuántos productos desea ingresar?");
            int cantidad;
            while (!int.TryParse(Console.ReadLine(), out cantidad) || cantidad <= 0)
            {
                Console.WriteLine("Por favor, ingrese una cantidad válida de productos.");
            }
            for (int i = 0; i < cantidad; i++)
            {
                Console.WriteLine($"\nProducto {i + 1}:");
                string nombre;
                do
                {
                    Console.Write("Nombre: ");
                    nombre = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(nombre))
                    {
                        Console.WriteLine("El nombre no puede estar vacío.");
                    }
                } while (string.IsNullOrWhiteSpace(nombre));
                decimal precio;
                do
                {
                    Console.Write("Precio: ");
                    if (!decimal.TryParse(Console.ReadLine(), out precio) || precio <= 0)
                    {
                        Console.WriteLine("Por favor, ingrese un precio válido y positivo.");
                    }
                } while (precio <= 0);
                Producto producto = new Producto(nombre, precio);
                inventaro.AgregarProducto(producto);
            }

            // Actualizar precio de un producto
            Console.WriteLine("\n¿Desea actualizar el precio de algún producto? (sí/no)");
            if (Console.ReadLine().ToLower() == "sí")
            {
                Console.Write("Ingrese el nombre del producto a actualizar: ");
                string nombreProducto = Console.ReadLine();
                Console.Write("Ingrese el nuevo precio: ");
                decimal nuevoPrecio;
                if (decimal.TryParse(Console.ReadLine(), out nuevoPrecio) && nuevoPrecio > 0)
                {
                    inventaro.ActualizarPrecioProducto(nombreProducto, nuevoPrecio);
                }
                else
                {
                    Console.WriteLine("Precio inválido.");
                }
            }
            // Eliminar un producto
            Console.WriteLine("\n¿Desea eliminar algún producto? (sí/no)");
            if (Console.ReadLine().ToLower() == "sí")
            {
                Console.Write("Ingrese el nombre del producto a eliminar: ");
                string nombreEliminar = Console.ReadLine();
                inventaro.EliminarProductoPorNombre(nombreEliminar);
            }
            // Generar reporte
            inventaro.GenerarReporteInventario();
            // Agrupar productos por rango de precios
            inventaro.ContarYAgruparProductos();
        }
    }
}