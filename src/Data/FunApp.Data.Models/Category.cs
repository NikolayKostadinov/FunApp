using System;
using System.Collections.Generic;
using System.Text;

namespace FunApp.Models
{
    using Data.Common;

    public class Category:BaseModel<int>
    {
        public Category()
        {
            Jokes = new HashSet<Joke>();
        }

        public string Name { get; set; }
        public virtual ICollection<Joke> Jokes { get; set; }
    }
}
