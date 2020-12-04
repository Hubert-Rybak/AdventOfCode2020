namespace Day4.Validation
{
    public class ExpirationYearRule : IValidationRule
    {
        public bool Validate(Passport passport)
        {
            if (passport.TryGetEntry("eyr", out var expirationYear))
            {
                if (expirationYear.Length != 4)
                {
                    return false;
                }
                
                if (int.TryParse(expirationYear, out var parsedBirthYear))
                {
                    return 2020 <= parsedBirthYear && parsedBirthYear <= 2030;
                }

                return false;
            }

            return true;
        }
    }
}