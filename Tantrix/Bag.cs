﻿using System;

namespace Tantrix
{
	public readonly struct Bag
	{
		/// <summary>
		/// The number of discarded tiles.
		/// Also points a the next tile in this bag.
		/// </summary>
		private int DiscardedTiles { get; }

		/// <summary>
		/// A list of all the tiles in this bag, and maybe some outside it.
		/// </summary>
		private ReadOnlyMemory<Tile> Tiles { get; }

		/// <summary>
		/// The number of tiles left in this bag.
		/// </summary>
		public int Count => Tiles.Length - DiscardedTiles;

		/// <summary>
		/// Initializes a new bag containing all the tiles of
		/// <paramref name="tiles"/>.
		/// </summary>
		/// <param name="tiles">The tiles in the new bag.</param>
		public Bag(ReadOnlyMemory<Tile> tiles) : this(tiles, 0) { }
		/// <summary>
		/// Initializes a bag discarding some tiles a the begining of
		/// <paramref name="tiles"/>.
		/// </summary>
		/// <param name="tiles">The tiles in the bag.</param>
		/// <param name="discardedTiles">The number of discarded tiles.</param>
		private Bag(ReadOnlyMemory<Tile> tiles, int discardedTiles)
		{
			Tiles = tiles;
			DiscardedTiles = discardedTiles;
		}

		/// <summary>
		/// Takes out one tile from this bag and create a new bag without that
		/// tile.
		/// </summary>
		/// <returns>
		/// A tuple with the removed tile and a new bag without that tile.
		/// </returns>
		public (Tile, Bag) TakeTile()
		{
			return (
					Tiles.Span[DiscardedTiles],
					new Bag(Tiles, DiscardedTiles + 1)
				);
		}
	}
}