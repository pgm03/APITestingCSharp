using System.Collections.Generic;

namespace APIDemo
{
    public partial class CreatePetDTO
    {
        public double Id { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public List<string> PhotoUrls { get; set; }
        public List<Category> Tags { get; set; }
        public string Status { get; set; }
    }

    public partial class Category
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
