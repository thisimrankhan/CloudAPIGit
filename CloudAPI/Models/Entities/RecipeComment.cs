using CloudAPI.ApplicationCore.Entities;
using System;

namespace CloudAPI.Models.Entities
{
    public class RecipeComment: BaseEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int RecipeId { get; set; }
        public string Comment { get; set; }
        public DateTime CommentDate { get; set; }
    }
}
