using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Mhrs_Otomasyonu
{

    internal class Class1
    {
        public SqlConnection connect()
        {
            SqlConnection bgl = new SqlConnection("Data Source=iremerturk\\SQLEXPRESS02;Initial Catalog=DbMhrsOtomasyonu;Integrated Security=True");
            bgl.Open();
            return bgl;
        }
    }
}
