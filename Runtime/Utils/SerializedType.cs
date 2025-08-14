using System;
using UnityEngine;

namespace BlueGraph.Utils
{
    [Serializable]
    public class SerializableType
    {
        [SerializeField] private string typeName;

        public Type Type
        {
            get => string.IsNullOrEmpty(typeName) ? null : Type.GetType(typeName);
            set => typeName = value?.AssemblyQualifiedName;
        }

        public static implicit operator Type(SerializableType serializableType)
        {
            return serializableType?.Type;
        }

        public static implicit operator SerializableType(Type type)
        {
            return new SerializableType { Type = type };
        }

        public override string ToString()
        {
            return Type?.FullName ?? "null";
        }

        public override bool Equals(object obj)
        {
            if (obj is SerializableType other)
            {
                return Type == other.Type; // Compare the actual Type objects
            }
            if (obj is Type type)
            {
                return Type == type;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Type?.GetHashCode() ?? 0;
        }

        public static bool operator ==(SerializableType a, SerializableType b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (a is null || b is null) return false;
            return a.Type == b.Type;
        }

        public static bool operator !=(SerializableType a, SerializableType b) => !(a == b);
    }

}