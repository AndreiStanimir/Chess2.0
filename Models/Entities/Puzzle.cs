using Chess20.Common;
using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chess20.Models.Entities
{
    public class Puzzle
    {
        private const string FEN_REGEX = @"\s*([rnbqkpRNBQKP1-8]+\/){7}([rnbqkpRNBQKP1-8]+)\s[bw-]\s(([a-hkqA-HKQ]{1,4})|(-))\s(([a-h][36])|(-))\s\d+\s\d+\s*";

        [Required]
        [Key]
        public int PuzzleId { get; set; }

        [Required]
        [GameValidator]
        public string Moves { get; set; }

        [Required]
        [RegularExpression(FEN_REGEX, ErrorMessage = "Position isn't valid")]
        public string StartingPosition { get; set; }

        [Required]
        [Min(0, ErrorMessage = "Can't be negative")]
        public int Elo { get; set; }
    }
}