using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chess20.Common
{
    public class GameValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return true;
        }
    }
}