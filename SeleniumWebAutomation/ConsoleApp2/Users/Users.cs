using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Users
{
    public class Users
    {
        [Index(0)]
        public  string Email { get; set; }
        [Index(1)]
        public  string Password { get; set; }
    }
}
