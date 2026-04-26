using System;
using System.Collections.Generic;
using UnityEngine;

namespace AssetsPlugin
{
   public class AssetsService : MonoBehaviour
   {
      Dictionary<AssetId, AssetContainer> assets = new(64);

      public void RegisterAssets(BuilderAssets builder)
      {
         assets.Clear();

         // Первый проход (объекты)
         foreach (var item in builder.Builders)
         {
            try
            {
               var container = item.container;
               assets.Add(item.assetId, container);
            }
            catch (Exception e)
            {
               Debug.LogError(item.assetId);
               Debug.LogException(e);
            }
         }

         // Второй проход (link/ joined)
         foreach (var item in builder.Builders)
         {
            try
            {
               if (item.assetsJoin != null)
                  foreach (var id in item.assetsJoin)
                     assets[item.assetId].Add(assets[id]);
            }
            catch (Exception e)
            {
               Debug.LogError(item.assetId);
               Debug.LogException(e);
            }
         }

         builder.Clear();
      }

      public AssetAbstract Get(AssetId    assetId)                         => assets[assetId];
      public T             Get<T>(AssetId assetId) where T : AssetAbstract => assets[assetId].As<T>();
   }
}