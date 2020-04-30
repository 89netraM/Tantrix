using System;

namespace Tantrix
{
	/// <summary>
	/// A tile.
	/// </summary>
	public readonly struct Tile
	{
		/// <summary>
		/// The colors of the six sides in clockwise order.
		/// </summary>
		public ReadOnlyMemory<Color> Sides { get; }

		/// <summary>
		/// Initializes a new immutable tile.
		/// </summary>
		/// <param name="sides">
		/// Provide the colors of the six sides of the new tile in clockwise
		/// order.
		/// </param>
		public Tile(ReadOnlyMemory<Color> sides)
		{
			if (sides.Length != 6)
			{
				throw new ArgumentException("Tiles must have exactly 6 sides", nameof(sides));
			}

			Sides = sides;
		}
	}
}