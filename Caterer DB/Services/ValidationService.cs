using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Caterer_DB.Services
{
   
        public class IsTrueAttribute : ValidationAttribute
        {
            #region Overrides of ValidationAttribute

            /// <summary>
            /// Determines whether the specified value of the object is valid. 
            /// </summary>
            /// <returns>
            /// true if the specified value is valid; otherwise, false. 
            /// </returns>
            /// <param name="value">The value of the specified validation object on which the <see cref="T:System.ComponentModel.DataAnnotations.ValidationAttribute"/> is declared.
            ///                 </param>
            public override bool IsValid(object value)
            {
                if (value == null) return false;
                if (value.GetType() != typeof(bool)) throw new InvalidOperationException("can only be used on boolean properties.");

                return (bool)value == true;
            }

            #endregion
        }
    public class EnforceTrueAttribute : ValidationAttribute, IClientValidatable
    {
        public override bool IsValid(object value)
        {
            if (value == null) return false;
            if (value.GetType() != typeof(bool)) throw new InvalidOperationException("can only be used on boolean properties.");
            return (bool)value == true;
        }

        public override string FormatErrorMessage(string name)
        {
            return "The " + name + " field must be checked in order to continue.";
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            yield return new ModelClientValidationRule
            {
                ErrorMessage = String.IsNullOrEmpty(ErrorMessage) ? FormatErrorMessage(metadata.DisplayName) : ErrorMessage,
                ValidationType = "enforcetrue"
            };
        }
    }
}