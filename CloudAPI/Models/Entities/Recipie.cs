using CloudAPI.ApplicationCore.Entities;

namespace CloudAPI.Models.Entities
{
    public class Recipie: BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AppUser Identity { get; set; }  // navigation property
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public string Image { get; set; }
        public int Rating { get; set; }

    }
}
