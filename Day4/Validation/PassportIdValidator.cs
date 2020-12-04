namespace Day4.Validation
{
    public class PassportIdValidator : IValidationRule
    {
        public bool Validate(Passport passport)
        {
            if (passport.TryGetEntry("pid", out var pid))
            {
                return pid.Length == 9;
            }

            return true;
        }
    }
}