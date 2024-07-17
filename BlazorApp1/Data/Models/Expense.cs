    using System.ComponentModel.DataAnnotations.Schema;

    namespace BlazorApp1.Data.Models
    {
        public class Expense
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public DateTime Date { get; set; }
            public decimal Amount { get; set; }
            public bool Planned { get; set; }
            public int CategoryId { get; set; }     

            [ForeignKey("CategoryId")]
            public virtual Category Category { get; set; }
        }   
    }
