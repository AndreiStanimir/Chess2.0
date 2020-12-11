using Chess20.Common;
using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chess20.Models
{
    public enum Winner
    {
        Draw,
        Player1,
        Player2
    }

    public class Game
    {
        [Required]
        public int GameId { get; set; }

        public virtual ApplicationUser Player1 { get; set; }
        public virtual ApplicationUser Player2 { get; set; }

        [Required]
        [Min(0)]
        public TimeSpan Timer1 { get; set; }

        [Min(0)]
        public TimeSpan Timer2 { get; set; }

        [Required]
        [GameValidator]
        public string Moves { get; set; }

        [Range(0, (int)Winner.Player2, ErrorMessage = ""), Display(Name = "Test Enum")]
        public Winner Winner { get; set; }
    }
}