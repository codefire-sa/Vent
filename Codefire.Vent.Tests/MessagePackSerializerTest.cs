using System;
using Codefire.Vent.Models;
using Codefire.Vent.Serializers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codefire.Vent.Tests
{
    [TestClass]
    public class MessagePackSerializerTest
    {
        [TestMethod]
        public void TestSerialize()
        {
            var msg = new VentMessage
            {
                Source = "web",
                Name = "test",
                MessageType = MessageType.Event,
                Timestamp = DateTime.Now
            };

            var serializer = new MessagePackSerializer();
            var data = serializer.Serialize(msg);

            var xx = serializer.Deserialize(data);
        }
    }
}
