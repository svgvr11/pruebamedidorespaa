using MedidorInteligenteModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidorInteligenteModel.DAL
{
    public interface ILecturaMedidorDAL
    {
        void IngresarLecturaMedidor(LecturasMedidores lecturasMedidores);
        List<LecturasMedidores> GetLecturas();
    }
}
