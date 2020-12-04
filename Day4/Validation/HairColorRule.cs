using System.Text.RegularExpressions;

namespace Day4.Validation
{
    public class HairColorRule : IValidationRule
    {
        private static readonly Regex HexRegex = new Regex(@"^#(?:[0-9a-fA-F]{3}){1,2}$", RegexOptions.Compiled);
        
        public bool Validate(Passport passport)
        {
            if (passport.TryGetEntry("hcl", out var hairColor))
            {
                return HexRegex.IsMatch(hairColor);
            }

            return true;
        }
    }
}