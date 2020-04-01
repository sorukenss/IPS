using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class PacienteEntity
    {
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public decimal Salario { get; set; }
        public string TipoDeAfilacion { get; set; }

        public PacienteEntity() { }
    }
}
