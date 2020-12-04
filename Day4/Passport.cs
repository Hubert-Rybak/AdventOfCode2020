using System.Collections.Generic;
using System.Linq;
using Day4.Validation;

namespace Day4
{
    public class Passport
    {
        private readonly Dictionary<string, string> _entries = new();
        private readonly List<IValidationRule> _validationRules = new();
        
        private static readonly IReadOnlyList<string> RequiredFields = new[]
        {
            "byr",
            "iyr",
            "eyr",
            "hgt",
            "hcl",
            "ecl",
            "pid"
        };

        public void AddData(string line)
        {
            var entries = line.Split(' ');

            foreach (var entry in entries)
            {
                var keyValuePair = entry.Split(':');
                _entries.Add(keyValuePair[0], keyValuePair[1]);
            }
        }

        public bool IsValid()
        {
            return RequiredFields.All(f => _entries.ContainsKey(f)) 
                   && _validationRules.All(v => v.Validate(this));
        }

        public bool TryGetEntry(string entryKey, out string entryValue)
        {
            return _entries.TryGetValue(entryKey, out entryValue);
        }
        
        public void AddValidationRule(IValidationRule validationRule)
        {
            _validationRules.Add(validationRule);
        }

        public static Passport CreateWithValidationRules()
        {
            var passport = new Passport();
            passport.AddValidationRule(new BirthYearRule());
            passport.AddValidationRule(new IssueYearRule());
            passport.AddValidationRule(new ExpirationYearRule());
            passport.AddValidationRule(new HeightRule());
            passport.AddValidationRule(new HairColorRule());
            passport.AddValidationRule(new EyeColorRule());
            passport.AddValidationRule(new PassportIdValidator());

            return passport;
        }
    }
}