using System;
using System.Collections.Generic;
using System.Text;

namespace FunApp.Models
{
    using Data.Common;

    public class Joke : BaseModel<int>
    {
        public string Content { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
