//  ------------------------------------------------------------------------------------------------
//   <copyright file="BaseModel.cs" company="Business Management System Ltd.">
//       Copyright "2019" (c), Business Management System Ltd.
//       All rights reserved.
//   </copyright>
//   <author>Nikolay.Kostadinov</author>
//  ------------------------------------------------------------------------------------------------

namespace FunApp.Data.Common
{
    public abstract class BaseModel<T>
    {
        public T Id { get; set; }
    }
}