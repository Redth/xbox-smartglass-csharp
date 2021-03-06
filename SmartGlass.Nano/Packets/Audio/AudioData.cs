using System;
using System.IO;
using SmartGlass.Common;
using SmartGlass.Nano;

namespace SmartGlass.Nano.Packets
{
    [AudioPayloadType(AudioPayloadType.Data)]
    public class AudioData : StreamerMessage
    {
        public uint Flags { get; private set; }
        public uint FrameId { get; private set; }
        public ulong Timestamp { get; private set; }
        public byte[] Data { get; private set; }

        public AudioData()
            : base((uint)AudioPayloadType.Data)
        {
        }

        public AudioData(uint flags, uint frameId,
                         ulong timestamp, byte[] data)
            : base((uint)AudioPayloadType.Data)
        {
            Flags = flags;
            FrameId = frameId;
            Timestamp = timestamp;
            Data = data;
        }

        internal override void DeserializeStreamer(BinaryReader reader)
        {
            Flags = reader.ReadUInt32();
            FrameId = reader.ReadUInt32();
            Timestamp = reader.ReadUInt64();
            Data = reader.ReadUInt32PrefixedBlob();
        }

        internal override void SerializeStreamer(BinaryWriter writer)
        {
            writer.Write(Flags);
            writer.Write(FrameId);
            writer.Write(Timestamp);
            writer.WriteUInt32PrefixedBlob(Data);
        }
    }
}
