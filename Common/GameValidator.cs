using System.ComponentModel.DataAnnotations;

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