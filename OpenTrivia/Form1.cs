using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenTriviaConsumer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            client = new HttpClient();
            client.BaseAddress = new Uri("https://opentdb.com");
        }

        private static HttpClient client;

        private async void Form1_Load(object sender, EventArgs e)
        {
            HttpResponseMessage response =
                await client.GetAsync("api_category.php");
            if (response.IsSuccessStatusCode)
            {
                string cats =
                    await response.Content.ReadAsStringAsync();

                CategoryResponse catResponse =
                    JsonConvert.DeserializeObject<CategoryResponse>(cats);

                PopulateCategoryComboBox(catResponse);
            }
        }

        private void PopulateCategoryComboBox(CategoryResponse catResponse)
        {
            //cboCategories.DataSource = catResponse.trivia_categories;
            //cboCategories.DisplayMember = nameof(TriviaCategory.name);

            List<TriviaCategory> entertainment = getEntertainmentCategories(catResponse);

            foreach (TriviaCategory category in entertainment)
            {
                cboCategories.Items.Add(category.name);
            }
        }

        private static List<TriviaCategory> getEntertainmentCategories(CategoryResponse catResponse)
        {
            //LINQ to Objects
            //all entertainment categories sorted alphabetically
            return catResponse.trivia_categories
                            .Where(c => c.name.StartsWith("Entertainment"))
                            .OrderBy(c => c.name)
                            .ToList();
        }

        private async void cboCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategories.SelectedIndex < 0)
                return;

            ////Get selected category id
            //TriviaCategory cat = (TriviaCategory)cboCategories.SelectedItem;
            TriviaCategory cat =
                    cboCategories.SelectedItem as TriviaCategory;
            int selectedId = cat.id;

            //Get number of questions in that category
            HttpResponseMessage msg =
                await client.GetAsync($"api_count.php?category={selectedId}");

            if (msg.IsSuccessStatusCode)
            {
                string response = await msg.Content.ReadAsStringAsync();
                MessageBox.Show(response);
            }
        }
    }
}
