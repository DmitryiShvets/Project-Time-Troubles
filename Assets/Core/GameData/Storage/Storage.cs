using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace StorageSystem
{
    public abstract class Storage
    {
        protected static readonly DictionarySerializationSurrogate _dictSurrogate =
            new DictionarySerializationSurrogate();

        protected static readonly NpcSerializationSurrogate _npcSurrogate = new NpcSerializationSurrogate();

        protected static readonly GameStateSerializationSurrogate _gameStateSurrogate =
            new GameStateSerializationSurrogate();

        protected static readonly GameObjectSerializationSurrogate _gameObjectSurrogate =
            new GameObjectSerializationSurrogate();

        protected static readonly LootBoxesSerializationSurrogate _lootBoxesSurrogate =
            new LootBoxesSerializationSurrogate();

        public abstract void Save(string sceneName);

        public abstract void Load(string sceneName);
    }
}