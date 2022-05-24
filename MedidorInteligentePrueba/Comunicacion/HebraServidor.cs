﻿using MedidorInteligenteModel.DAL;
using ServerSocketUtils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MedidorInteligentePrueba.Comunicacion
{
    public class HebraServidor
    {
        private static IMedidorInteligenteDAL medidorInteligenteDAL = MedidorInteligenteDALArchivos.GetInstancia();
        private static ILecturaMedidorDAL lecturaMedidorDAL = LecturaMedidorDALArchivos.GetInstancia();
        public void Ejecutar()
        {
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);
            ServerSocket server = new ServerSocket(puerto);
            if (server.Iniciar())
            {
                while (true)
                {
                    Console.WriteLine("S: Esperando Cliente ..");
                    Socket cliente = server.ObtenerCliente();
                    Console.WriteLine("S: Cliente Recibido");

                    // Esto estaba en generar comunicación
                    ClienteCom clienteCom = new ClienteCom(cliente);

                    HebraCliente clienteThread = new HebraCliente(clienteCom);
                    Thread t = new Thread(new ThreadStart(clienteThread.Ejecutar));
                    t.IsBackground = true;
                    t.Start();
                }
            }
            else
            {
                Console.WriteLine("Fail, no se puede levantar server en {0}", puerto);
            }
        }
    }
}
