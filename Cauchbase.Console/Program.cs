using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using Couchbase;
using Couchbase.KeyValue;

namespace Cauchbase.Console
{
    public class Program

    {
        static async Task Main(string[] args)
        {
            var collection = await GetCollection();
            
            var id = Guid.NewGuid().ToString();
            var list = GetSampleData(10000);

            await UpsertAsync(collection, id, list);

            //// get
            //watch.Start();

            //var result = await collection.GetAsync(id);
            //System.Console.WriteLine(result.ContentAs<dynamic>());

            //watch.Stop();
            //System.Console.WriteLine($"Get ItemCount:{list.Count} row, ElapsedTime:{watch.Elapsed.Milliseconds} ms");

            System.Console.ReadKey();
        }

        private static IEnumerable<TestEntity> GetSampleData(int count)
        {
            // timer
            var watch = new Stopwatch();
            watch.Start();

            var fixture = new Fixture();
            var list = fixture.CreateMany<TestEntity>(count);
            
            // stop timer
            watch.Stop();
            System.Console.WriteLine($"Fixture ItemCount:{count} row, ElapsedTime:{watch.Elapsed.Milliseconds} ms");

            return list;
        }

        private static async Task<ICouchbaseCollection> GetCollection()
        {
            // timer
            var watch = new Stopwatch();
            watch.Start();

            // server
            var cluster = await Cluster.ConnectAsync("couchbase://localhost", "Administrator", "Password12*");

            // database
            var bucket = await cluster.BucketAsync("beer-sample");

            // schema
            var scope = await bucket.ScopeAsync("_default");

            // table
            var collection = await scope.CollectionAsync("itemMaster");

            // stop timer
            watch.Stop();
            System.Console.WriteLine($"Connection, ElapsedTime:{watch.Elapsed.Milliseconds} ms");

            return collection;
        }

        private static async Task UpsertAsync(ICouchbaseCollection collection, string id, IEnumerable<TestEntity> list)
        {
            // timer
            var watch = new Stopwatch();
            watch.Start();

            // add-or-update
            await collection.UpsertAsync(id, list);

            // stop timer
            watch.Stop();
            System.Console.WriteLine($"Save, ElapsedTime:{watch.Elapsed.Milliseconds} ms");
        }

        private async Task Test()
        {
            // server
            var cluster = await Cluster.ConnectAsync("couchbase://localhost", "Administrator", "Password12*");

            // database
            var bucket = await cluster.BucketAsync("beer-sample");

            // get a user-defined collection reference
            // schema
            var scope = await bucket.ScopeAsync("_default");
            // table
            var collection = await scope.CollectionAsync("itemMaster");

            // add-or-update
            await collection.UpsertAsync("id01", new TestEntity { Code = "code-01", Name = "name-01", Desc = "desc-01" });

            // get
            var result = await collection.GetAsync("id01");
            System.Console.WriteLine(result.ContentAs<dynamic>());
        }
    }

    public class TestEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string AttributeA { get; set; }
        public string AttributeB { get; set; }
        public string AttributeC { get; set; }
        public string AttributeD { get; set; }
        public string AttributeE { get; set; }
        public string AttributeF { get; set; }
        public string AttributeG { get; set; }
        public string AttributeH { get; set; }
        public string AttributeI { get; set; }
        public string AttributeJ { get; set; }
        public string AttributeK { get; set; }
        public string AttributeL { get; set; }
        public string AttributeM { get; set; }
        public string AttributeN { get; set; }
        public string AttributeO { get; set; }
        public string AttributeP { get; set; }
        public string AttributeQ { get; set; }
        public string AttributeR { get; set; }
        public string AttributeS { get; set; }
        public string AttributeT { get; set; }
        public string AttributeU { get; set; }
        public string AttributeV { get; set; }
        public string AttributeW { get; set; }
        public string AttributeX { get; set; }
        public string AttributeY { get; set; }
        public string AttributeZ { get; set; }
    }
}
