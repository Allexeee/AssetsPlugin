using System;
using UnityEngine;

namespace AssetsPlugin
{
   [Serializable]
   public struct AssetId : IEquatable<AssetId>
   {
      [SerializeField] string _value;

      public string Value => _value;

      public AssetId(string value)
      {
         _value = value;
      }

      public static implicit operator AssetId(string value) => new(value);
      public static implicit operator AssetId(Enum   value) => new(Convert.ToString(value));
      public static implicit operator string(AssetId id)    => id._value;

      public          bool Equals(AssetId other)                    => string.Equals(_value, other._value, StringComparison.CurrentCulture);
      public override bool Equals(object  obj)                      => obj is AssetId other && Equals(other);
      public override int  GetHashCode()                            => _value.GetHashCode();
      public static   bool operator ==(AssetId left, AssetId right) => left.Equals(right);
      public static   bool operator !=(AssetId left, AssetId right) => !left.Equals(right);

      public override string ToString() => _value;
   }
}