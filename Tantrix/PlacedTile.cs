using System;

namespace Tantrix
{
	/// <summary>
	/// An immutable representation of a placed tantrix tile.
	/// </summary>
	readonly struct PlacedTile : ITile
	{
		/// <summary>
		/// The original tile this tile is based on.
		/// </summary>
		private ITile BaseTile { get; }

		/// <inheritdoc/>
		public ReadOnlyMemory<Color> Sides => BaseTile.Sides;

		/// <inheritdoc/>
		public Color Colors => BaseTile.Colors;

		/// <summary>
		/// The index of the topmost side.
		/// </summary>
		public int Rotation { get; }

		/// <summary>
		/// Initializes an immutable tile based on <paramref name="baseTile"/>
		/// and rotated <paramref name="rotation"/> steps.
		/// </summary>
		/// <param name="baseTile">The original tile.</param>
		/// <param name="rotation">
		/// The number of steps the tile should be rotated.
		/// </param>
		/// <exception cref="ArgumentNullException"/>
		public PlacedTile(ITile baseTile, int rotation)
		{
			BaseTile = baseTile ?? throw new ArgumentNullException(nameof(baseTile));
			Rotation = rotation;
		}
	}
}