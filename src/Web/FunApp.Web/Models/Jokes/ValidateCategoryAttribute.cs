//  ------------------------------------------------------------------------------------------------
//   <copyright file="ValidateCategoryAttribute.cs" company="Business Management System Ltd.">
//       Copyright "" (c), Business Management System Ltd.
//       All rights reserved.
//   </copyright>
//   <author>Nikolay.Kostadinov</author>
//  ------------------------------------------------------------------------------------------------
namespace FunApp.Web.Models.Jokes
{
    using System.ComponentModel.DataAnnotations;
    using Services.DataServices;

    public class ValidateCategoryAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var categoryService = (ICategoryService) validationContext.GetService(typeof(ICategoryService));
            var jokeCategoriId = (int) value;
            if (!categoryService.IsValidCategoryIdAsync(jokeCategoriId).Result)
            {
                return new ValidationResult($"Invalid category Id: {jokeCategoriId}");
            }

            return ValidationResult.Success;
        }
    }
}