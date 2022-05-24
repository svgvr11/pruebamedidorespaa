using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidorInteligenteModel.DTO
{
    public class MedidorInteligente
    {
        private static List<int> nroMedidoreInteligente = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, };

        public static List<int> NroMedidoreInteligente { get => nroMedidoreInteligente; set => nroMedidoreInteligente = value; }
    }
}
