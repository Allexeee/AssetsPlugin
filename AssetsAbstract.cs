namespace AssetsPlugin
{
   public abstract class AssetAbstract
   {
      public virtual bool Is<T>() where T : AssetAbstract
      {
         return this is T;
      }

      public virtual bool Is<T>(out T val) where T : AssetAbstract
      {
         if (this is T val1)
         {
            val = val1;
            return true;
         }

         val = default;
         return false;
      }

      public virtual T As<T>() where T : AssetAbstract
      {
         return this as T;
      }
   }
}