using System.ComponentModel.DataAnnotations;

namespace WebAppShiba.Models
{
    public class Shiba
    {
        [Key]
        public string Url { get; set; }

        public Shiba():this("")
        {

        }

        public Shiba(string url)
        {
            Url = url;
        }
    }
}
