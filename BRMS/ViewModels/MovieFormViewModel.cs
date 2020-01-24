using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BRMS.Models;
using System.ComponentModel.DataAnnotations;

namespace BRMS.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public byte GenreId { get; set; }

        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        [Required]
        public byte? NumberInStock { get; set; }

        [Display(Name = "Number Available")]
        [Required]
        public byte? NumberAvailable { get; set; }

        public string Title
        {
            get
            {
                return (Id != 0)? "Edit Movie ": " New Movie";
            }
           

        }

        public MovieFormViewModel()
        {
            Id = 0;
        }
        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            GenreId = movie.GenreId;
            ReleaseDate = movie.ReleaseDate;
            NumberAvailable = movie.NumberAvailable;
            NumberInStock = movie.NumberInStock;

        }
    }
}