﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace TempleFileFormats.Mes
{
    public abstract class EntryReader
    {
        protected StreamReader reader;

        public EntryReader(StreamReader reader)
        {
            this.reader = reader;
        }

        public EntryReader(string input) 
        {
            this.input = input;
        }

        public string[] Parse(string input)
        {
            Regex regex = new Regex(pattern);
            MatchCollection matches = Regex.Matches(input, pattern);

            string[] output = new string[matches.Count];
            for (int i = 0; i < matches.Count; i++)
            {
                output[i] = regex.Replace(matches[i].Value, substitution);
            }

            return output;
        }

        public string[] Parse()
        {
            return Parse(this.input);
        }

        protected string pattern = @"{(.*?)}";
        protected string substitution = @"$1";
        protected string input;
    }
}
