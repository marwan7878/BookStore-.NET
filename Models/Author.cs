using System.Collections.Generic;

namespace ThirdDotNet.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        
        public Author()
        {
            Id = 0;
            Name = "";

        }
        public Author(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
