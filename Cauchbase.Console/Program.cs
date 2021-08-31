using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using App.Metrics.Serialization;
using Couchbase;
using Couchbase.Extensions.DependencyInjection;

namespace Cauchbase.Console
{
    public class Program

    {
        static async Task Main(string[] args)
        {
            var clusterOptions = new ClusterOptions
            {
                UserName = "Administrator",
                Password = "Password12*",
                ConnectionString = "couchbase://localhost"
            };

            var cluster = await Cluster.ConnectAsync(
                clusterOptions.ConnectionString,
                clusterOptions.UserName,
                clusterOptions.Password);

            var bucket = await cluster.BucketAsync("beer-sample");
            
            var collection = await bucket.CollectionAsync("_default");
            _ = await collection.InsertAsync("id01", new TestEntity { Code = $"ddd" });
            
            System.Console.WriteLine("Hello World!");
        }
    }

    public class TestEntity
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
    }
}
