using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using System.ComponentModel.DataAnnotations.Schema;

namespace Chess20.Models
{
    [Table("Score")]
    public class Score
    {
        
        //[ForeignKey("I")]
        public int ScoreId { get; set; }
        public int Elo { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Loses { get; set; }

        public virtual  ApplicationUser ApplicationUser { get; set; }

        public Score()
        {

        }
    }
}