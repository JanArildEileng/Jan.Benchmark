using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, Benchmark!");


MyTestPrimeCalc myTestPrimeCalc=new MyTestPrimeCalc();

 Console.WriteLine($"NumberOfPrimesTestSimple antalPrimes={myTestPrimeCalc.NumberOfPrimesTestSimple()}");
 Console.WriteLine($"NumberOfPrimesTestBetter antalPrimes={myTestPrimeCalc.NumberOfPrimesTestBetter()}");

 var summary = BenchmarkRunner.Run<MyTestPrimeCalc>();




public class MyTestPrimeCalc {
  
    const long MAX=20;


[Benchmark]
     public long NumberOfPrimesTestSimple() {
       long antalPrimes=0;

        Func<long,bool> isPrime= (p)=> {
         if ( p <2) return false;
         if ( p==2) return true;
         if ( p % 2==0) return false;
         
         for( long t=3;t<p;t+=2) {
             if ( p % t==0) return false;
         }
          return true;
        };

         for(long primeCandidate=2;primeCandidate<=MAX;primeCandidate++) {
            antalPrimes+=isPrime(primeCandidate)?1:0;
         } 

         return antalPrimes;
     }


    [Benchmark]
     public long NumberOfPrimesTestBetter() {
       long antalPrimes=0;

        Func<long,bool> isPrime= (p)=> {
         if ( p <2) return false;
         if ( p==2) return true;
         if ( p % 2==0) return false;
         
         for( long t=3;t<p;t+=2) {
             if ( p % t==0) return false;
         }
          return true;
        };

         for(long primeCandidate=2;primeCandidate<=MAX;primeCandidate++) {
            antalPrimes+=isPrime(primeCandidate)?1:0;
         } 

         return antalPrimes;
     }
   
   
   



}
