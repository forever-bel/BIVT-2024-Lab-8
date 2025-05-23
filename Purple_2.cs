﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Purple_2 : Purple
    {
        private string[] _output;
        public string[] Output
        {
            get
            {
                if (_output == null) return null;
                var array = new string[_output.Length];
                Array.Copy(_output, array, _output.Length);
                return array;
            }
        }
        public Purple_2(string input) : base(input)
        {
            _output = null;
        }

        public override void Review()
        {
            if (Input == null) return;
            _output = new string[0];
            string text = Input;
            string str = "";
            int index = 0;
            while (text.Length > 0)
            {
                if (text.Length > 50)
                {
                    index = text.Substring(0, 51).LastIndexOf(' ');
                    str = text.Substring(0, index);
                    text = text.Substring(index + 1);
                }
                else
                {
                    str = text;
                    index = text.Length;
                    text = "";
                }
                if (str.Count(x => x == ' ') != 0)
                {
                    var words = str.Split(' ');
                    int countspace = words.Length - 1;
                    if (countspace == 0) continue;
                    int dopspace = (50 - index) / countspace;
                    int extra = (50 - index) % countspace;
                    for (int i = 0; i < extra; i++) words[i] += " ";
                    string sep = " ";
                    for (int i = 0; i < dopspace; i++) sep += " ";
                    str = string.Join(sep, words);
                }
                Array.Resize(ref _output, _output.Length + 1);
                _output[_output.Length - 1] = str;
            }
        }

        public override string ToString()
        {
            if (Output == null) return null;
            string ans = "";
            for (int i = 0; i < Output.Length - 1; i++) ans += Output[i] + Environment.NewLine;
            ans += Output[Output.Length - 1];
            return ans;
        }
    }
}
