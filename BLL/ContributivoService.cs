using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
     public class ContributivoService : LiquidacionCuotaModeradoraService
    {
        List<LiquidacionEntity> liquidacones = new List<LiquidacionEntity>();

        public override double CalcularCoutaModeradora(LiquidacionEntity liquidacion)
        {
            if (liquidacion.Salario < (980000 * 2))
            {
                return liquidacion.CuotaModerada = liquidacion.ValorServicio * 0.15;
            }
            else if((liquidacion.Salario>=(980000*2))&&((liquidacion.Salario<=(980000*5))))
            {
                return liquidacion.CuotaModerada = liquidacion.ValorServicio * 0.2;
            }
            else
            {
                return liquidacion.CuotaModerada = liquidacion.ValorServicio * 0.25;
            }
            
        }
    }
}
