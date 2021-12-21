using EjemplosConsumoRest.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemplosConsumoRest {
    public class Articulo {
        public long id { get; set; }
        public string clave { get; set; }
        public string nombre { get; set; }
        public long clasificacion_id { get; set; }
        public long moneda_id { get; set; }

        public List<PrecioPorMoneda> precios_por_moneda { get; set; } = new List<PrecioPorMoneda>();

        public List<Existencia> existencias { get; set; } = new List<Existencia>();

        public List<Promocion> promociones { get; set; } = new List<Promocion>();

        public List<CodigoAdicional> codigos_adicionales { get; set; } = new List<CodigoAdicional>();

    }
}
