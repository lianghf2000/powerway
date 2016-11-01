using System;


    public class StrCN
    {
        public static int LengthCN(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return 0;
            }
            int length = str.Length;
            char[] chars = str.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (System.Convert.ToInt32(chars[i]) > 255)
                {
                    length++;
                }
            }
            return length;
        }
        public static string LeftCNmore(string str, int length)
        {
            return LeftCN(str, length * 2);
        }
        public static string LeftCN(string str,int length)
        {
            if (LengthCN(str) > length)
            {
                int start = 0;
                int end = str.Length;
                char[] chars = str.ToCharArray();
                int single = 0;
                for (int i = start; i <= length; i++)
                {
                    if (Convert.ToInt32(chars[i]) > 255)
                    {
                        start += 2;
                    }
                    else
                    {
                        start ++;
                        single++;
                    }
                    if (start >= length)
                    {
                        if (end % 2 == 0)
                        {
                            if (single % 2 == 0)
                            {
                                end = i + 1;
                            }
                            else
                            {
                                end = i;
                            }
                        }
                        else
                        {
                            end = i + 1;
                        }
                        break;
                    }
                }
                return str.Substring(0, end);
            }
            else
            {
                return str;
            }
        }
    }

