﻿using System.Collections.Generic;
using System.Web.ModelBinding;

namespace Foolproof
{
    public class FoolproofValidator : DataAnnotationsModelValidator<ModelAwareValidationAttribute>
    {
      public FoolproofValidator(ModelMetadata metadata, ModelBindingExecutionContext context, ModelAwareValidationAttribute attribute)
            : base(metadata, context, attribute) { }

        public override IEnumerable<ModelValidationResult> Validate(object container)
        {
            if (!Attribute.IsValid(Metadata.Model, container))
                yield return new ModelValidationResult { Message = ErrorMessage };                    
        }

        //public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        //{
        //    var result = new ModelClientValidationRule()
        //    {
        //        ValidationType = Attribute.ClientTypeName.ToLower(),
        //        ErrorMessage = ErrorMessage       
        //    };
            
        //    foreach (var validationParam in Attribute.ClientValidationParameters)
        //        result.ValidationParameters.Add(validationParam);
            
        //    yield return result;
        //}
    }
}
