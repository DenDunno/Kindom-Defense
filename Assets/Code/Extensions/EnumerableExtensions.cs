using System;
using System.Collections.Generic;

public static class EnumerableExtensions
{
    public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
    {
        foreach (T element in collection)
        {
            action(element);
        }
    }
    
    public static bool IsNotEmpty<T>(this Stack<T> stack)
    {
        return stack.Count != 0;
    }
}