using System.ComponentModel.DataAnnotations;
using CardsWeb.Models.Base;
using CardsWeb.Models.Enums;

namespace Cards.Models
{
    public class Card : BaseModel
    {
        [Required]
        public string Name { get; set; }

        [RegularExpression("^#[a-zA-Z0-9]{6}$")]
        public string Color { get; set; }

        public Status Status { get; set; } = Status.ToDo;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
