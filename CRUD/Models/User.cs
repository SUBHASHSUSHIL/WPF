using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
