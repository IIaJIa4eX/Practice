using System;

namespace Lesson5_Exercise1_OOP
{



    class RatioNumber
    {
        private int m_Number; //верх

        private int n_Number;

        private int integerPart;



        public RatioNumber()
        {

        }

        public RatioNumber(int integerPart, int m_Number, int n_Number)
        {
            this.integerPart = integerPart;
            this.m_Number = m_Number;
            this.n_Number = n_Number;
        }


        public RatioNumber(int m_Number, int n_Number)
        {
            this.m_Number = m_Number;
            this.n_Number = n_Number;
        }

        public bool Equals(RatioNumber ratNum)
        {

            if (ratNum == null)
                return false;

            return ratNum.m_Number == m_Number && ratNum.n_Number == n_Number;
        }

        public static bool operator ==(RatioNumber r1, RatioNumber r2)
        {

            if (r1.m_Number == r2.m_Number && r1.n_Number == r2.m_Number)
                return true;
            return false;
        }

        public static bool operator !=(RatioNumber r1, RatioNumber r2)
        {

            if (r1.m_Number != r2.m_Number || r1.n_Number != r2.m_Number)
                return true;
            return false;
        }

        public static bool operator >(RatioNumber r1, RatioNumber r2)
        {

            if (r1.m_Number == r2.m_Number)
            {
                if (r1.n_Number < r2.n_Number)
                {
                    return true;
                }

                return false;
            }

            if (r1.n_Number == r2.n_Number)
            {
                if (r1.m_Number > r2.m_Number)
                {
                    return true;
                }

                return false;
            }

            int nok = lcm(r1.n_Number, r2.n_Number);

            int first = nok / r1.n_Number;
            int second = nok / r2.n_Number;

            if (first * r1.m_Number > second * r2.m_Number)
                return true;

            return false;
        }

        static int gcd(int a, int b)
        {
            return b != 0 ? gcd(b, a % b) : a; ;
        }

        static int lcm(int a, int b)
        {
            return a / gcd(a, b) * b;
        }


        public static bool operator <(RatioNumber r1, RatioNumber r2)
        {
            if (r1.m_Number == r2.m_Number)
            {
                if (r1.n_Number > r2.n_Number)
                {
                    return true;
                }

                return false;
            }

            if (r1.n_Number == r2.n_Number)
            {
                if (r1.m_Number < r2.m_Number)
                {
                    return true;
                }

                return false;
            }

            int nok = lcm(r1.n_Number, r2.n_Number);

            int first = nok / r1.n_Number;
            int second = nok / r2.n_Number;

            if (first * r1.m_Number < second * r2.m_Number)
                return true;

            return false;

        }

        public static bool operator <=(RatioNumber r1, RatioNumber r2)
        {
            if (r1.m_Number == r2.m_Number)
            {
                if (r1.n_Number >= r2.n_Number)
                {
                    return true;
                }

                return false;
            }

            if (r1.n_Number == r2.n_Number)
            {
                if (r1.m_Number <= r2.m_Number)
                {
                    return true;
                }

                return false;
            }

            int nok = lcm(r1.n_Number, r2.n_Number);

            int first = nok / r1.n_Number;
            int second = nok / r2.n_Number;

            if (first * r1.m_Number <= second * r2.m_Number)
                return true;

            return false;
        }

        public static bool operator >=(RatioNumber r1, RatioNumber r2)
        {
            if (r1.m_Number == r2.m_Number)
            {
                if (r1.n_Number <= r2.n_Number)
                {
                    return true;
                }

                return false;
            }

            if (r1.n_Number == r2.n_Number)
            {
                if (r1.m_Number >= r2.m_Number)
                {
                    return true;
                }

                return false;
            }

            int nok = lcm(r1.n_Number, r2.n_Number);

            int first = nok / r1.n_Number;
            int second = nok / r2.n_Number;

            if (first * r1.m_Number >= second * r2.m_Number)
                return true;

            return false;
        }



        public static RatioNumber operator +(RatioNumber r1, RatioNumber r2)
        {
            int commonM;

            if (r1.n_Number == r2.n_Number)
            {
                commonM = r1.m_Number + r2.m_Number;

                if (commonM == r1.n_Number)
                {
                    int _gcd = gcd(commonM, r1.n_Number);

                    if (_gcd != 1)
                    {
                        int m = commonM / _gcd;
                        int n = r1.n_Number / _gcd;

                        return new RatioNumber() { integerPart = m / n, m_Number = m % n, n_Number = n };
                    }

                    return new RatioNumber() { integerPart = commonM / r1.n_Number, m_Number = commonM % r1.n_Number, n_Number = r1.n_Number };
                }

                int _gcd2 = gcd(commonM, r1.n_Number);

                if (_gcd2 != 1)
                {
                    int m = commonM / _gcd2;
                    int n = r1.n_Number / _gcd2;

                    return new RatioNumber() { integerPart = m / n, m_Number = m % n, n_Number = n };
                }


                return new RatioNumber() { m_Number = commonM, n_Number = r1.n_Number };
            }

            int nok = lcm(r1.n_Number, r2.n_Number);

            int first = nok / r1.n_Number;
            int second = nok / r2.n_Number;


            int m_r1 = r1.m_Number * first;
            int m_r2 = r2.m_Number * second;

            int commonN = r1.n_Number * first;

            commonM = m_r1 + m_r2;

            if (commonM >= commonN)
            {
                int _gcd3 = gcd(commonM, commonN);

                if (_gcd3 != 1)
                {
                    int m = commonM / _gcd3;
                    int n = commonN / _gcd3;

                    return new RatioNumber() { integerPart = m / n, m_Number = m % n, n_Number = n };
                }

                return new RatioNumber() { integerPart = commonM / commonN, m_Number = commonM % commonN, n_Number = commonN };
            }

            int _gcd4 = gcd(commonM, commonN);

            if (_gcd4 != 1)
            {
                int m = commonM / _gcd4;
                int n = commonN / _gcd4;

                return new RatioNumber() { integerPart = m / n, m_Number = m % n, n_Number = n };
            }

            return new RatioNumber() { m_Number = commonM, n_Number = commonN };
        }

        public static RatioNumber operator -(RatioNumber r1, RatioNumber r2)
        {
            int commonM;

            if (r1.n_Number == r2.n_Number)
            {
                commonM = r1.m_Number - r2.m_Number;

                if (commonM == r1.n_Number)
                {
                    int _gcd = gcd(commonM, r1.n_Number);

                    if (_gcd != 1)
                    {
                        int m = commonM / _gcd;
                        int n = r1.n_Number / _gcd;

                        return new RatioNumber() { integerPart = m / n, m_Number = m % n, n_Number = n };
                    }

                    return new RatioNumber() { integerPart = commonM / r1.n_Number, m_Number = commonM % r1.n_Number, n_Number = r1.n_Number };
                }

                int _gcd2 = gcd(commonM, r1.n_Number);

                if (_gcd2 != 1)
                {
                    int m = commonM / _gcd2;
                    int n = r1.n_Number / _gcd2;

                    return new RatioNumber() { integerPart = m / n, m_Number = m % n, n_Number = n };
                }


                return new RatioNumber() { m_Number = commonM, n_Number = r1.n_Number };
            }

            int nok = lcm(r1.n_Number, r2.n_Number);

            int first = nok / r1.n_Number;
            int second = nok / r2.n_Number;


            int m_r1 = r1.m_Number * first;
            int m_r2 = r2.m_Number * second;

            int commonN = r1.n_Number * first;

            commonM = m_r1 - m_r2;

            if (commonM >= commonN)
            {
                int _gcd3 = gcd(commonM, commonN);

                if (_gcd3 != 1)
                {
                    int m = commonM / _gcd3;
                    int n = commonN / _gcd3;

                    return new RatioNumber() { integerPart = m / n, m_Number = m % n, n_Number = n };
                }

                return new RatioNumber() { integerPart = commonM / commonN, m_Number = commonM % commonN, n_Number = commonN };
            }

            int _gcd4 = gcd(commonM, commonN);

            if (_gcd4 != 1)
            {
                int m = commonM / _gcd4;
                int n = commonN / _gcd4;

                return new RatioNumber() { integerPart = m / n, m_Number = m % n, n_Number = n };
            }

            return new RatioNumber() { m_Number = commonM, n_Number = commonN };
        }


        public override string ToString()
        {
            if (integerPart != 0)
            {
                return $"{integerPart} {m_Number}/{n_Number}";
            }

            return $"{m_Number}/{n_Number}";
        }

        public static RatioNumber operator --(RatioNumber r)
        {
            if (r.m_Number - 1 <= 0)
            {
                return r;
            }

            return new RatioNumber() { integerPart = r.integerPart, m_Number = r.m_Number - 1, n_Number = r.n_Number };


        }

        public static RatioNumber operator ++(RatioNumber r)
        {
            if (r.m_Number - 1 <= 0)
            {
                return r;
            }

            return new RatioNumber() { integerPart = r.integerPart, m_Number = r.m_Number + 1, n_Number = r.n_Number };
        }


        public static implicit operator float(RatioNumber r)
        {

                return (float)r.m_Number / (float)r.n_Number;

        }

        public static implicit operator int(RatioNumber r)
        {

            return r.m_Number / r.n_Number; ;
        }


        public static RatioNumber operator *(RatioNumber r1, RatioNumber r2)
        {
            int commonM = r1.m_Number * r2.m_Number;
            int commonN = r1.n_Number * r2.n_Number;

            if (commonM > commonN)
            {
                int _gcd = gcd(commonM, commonN);

                if (_gcd != 1)
                {
                    int m = commonM / _gcd;
                    int n = commonN / _gcd;

                    return new RatioNumber() { integerPart = m / n, m_Number = m % n, n_Number = n };
                }

                return new RatioNumber() { integerPart = commonM / commonN, m_Number = commonM % commonN, n_Number = commonN };
            }

            int _gcd2 = gcd(commonM, commonN);

            if (_gcd2 != 1)
            {
                int m = commonM / _gcd2;
                int n = commonN / _gcd2;

                return new RatioNumber() { integerPart = m / n, m_Number = m % n, n_Number = n };
            }

            return new RatioNumber() { m_Number = r1.m_Number * r2.m_Number, n_Number = r1.n_Number * r2.n_Number };
        }

        public static RatioNumber operator /(RatioNumber r1, RatioNumber r2)
        {

            int commonM = r1.m_Number * r2.n_Number;
            int commonN = r1.n_Number * r2.m_Number;

            if (commonM > commonN)
            {
                int _gcd = gcd(commonM, commonN);

                if (_gcd != 1)
                {
                    int m = commonM / _gcd;
                    int n = commonN / _gcd;

                    return new RatioNumber() { integerPart = m / n, m_Number = m % n, n_Number = n };
                }

                return new RatioNumber() { integerPart = commonM / commonN, m_Number = commonM % commonN, n_Number = commonN };
            }

            int _gcd2 = gcd(commonM, commonN);

            if (_gcd2 != 1)
            {
                int m = commonM / _gcd2;
                int n = commonN / _gcd2;

                return new RatioNumber() { integerPart = m / n, m_Number = m % n, n_Number = n };
            }

            return new RatioNumber() { m_Number = r1.m_Number * r2.m_Number, n_Number = r1.n_Number * r2.n_Number };
        }

        class Program
        {


            static void Main(string[] args)
            {
                RatioNumber n1 = new RatioNumber(4, 7);
                RatioNumber n2 = new RatioNumber(6, 5);

                bool dr = n2 > n1;

                var minus = n1 - n2;
                var plus = n1 + n2;
                var milti = n1 * n2;
                var dev = n1 / n2;

                //var test = n1 - n2;
                float a = (float)n1;
                var tsets = --n1;
                Console.WriteLine(n1.ToString());
            }
        }
    }
}