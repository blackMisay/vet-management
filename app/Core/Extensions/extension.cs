using System;
using System.Collections.Generic;

namespace app.core.Extensions
{
    public static class Extension
    {
        public static Dictionary<string, string> ConvertToStringDict(this Dictionary<string, object> original)
        {
            var dict = new Dictionary<string, string>();
            foreach (var kv in original)
                dict[kv.Key] = kv.Value?.ToString() ?? "";
            return dict;
        }
    }
}

