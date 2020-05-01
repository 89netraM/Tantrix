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
	}
}