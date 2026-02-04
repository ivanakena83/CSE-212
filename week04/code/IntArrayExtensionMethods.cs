using System.Collections;
using System.Linq;

public static class IntArrayExtensionMethods
{
    public static string AsString(this IEnumerable source)
    {
        return "<IEnumerable>{" + string.Join(", ", source.Cast<int>()) + "}";
    }
}
