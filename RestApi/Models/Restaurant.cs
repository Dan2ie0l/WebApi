using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Models
{
    public class Restaurant
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Website { get; set; }
        public string SocialMedia { get; set; }
        [NotMapped]
        public ICollection<string> ImagesEdit { get; set; }
        public string Images
        {
            get { return string.Join(",", ImagesEdit); }
            set { ImagesEdit = value.Split(',').ToList(); }
        }


    }
}
