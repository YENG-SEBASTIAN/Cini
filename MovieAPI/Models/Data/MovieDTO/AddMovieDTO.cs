using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Models.Data.MovieDTO
{
    public class AddMovieDTO
    {

        public string Title { get; set; }

        public string Genre { get; set; }

        public DateTime ReleaseYear {get; set;} = DateTime.Now;
    }
}