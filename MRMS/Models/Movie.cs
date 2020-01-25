using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MRMS.Models;
using System.ComponentModel.DataAnnotations;


namespace MRMS.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte GenreId { get; set; }

        public DateTime DateAdded { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        [Required]
        public byte NumberInStock { get; set; }

        [Display(Name = "Number Available")]
        [Required]
        public byte NumberAvailable { get; set; }




    }
}