using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace DAL
{
    public class LiquidacionCuotaModeradoraRepository
    {
        private string ruta = "IPS.txt";
        public List<LiquidacionEntity> liquidaciones;

        public LiquidacionCuotaModeradoraRepository()
        {
            liquidaciones = new List<LiquidacionEntity>();
        }

        public void Guardar(List<LiquidacionEntity> ListLiquidaciones)
        {
            File.Delete(ruta);
            FileStream file = new FileStream(ruta, FileMode.Append);
            StreamWriter escribir = new StreamWriter(file);
            foreach(var item in ListLiquidaciones)
            {
                escribir.WriteLine($"{item.Nombre};{item.Identificacion};{item.Salario};{item.TipoDeAfilacion};{item.ValorServicio};{item.NumeroLiquidacion};{item.CuotaModerada}");
                
                    
            }


            escribir.Close();
            file.Close();
        }


        public List<LiquidacionEntity> Consultar()
        {
            liquidaciones = new List<LiquidacionEntity>();
            string linea = string.Empty;
            FileStream sourceStream = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(sourceStream);
            while ((linea = reader.ReadLine()) != null)
            {
                LiquidacionEntity liquidacion = new LiquidacionEntity();
                char delimiter = ';';
                string[] matriz = linea.Split(delimiter);
                liquidacion.Nombre = matriz[0];
                liquidacion.Identificacion = matriz[1];
                liquidacion.Salario = Convert.ToDecimal(matriz[2]);
                liquidacion.TipoDeAfilacion = matriz[3];
                liquidacion.ValorServicio = Convert.ToDouble(matriz[4]);
                liquidacion.NumeroLiquidacion = Convert.ToInt32(matriz[5]);
                liquidacion.CuotaModerada = Convert.ToInt32(matriz[6]);
                liquidaciones.Add(liquidacion);

            }
            reader.Close();
            sourceStream.Close();
            return liquidaciones;
        }

        public LiquidacionEntity Buscar(string id)
        {
            liquidaciones = Consultar();
            foreach(var item in liquidaciones)
            {
                if (item.Identificacion.Equals(id))
                {
                    return item;
                }
                
            }
            return null;
        }

        public void Modificar(LiquidacionEntity liquidacionOld,LiquidacionEntity liquidacionNew)
        {
            liquidaciones.Remove(liquidacionOld);
            liquidaciones.Add(liquidacionNew);
            Guardar(liquidaciones);
        }

        public void Eliminar(LiquidacionEntity liquidacion)
        {
            liquidaciones.Remove(liquidacion);
            Guardar(liquidaciones);
        }
    }
}
