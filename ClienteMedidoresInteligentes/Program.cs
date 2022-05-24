using MedidorInteligenteModel.DAL;
using MedidorInteligenteModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteMedidoresInteligentes
{
    class Program
    {
        private static IMedidorInteligenteDAL medidorInteligenteDAL = MedidorInteligenteDALArchivos.GetInstancia();
        private static ILecturaMedidorDAL lecturaMedidorDAL = LecturaMedidorDALArchivos.GetInstancia();
        static void Main(string[] args)
        {
        }

        static void Ingresar()
        {
            Console.WriteLine("Ingrese medidor: ");
            string medidor = Console.ReadLine().Trim();
            Console.WriteLine("Ingrese lectura: ");
            string lectura = Console.ReadLine().Trim();

            LecturasMedidores lecturasMedidores = new LecturasMedidores()
            {
                Medidor = medidor,
                Fecha = DateTime.Now,
                Lectura = lectura
            };
            lock (lecturaMedidorDAL)
            {
                lecturaMedidorDAL.IngresarLecturaMedidor(lecturasMedidores);
            }

        }
    }
}
