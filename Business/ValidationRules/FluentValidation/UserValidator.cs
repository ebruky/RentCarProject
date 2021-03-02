using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Password).Must(ContainCharacter).WithMessage("Özel Karakter İçermeli");
        }

        private bool ContainCharacter(string arg)
        {
            for (int i = 0; i < arg.Length; i++)
            {
                if (arg[i] == '.' || arg[i] == '?' || arg[i] == '*' || arg[i] == '/' || arg[i] == '&' || arg[i] == '#') 
                { return true; }
                    
            }
            return false;
        }
    }
}
