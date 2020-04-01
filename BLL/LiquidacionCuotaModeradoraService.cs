using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DAL;



namespace BLL
{
    public  abstract class LiquidacionCuotaModeradoraService
    {
        LiquidacionCuotaModeradoraRepository liquidacionRepository;
        LiquidacionEntity liquidacion;
        List<LiquidacionEntity> liquidaciones;

        public LiquidacionCuotaModeradoraService()
        {
            liquidacionRepository = new LiquidacionCuotaModeradoraRepository();
            LeerLista();
        }

        public LiquidacionEntity Buscar(string id)
        {
            liquidacion = new LiquidacionEntity();
            liquidacion = liquidacionRepository.Buscar(id);
            if (liquidacion == null)
            {
                return null;
            }
            return liquidacion;

        }


        public List<LiquidacionEntity> LeerLista()
        {
            liquidaciones = liquidacionRepository.Consultar();
            return liquidaciones;
        }



        public void AñadirPaciente(LiquidacionEntity liquidacion)
        {
            liquidaciones.Add(liquidacion);
            liquidacionRepository.Guardar(liquidaciones);
        }

        public void Modificar( LiquidacionEntity liquidacionOld,LiquidacionEntity liquidacionNew) 
        {
            liquidacionRepository.Modificar(liquidacionOld, liquidacionNew);

        }

        public void Eliminar(LiquidacionEntity liquidacion)
        {
            liquidacionRepository.Eliminar(liquidacion);
        }

        public abstract double CalcularCoutaModeradora(LiquidacionEntity liquidacion);
    }
}
