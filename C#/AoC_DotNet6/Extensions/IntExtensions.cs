namespace AoC.Extensions;

public static class IntExtensions
{
    /// <summary>
    /// Returns the positive modulus of the integer.
    /// <code>Mod(1, 5) => 1, Mod(6, 5) => 1, Mod(-1, 5) => 4</code>
    /// https://github.com/dotnet/csharplang/discussions/4744
    /// </summary>
    /// <param name="i"></param>
    /// <param name="mod"></param>
    /// <returns></returns>
    public static int Mod(this int i, int mod)
    {
        var rest = i % mod;
        if ((rest < 0 && mod > 0) || (rest > 0 && mod < 0))
        {
            rest += mod;
        }

        return rest;
    }
}