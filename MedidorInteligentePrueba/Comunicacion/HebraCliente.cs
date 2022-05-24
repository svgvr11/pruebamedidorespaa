using MedidorInteligenteModel.DAL;
using MedidorInteligenteModel.DTO;
using ServerSocketUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidorInteligentePrueba.Comunicacion
{
    class HebraCliente
    {
        private static IMedidorInteligenteDAL medidorInteligenteDAL = MedidorInteligenteDALArchivos.GetInstancia();
        private static ILecturaMedidorDAL lecturaMedidorDAL = LecturaMedidorDALArchivos.GetInstancia();

        private ClienteCom clienteCom;

        public HebraCliente(ClienteCom clienteCom)
        {
            this.clienteCom = clienteCom;
        }

        public void Ejecutar()
        {
            // Acá dentro, ingresamos el código que atiende al Cliente.
            clienteCom.Escribir("Ingrese el medidor: ");
            string medidor = clienteCom.Leer();
            clienteCom.Escribir("Ingrese lectura de medidor: ");
            string lectura = clienteCom.Leer();

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
            clienteCom.Desconectar();
        }
    }
}
