using Chess20.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace Chess20.Models
{
    public class User
    {
        [Key]
        //[ForeignKey("Game")]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }   
        public Roles Role { get; set; }
        public string Password { get; set; }

        [Required]
        //public int ScoreId { get; set; }

        //public int ScoreId { get; set; }
        
        //[ForeignKey("ScoreId")]
        public virtual Score Score { get; set; }    
    }
}