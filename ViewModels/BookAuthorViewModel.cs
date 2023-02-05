using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ThirdDotNet.Models;

namespace ThirdDotNet.ViewModels
{
    public class BookAuthorViewModel
    {
        public int BookId { get; set; }
        
        [Required]
        [MinLength(5)]
        public string Title { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        [Required]
        public int AuthorId { get; set; }
        
        public List<Author> Authors { get; set; }


        public BookAuthorViewModel()
        {
            BookId = 0;
            Title = "";
            Description = "";
            AuthorId = 0;
            Authors = new List<Author>();
        }
    }
}