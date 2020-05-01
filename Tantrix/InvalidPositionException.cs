using System;

namespace Tantrix
{
	/// <summary>
	/// The exception that is thrown when trying to wrongly place a tile on a
	/// <see cref="Board"/>.
	/// </summary>
	public class InvalidPositionException : Exception
	{
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="InvalidPositionException"/> class.
		/// </summary>
		public InvalidPositionException() : base() { }

		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="InvalidPositionException"/> class with a specified error
		/// message.
		/// </summary>
		public InvalidPositionException(string message) : base(message) { }

		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="InvalidPositionException"/> class with a specified error
		/// message and a reference to the inner exception that is the cause of
		/// this exception.
		/// </summary>
		public InvalidPositionException(string message, Exception innerException) : base(message, innerException) { }
	}
}