using System;
using System.Collections.Generic;

namespace AssetsPlugin
{
   public class BuilderAssets
   {
      List<BuilderAsset> builders = new();

      public IReadOnlyList<BuilderAsset> Builders => builders;

      public BuilderAsset AddAsset(AssetId assetId)
      {
         var builder = new BuilderAsset {assetId = assetId};
         builders.Add(builder);
         return builder;
      }

      public BuilderAsset AddAsset<T>(AssetId assetId, T asset) where T : AssetAbstract
      {
         var builder = new BuilderAsset {assetId = assetId};
         builder.Join(asset);
         builders.Add(builder);
         return builder;
      }

      public void Clear() => builders.Clear();
   }
}