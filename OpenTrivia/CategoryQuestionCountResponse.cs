using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTrivia
{
    public class CategoryQuestionCount
    {
        /// <summary>
        /// Gets/Sets the total number of questions for
        /// a specific category
        /// </summary>
        [JsonProperty("total_question_count")]
        public int TotalQuestions { get; set; }

        public int total_easy_question_count { get; set; }
        public int total_medium_question_count { get; set; }
        public int total_hard_question_count { get; set; }
    }

    public class CategoryQuestionCountResponse
    {
        public int category_id { get; set; }
        public CategoryQuestionCount category_question_count { get; set; }
    }
}
