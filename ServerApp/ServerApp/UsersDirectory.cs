using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp
{
    public class UsersDirectory
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FIO { get; set; }
        public string PhoneNumber { get; set; }
    }
}
