using System;

namespace Day4.Validation
{
    public class HeightRule : IValidationRule
    {
        public bool Validate(Passport passport)
        {
            if (passport.TryGetEntry("hgt", out var height))
            {
                if (height.Contains("cm"))
                {
                    var cmValue = int.Parse(height.Substring(0, height.IndexOf("cm", StringComparison.Ordinal)));
                    return 150 <= cmValue && cmValue <= 193;
                }
                
                if (height.Contains("in"))
                {
                    var inValue = int.Parse(height.Substring(0, height.IndexOf("in", StringComparison.Ordinal)));
                    return 59 <= inValue && inValue <= 76;
                }

                return false;
            }

            return true;
        }
    }
}