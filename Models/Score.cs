using DataAnnotationsExtensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chess20.Models
{
    [Table("Score")]
    public class Score
    {
        //[ForeignKey("I")]
        public int ScoreId { get; set; }

        [Required]
        [Min(0, ErrorMessage = "Can't be negative")]
        [Max(3000, ErrorMessage = "Elo must be lower than 3000")]
        public int Elo { get; set; }

        [Required]
        [Min(0, ErrorMessage = "Can't be negative")]
        public int Wins { get; set; }

        [Required]
        [Min(0, ErrorMessage = "Can't be negative")]
        public int Draws { get; set; }
        
        [Required]
        [Min(0, ErrorMessage = "Can't be negative")]
        public int Loses { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public Score()
        {
        }
    }
}