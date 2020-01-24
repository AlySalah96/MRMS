using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using BRMS.Models;

namespace BRMS.Models
{
    public class Min18IfAMember:ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId==MembershipType.PayAsYouGO)
                return ValidationResult.Success;
            if (customer.Birthdate == null)
                return new ValidationResult("Birthate is required !");

            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;
            return (age > 18) ? ValidationResult.Success : new ValidationResult("customer should at least 18 years old");
        }
    }
}