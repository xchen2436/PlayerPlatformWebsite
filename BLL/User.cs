using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class User
    {
        public static bool add(Model.User user) {
            return DAL.User.add(user);
        }
    }
}
