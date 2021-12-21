using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemplosConsumoRest {
    public class PrecioPorMoneda {
        public long orden { get; set; }
        public double precio { get; set; }
        public double margen { get; set; }
        public long moneda_id { get; set; }
    }
}
