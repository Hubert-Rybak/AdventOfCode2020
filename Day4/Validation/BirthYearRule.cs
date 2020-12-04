namespace Day4.Validation
{
    public class BirthYearRule : IValidationRule
    {
        public bool Validate(Passport passport)
        {
            if (passport.TryGetEntry("byr", out var birthYear))
            {
                if (birthYear.Length != 4)
                {
                    return false;
                }
                
                if (int.TryParse(birthYear, out var parsedBirthYear))
                {
                    return 1920 <= parsedBirthYear && parsedBirthYear <= 2002;
                }

                return false;
            }

            return true;
        }
    }

    public class IssueYearRule : IValidationRule
    {
        public bool Validate(Passport passport)
        {
            if (passport.TryGetEntry("iyr", out var issueYear))
            {
                if (issueYear.Length != 4)
                {
                    return false;
                }
                
                if (int.TryParse(issueYear, out var parsedBirthYear))
                {
                    return 2010 <= parsedBirthYear && parsedBirthYear <= 2020;
                }

                return false;
            }

            return true;
        }
    }
}