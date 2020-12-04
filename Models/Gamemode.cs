using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chess20.Models
{
    public class Gamemode
    {
        [Key]
        public int GamemodeId { get; set; }
        public string Name { get; set; }
        public int Time { get; set; }
        public int Increment { get; set; }
    }
}