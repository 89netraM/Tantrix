using System;

namespace Tantrix
{
	/// <summary>
	/// An tantrix tile.
	/// </summary>
	public interface ITile
	{
		/// <summary>
		/// The colors of the six sides in clockwise order.
		/// </summary>
		ReadOnlyMemory<Color> Sides { get; }

		/// <summary>
		/// Represetns all colors on this tile.
		/// </summary>
		Color Colors { get; }

		/// <summary>
		/// Gets the color of one of the sides, starting at the top going
		/// clockwise.
		/// </summary>
		/// <param name="index">A zero-indexed side [0, 6).</param>
		Color GetSide(int index);
	}
}