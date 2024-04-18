using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using ObjectMerger;

namespace BenchMarks
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run(typeof(Program).Assembly);
        }
    }

    public class Md5VsSha256
    {
        [Benchmark]
        public PersonRoot Reflection() => MergerReflection.MergeReflection();

        [Benchmark]
        public PersonRoot Traditional() => MergerTraditional.MergeTraditional();
    }
}