using System;
using System.ComponentModel.DataAnnotations;
using Chess20.Common;

namespace Chess20.Models.Entities
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
        private const string TIME_REGEX = @"((([0-1][0-9])|(2[0-3]))(:[0-5][0-9])(:[0-5][0-9])?)";

        [Required]
        [Key]
        public int GameId { get; set; }

        public virtual ApplicationUser Player1 { get; set; }

        public virtual ApplicationUser Player2 { get; set; }

        public string GetUsername1 { get => Player1 == null ? "Deleted User" : Player1?.UserName; }

        public string GetUsername2 { get => Player2 == null ? "Deleted User" : Player2.UserName; }

        private Gamemode gamemode;

        public virtual Gamemode Gamemode
        {
            get
            {
                return gamemode;
            }
            set
            {
                //Timer1 = TimeSpan.FromSeconds(value.Time);
                //Timer2 = TimeSpan.FromSeconds(value.Time);
                gamemode = value;
            }
        }

        [Required]
        [RegularExpression(TIME_REGEX, ErrorMessage = "Time must be between 00:00:00 to 23:59:59")]
        public TimeSpan Timer1 { get; set; }

        [Required]
        [RegularExpression(TIME_REGEX, ErrorMessage = "Time must be between 00:00:00 to 23:59:59")]
        public TimeSpan Timer2 { get; set; }

        [Required]
        [GameValidator]
        public string Moves { get; set; }

        [Range(0, (int)Winner.Player2), Display(Name = "Result")]
        public Winner Winner { get; set; }

        public Game()
        {
        }

        public Game(Gamemode gamemode)
        {
            Gamemode = gamemode;
            Timer1 = TimeSpan.FromSeconds(Gamemode.Time);
            Timer2 = TimeSpan.FromSeconds(Gamemode.Time);
        }
    }
}