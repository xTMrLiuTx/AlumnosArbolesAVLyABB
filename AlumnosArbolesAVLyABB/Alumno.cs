using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlumnosArbolesAVLyABB
{
    public class Alumno
    {
        public string Carnet { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public int Parcial1 { get; set; }
        public int Parcial2 { get; set; }
        public int Zona { get; set; }
        public int Final { get; set; }
        public int Total { get; set; }

        public Alumno(string carnet, string nombre, string correo, int parcial1, int parcial2, int zona, int final, int total)
        {
            Carnet = carnet;
            Nombre = nombre;
            Correo = correo;
            Parcial1 = parcial1;
            Parcial2 = parcial2;
            Zona = zona;
            Final = final;
            Total = total;
        }
    }
}
