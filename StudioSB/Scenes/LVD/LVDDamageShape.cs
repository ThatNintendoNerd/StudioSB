﻿using StudioSB.Tools;
using System.ComponentModel;

namespace StudioSB.Scenes.LVD
{
    public class LVDDamageShape : LVDBase
    {
        [ReadOnly(true), Category("Version")]
        public byte Version { get; internal set; } = 1;

        [Category("Shape"), TypeConverter(typeof(ExpandableObjectConverter))]
        public LVDShape3 Shape { get; set; } = new LVDShape3();

        public bool IsDamager { get; set; }

        public uint ID { get; set; }

        public override void Read(BinaryReaderExt reader)
        {
            Version = reader.ReadByte();

            base.Read(reader);

            Shape.Read(reader);

            IsDamager = reader.ReadBoolean();
            ID = reader.ReadUInt32();
        }

        public override void Write(BinaryWriterExt writer)
        {
            writer.Write(Version);

            base.Write(writer);

            Shape.Write(writer);

            writer.Write(IsDamager);
            writer.Write(ID);
        }
    }
}
