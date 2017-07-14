using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.ViewModels
{
    public class FirstNameValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Please Provide First Name");
            }
            else if (value.ToString().Contains("@"))
            {
                return new ValidationResult("First Name 不能包含 @");
            }
            else if (value.ToString().Length < 1 || value.ToString().Length > 5)
            {
                return new ValidationResult("First Name 必须在 1 - 5 个字符之间");
            }
            return ValidationResult.Success;
        }
    }
}