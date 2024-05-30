
namespace at.SerializerLocator;

public class SerializerLocator
{
    private readonly Dictionary<Type, object> _serializers = new Dictionary<Type, object>();

    public void Add<T, TSerializer>() where TSerializer : ISerializer<T>, new()
    {
        _serializers[typeof(T)] = new TSerializer();
    }

    public byte[] Serialize<T>(T obj)
    {
        if (_serializers.TryGetValue(typeof(T), out var serializer))
        {
            return ((ISerializer<T>)serializer).Serialize(obj);
        }
        throw new InvalidOperationException($"No serializer found for type {typeof(T)}");
    }

    public T Deserialize<T>(byte[] data)
    {
        if (_serializers.TryGetValue(typeof(T), out var serializer))
        {
            return ((ISerializer<T>)serializer).Deserialize(data);
        }
        throw new InvalidOperationException($"No serializer found for type {typeof(T)}");
    }
}