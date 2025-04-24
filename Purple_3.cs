using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Purple_3 : Purple
    {
        private string _output;
        private (string, char)[] _codes;
        public string Output => _output;
        public (string, char)[] Codes
        {
            get
            {
                if (_codes == null) return null;
                var arr = new (string, char)[5];
                Array.Copy(_codes, arr, 5);
                return arr;
            }
        }
        public Purple_3(string input) : base(input)
        {
            _output = null;
            _codes = null;
        }

        public override void Review()
        {
            if (Input == null) return;
            var Codes = new (string, int)[0];
            for (int i = 0; i < Input.Length - 1; i++)
            {
                if (char.IsLetter(Input[i]) && char.IsLetter(Input[i + 1]))
                {
                    var str = Input.Substring(i, 2);
                    var count = Input.Split(new string[] { Input.Substring(i, 2) }, StringSplitOptions.None).Length - 1;
                    var current = (str, count);
                    if (Codes.Count(x => x == current) == 0)
                    {
                        Array.Resize(ref Codes, Codes.Length + 1);
                        Codes[Codes.Length - 1] = current;
                    }
                }
            }
            for (int i = 0; i < Codes.Length; i++)
            {
                for (int j = 0; j < Codes.Length - i - 1; j++)
                {
                    (string s, int a) cor1 = Codes[j];
                    (string s, int a) cor2 = Codes[j + 1];
                    if (cor1.a < cor2.a)
                    {
                        (Codes[j], Codes[j + 1]) = (Codes[j + 1], Codes[j]);
                    }
                }
            }
            Array.Resize(ref Codes, 5);
            var text = Input;
            var Arr = new (string, char)[5];
            for (int i = 0, c = 0; i < 5; i++, c++)
            {
                (string s, int a) cor = Codes[i];
                if (Input.Count(x => x == (char)(33 + c)) == 0)
                {
                    Arr[i] = (cor.s, (char)(33 + c));
                    text = text.Replace(cor.s, (char)(33 + c) + "");
                }
                else i--;
            }
            _output = text;
            _codes = Arr;
        }

        public override string ToString()
        {
            return Output;
        }
    }
}
