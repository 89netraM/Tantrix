﻿using System;

namespace Tantrix
{
	/// <summary>
	/// A position on a Tantrix bord.
	/// </summary>
	public readonly struct Position : IEquatable<Position>
	{
		/// <summary>
		/// X-coordinate, positive direction is east.
		/// </summary>
		public int X { get; }
		/// <summary>
		/// Y-coordinate, positive direction is northwest.
		/// </summary>
		public int Y { get; }
		/// <summary>
		/// Z-coordinate, positive direction is southwest.
		/// </summary>
		public int Z { get; }

		/// <summary>
		/// Initializes a new position at the specified coordinates.
		/// </summary>
		/// <param name="x">The X-coordinate.</param>
		/// <param name="y">The Y-coordinate.</param>
		/// <param name="z">The Z-coordinate.</param>
		/// <exception cref="InvalidCoordinatesException">
		/// The sum of the coordinates (x + y + x) must equal 0 or an exception
		/// is thrown.
		/// </exception>
		public Position(int x, int y, int z)
		{
			if (x + y + z != 0)
			{
				throw new InvalidCoordinatesException("The sum of the coordinates (x + y + x) must equal 0.");
			}

			X = x;
			Y = y;
			Z = z;
		}

		/// <summary>
		/// Returns the six positions surrounding this position. In clockwise
		/// order starting at the top.
		/// </summary>
		public Position[] GetSurroundingPositions()
		{
			return new[]
			{
				new Position(X, Y + 1, Z - 1),
				new Position(X + 1, Y, Z - 1),
				new Position(X + 1, Y - 1, Z),
				new Position(X, Y - 1, Z + 1),
				new Position(X - 1, Y, Z + 1),
				new Position(X - 1, Y + 1, Z)
			};
		}

		/// <inheritdoc/>
		public override bool Equals(object obj)
		{
			return obj is Position position && Equals(position);
		}

		/// <inheritdoc/>
		public bool Equals(Position other)
		{
			return X == other.X &&
				   Y == other.Y &&
				   Z == other.Z;
		}

		/// <inheritdoc/>
		public override int GetHashCode()
		{
			return X * 1000000 + Y * 1000 + Z;
		}

		public static bool operator ==(Position left, Position right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(Position left, Position right)
		{
			return !(left == right);
		}

		public static implicit operator Position((int x, int y, int z) tuple)
		{
			return new Position(tuple.x, tuple.y, tuple.z);
		}
	}
}