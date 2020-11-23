using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acceso
{
    public class Operaciones
    {
        public List<solicitudDTO> Obtener()
        {
            List<solicitudDTO> sol = null;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnnDBSolicitudes"].ConnectionString))
            { 
                
            }

            return sol;
        }
    }
}
