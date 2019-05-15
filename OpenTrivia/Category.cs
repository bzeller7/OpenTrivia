using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTriviaConsumer
{
    /// <summary>
    ///A single category
    /// </summary>
    public class TriviaCategory
    {
        public int id { get; set; }
        public string name { get; set; }

        public override string ToString()
        {
            return name;
        }
    }

    /// <summary>
    /// This object is return, when requesting
    /// all categories
    /// </summary>
    public class CategoryResponse
    {
        
        public List<TriviaCategory> trivia_categories { get; set; }
    }
}
