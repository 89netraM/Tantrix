using System;
using System.Collections.Immutable;

namespace Tantrix
{
	/// <summary>
	/// A representation of a played Tantrix.
	/// </summary>
	public readonly struct Board
	{
		/// <summary>
		/// Creates a new empty board.
		/// </summary>
		public static Board Create()
		{
			return new Board(ImmutableDictionary.Create<Position, PlacedTile>());
		}

		/// <summary>
		/// A collection of placed tiles at their positions.
		/// </summary>
		private IImmutableDictionary<Position, PlacedTile> Tiles { get; }

		/// <summary>
		/// Initializes a bord with a certain setup.
		/// </summary>
		/// <param name="tiles">The starting setup with tiles.</param>
		/// <exception cref="ArgumentNullException"/>
		private Board(IImmutableDictionary<Position, PlacedTile> tiles)
		{
			Tiles = tiles ?? throw new ArgumentNullException(nameof(tiles));
		}

		/// <summary>
		/// Adds a tile to the board and returns the new board.
		/// </summary>
		/// <param name="tile">The tile to be placed.</param>
		/// <param name="position">
		/// The position where to place the tile.
		/// </param>
		/// <param name="rotation">
		/// The number of steps the tile should be rotated [0, 6).
		/// </param>
		/// <exception cref="InvalidOperationException"/>
		/// <exception cref="ArgumentNullException"/>
		public Board PlaceTile(Tile tile, Position position, int rotation)
		{
			if (Tiles.ContainsKey(position))
			{
				throw new InvalidOperationException("Can not place a tile on top of another already place tile.");
			}

			return new Board(Tiles.Add(position, new PlacedTile(tile, rotation)));
		}
	}
}