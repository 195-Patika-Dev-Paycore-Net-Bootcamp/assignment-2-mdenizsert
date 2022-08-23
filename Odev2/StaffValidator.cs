using System.Text.RegularExpressions;
using FluentValidation;

namespace Odev2
{
    public class StaffValidator : AbstractValidator<Staff>
    {
        public StaffValidator()
        {
        
            RuleFor(s => s.Name).MinimumLength(5);
            RuleFor(s => s.Name).MaximumLength(120);
            RuleFor(s => s.Lastname).MinimumLength(5);
            RuleFor(s => s.Lastname).MaximumLength(120);
            RuleFor(s => s.PhoneNumber).MinimumLength(13);
            RuleFor(s => s.Salary).GreaterThan(2000);
            RuleFor(s => s.Salary).LessThan(9000);
            RuleFor(s => s.Email).EmailAddress();
            RuleFor(s => s.DateOfBirth).Must(validateDate)
                .WithMessage("Dogum tarihi 10-10-2002 ile 11-11-1945 arasinda olmalı.");
            RuleFor(s => s.Name).Must(hasSpecialCharacter);



        }

    private bool hasSpecialCharacter(string str)
    {
        var regexItem = new Regex("^[a-zA-Z0-9.]*$");

        if (regexItem.IsMatch(str))
        {
            return true;
        }

        return false;
    }

    private bool validateDate(DateTime date)
    {
        DateTime d1 = new DateTime(2002, 10, 10);
        DateTime d2 = new DateTime(1945, 11, 11);

        int res1 = DateTime.Compare(date, d1);
        int res2 = DateTime.Compare(date, d2);

        if (res1 < 0 && res2 > 0)
        {
            return true;
        }

        return false;
    }

    }
}
