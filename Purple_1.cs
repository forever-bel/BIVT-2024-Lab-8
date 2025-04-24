using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Purple_1 : Purple
    {
        private string _output;
        public string Output => _output;
        public Purple_1(string input) : base(input)
        {
            _output = null;
        }

        private static string Reverse(string text)
        {
            string ans = "";
            for (int i = text.Length - 1; i >= 0; i--)
            {
                ans += text[i];
            }
            return ans;
        }

        public override void Review()
        {
            if (Input == null) return;
            var words = Input.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                int index = 999999, count = 0;
                for (int j = 0; j < words[i].Length; j++)
                {
                    if (char.IsDigit(words[i][j])) break;
                    if (char.IsLetter(words[i][j]) || words[i][j] == '-' || (int)words[i][j] == 39)
                    {
                        index = Math.Min(index, j);
                        count++;
                    }
                }
                if (index == 999999) continue;
                words[i] = words[i].Substring(0, index) + Reverse(words[i].Substring(index, count)) + words[i].Substring(index + count);
            }
            _output = String.Join(" ", words);
        }
        
        public override string ToString()
        {
            return Output;
        }
    }
}
