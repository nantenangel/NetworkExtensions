﻿using System;
using System.Collections.Generic;
using ColossalFramework;
using ColossalFramework.UI;
using Transit.Framework.Builders;

namespace Transit.Framework
{
    public class AtlasManager : Singleton<AtlasManager>
    {
        private readonly ICollection<Type> _atlasTypes = new HashSet<Type>();
        private readonly IDictionary<string, UITextureAtlas> _atlases = new Dictionary<string, UITextureAtlas>(StringComparer.InvariantCultureIgnoreCase);

        public void Include<T>()
            where T : IAtlasBuilder, new()
        {
            Include(typeof (T));
        }

        public void Include(Type atlasBuilderType)
        {
            if (!typeof(IAtlasBuilder).IsAssignableFrom(atlasBuilderType))
            {
                throw new Exception(string.Format("Type {0} is not supported by the AtlasManager", atlasBuilderType));
            }

            if (_atlasTypes.Contains(atlasBuilderType))
            {
                return;
            }

            var builder = (IAtlasBuilder)Activator.CreateInstance(atlasBuilderType);
            var atlas = builder.Build();

            foreach (var atlasKey in builder.Keys)
            {
                _atlases[atlasKey] = atlas;
            }

            _atlasTypes.Add(atlasBuilderType);
        }

        public UITextureAtlas GetAtlas(string atlasKey)
        {
            if (!_atlases.ContainsKey(atlasKey))
            {
                return null;
            }

            return _atlases[atlasKey];
        }
    }
}
