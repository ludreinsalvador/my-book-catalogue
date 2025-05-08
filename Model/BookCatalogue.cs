using System.ComponentModel.DataAnnotations;

namespace MyBookCatalogue.Model
{
    public class BookCatalogue
    {
        // Use auto-implemented properties
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter the title.")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 60 characters.")]
        public string Title { get; set; }

        [Display(Name = "Author")]
        [Required(ErrorMessage = "Please enter the author's name.")]
        public string Author { get; set; }

        [Display(Name = "ISBN")]
        [RegularExpression(
            @"^(?=(?:\D*\d){10}(?:(?:\D*\d){3})?$)[\d\- ]{13,17}$",
            ErrorMessage = "Invalid ISBN format. Please enter a valid ISBN number.")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Please enter the publisher.")]
        public string Publisher { get; set; }
    }
}
