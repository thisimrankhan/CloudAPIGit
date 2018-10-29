using CloudAPI.ApplicationCore.Entities;
using System;

namespace CloudAPI.Models.Entities
{
    public class RecipeRating : BaseEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int RecipeId { get; set; }
        public int Rating { get; set; }
        public DateTime RatingDate { get; set; }
    }
}
