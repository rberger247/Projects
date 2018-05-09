using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace resterauntWeb.Models
{
    public class Reviews
    {
        [Key]
        [Display(Name = "Restaurant Name")]
        public int Id { get; set; }
        [Required(ErrorMessage = "A Rating is required")]
        [Range(1, 10)]
        public double Rating { get; set; }
        [StringLength(200)]
        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? Created { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? Modified { get; set; }
        //  [Required]
        [ForeignKey("RestaurantId")]
        [Display(Name = "Restaurant Name")]
        public int RestaurauntId { get; set; }
        public virtual Restaurant RestaurantId { get; set; }
    }
}