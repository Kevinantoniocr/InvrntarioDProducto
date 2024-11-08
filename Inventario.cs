using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace InventarioDProductos
{
    internal class Inventario
    {
        private List<Producto> productos;
        public Inventario()
        {
            productos = new List<Producto>();
        }
        public void AgregarProducto(Producto producto)
        {
            productos.Add(producto);
            Console.WriteLine($"Producto '{producto.Nombre}' agregado al inventario.");
        }
        public void ActualizarPrecioProducto(string nombre, decimal nuevoPrecio)
        {
            var producto = productos.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (producto != null)
            {
                producto.Precio = nuevoPrecio;
                Console.WriteLine($"El precio del producto '{nombre}' ha sido actualizado a {nuevoPrecio}.");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }
        public void EliminarProductoPorNombre(string nombre)
        {
            var producto = productos.FirstOrDefault(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (producto != null)
            {
                productos.Remove(producto);
                Console.WriteLine($"Producto '{nombre}' eliminado del inventario.");
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }
        public void ContarYAgruparProductos()
        {
            var grupos = new
            {
                MenoresDe100 = productos.Count(p => p.Precio < 100),
                Entre100y500 = productos.Count(p => p.Precio >= 100 && p.Precio <= 500),
                MayoresDe500 = productos.Count(p => p.Precio > 500)
            };
            Console.WriteLine($"\nProductos en rango de precios:");
            Console.WriteLine($"Menores de $100: {grupos.MenoresDe100}");
            Console.WriteLine($"Entre $100 y $500: {grupos.Entre100y500}");
            Console.WriteLine($"Mayores de $500: {grupos.MayoresDe500}");
        }
        public void GenerarReporteInventario()
        {
            Console.WriteLine("\nReporte del Inventario:");
            int totalProductos = productos.Count;
            decimal precioPromedio = totalProductos > 0 ? productos.Average(p => p.Precio) : 0;
            var productoMasCaro = productos.OrderByDescending(p => p.Precio).FirstOrDefault();
            var productoMasBarato = productos.OrderBy(p => p.Precio).FirstOrDefault();
            Console.WriteLine($"Número total de productos: {totalProductos}");
            Console.WriteLine($"Precio promedio de los productos: {precioPromedio:C}");
            Console.WriteLine($"Producto con el precio más alto: {(productoMasCaro != null ? productoMasCaro.Nombre + " :" + productoMasCaro.Precio : "N/A")}");
            Console.WriteLine($"Producto con el precio más bajo: {(productoMasBarato != null ? productoMasBarato.Nombre + " : " + productoMasBarato.Precio : "N/A")}");
        }
    }
}
