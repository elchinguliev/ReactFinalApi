using System.ComponentModel.DataAnnotations;

namespace ReactFinalApi.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PublishDate { get; set; }
        public string Author { get; set; }
        public string ImageUrl { get; set; }



    }
}
