using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ZombieParty.Models
{
    public class Weapon : IValidatableObject
    {
        [Required]
        [Range(2, 250)]
        [DisplayName("Weapon's Name")]
        public string Name { get; set; }
        [Range(0, 2500)]
        [DataType(DataType.MultilineText)]
        [DisplayName("Weapon's Description")]
        public string? Description { get; set; }
        [Range(0, 500)]
        public decimal Force { get; set; }
        [Range(0, 100000, ErrorMessage = "The price must be between {0} and {1}"), DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayName("Created Date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [DataType(DataType.ImageUrl)]
        [DisplayName("Weapon's Image")]
        public string? Image { get; set; }
        public int Qty { get; set; }
        [DisplayName("Qty Bought")]
        public int QtyBought { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var item = validationContext.ObjectInstance as Weapon;
            if (item == null) yield break;
            if (string.IsNullOrWhiteSpace(item.Description)) yield break;
            if (item.Description.Split(" ").Length <= 3)
                yield return new ValidationResult("Description needs to have more than 3 words please.", new[] { "Description" });
        }

    }
}
