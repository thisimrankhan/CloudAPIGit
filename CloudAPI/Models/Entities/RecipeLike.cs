using CloudAPI.ApplicationCore.Entities;
using System;

namespace CloudAPI.Models.Entities
{
    public class RecipeLike: BaseEntity
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public string UserId { get; set; }
        public bool IsLiked { get; set; }
        public DateTime LikedDate { get; set; }
    }
}
