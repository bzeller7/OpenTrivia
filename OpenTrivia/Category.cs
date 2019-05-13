using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTriviaConsumer
{
    /// <summary>
    /// Represents an Open Trivia
    /// Category
    /// </summary>
    class TriviaCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class CategoryResponse
    {
        
        public List<CategoryResponse> trivia_categories { get; set; }
    }
}
