using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Order;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, Benchmark!");



 var summary = BenchmarkRunner.Run<TestIsPrime>();


var testIsPrime=new TestIsPrime();

 Console.WriteLine($"IsPrimeSimple antalPrimes={testIsPrime.IsPrimeSimple()}");
 Console.WriteLine($"IsPrimeBetter antalPrimes={testIsPrime.IsPrimeBetter()}");

  [MemoryDiagnoser]
  [Orderer(SummaryOrderPolicy.FastestToSlowest)]
  [RankColumn()]
public class TestIsPrime {
  
    const long MAX=20;


[Benchmark]
     public long IsPrimeSimple() {
     
        Func<long,bool> isPrime= (p)=> {
         if ( p <2) return false;
         if ( p==2) return true;
         if ( p % 2==0) return false;
         
         for( long t=3;t<p;t+=2) {
             if ( p % t==0) return false;
         }
          return true;
        };

     
         return FindNumbersOfPrimes(isPrime);
     }


    [Benchmark]
     public long IsPrimeBetter() {

        Func<long,bool> isPrime= (p)=> {
         if ( p <2) return false;
         if ( p==2) return true;
         if ( p % 2==0) return false;
         
         for( long t=3;t<p;t+=2) {
             if ( p % t==0) return false;
         }
          return true;
        };

         return FindNumbersOfPrimes(isPrime);
     }
   
   
     private long FindNumbersOfPrimes( Func<long,bool> isPrime) {
        long antalPrimes=0;
        for(long primeCandidate=2;primeCandidate<=MAX;primeCandidate++) {
            antalPrimes+=isPrime(primeCandidate)?1:0;
        } 

         return antalPrimes;
     }
}
