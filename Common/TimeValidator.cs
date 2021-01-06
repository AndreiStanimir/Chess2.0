using System;
using System.ComponentModel.DataAnnotations;

namespace Chess20.Common
{
    public class TimeValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return ((TimeSpan)value).TotalSeconds >= 0;
        }
    }
}