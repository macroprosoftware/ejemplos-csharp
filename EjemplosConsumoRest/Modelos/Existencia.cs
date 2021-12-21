using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemplosConsumoRest {

    public class Existencia {

        public long id { get; set; }
        public double cantidad_existencia { get; set; }
        public double cantidad_transito { get; set; }
        public double valor { get; set; }
        public long articulo_id { get; set; }
        public long almacen_id { get; set; }

        public Existencia() {
        }
    }
}
