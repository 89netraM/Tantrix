using System;
using System.Linq;

namespace Tantrix
{
	public readonly struct Bag
	{
		/// <summary>
		/// Creates a shuffled and fully packed standard bag of Tantrix tiles.
		/// </summary>
		public static Bag CreateStandardBag()
		{
			ITile[] tiles = new ITile[Tile.StandardTiles.Length];
			Random rand = new Random();
			foreach ((int r, int i) item in Enumerable.Range(0, Tile.StandardTiles.Length).OrderBy(rand.Next).Zip(Enumerable.Range(0, Tile.StandardTiles.Length), (r, i) => (r, i)))
			{
				tiles[item.i] = Tile.GetNumberedTile(item.r);
			}

			return new Bag(tiles);
		}

		/// <summary>
		/// The number of discarded tiles.
		/// Also points a the next tile in this bag.
		/// </summary>
		private int DiscardedTiles { get; }

		/// <summary>
		/// A list of all the tiles in this bag, and maybe some outside it.
		/// </summary>
		private ReadOnlyMemory<ITile> Tiles { get; }

		/// <summary>
		/// The number of tiles left in this bag.
		/// </summary>
		public int Count => Tiles.Length - DiscardedTiles;

		/// <summary>
		/// Initializes a new bag containing all the tiles of
		/// <paramref name="tiles"/>.
		/// </summary>
		/// <param name="tiles">The tiles in the new bag.</param>
		public Bag(ReadOnlyMemory<ITile> tiles) : this(tiles, 0) { }
		/// <summary>
		/// Initializes a bag discarding some tiles a the begining of
		/// <paramref name="tiles"/>.
		/// </summary>
		/// <param name="tiles">The tiles in the bag.</param>
		/// <param name="discardedTiles">The number of discarded tiles.</param>
		private Bag(ReadOnlyMemory<ITile> tiles, int discardedTiles)
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
		public (ITile, Bag) TakeTile()
		{
			return (
					Tiles.Span[DiscardedTiles],
					new Bag(Tiles, DiscardedTiles + 1)
				);
		}
	}
}