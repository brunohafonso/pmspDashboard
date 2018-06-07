using System;

namespace bruno.pmsp.domain.Entities 
{
    public class Escola : Base {
    public double CalcularDistancia(double origem_lat, double destino_lat, double origem_lng, double destino_lng) 
    {
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
        
        
        public string DRE { get; set; }
        public string Tipo { get; set; }
        public string TipoCod { get; set; }
        public string CodEol { get; set; }
        public string Nome { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Distrito { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string distancia { get; set; }

        public Escola () {

        }

        public Escola (string DRE, string Tipo, string TipoCod, string CodEol, string Nome, string CEP, string Logradouro, int Numero, string Bairro, string Distrito, double Latitude, double Longitude) {
            this.DRE = DRE;
            this.Tipo = Tipo;
            this.TipoCod = TipoCod;
            this.CodEol = CodEol;
            this.Nome = Nome;
            this.CEP = CEP;
            this.Logradouro = Logradouro;
            this.Numero = Numero;
            this.Bairro = Bairro;
            this.Distrito = Distrito;
            this.Latitude = Latitude;
            this.Longitude = Longitude;
        }
    }
}