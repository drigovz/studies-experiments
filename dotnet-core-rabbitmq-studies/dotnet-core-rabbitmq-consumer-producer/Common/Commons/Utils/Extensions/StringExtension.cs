using System.Text;

namespace System;

public static class StringExtension
{
    public static string ConvertToString(this byte[] value) =>
        Encoding.UTF8.GetString(value);
}