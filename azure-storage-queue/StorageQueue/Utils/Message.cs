namespace StorageQueue.Utils;

public static class Message
{
    public static T? Deserialize<T>(object message) =>
        JsonSerializer.Deserialize<T>(message.ToString() ?? string.Empty);

    public static string SerializeToString(object message) => 
        JsonSerializer.Serialize(message);
    
    public static byte[] Serialize(object message)
    {
        var serializedMessage = JsonSerializer.Serialize(message);
        return Encoding.UTF8.GetBytes(serializedMessage);
    }
}
