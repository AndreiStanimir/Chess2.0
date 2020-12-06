using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chess20.Models
{
    public enum Winner
    {
        None,
        Draw,
        Player1,
        Player2
    }
    public class Game
    {
       
        [Required]
        public int GameId { get; set; }

        public virtual User Player1 { get; set; }
        public virtual User Player2 { get; set; }
        //public User timer1 { get; set; }
        //public User timer2 { get; set; }
        public string Moves { get; set; }
        public Winner Winner { get; set; }
    }
}