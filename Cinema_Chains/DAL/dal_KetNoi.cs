using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class dal_KetNoi
    {
        private static readonly string _connStr =
            @"Data Source=ADMIN-PC\SQLEXPRESS;Initial Catalog=Cinema_Chains;Integrated Security=True";

        public static Cinema_ChainsDataContext GetDataContext()
        {
            return new Cinema_ChainsDataContext(_connStr);
        }
    }
}
