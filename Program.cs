using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Order;

using Test;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, Benchmark!");



var summary = BenchmarkRunner.Run<TestIsPrime>();


var testIsPrime=new TestIsPrime();

 Console.WriteLine($"IsPrimeSimple antalPrimes={testIsPrime.IsPrimeSimple()}");
 Console.WriteLine($"IsPrimeBetter antalPrimes={testIsPrime.IsPrimeBetter()}");
Console.WriteLine($"IsPrimeBest antalPrimes={testIsPrime.IsPrimeBest()}");
Console.WriteLine($"IsPrimeSveinParallel antalPrimes={testIsPrime.IsPrimeSveinParallel()}");





