﻿using HomeSeerAPI;
using NullGuard;
using System.Collections.Generic;

namespace Hspi
{
    using static System.FormattableString;

    [NullGuard(ValidationFlags.Arguments | ValidationFlags.NonPublic)]
    internal abstract class NonScaledNumberDeviceData : NumberDeviceData
    {
        public NonScaledNumberDeviceData(string name, XmlPathData pathData) : base(name, pathData)
        {
        }

        public override IList<VSVGPairs.VSPair> StatusPairs
        {
            get
            {
                return GetNonScaledSingleStatusPairs(Suffix);
            }
        }

        protected abstract string Suffix { get; }

        protected static IList<VSVGPairs.VSPair> GetNonScaledSingleStatusPairs(string suffix, int rangeStart = int.MinValue,
                                                                               int rangeEnd = int.MaxValue)
        {
            var pairs = new List<VSVGPairs.VSPair>();
            pairs.Add(new VSVGPairs.VSPair(HomeSeerAPI.ePairStatusControl.Status)
            {
                PairType = VSVGPairs.VSVGPairType.Range,
                RangeStart = rangeStart,
                RangeEnd = rangeEnd,
                IncludeValues = true,
                RangeStatusDecimals = 2,
                RangeStatusSuffix = Invariant($" {suffix}"),
            });
            return pairs;
        }
    }
}