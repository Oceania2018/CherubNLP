﻿//using Bigtree.Algorithm.Matrix;
using System;
using System.Collections.Generic;
using System.Text;

namespace CherubNLP.Featuring
{
    public interface IFeatureExtractor
    {
        /// <summary>
        /// Feature dimension size
        /// </summary>
        int Dimension { get; set; }

        /// <summary>
        /// The whole corpus
        /// </summary>
        List<Sentence> Sentences { get; set; }

        /// <summary>
        /// Feature names
        /// </summary>
        List<String> Features { get; set; }

        /// <summary>
        /// All words and frequency
        /// </summary>
        List<Tuple<String, int>> Dictionary { get; set; }

        /// <summary>
        /// Vectorize sentence
        /// </summary>
        void Vectorize(List<string> features);

        /// <summary>
        /// Array shape
        /// </summary>
        //Shape Shape { get; set; }

        /// <summary>
        /// Pre-trained model file path
        /// </summary>
        string ModelFile { get; set; }
    }
}