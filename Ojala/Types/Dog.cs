using System;
using GraphQL.Types;
using DogEntity = Ojala.Models.Dog;

namespace Ojala.Types
{
    public class Dog : ObjectGraphType<DogEntity>
    {
        public Dog()
        {
            Name = "Dog";
            Field(x => x.Id);
            Field(x => x.Name).Description("Nombre de la mascota");
            Field(x => x.Age);
            Field(x => x.Owner);
        }
    }
}
