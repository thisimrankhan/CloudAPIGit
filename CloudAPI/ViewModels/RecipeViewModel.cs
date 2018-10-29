using CloudAPI.ApplicationCore.Entities;
using System;

namespace CloudAPI.ViewModels
{
    public class RecipeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public string Image { get; set; }
        public int Rating { get; set; }
        public int LikeCount { get; set; }
        public bool isLiked { get; set; }
        public DateTime RecipeDate { get; set; }
    }
}
