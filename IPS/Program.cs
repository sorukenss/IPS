using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using Entity;

namespace IPS
{
    class Program
    {
        static int option;
        static LiquidacionEntity liquidacion;
        static LiquidacionCuotaModeradoraService liquidacionService;
        static List<LiquidacionEntity> liquidaciones;
        static void Main(string[] args)
        {
            do
            {
                Menu();
                option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:Verificar();
                        break;
                    case 2:ListaDePaciente();
                        break;
                    case 3: Eliminar();
                        break;
                    case 4:BuscarPaciente();
                        break;
                    case 5: 
                        break;
                    case 6: option = 6;
                        break;
                    default: Console.WriteLine("NO tomo ninguna opcion disponible vuelva a intentarlo plis");
                        break;
                        
                }

            } while (option!=6);
            Console.ReadKey();
        }


        static public void Menu()
        {
            Console.Clear();
            Console.WriteLine("1-> para ingresar  datos del Paciente");
            Console.WriteLine("2-> para lista de Pacientes");
            Console.WriteLine("3-> para Eliminar a un Paciente");
            Console.WriteLine("4-> para Buscar Un paciente");
            Console.WriteLine("5-> Modificar Datos DEl paciente");
            Console.WriteLine("6-> para salir");


        }

        static public void Guardar( LiquidacionEntity liquidacion,string id)
        {
            liquidaciones = liquidacionService.LeerLista();
            liquidacion.Identificacion = id;
            Console.WriteLine("Nombre Del Paciente : ");
            liquidacion.Nombre = Console.ReadLine();
            Console.WriteLine("Salario Del Paciente: ");
            liquidacion.Salario = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Valor Del servicio:");
            liquidacion.ValorServicio = Convert.ToInt32(Console.ReadLine());
            liquidacionService.CalcularCoutaModeradora(liquidacion);
            liquidacionService.AñadirPaciente(liquidacion);
            Console.WriteLine("se resgistro con exito......");
            Console.ReadKey();
        }

        static public void Verificar()
        {
            string identificacion;
            liquidacion = new LiquidacionEntity();
            Console.Clear();
            Console.WriteLine("Identificacion del paciente: ");
            identificacion = Console.ReadLine();
            Console.WriteLine("ingrese que tipo de afilacion es subsidiado --- contributivo");
            liquidacion.TipoDeAfilacion = Console.ReadLine().ToUpper();
            if (liquidacion.TipoDeAfilacion.Equals("SUBSIDIADO")) { 
                liquidacionService = new SubsidiadoService();
            }
            else if (liquidacion.TipoDeAfilacion.Equals("CONTRIBUTIVO")) { 
                liquidacionService = new ContributivoService();
            }
            if  ((liquidacionService.Buscar(identificacion)) == null) { 
                Guardar(liquidacion, identificacion);
            }
            else
            {
                Console.WriteLine("ya se encuentra el paciente registrado");
                Console.ReadKey();
            }

        }


        static public void Eliminar()
        {
            liquidacion = new LiquidacionEntity();
            Console.Clear();
            Console.WriteLine("Ingresar la Identificacion del paciente que desea eliminar:");
            liquidacionService = new SubsidiadoService();
            liquidacion = liquidacionService.Buscar(Console.ReadLine());
            if (liquidacion != null)
            {
                liquidacionService.Eliminar(liquidacion);
                Console.WriteLine("eliminado....");

            }
            else
            {
                Console.WriteLine("no se encuentra el paciente indicado");
                Console.ReadKey();
            }
        }


        static public void ListaDePaciente()
        {
            liquidacionService = new SubsidiadoService();
            liquidaciones = liquidacionService.LeerLista();
            Console.Clear();
            Console.WriteLine("--------- Lista De Pacientes--------------");
            foreach(var item in liquidaciones)
            {
                Console.WriteLine($"Nombre :{item.Nombre}");
                Console.WriteLine($"Identificacion:{item.Identificacion}");
                Console.WriteLine($"Salario:{item.Salario}");
                Console.WriteLine($"Tipo DE Afiliacion:{item.Salario}");
                Console.WriteLine($"Numero de Liquidacion:{item.NumeroLiquidacion}");
                Console.WriteLine($"Valor de Servicio:{item.ValorServicio}");
                Console.WriteLine($"Cuota moderadora:{item.CuotaModerada}");
                Console.WriteLine("--------------//--------------------------//---------------------------");
            }
            Console.ReadKey();
        }

       

        static public void BuscarPaciente()
        {
            string id;
            liquidacionService = new SubsidiadoService();
            liquidaciones = liquidacionService.LeerLista();
            Console.Clear();
            Console.WriteLine("digite la identificacion del paciente que desea buscar : ");
            id = Console.ReadLine();
            foreach(var item in liquidaciones)
            {
                if (item.Identificacion.Equals(id))
                {
                    Console.WriteLine($"Nombre :{item.Nombre}");
                    Console.WriteLine($"Identificacion:{item.Identificacion}");
                    Console.WriteLine($"Salario:{item.Salario}");
                    Console.WriteLine($"Tipo DE Afiliacion:{item.Salario}");
                    Console.WriteLine($"Numero de Liquidacion:{item.NumeroLiquidacion}");
                    Console.WriteLine($"Valor de Servicio:{item.ValorServicio}");
                    Console.WriteLine($"Cuota moderadora:{item.CuotaModerada}");
                }
                Console.ReadKey();
            }

        }



        


       
    }
}
