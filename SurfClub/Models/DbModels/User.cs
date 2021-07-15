using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurfClub.Models.DbModels
{
    public class User
    {
        public int Id { get; set; }
        public String Nickname { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public String Surname { get; set; }
        public String Name { get; set; }
        public Guid Photo { get; set; }
        public String Contact { get; set; }
        public String AboutMe { get; set; }
        public String Progress { get; set; }
    }
}
