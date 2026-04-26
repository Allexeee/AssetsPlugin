using System;
using System.Collections.Generic;

namespace AssetsPlugin
{
   public class AssetContainer : AssetAbstract
   {
      Dictionary<TypeId, AssetAbstract> dictionary = new();

      public AssetContainer Add<T>(T obj) where T : AssetAbstract
      {
         var key = TypeId.Get<T>();
         dictionary.Add(key, obj);

         return this;
      }

      public override T As<T>()
      {
         var key = TypeId.Get<T>();
         if (dictionary.TryGetValue(key, out var value))
            return (T) value;

         throw new Exception($"Не найден объект по ключу {key}");
      }

      public override bool Is<T>() => dictionary.ContainsKey(TypeId.Get<T>());

      public override bool Is<T>(out T val)
      {
         var found = dictionary.TryGetValue(TypeId.Get<T>(), out var value);
         val = found ? (T) value : default;
         return found;
      }
   }
}