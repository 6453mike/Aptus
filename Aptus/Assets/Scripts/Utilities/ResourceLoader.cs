using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Utilities
{
    /// <summary>
    ///     A helper class for loading resources efficiently.
    /// </summary>
    public class ResourceLoader
    {
        private static readonly Dictionary<string, Object> Resources = new Dictionary<string, Object>();

        public static Object Load(string path)
        {
            Object o;
            if (Resources.TryGetValue(path, out o)) return o;

            o = UnityEngine.Resources.Load(path);
            Resources.Add(path, o);

            return o;
        }
    }
}