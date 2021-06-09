using System.Collections.Generic;
using GraphQL.Types;
using DogType = Ojala.Types.Dog;
using Ojala.Models;
using GraphQL;

namespace Ojala.Queries
{
    public class Dogs : ObjectGraphType
    {
        private List<Dog> GetDogs(int id)
        {
            List<Dog> dogs = new List<Dog>();
            for (int i = 0; i < 10; i++)
            {
                dogs.Add(new Dog(i, "Gorda" + i, 1 + i, "Wilfrido" + i));
            }
            return dogs.FindAll(x => x.Id == id);
        }

        public Dogs()
        {
            Field<ListGraphType<DogType>>("Dogs", arguments: new QueryArguments(new List<QueryArgument>
            {
                new QueryArgument<IdGraphType>
                {
                    Name="id"
                }
            }),
            resolve: context =>
            {
                // var dogRepository = new DogRepository(serviceProvider); MAL
                

                var id = context.GetArgument<int>("id");
                var response = this.GetDogs(id);
                // var response = dogRepository.Get(id).GetAwaiter().GetResult();
                return response;
            }
            );
        }
    }
}