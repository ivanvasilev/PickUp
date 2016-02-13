namespace PickUp.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using PickUp.Data.Common.Models;

    public class Rate : BaseModel<int>
    {
        [Range(1, 5)]
        [Required]
        public int Value { get; set; }

        public string RaterId { get; set; }

        public virtual ApplicationUser Rater { get; set; }

        public string RatedId { get; set; }

        public virtual ApplicationUser Rated { get; set; }
    }
}
