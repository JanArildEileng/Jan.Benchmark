using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Order;

namespace Test;

  [MemoryDiagnoser]
  [Orderer(SummaryOrderPolicy.FastestToSlowest)]
  [RankColumn()]
public class TestIsPrime {
  
    const long MAX=200000;


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
         
           var upperLimit=(long)Math.Sqrt ((double)p);
          for( long t=3;t<=upperLimit;t+=2) {
             if ( p % t==0) return false;
         }
          return true;
        };

         return FindNumbersOfPrimes(isPrime);
     }
   
     [Benchmark]
     public long IsPrimeBest() {

         //HashSet<long> map=new System.Collections.Generic.HashSet<long>() ;
         List<long> primeFoundListe=new List<long>((int)MAX/5) ;
         
         primeFoundListe.Add(2);

          Func<long,bool> isPrime= (p)=> {
         if ( p <2) return false;
         if ( p==2) return true;
         
         var upperLimit=(long)Math.Sqrt ((double)p);

         foreach(var t in primeFoundListe) {
             if (t>upperLimit) break;
             if ( p % t==0) return false;
         }

         primeFoundListe.Add(p);

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