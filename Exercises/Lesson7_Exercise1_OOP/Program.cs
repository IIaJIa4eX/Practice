using System;

namespace Lesson7_Exercise1_OOP
{
    interface ICoder
    {

        string ENcode(string ss);
        string Decode(string ss);

    }


    class ACoder : ICoder
    {
        public string Decode(string ss)
        {
            char[] tmp = ss.ToCharArray();
            char[] toCovert = new char[ss.Length];


            for (int i = 0; i < ss.Length; i++)
            {
                if (char.IsLetter(tmp[i]))
                {
                    toCovert[i] = Convert.ToChar(Convert.ToInt32(tmp[i]) - 1);
                    continue;
                }

                toCovert[i] = tmp[i];
            }

            return string.Join("", toCovert);
        }

        public string ENcode(string ss)
        {
            char[] tmp = ss.ToCharArray();
            char[] toCovert = new char[ss.Length];


            for(int i = 0; i < ss.Length; i ++)
            {
                if (char.IsLetter(tmp[i]))
                {
                    toCovert[i] = Convert.ToChar(Convert.ToInt32(tmp[i]) + 1);
                    continue;
                }

                toCovert[i] = tmp[i];
            }

            return string.Join("", toCovert);
        }
    }

    class BCoder : ICoder
    {
        public string Decode(string ss)
        {
            return ENcode(ss);
        }

        public string ENcode(string ss)
        {
            char[] tmp = ss.ToCharArray();
            char[] toCovert = new char[ss.Length];

            for (int i = 0; i < ss.Length; i++)
            {

                    if (tmp[i] >= 'А' && tmp[i] <= 'Я')
                    {
                        toCovert[i] = Convert.ToChar('А' + 'Я' - tmp[i]);
                        continue;
                    }
                    if (tmp[i] >= 'а' && tmp[i] <= 'я')
                    {
                        toCovert[i] = Convert.ToChar('а' + 'я' - tmp[i]);
                        continue;
                    }
                    if (tmp[i] >= 'A' && tmp[i] <= 'Z')
                    {
                        toCovert[i] = Convert.ToChar('A' + 'Z' - tmp[i]);
                        continue;
                    }
                    if (tmp[i] >= 'a' && tmp[i] <= 'z')
                    {
                        toCovert[i] = Convert.ToChar('a' + 'z' - tmp[i]);
                        continue;
                    }

                toCovert[i] = tmp[i];
            }


            return string.Join("", toCovert);
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            ACoder tmp = new ACoder();
            BCoder tmp2 = new BCoder();
            string ss = tmp.ENcode("Аллелуя, братья! Hallelujah, brothers!");
            string ss2 = tmp.Decode(ss);
            string ss3 = tmp2.ENcode("Аллелуя, братья! Hallelujah, brothers!");
            string ss4 = tmp2.Decode(ss3);

        }
    }
}
