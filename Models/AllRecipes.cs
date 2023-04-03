using MessagePack;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace RecipeBook.Models
{
    [Table("AllRecipes")]
    public class AllRecipes
    {

        
        public string ID { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Recipe Name")]
        public string RecipeName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Ingredients")]
        public string RecipeIngredients { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Steps")]
        public string RecipeSteps { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Time")]
        public string RecipeTime { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Date")]
        public DateTime RecipeDate { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Image")]
        public string RecipeImage { get; set; }


        
    }
}
