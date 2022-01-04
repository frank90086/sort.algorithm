using System.Collections.Generic;
using BenchmarkDotNet.Running;
using Sort.Algorithm;

var summary = BenchmarkRunner.Run<Algorithm>();
Console.Read();