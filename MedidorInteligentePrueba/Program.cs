using MedidorInteligenteModel.DAL;
using MedidorInteligenteModel.DTO;
using MedidorInteligentePrueba.Comunicacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MedidorInteligentePrueba
{
    class Program
    {
        private static IMedidorInteligenteDAL medidorInteligenteDAL = MedidorInteligenteDALArchivos.GetInstancia();
        private static ILecturaMedidorDAL lecturaMedidorDAL = LecturaMedidorDALArchivos.GetInstancia();
        static void Main(string[] args)
        {
            HebraServidor hebra = new HebraServidor();
            Thread t = new Thread(new ThreadStart(hebra.Ejecutar));
            t.IsBackground = true;
            t.Start();

            while (Menu()) ;
        }

        static bool Menu()
        {
            bool continuar = true;
            Console.WriteLine("Que desea hacer?");
            Console.WriteLine("1. Mostrar \n 0. Salir");
            switch (Console.ReadLine().Trim())
            {
                case "1":
                    Mostrar();
                    break;
                default:
                    Console.WriteLine("Ingrese de nuevo");
                    break;
            }
            return continuar;
        }

        static void Mostrar()
        {
            List<LecturasMedidores> lecturasMedidores = null;
            lock (lecturaMedidorDAL)
            {
                lecturasMedidores = lecturaMedidorDAL.GetLecturas();
            }
            foreach (LecturasMedidores lecturasMedidor in lecturasMedidores)
            {
                Console.WriteLine(lecturasMedidor);
            }
        }
    }
}
