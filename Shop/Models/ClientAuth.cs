using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class ClientAuth
    {
        [Key] public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public DateTime registrationTime { get; set; }
        public string usertype { get; set; }
    }
}
