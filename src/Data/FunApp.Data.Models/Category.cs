using System;
using System.Collections.Generic;
using System.Text;

namespace FunApp.Models
{
    using Data.Common;

    public class Category:BaseModel<int>
    {
        public string Name { get; set; }
    }
}
