using System.Collections.Generic;

namespace AssetsPlugin.Common
{
   public class AssetPrefabs : AssetAbstract
   {
      Dictionary<string, AssetPrefab> dictionary = new();

      public AssetPrefab Main  { get; private set; }
      public int         Count => dictionary.Count;

      public AssetPrefabs Add(string key, AssetPrefab obj)
      {
         Main ??= obj;

         dictionary.Add(key, obj);

         return this;
      }

      public AssetPrefabs Add(AssetPrefab obj)
      {
         Main ??= obj;

         dictionary.Add("main", obj);

         return this;
      }
   }
}