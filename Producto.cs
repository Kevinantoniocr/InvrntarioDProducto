﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioDProductos
{

    internal class Producto
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public Producto(string nombre, decimal precio)
        {
            Nombre = nombre;
            Precio = precio;
        }
        public void MostrarInformacion()
        {
            Console.WriteLine($"Producto: {Nombre}");
            Console.WriteLine($"Precio: {Precio:C}");
        }
    }
}

