using UnityEngine;

namespace AssetsPlugin.Common
{
   public class AssetPrefab : AssetAbstract
   {
      public GameObject prefab;
      public bool       pooled;

      public AssetPrefab(GameObject prefab, bool pooled)
      {
         this.prefab = prefab;
         this.pooled = pooled;
      }

      public AssetPrefab(string fullPath, bool pooled)
      {
         this.pooled = pooled;

         prefab = Resources.Load<GameObject>(fullPath);

         if (prefab == default)
            Debug.LogWarning($"The prefab was not found on the specified path. path: {fullPath}");
      }
   }
}