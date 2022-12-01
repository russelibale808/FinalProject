using System.ComponentModel.DataAnnotations.Schema;

namespace MyProject.Models
{
    public class Keyboard
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Title { get; set; } = String.Empty;
        public string Url { get; set; } = String.Empty;
        public string Brand { get; set; } = String.Empty;
        public string Size { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;


        public virtual ICollection<Image>? Images { get; set; }


    }
}
