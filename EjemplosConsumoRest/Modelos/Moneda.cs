using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemplosConsumoRest.Modelos {
    public class Moneda {
        public long id { get; set; }
        public string clave { get; set; }
        public string nombre { get; set; }
        public string clave_moneda_sat { get; set; }
    }
}
