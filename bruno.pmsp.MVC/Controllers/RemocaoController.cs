using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using bruno.pmsp.domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace bruno.pmsp.MVC.Controllers {
    public class RemocaoController : Controller {
        public static double CalcularDistancia (double origem_lat, double destino_lat, double origem_lng, double destino_lng) {
            double x1 = origem_lat;
            double x2 = destino_lat;
            double y1 = origem_lng;
            double y2 = destino_lng;

            // Distancia entre os 2 pontos no plano cartesiano ( pitagoras )
            //double distancia = System.Math.Sqrt( System.Math.Pow( (x2 - x1), 2 ) + System.Math.Pow( (y2 - y1), 2 ) );

            // ARCO AB = c 
            double c = 90 - (y2);

            // ARCO AC = b 
            double b = 90 - (y1);

            // Arco ABC = a 
            // Diferença das longitudes: 
            double a = x2 - x1;

            // Formula: cos(a) = cos(b) * cos(c) + sen(b)* sen(c) * cos(A) 
            double cos_a = Math.Cos (b) * Math.Cos (c) + Math.Sin (c) * Math.Sin (b) * Math.Cos (a);

            double arc_cos = Math.Acos (cos_a);

            // 2 * pi * Raio da Terra = 6,28 * 6.371 = 40.030 Km 
            // 360 graus = 40.030 Km 
            // 3,2169287 = x 
            // x = (40.030 * 3,2169287)/360 = 357,68 Km 

            double distancia = (40030 * arc_cos) / 360;

            return distancia;
        }

        public static int validarNumero(string numero) 
        {
            var num = 0;
            if(Int32.TryParse(numero, out num))
            {
                num = Convert.ToInt32(num);
            }
            return num;
        } 

        public static string formatarCep(string cep) 
        {
            cep = "0" + cep.Substring(0, 4) + "-" + cep.Substring(3, 3);
            return cep;
        }

        public static double formatarCoord(string coord)
        {
            if(coord == null || coord == "")
            {
                return 0;
            }

            var currentCulture = System.Globalization.CultureInfo.InstalledUICulture;
            var numberFormat = (System.Globalization.NumberFormatInfo) currentCulture .NumberFormat.Clone();
            numberFormat .NumberDecimalSeparator = "."; 

            double formCoord = Double.Parse(coord.Substring(0, 3) + "." + coord.Substring(3, 6), numberFormat);
            return formCoord;
        }

        public IActionResult Index () {
            WebClient client = new WebClient ();
            var dados = client.DownloadString ("http://dados.prefeitura.sp.gov.br/api/action/datastore_search_sql?sql=SELECT%20*%20from%20%22dfa2e046-b975-4ff5-983f-dacfd8cb06b2%22");
          
            dynamic result = JsonConvert.DeserializeObject<RootObject>(dados);
            var retorno = new List<Escola>();           

            foreach(var obj in result.result.records)
            {
                

                var escola = new Escola(obj.DRE, obj.TIPOESC, obj.REDE, obj.CODINEP, obj.NOMESC, formatarCep(obj.CEP), obj.ENDERECO, validarNumero(obj.NUMERO), obj.BAIRRO, obj.DISTRITO, formatarCoord(obj.LATITUDE), formatarCoord(obj.LONGITUDE));
                escola.distancia = String.Format("{0:f} Km.", CalcularDistancia (-23.6478665, escola.Latitude, -46.596793, escola.Longitude));
                retorno.Add(escola);
            }

            retorno = retorno.Where(x => x.TipoCod == "DIR").OrderBy(x => x.distancia).ToList();

           return View(retorno.OrderBy(x => x.distancia));
        }
    }
}