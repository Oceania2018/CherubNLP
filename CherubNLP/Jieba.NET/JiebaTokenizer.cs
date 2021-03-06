﻿using CherubNLP.Tokenize;
using JiebaNet.Segmenter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Token = CherubNLP.Tokenize.Token;

namespace BotSharp.Core.Engines.Jieba.NET
{
    public class JiebaTokenizer : TokenizerBase, ITokenizer
    {
        private JiebaSegmenter segmenter;

        public List<Token> Tokenize(string sentence, TokenizationOptions options)
        {
            Init();

            var tokens = segmenter.Cut(sentence)
                .Select(x => new Token
                {
                    Text = x
                }).ToList();

            CorrectTokenPosition(sentence, tokens);

            return tokens;
        }

        private void Init()
        {
            if (segmenter == null)
            {
                string contentDir = AppDomain.CurrentDomain.GetData("DataPath").ToString();
                AppDomain.CurrentDomain.SetData("JiebaConfigFileDir", contentDir);

                segmenter = new JiebaSegmenter();
                segmenter.LoadUserDict(Path.Combine(contentDir, "userdict.txt"));
            }
        }
    }
}
