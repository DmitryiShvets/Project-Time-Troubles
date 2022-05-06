using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace StorageSystem
{
    public abstract class Storage
    {
        public static DictionarySerializationSurrogate _dictSurrogate = new DictionarySerializationSurrogate();

        public static NpcSerializationSurrogate _npcSurrogate = new NpcSerializationSurrogate();
        public abstract void Save();

        public abstract void Load();
    }
}