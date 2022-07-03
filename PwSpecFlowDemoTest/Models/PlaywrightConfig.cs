using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PwSpecFlowDemoTest.Models
{
    public enum Browser
    {
        Chrome,
        Firefox,
        Chromium,
        WebKit
    }

    public enum RunTypeBrowser
    {
       Local,
       Wss
    }

    public class PlaywrightConfig
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public Browser Browser { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public RunTypeBrowser RunTypeBrowser { get; set; }
        public Dictionary<string, string>? BrowserArgs { get; set; }
        public string? WssUrl { get; set; }
        public string? PlaywrightVersion { get; set; }
    }
}
