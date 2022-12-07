using System.ComponentModel.DataAnnotations.Schema;

namespace MyProject.Models
{
    public class Keyboard
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Brand { get; set; }
        public string Size { get; set; }
        public string Description { get; set; }

        


        public virtual ICollection<Image>? Images { get; set; }


    }
}
