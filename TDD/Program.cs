using System;
using System.Collections.Generic;
using System.Linq;

namespace TDD
{
    public class Program
    {
        static void Main()
        {

        }
        
        public static int Parse(string s)
        {
            IEnumerable<string> delims = new string[]{ ",", "\n" };
            if (s.StartsWith("//"))
            {
                var tmp = s.Skip(2);
                string delim;
                if (tmp.First() == '[')
                    delim = new string(
                        tmp
                        .Skip(1)
                        .TakeWhile((c) => c != ']').ToArray()
                        );
                else
                    delim = tmp.First().ToString();

                delims = delims.Append(delim);
                s = new string(tmp.SkipWhile((c) => c != '\n').Skip(1).ToArray());
            }
            string[] vs = s==""? Array.Empty<string>() : s.Split(delims.ToArray(), StringSplitOptions.RemoveEmptyEntries);

            var vals = vs.Select((x) => int.Parse(x));

            if(vals.Any((i)=>i<0))
                throw new ArgumentOutOfRangeException("negative");

            return vals
                .Select((i)=>i>1000?0:i)
                .Sum();
        }

    }
}
