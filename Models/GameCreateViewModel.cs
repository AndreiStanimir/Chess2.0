using System.ComponentModel.DataAnnotations;
using Chess20.Models.Entities;

namespace Chess20.Models
{
    public class GameCreateViewModel
    {
        [Required]
        [Key]
        public int GameId { get; set; }

        //[Required]
        public string Player1Id { get; set; }

        //[Required]
        public string Player2Id { get; set; }

        //[ForeignKey("Gamemode")]

        public int GamemodeId { get; set; }

        //[Required]
        //[RegularExpression(@"((([0-1][0-9])|(2[0-3]))(:[0-5][0-9])(:[0-5][0-9])?)", ErrorMessage = "Time must be between 00:00:00 to 23:59:59")]
        //public TimeSpan Timer1 { get; set; }

        //[Required]
        //[RegularExpression(@"((([0-1][0-9])|(2[0-3]))(:[0-5][0-9])(:[0-5][0-9])?)", ErrorMessage = "Time must be between 00:00:00 to 23:59:59")]

        ////[NotMapped]
        //public TimeSpan Timer2 { get; set; }

        [Required]
        public string Moves { get; set; }

        [Range(0, (int)Winner.Player2), Display(Name = "Result")]
        public Winner Winner { get; set; }
    }
}