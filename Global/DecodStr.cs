﻿using System;
using System.IO;
using System.IO.Compression;

namespace last_society
{
    public static class DecodStr
    {
        public static string UnPack(string str)
        {
            var value = Convert.FromBase64String(str);
            string resultString = string.Empty;
            if (value != null && value.Length > 0)
            {
                using (MemoryStream stream = new MemoryStream(value))
                using (GZipStream zip = new GZipStream(stream, CompressionMode.Decompress))
                using (StreamReader reader = new StreamReader(zip))
                {
                    resultString = reader.ReadToEnd();
                }
            }
            return resultString;
        }
    }
}
