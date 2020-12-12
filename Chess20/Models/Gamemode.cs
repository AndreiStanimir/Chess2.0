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
        public int Time { get; set; }

        [Min(0, ErrorMessage = "Time can't be negative")]
        [Max(CONSTANTS.MAX_INCREMENT, ErrorMessage = "Increment too high")]
        public int Increment { get; set; }
    }
}