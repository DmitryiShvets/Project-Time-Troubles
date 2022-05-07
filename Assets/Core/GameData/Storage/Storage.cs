using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace StorageSystem
{
    public abstract class Storage
    {
        protected static readonly DictionarySerializationSurrogate _dictSurrogate = new DictionarySerializationSurrogate();

        protected static readonly NpcSerializationSurrogate _npcSurrogate = new NpcSerializationSurrogate();

        public static GameStateSerializationSurrogate _gameStateSurrogate = new GameStateSerializationSurrogate();
        public abstract void Save(string sceneName);

        public abstract void Load(string sceneName);
    }
}