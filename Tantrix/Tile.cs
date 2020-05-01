using System;

namespace Tantrix
{
	/// <summary>
	/// An immutable representation of a tantrix tile.
	/// </summary>
	public readonly struct Tile : ITile
	{
		#region Factory Methods

		/// <summary>
		/// A list of the standard tiles in numerical order.
		/// </summary>
		public static ReadOnlyMemory<Tile> StandardTiles { get; } = new[]
		{
			new Tile(new[] { Color.Red, Color.Yellow, Color.Yellow, Color.Blue, Color.Red, Color.Blue }),
			new Tile(new[] { Color.Blue, Color.Yellow, Color.Yellow, Color.Blue, Color.Red, Color.Red }),
			new Tile(new[] { Color.Yellow, Color.Red, Color.Red, Color.Blue, Color.Blue, Color.Yellow }),
			new Tile(new[] { Color.Blue, Color.Yellow, Color.Red, Color.Blue, Color.Red, Color.Yellow }),
			new Tile(new[] { Color.Red, Color.Blue, Color.Blue, Color.Red, Color.Yellow, Color.Yellow }),
			new Tile(new[] { Color.Yellow, Color.Red, Color.Blue, Color.Yellow, Color.Blue, Color.Red }),
			new Tile(new[] { Color.Red, Color.Blue, Color.Blue, Color.Yellow, Color.Red, Color.Yellow }),
			new Tile(new[] { Color.Yellow, Color.Blue, Color.Blue, Color.Red, Color.Yellow, Color.Red }),
			new Tile(new[] { Color.Red, Color.Blue, Color.Yellow, Color.Red, Color.Yellow, Color.Blue }),
			new Tile(new[] { Color.Blue, Color.Yellow, Color.Yellow, Color.Red, Color.Blue, Color.Red }),
			new Tile(new[] { Color.Yellow, Color.Red, Color.Red, Color.Blue, Color.Yellow, Color.Blue }),
			new Tile(new[] { Color.Blue, Color.Red, Color.Red, Color.Yellow, Color.Blue, Color.Yellow }),
			new Tile(new[] { Color.Yellow, Color.Red, Color.Red, Color.Yellow, Color.Blue, Color.Blue }),
			new Tile(new[] { Color.Red, Color.Yellow, Color.Yellow, Color.Blue, Color.Blue, Color.Red }),
			new Tile(new[] { Color.Red, Color.Green, Color.Green, Color.Red, Color.Yellow, Color.Yellow }),
			new Tile(new[] { Color.Yellow, Color.Red, Color.Red, Color.Yellow, Color.Green, Color.Green }),
			new Tile(new[] { Color.Red, Color.Yellow, Color.Yellow, Color.Green, Color.Red, Color.Green }),
			new Tile(new[] { Color.Green, Color.Yellow, Color.Yellow, Color.Red, Color.Green, Color.Red }),
			new Tile(new[] { Color.Yellow, Color.Red, Color.Red, Color.Green, Color.Yellow, Color.Green }),
			new Tile(new[] { Color.Green, Color.Red, Color.Red, Color.Yellow, Color.Green, Color.Yellow }),
			new Tile(new[] { Color.Yellow, Color.Green, Color.Green, Color.Red, Color.Red, Color.Yellow }),
			new Tile(new[] { Color.Green, Color.Yellow, Color.Yellow, Color.Green, Color.Red, Color.Red }),
			new Tile(new[] { Color.Green, Color.Yellow, Color.Yellow, Color.Red, Color.Red, Color.Green }),
			new Tile(new[] { Color.Blue, Color.Green, Color.Green, Color.Blue, Color.Red, Color.Red }),
			new Tile(new[] { Color.Blue, Color.Red, Color.Red, Color.Green, Color.Green, Color.Blue }),
			new Tile(new[] { Color.Green, Color.Red, Color.Red, Color.Green, Color.Blue, Color.Blue }),
			new Tile(new[] { Color.Green, Color.Red, Color.Red, Color.Blue, Color.Green, Color.Blue }),
			new Tile(new[] { Color.Red, Color.Blue, Color.Blue, Color.Green, Color.Green, Color.Red }),
			new Tile(new[] { Color.Blue, Color.Red, Color.Red, Color.Green, Color.Blue, Color.Green }),
			new Tile(new[] { Color.Red, Color.Blue, Color.Blue, Color.Red, Color.Green, Color.Green }),
			new Tile(new[] { Color.Yellow, Color.Green, Color.Green, Color.Red, Color.Yellow, Color.Red }),
			new Tile(new[] { Color.Green, Color.Yellow, Color.Red, Color.Green, Color.Red, Color.Yellow }),
			new Tile(new[] { Color.Red, Color.Green, Color.Green, Color.Yellow, Color.Red, Color.Yellow }),
			new Tile(new[] { Color.Red, Color.Green, Color.Yellow, Color.Red, Color.Yellow, Color.Green }),
			new Tile(new[] { Color.Yellow, Color.Red, Color.Green, Color.Yellow, Color.Green, Color.Red }),
			new Tile(new[] { Color.Blue, Color.Green, Color.Green, Color.Red, Color.Blue, Color.Red }),
			new Tile(new[] { Color.Red, Color.Blue, Color.Blue, Color.Green, Color.Red, Color.Green }),
			new Tile(new[] { Color.Green, Color.Blue, Color.Blue, Color.Red, Color.Green, Color.Red }),
			new Tile(new[] { Color.Green, Color.Red, Color.Blue, Color.Green, Color.Blue, Color.Red }),
			new Tile(new[] { Color.Blue, Color.Green, Color.Red, Color.Blue, Color.Red, Color.Green }),
			new Tile(new[] { Color.Red, Color.Green, Color.Green, Color.Blue, Color.Red, Color.Blue }),
			new Tile(new[] { Color.Red, Color.Blue, Color.Green, Color.Red, Color.Green, Color.Blue }),
			new Tile(new[] { Color.Blue, Color.Yellow, Color.Yellow, Color.Green, Color.Green, Color.Blue }),
			new Tile(new[] { Color.Yellow, Color.Blue, Color.Green, Color.Yellow, Color.Green, Color.Blue }),
			new Tile(new[] { Color.Yellow, Color.Blue, Color.Blue, Color.Green, Color.Green, Color.Yellow }),
			new Tile(new[] { Color.Yellow, Color.Green, Color.Green, Color.Blue, Color.Yellow, Color.Blue }),
			new Tile(new[] { Color.Yellow, Color.Blue, Color.Blue, Color.Yellow, Color.Green, Color.Green }),
			new Tile(new[] { Color.Blue, Color.Green, Color.Green, Color.Blue, Color.Yellow, Color.Yellow }),
			new Tile(new[] { Color.Green, Color.Yellow, Color.Yellow, Color.Green, Color.Blue, Color.Blue }),
			new Tile(new[] { Color.Blue, Color.Green, Color.Yellow, Color.Blue, Color.Yellow, Color.Green }),
			new Tile(new[] { Color.Green, Color.Yellow, Color.Blue, Color.Green, Color.Blue, Color.Yellow }),
			new Tile(new[] { Color.Blue, Color.Green, Color.Green, Color.Yellow, Color.Blue, Color.Yellow }),
			new Tile(new[] { Color.Blue, Color.Yellow, Color.Yellow, Color.Green, Color.Blue, Color.Green }),
			new Tile(new[] { Color.Green, Color.Yellow, Color.Yellow, Color.Blue, Color.Green, Color.Blue }),
			new Tile(new[] { Color.Yellow, Color.Blue, Color.Blue, Color.Green, Color.Yellow, Color.Green }),
			new Tile(new[] { Color.Green, Color.Blue, Color.Blue, Color.Yellow, Color.Green, Color.Yellow })
		};

		/// <summary>
		/// Returns the standard tile corresponding to the number of
		/// <paramref name="number"/>.
		/// </summary>
		/// <param name="number">A number of one of the standard tiles.</param>
		/// <returns></returns>
		public static Tile GetNumberedTile(int number)
		{
			number--;
			if (number < 0 || StandardTiles.Length <= number)
			{
				throw new ArgumentOutOfRangeException(nameof(number), $"Please provide a number of one of the standard tiles [1, {StandardTiles.Length}]");
			}

			return StandardTiles.Span[number];
		}

		#endregion Factory Methods

		/// <inheritdoc/>
		public ReadOnlyMemory<Color> Sides { get; }

		/// <inheritdoc/>
		public Color Colors
		{
			get
			{
				Color colors = 0b000;

				for (int i = 0; i < Sides.Length; i++)
				{
					colors |= Sides.Span[i];
				}

				return colors;
			}
		}

		/// <summary>
		/// Initializes a new immutable tile.
		/// </summary>
		/// <param name="sides">
		/// Provide the colors of the six sides of the new tile in clockwise
		/// order.
		/// </param>
		/// <exception cref="ArgumentException"/>
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