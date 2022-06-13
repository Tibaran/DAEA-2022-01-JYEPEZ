using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab13.Models
{
    public class Persona
    {
        public int PersonaID { get; set; }
        public String Nombre{ get; set; }
        public String Apellido { get; set; }
        public DateTime FechaNac { get; set; }
        public String Direccion { get; set; }
        public String Email { get; set; }
    }
}