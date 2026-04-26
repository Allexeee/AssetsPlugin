using System;
using System.Collections.Generic;

namespace AssetsPlugin
{
   public class BuilderAsset
   {
      public AssetContainer container;
      public AssetId        assetId;
      public List<AssetId>  assetsJoin;

      public BuilderAsset Join<T>(T asset) where T : AssetAbstract
      {
         container ??= new();
         container.Add(asset);
         return this;
      }

      public BuilderAsset Join(AssetId assetId)
      {
         assetsJoin ??= new List<AssetId>();
         assetsJoin.Add(assetId);
         return this;
      }
   }
}