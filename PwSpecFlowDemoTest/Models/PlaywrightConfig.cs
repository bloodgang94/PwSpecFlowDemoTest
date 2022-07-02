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
    public class PlaywrightConfig
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public Browser Browser { get; set; }
    }
}
