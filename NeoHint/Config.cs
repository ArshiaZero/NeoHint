using System;
using System.ComponentModel;
using Exiled.API.Interfaces;
using HintServiceMeow.Core.Enum;

namespace NeoHint
{
    public class Config : IConfig
    {
        [Description("Whether or not the plugin is enabled.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Enables or disables debug mode for the plugin.")]
        public bool Debug { get; set; } = false;

        [Description("The text to be displayed as a hint. Use \\n to insert a new line.")]
        public string HintText { get; set; } = "Hello, World!";

        [Description("The font size of the hint text.")]
        public int FontSize { get; set; } = 20;

        [Description("The X coordinate for the hint text position. 0 for disable this feature.")]
        public int XCoordinate { get; set; } = 0;

        [Description("The Y coordinate for the hint text position. 0 for disable this feature.")]
        public int YCoordinate { get; set; } = 1040;

        [Description("The alignment of the hint text. Values: Left, Right, Center.")]
        public HintAlignment Alignment { get; set; } = HintAlignment.Center;
    }
}
