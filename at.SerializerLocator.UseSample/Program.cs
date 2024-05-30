// See https://aka.ms/new-console-template for more information

using at.SerializerLocator;
using at.SerializerLocator.UseSample;


SerializerLocator serializer = new();
serializer.Add<Message,MessageSerializer>();


var obj = new Message
{
    Id = 1,
    Content = "HelloWorld"
};
var data = serializer.Serialize(obj);

var deserializedObj= serializer.Deserialize<Message>(data);

Console.WriteLine(deserializedObj.Content);

Console.ReadLine();