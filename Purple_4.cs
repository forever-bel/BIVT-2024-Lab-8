using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Purple_4 : Purple
    {
        private string _output;
        private (string, char)[] _codes;
        public string Output => _output;
        public Purple_4(string input, (string, char)[] codes) : base(input)
        {
            _output = null;
            _codes = new (string, char)[codes.Length];
            Array.Copy(codes, _codes, codes.Length);
        }

        public override void Review()
        {
            if (Input == null || _codes == null) return;
            string text = Input;
            foreach (var code in _codes)
            {
                (string s, char r) = code;
                text = text.Replace(r + "", s);
            }
            _output = text;
        }

        public override string ToString()
        {
            return Output;
        }
    }
}
