using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FilmDude2.Models;

namespace FilmDude2.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movies Movie { get; set; }
        public List<Customer> Customer { get; set; }
    }
}