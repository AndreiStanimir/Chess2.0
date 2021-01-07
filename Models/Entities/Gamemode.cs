using System.ComponentModel.DataAnnotations;
using Chess20.Common;
using DataAnnotationsExtensions;

namespace Chess20.Models.Entities
{
    public class Gamemode
    {
        [Key]
        public int GamemodeId { get; set; }

        [MaxLength(30, ErrorMessage = "Name too long")]
        public string Name { get; set; }

        [Min(0, ErrorMessage = "Time can't be negative")]
        [Max(CONSTANTS.MAX_TIME, ErrorMessage = "Too much time")]
        public int Time { get; set; } //in seconds

        [Min(0, ErrorMessage = "Time can't be negative")]
        [Max(CONSTANTS.MAX_INCREMENT, ErrorMessage = "Increment too high")]
        public int Increment { get; set; } //in seconds

        private readonly int[] _gamemodeLimits = { 30, 15, 3, 0 };
        private readonly string[] _standardGamemodeNames = { "Classical", "Standard", "Blitz", "Bullet" };

        public Gamemode()
        {
        }

        public Gamemode(int time, int increment)
        {
            SetDefaultName(time, increment);
        }

        public void SetDefaultName(int time, int increment)
        {
            Time = time;
            Increment = increment;
            float totalPlayingTime = (float)time / 60 + 40 / 60 * increment;
            for (int i = 0; i < _gamemodeLimits.Length; i++)
            {
                if (totalPlayingTime >= _gamemodeLimits[i])
                {
                    Name = _standardGamemodeNames[i];
                    break;
                }
            }
        }
    }
}