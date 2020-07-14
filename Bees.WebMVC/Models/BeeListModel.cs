using Bees.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bees.WebMVC.Models
{
    public class BeeListModel
    {
        public List<Bee> BeeList { get; set; } = new List<Bee>();

        public int Id { get; set; }
        public int Damage { get; set; }
    }
}