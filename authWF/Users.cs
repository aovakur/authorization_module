using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace authWF
{
   // [Serializable]
    class Users
    {
        public static string Name { get; set; }
        public static string Surname { get; set; }
        public static string Patronymic { get; set; }
        public static string Date { get; set; }

        public static string Position { get; set; }
        public static string Views { get; set; }
        public static string Accesses { get; set; }
        public static string Mail { get; set; }
        public static string Login { get; set; }
        public static string Password { get; set; }
        public static string PasswordRepeat { get; set; }

        
    }
}
