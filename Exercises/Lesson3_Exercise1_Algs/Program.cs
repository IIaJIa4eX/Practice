using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Lesson3_Exercise1_Algs
{

 

    public class Program
    {
        public class PointClass
        {
            public int X;
            public int Y;

        }

        public struct PointStruct
        {
            public int X;
            public int Y;
        }


        public float PointDistance(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }


        public double PointDistanceDb(PointStruct pointOneDb, PointStruct pointTwoDb)
        {
            double x = pointOneDb.X - pointTwoDb.X;
            double y = pointOneDb.Y - pointTwoDb.Y;
            return Math.Sqrt((x * x) + (y * y));
        }

        public float PointDistanceNoSqrt(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return (x * x) + (y * y);
        }


        public float PointDistance(PointClass pointOne, PointClass pointwo)
        {
            float x = pointOne.X - pointwo.X;
            float y = pointOne.Y - pointwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }



        [Benchmark]
        public void TestDistanceFlStruct()
        {
            var point1 = new PointStruct { X = 1245, Y = 1246 };
            var point2 = new PointStruct { X = 666, Y = 665 };
            PointDistance(point1, point2);
        }

        [Benchmark]
        public void TestDistanceDoubleStruct()
        {
            var point1 = new PointStruct { X = 1245, Y = 1246 };
            var point2 = new PointStruct { X = 666, Y = 665 };
            PointDistanceDb(point1, point2);
        }

        [Benchmark]
        public void TestDistanceFlNoSqrtStruct()
        {
            var point1 = new PointStruct { X = 1245, Y = 1246 };
            var point2 = new PointStruct { X = 666, Y = 665 };
            PointDistanceNoSqrt(point1, point2);
        }

        [Benchmark]
        public void TestDistanceFlClass()
        {
            var point1 = new PointClass { X = 1245, Y = 1246 };
            var point2 = new PointClass { X = 666, Y = 665 };
            PointDistance(point1, point2);
        }

        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }
}
