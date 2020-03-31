using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController: Controller
    {
        private readonly List<Movie> _movies;
        
        public MoviesController()
        {
                _movies = new List<Movie>()
                {
                    new Movie()
                    {
                        Id = 1,
                        Name = "Talash"
                    },
                    new Movie()
                    {
                        Id = 2,
                        Name = "Table No. 21"
                    }
                    
                };
        }
        
        public IActionResult Index()
        {
            return View(_movies);
        }
        
        public IActionResult Random()
        {
            Movie movie = new Movie()
            {
                Name = "Shrek"
            };
            
            List<Customer> customers = new List<Customer>()
            {
                new Customer() { Name = "Himanshu Sharma" },
                new Customer() { Name = "Shivani Bansal" }
            };
            
            RandomMovieViewModel viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };
            
            return View(viewModel);
        }

        [Route("movies/released/{pageIndex:regex(\\d{{2}})}/{sortBy:minlength(2)}")]
        public IActionResult Test(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }
            if (sortBy == null)
            {
                sortBy = "Name";
            }
            return Content(String.Format($"Page Index = {pageIndex}, Sort By = {sortBy}"));
        }
    }
}