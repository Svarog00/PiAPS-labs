using System.Runtime.InteropServices;

namespace DialogueSerializerPrototype
{
    [Guid("364C5E66-4412-48E3-8BD8-7B2BF09E8922")]
    [ComVisible(true)]
    public interface ISerializator
    {
        void Serialize(object objToSerialize, string path);
        void Deserialize(object objToDeserialize, string path);
    }
}
