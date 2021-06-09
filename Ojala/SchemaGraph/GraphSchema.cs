using System;
using GraphQL;
using GraphQL.Types;
using Ojala.Queries;
// using EFC.Types;
using Microsoft.Extensions.DependencyInjection;

namespace Ojala.SchemaGraph
{
    public class GraphSchema : Schema
    {
        public GraphSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<Dogs>();
        }
    }
}
