using System.Numerics;

namespace AoC.Tools
{
    /// <summary>
    /// Functions regarging positions on a square grid
    /// </summary>
    public class SquareGrid
    {
        /// <summary>
        /// Gets the 8 sourrounding points of a vector
        /// </summary>
        /// <param name="point">Vector2 to serach around (Expecting integer values)</param>
        /// <returns>Array of Vector2 with the adjecent points</returns>
        public static Vector2[] AdjacentPoints(Vector2 point)
        {
            return new Vector2[] {   new Vector2(point.X-1, point.Y),
                                        new Vector2(point.X-1, point.Y-1),
                                        new Vector2(point.X, point.Y-1),
                                        new Vector2(point.X+1,point.Y-1),
                                        new Vector2(point.X+1, point.Y),
                                        new Vector2(point.X+1, point.Y+1),
                                        new Vector2(point.X, point.Y+1),
                                        new Vector2(point.X-1, point.Y+1),
                                    };
        }
    }
}
