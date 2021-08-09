using System.ComponentModel.DataAnnotations;

namespace SessionDemo.Models
{
    public class StoryFragment
    {
        [Display(Name = "Add a word to the story!")]
        public string Word { get; set; }
    }
}