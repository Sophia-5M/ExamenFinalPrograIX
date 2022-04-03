using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal1.Models
{
    public class tbl_bitacora
    {
        public int id { get; set; }
        public int id_proc { get; set; }
        public int id_request { get; set; }
        public string JSON { get; set; }
        public DateTime fecha_trn { get; set; }
        public int id_marca { get; set; }
        public int id_tipoV { get; set; }
    }
}
