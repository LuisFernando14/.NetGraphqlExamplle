using System;
namespace Ojala.Models
{
    public class Dog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Owner { get; set; }

        public Dog(int Id, string Name, int Age, string Owner)
        {
            this.Id = Id;
            this.Name = Name;
            this.Age = Age;
            this.Owner = Owner;
        }
    }
}
