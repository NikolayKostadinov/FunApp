//  ------------------------------------------------------------------------------------------------
//   <copyright file="JokeBuffer.cs" company="Business Management System Ltd.">
//       Copyright "2019" (c), Business Management System Ltd.
//       All rights reserved.
//   </copyright>
//   <author>Nikolay.Kostadinov</author>
//  ------------------------------------------------------------------------------------------------

namespace FunApp.Data.Models
{
    using Common;

    public class JokeBuffer:BaseModel<int>
    {
        public string Content { get; set; }

        public string CategoryName { get; set; }
    }
}