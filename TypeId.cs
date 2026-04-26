using System;
using UnityEngine;

namespace AssetsPlugin
{
   [Serializable]
   public struct TypeId : IEquatable<TypeId>
   {
      [SerializeField] string _value;

      public string Value => _value;

      public          bool Equals(TypeId other)                   => string.Equals(_value, other._value, StringComparison.CurrentCulture);
      public override bool Equals(object obj)                     => obj is TypeId other && Equals(other);
      public override int  GetHashCode()                          => _value.GetHashCode();
      public static   bool operator ==(TypeId left, TypeId right) => left.Equals(right);
      public static   bool operator !=(TypeId left, TypeId right) => !left.Equals(right);

      public override string ToString() => _value;

      public static TypeId Create<T>() => new() {_value = StaticTypeId<T>.Id};
      public static TypeId Get<T>()    => new() {_value = StaticTypeId<T>.Id};
   }

   internal static class StaticTypeId<T>
   {
      public static string Id { get; } = typeof(T).Name;
   }
}