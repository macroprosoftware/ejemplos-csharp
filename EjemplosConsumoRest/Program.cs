using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;

namespace EjemplosConsumoRest {
    class Program {

        // Configuración
        public const string Url = "http://74.208.252.127:8080";
        public const string Tenant = "su_tenant";

        /// <summary>
        /// Este es el objeto que se utiliza para hacer TODAS las peticiones. 
        /// Idealmente solo debe haber 1 en todo el programa, por el tema de las sesiones y la autenticación.
        /// </summary>
        static RestClient client = new RestClient(Url);

        static void Main(string[] args) {
            Configurar();

            // Iniciamos sesión antes que nada. Si no, no podemos consultar
            IniciarSesion();

            // Consultamos las existencias del almacen 2
            List<Existencia> existencias = ConsultarExistencias(2);

            // Revisamos que nos llegó
            Console.WriteLine($"Se recibieron {existencias.Count} registros de existencias");
            foreach (Existencia existencia in existencias) {
                Console.WriteLine($"articulo:{existencia.articulo_id}, cantidad:{existencia.cantidad_existencia}, valor:{existencia.valor}");
            }
            Console.ReadLine();
        }

        public static void Configurar() {

            /// Necesario para que funcione la autenticación. Aquí se guarda la sesión.
            client.CookieContainer = new System.Net.CookieContainer();

            /// Esta configuración es para que, si el servidor de Macronnect tira un error, 
            /// en C# también aparezca el error como una Exception. 
            /// Sin esto, sería necesario validar manualmente en cada llamada a los servicios, para ver si ocurrió un error o no.
            client.ThrowOnAnyError = true;
        }

        /// <summary>
        /// Ejemplo simple de como iniciar sesión.
        /// </summary>
        public static void IniciarSesion() {

            var request = new RestRequest("login", DataFormat.Json);
            request.AddJsonBody(new {
                usuario = "ADMIN",
                contrasena = "12345",
                uuid = "0000-0000-0000-INSOMNIA-UUID",
                tipo_sesion = "ESCRITORIO",
                direccion_mac = "00:00:00:00:00",
                reemplazar = true
            });
            var respuesta = client.Post(request);

            Console.WriteLine(respuesta.Content);
        }

        /// <summary>
        /// Ejemplo simple de cómo hacer un método que consulte las existencias de un almacen en especifico.
        /// </summary>
        /// <returns></returns>
        public static List<Existencia> ConsultarExistencias(long idAlmacen) {
            var request = new RestRequest("api/v1/inventarios/existencias");
            request.AddHeader("tenantId", Tenant);

            request.AddParameter("limit", 100);
            request.AddParameter("offset", 0);
            request.AddParameter("inv-almacen-id", idAlmacen);
            request.AddParameter("cantidad-existencia[gt]", 0);

            var respuesta = client.Get<List<Existencia>>(request);

            Console.WriteLine(respuesta.Content);

            List<Existencia> existencia = respuesta.Data;
            return existencia;
        }
    }
}
