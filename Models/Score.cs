﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using System.ComponentModel.DataAnnotations.Schema;

namespace Chess20.Models
{
    [Table("Score")]
    public class Score
    {
        
        [ForeignKey("User")]
        public int ScoreId { get; set; }
        public int Elo { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Loses { get; set; }

        public virtual User User { get; set; }

        public Score()
        {

        }
    }
}