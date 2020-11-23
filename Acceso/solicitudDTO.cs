using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acceso
{
    public class solicitudDTO
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public int cola { get; set; }
        public bool atendido { get; set; }
    }
}
