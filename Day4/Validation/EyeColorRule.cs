using System.Collections.Generic;
using System.Linq;

namespace Day4.Validation
{
    public class EyeColorRule : IValidationRule
    {
        private static readonly IReadOnlyList<string> ValidEyeColors = new[]
        {
            "amb",
            "blu",
            "brn",
            "gry",
            "grn",
            "hzl",
            "oth"
        };
        
        public bool Validate(Passport passport)
        {
            if (passport.TryGetEntry("ecl", out var eyeColor))
            {
                return ValidEyeColors.Contains(eyeColor);
            }

            return true;
        }
    }
}