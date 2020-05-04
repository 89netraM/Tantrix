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
		/// <exception cref="InvalidPositionException"/>
		/// <exception cref="ArgumentNullException"/>
		public Board PlaceTile(Tile tile, Position position, int rotation)
		{
			if (Tiles.ContainsKey(position))
			{
				throw new InvalidOperationException("Can not place a tile on top of another already place tile.");
			}

			PlacedTile newTile = new PlacedTile(tile, rotation);

			Color[] limits = GetLimitsAt(position);
			Color combinedLimits = (Color)0b1111;
			for (int i = 0; i < 6; i++)
			{
				combinedLimits &= limits[i];

				if ((newTile.GetSide(i) & limits[i]) == (Color)0b0000)
				{
					throw new InvalidPositionException("Must color match when placing tiles.");
				}
			}
			if (Tiles.Count > 0 && combinedLimits == (Color)0b1111)
			{
				throw new InvalidPositionException("Must place tiles adjacent to atleast one existing tile.");
			}

			return new Board(Tiles.Add(position, newTile));
		}

		/// <summary>
		/// Returns the valid color connections for the specified position.
		/// </summary>
		/// <param name="position">
		/// The position to get the color connections of.
		/// </param>
		public Color[] GetConnectingColorsAt(Position position)
		{
			return GetConnectingColorsAt(position, position.GetSurroundingPositions());
		}
		/// <summary>
		/// Returns the valid color connections for the specified position.
		/// </summary>
		/// <param name="position">
		/// The position to get the color connections of.
		/// </param>
		/// <param name="neighbours">The surrounding positions.</param>
		public Color[] GetConnectingColorsAt(Position position, Position[] neighbours)
		{
			Color[] colors = new Color[6];

			for (int i = 0; i < 6; i++)
			{
				colors[i] = (Color)0b1111;

				if (Tiles.TryGetValue(neighbours[i], out PlacedTile neighbourTile))
				{
					colors[i] &= neighbourTile.GetSide((i + 3) % 6);
				}
			}

			return colors;
		}

		/// <summary>
		/// Returns the limits on the sides for the specified position.
		/// </summary>
		/// <param name="position">
		/// The position to get the limits of.
		/// </param>
		public Color[] GetLimitsAt(Position position)
		{
			return GetLimitsAt(position, position.GetSurroundingPositions());
		}
		/// <summary>
		/// Returns the limits on the sides for the specified position.
		/// </summary>
		/// <param name="position">
		/// The position to get the limits of.
		/// </param>
		/// <param name="neighbours">The surrounding positions.</param>
		public Color[] GetLimitsAt(Position position, Position[] neighbours)
		{
			Color[] limits = GetConnectingColorsAt(position, neighbours);

			for (int i = 0; i < 6; i++)
			{
				if (limits[i] == (Color)0b1111 && !Tiles.ContainsKey(neighbours[i]))
				{
					Color[] colors = GetConnectingColorsAt(neighbours[i]);

					for (int j = 1; j < colors.Length; j++)
					{
						if (colors[j] != (Color)0b1111 && colors[j - 1] == colors[j])
						{
							limits[i] ^= colors[j];
							break;
						}
					}
				}
			}

			return limits;
		}
	}
}