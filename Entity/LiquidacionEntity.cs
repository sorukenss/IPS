using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
     public class LiquidacionEntity : PacienteEntity
    {
        public int NumeroLiquidacion { get; set; }
        public double CuotaModerada { get; set; }
        public double ValorServicio { get; set; }

        public LiquidacionEntity()
        {
        }
    }
}
