using System.Reflection;

namespace InjectXpress;

public static class TypeInfoExtensions
{
    public static bool IsAssignableToType<T>(this TypeInfo typeInfo) => typeInfo.IsAssignableFrom(typeof(T));
}