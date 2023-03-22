using System.Text;
using System.Text.Json;

namespace System;

public static class ObjectExtension
{
    public static byte[] ConvertToByteArray(this object value)
    {
        var strMessage = JsonSerializer.Serialize(value);
        return Encoding.UTF8.GetBytes(strMessage);
    }
}