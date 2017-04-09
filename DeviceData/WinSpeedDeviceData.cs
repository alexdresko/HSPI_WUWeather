﻿using HomeSeerAPI;
using NullGuard;
using System.Collections.Generic;

namespace Hspi
{
    [NullGuard(ValidationFlags.Arguments | ValidationFlags.NonPublic)]
    public class WindSpeedDeviceData : NumberDeviceData
    {
        public WindSpeedDeviceData(string name, XmlPathData pathData) :
            base(name, pathData)
        {
        }

        protected override string GetUnitString(PluginConfig config) => config.GetUnit(DeviceUnitType.WinSpeed);

        public override IList<VSVGPairs.VGPair> GetGraphicsPairs(PluginConfig config) => GetSingleGraphicsPairs("wind.png");
    }
}