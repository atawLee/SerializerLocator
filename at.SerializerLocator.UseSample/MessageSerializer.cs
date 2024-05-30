using System;
using System.Text;

namespace at.SerializerLocator.UseSample;

public class MessageSerializer : ISerializer<Message>
{
    public byte[] Serialize(Message obj)
    {
        using var memoryStream = new MemoryStream();
        using var binaryWriter = new BinaryWriter(memoryStream, Encoding.UTF8, true);
        
        binaryWriter.Write(obj.Id);
        binaryWriter.Write(obj.Content);
        return memoryStream.ToArray();
    }

    public Message Deserialize(byte[] data)
    {
        using var memoryStream = new MemoryStream(data);
        using var binaryReader = new BinaryReader(memoryStream, Encoding.UTF8);
        
        var id = binaryReader.ReadInt32();
        var content = binaryReader.ReadString();
        return new Message { Id = id, Content = content };
    }
}