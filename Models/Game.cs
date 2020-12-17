using Chess20.Common;
using System;
using System.ComponentModel.DataAnnotations;

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
        [Key]
        public int GameId { get; set; }

        //[Required]
        public virtual ApplicationUser Player1 { get; set; }

        //[Required]
        public virtual ApplicationUser Player2 { get; set; }

        //[ForeignKey("Gamemode")]

        private Gamemode gamemode;

        public virtual Gamemode Gamemode
        {
            get
            {
                return gamemode;
            }
            set
            {
                Timer1 = TimeSpan.FromSeconds(value.Time);
                Timer2 = TimeSpan.FromSeconds(value.Time);
                gamemode = value;
            }
        }

        [Required]
        [TimeValidator]
        //[NotMapped]
        public TimeSpan Timer1 { get; set; }

        [Required]
        [TimeValidator]
        //[NotMapped]
        public TimeSpan Timer2 { get; set; }

        [Required]
        [GameValidator]
        public string Moves { get; set; }

        [Range(0, (int)Winner.Player2), Display(Name = "Result")]
        public Winner Winner { get; set; }

        public Game()
        {
            //if (Gamemode != null)
            //{
            //    Timer1 = TimeSpan.FromSeconds(Gamemode.Time);
            //    Timer2 = TimeSpan.FromSeconds(Gamemode.Time);
            //}
        }

        //public Game(Gamemode gamemode)
        //{
        //    Gamemode = gamemode;
        //    Timer1 = TimeSpan.FromSeconds(Gamemode.Time);
        //    Timer2 = TimeSpan.FromSeconds(Gamemode.Time);
        //}
    }
}