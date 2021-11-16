using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;

namespace Lesson4_Exercise1_Algs
{

    //Benchmark для массива и хешсета.
    public class Program
    {

        public string forArr;
        public string forHash;
        public int max = 10000;
        public int hashCount = 0;
        public HashSet<string> hashSearch { get; set; }
        public string[] arrSearch { get; set; }



        public Program()
        {

            arrSearch = new string[max];
            hashSearch = new HashSet<string>();

            while (hashCount < max)
            {

                if (hashCount == 8985)
                {
                    forHash = Guid.NewGuid().ToString();
                    hashSearch.Add(forHash);
                }
                else
                {
                    hashSearch.Add(Guid.NewGuid().ToString());
                }

                hashCount++;
            }

            for (int i = 0; i < arrSearch.Length; i++)
            {

                if (i == 8985)
                {
                    forArr = Guid.NewGuid().ToString();
                    arrSearch[i] = forArr;
                }
                else
                {
                    arrSearch[i] = Guid.NewGuid().ToString();
                }
            }
        }


            public  bool FindInArr()
        {
            bool ss = false;

            for(int i = 0; i < arrSearch.Length; i++)
            {
                if (arrSearch[i] == forArr)
                {
                    ss = true;
                    break;
                }
                
            }

            return ss;
        }

        
        public  bool FindInHash()
        {
            bool ss = false;          
            ss = hashSearch.Contains(forHash);

            return ss;
        }


        [Benchmark]
        public void testArr()
        {
            FindInArr();
        }


        [Benchmark]
        public void testHash()
        {
            FindInHash();
        }

    }

    public static class Main_
    {


        static void Main(string[] args)
        {

            //var ss = new Program();

            //bool kk = ss.FindInHash();
            //bool jj = ss.FindInArr();
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

        }
            


        
    }
}
