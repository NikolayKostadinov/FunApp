//  ------------------------------------------------------------------------------------------------
//   <copyright file="CreateJokeInputModel.cs" company="Business Management System Ltd.">
//       Copyright "2019" (c), Business Management System Ltd.
//       All rights reserved.
//   </copyright>
//   <author>Nikolay.Kostadinov</author>
//  ------------------------------------------------------------------------------------------------

namespace FunApp.Web.Models.Jokes
{
    #region Using

    using System.ComponentModel.DataAnnotations;

    #endregion

    public class CreateJokeInputModel
    {
        [Required]
        [MinLength(20)]
        public string Content { get; set; }

        [ValidateCategory]
        public int CategoriId { get; set; }
    }
}