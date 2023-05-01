using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Data.Model
{
    public   class Parqueadero
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int Capacidad { get; set; }
        public double TarifaHora { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
