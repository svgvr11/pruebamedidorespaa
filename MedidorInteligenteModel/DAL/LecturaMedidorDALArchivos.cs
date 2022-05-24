using MedidorInteligenteModel.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidorInteligenteModel.DAL
{
    public class LecturaMedidorDALArchivos : ILecturaMedidorDAL
    {
        // Para implementar Singleton:
        // 1. El constructor tiene que ser private
        private LecturaMedidorDALArchivos()
        {

        }
        // 2. Debe poseer un atributo del mismo tipo de la clase y estático.
        private static LecturaMedidorDALArchivos instancia;
        // 3. Tener un método GetInstance que devuelve una referencia al atributo.
        public static ILecturaMedidorDAL GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new LecturaMedidorDALArchivos();
            }
            return instancia;
        }

        public static string url = Directory.GetCurrentDirectory();

        private static string archivo = url + "/mensajes.txt";

        public void IngresarLecturaMedidor(LecturasMedidores lecturasMedidores)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(archivo, true))
                {
                    writer.WriteLine(lecturasMedidores.Medidor + ";" + lecturasMedidores.Fecha + ";" + lecturasMedidores.Lectura);
                    writer.Flush();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrio un error -> {0}", ex);
            }
        }
        public List<LecturasMedidores> GetLecturas()
        {
            List<LecturasMedidores> lista = new List<LecturasMedidores>();
            try
            {
                using (StreamReader reader = new StreamReader(archivo))
                {
                    string texto = "";
                    do
                    {
                        texto = reader.ReadLine();
                        if (texto != null)
                        {
                            string[] arr = texto.Trim().Split(';');
                            LecturasMedidores lecturasMedidores = new LecturasMedidores()
                            {
                                Medidor = arr[0],
                                Fecha = Convert.ToDateTime(arr[1]),
                                Lectura = arr[2]
                            };
                            lista.Add(lecturasMedidores);
                        }
                    } while (texto != null);
                }
            }
            catch (Exception ex)
            {
                lista = null;
            }
            return lista;
        }

    }
}
