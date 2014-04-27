using Codefire.Vent.Models;

namespace Codefire.Vent.Serializers
{
    public interface ISerializer
    {
        byte[] Serialize(VentMessage msg);
        VentMessage Deserialize(byte[] data);
    }
}