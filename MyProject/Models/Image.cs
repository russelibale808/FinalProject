using System.ComponentModel.DataAnnotations.Schema;

namespace MyProject.Models
{
    public class Image
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Folder { get; set; } = String.Empty;
        public string FileName { get; set; } = String.Empty;

        public int KeyboardID { get; set; }
        public virtual Keyboard? Keyboard { get; set; }


    }

}
