using System;
using System.IO;
using Codefire.Vent.Models;
using MsgPack;

namespace Codefire.Vent.Serializers
{
    public class MessagePackSerializer : ISerializer
    {
        public byte[] Serialize(VentMessage msg)
        {
            using (var stream = new MemoryStream())
            {
                var packer = Packer.Create(stream);
                packer.Pack(msg.Source);
                packer.Pack(msg.Name);
                packer.Pack(msg.MessageType);
                packer.Pack(msg.Timestamp);

                return stream.ToArray();
            }
        }

        public VentMessage Deserialize(byte[] data)
        {
            var msg = new VentMessage();

            using (var stream = new MemoryStream(data))
            {
                var unpacker = Unpacker.Create(stream);

                unpacker.Read();
                msg.Source = unpacker.Unpack<string>();

                unpacker.Read();
                msg.Name = unpacker.Unpack<string>();

                unpacker.Read();
                msg.MessageType = unpacker.Unpack<string>();

                unpacker.Read();
                msg.Timestamp = unpacker.Unpack<DateTime>().ToLocalTime();
            }
            
            return msg;
        }
    }
}