using System;
using System.Runtime.Serialization;
using System.Text;
using System.Web;

namespace MarcoGazzola
{
    public static class StringUtils
    {
        public static string UriConcat(this string baseUrl, params string[] parts)
        {
            if (parts == null || parts.Length == 0) return string.Empty;

            var urlBuilder = new StringBuilder();
            urlBuilder.Append(TryCreateRelativeOrAbsolute(baseUrl));
            foreach (var part in parts)
            {
                var tempUrl = TryCreateRelativeOrAbsolute(part);
                urlBuilder.Append(tempUrl);
            }
            return urlBuilder.ToString().TrimEnd('/');
        }
        private static string TryCreateRelativeOrAbsolute(string s)
        {
            Uri uri;
            Uri.TryCreate(s, UriKind.RelativeOrAbsolute, out uri);
            string tempUrl = uri.ToString().TrimEnd('/') + '/';
            return tempUrl;
        }
    }
}
