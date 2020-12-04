namespace Day4.Validation
{
    public interface IValidationRule
    {
        public bool Validate(Passport passport);
    }
}