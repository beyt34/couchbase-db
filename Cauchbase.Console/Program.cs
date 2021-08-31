using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using App.Metrics.Serialization;
using Couchbase;
using Couchbase.Extensions.DependencyInjection;

namespace Cauchbase.Console
{
    public class Program

    {
        static void Main(string[] args)
        {
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
