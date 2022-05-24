using MedidorInteligenteModel.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidorInteligenteModel.DAL
{
    public class MedidorInteligenteDALArchivos : IMedidorInteligenteDAL
    {
        // Para implementar Singleton:
        // 1. El constructor tiene que ser private
        private MedidorInteligenteDALArchivos()
        {

        }
        // 2. Debe poseer un atributo del mismo tipo de la clase y estático.
        private static MedidorInteligenteDALArchivos instancia;
        // 3. Tener un método GetInstance que devuelve una referencia al atributo.
        public static IMedidorInteligenteDAL GetInstancia()
        {
            if (instancia == null)
            {
                instancia = new MedidorInteligenteDALArchivos();
            }
            return instancia;
        }

        public List<int> GetMedidores()
        {
            List<int> listaMedidoresInteligentes = MedidorInteligente.NroMedidoreInteligente;
            return listaMedidoresInteligentes;
        }

    }
}
