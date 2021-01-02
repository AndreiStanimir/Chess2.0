using Chess20.Common;
using DataAnnotationsExtensions;
using System.ComponentModel.DataAnnotations;

namespace Chess20.Models
{
    public class Gamemode
    {
        [Key]
        public int GamemodeId { get; set; }

        [MaxLength(30, ErrorMessage = "Name too long")]
        public string Name { get; set; }

        [Min(0, ErrorMessage = "Time can't be negative")]
        [Max(CONSTANTS.MAX_TIME, ErrorMessage = "Too much time")]
        public int Time { get; } //in seconds

        [Min(0, ErrorMessage = "Time can't be negative")]
        [Max(CONSTANTS.MAX_INCREMENT, ErrorMessage = "Increment too high")]
        public int Increment { get; } //in seconds

        private readonly int[] gamemode_limits = { 30, 15, 3, 0 };
        private readonly string[] standard_gamemode_names = { "Classical", "Standard", "Blitz", "Bullet" };
        public Gamemode()
        {

        }
        public Gamemode(int time, int increment)
        {
            Time = time;
            Increment = increment;
            var totalPlayingTime = time / 60 + 40 / 60 * increment;
            for (int i = 0; i < gamemode_limits.Length; i++)
            {
                if (totalPlayingTime >= gamemode_limits[i])
                {
                    Name = standard_gamemode_names[i];
                    break;
                }
            }
        }
    }
}