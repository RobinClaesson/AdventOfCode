namespace AoC.Extensions;

public static class EnumerableExtensions
{
    public static int Multiply(this IEnumerable<int> list) => 
        list.Aggregate(1, (current, next) => current * next);
    
    public static long Multiply(this IEnumerable<long> list) => 
        list.Aggregate(1L, (current, next) => current * next);
}