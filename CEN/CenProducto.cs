﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN
{
    public class CenProducto
    {
        public int? Id { get; set; }
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public int? Stock { get; set; }
        public string? Estado { get; set; }
        public double Peso { get; set; }
    }
}
