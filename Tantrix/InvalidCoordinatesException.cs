using System;

namespace Tantrix
{
	/// <summary>
	/// The exception that is thrown when trying to create a
	/// <see cref="Position"/> with invalid coordinates.
	/// </summary>
	public class InvalidCoordinatesException : Exception
	{
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="InvalidCoordinatesException"/> class.
		/// </summary>
		public InvalidCoordinatesException() : base() { }

		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="InvalidCoordinatesException"/> class with a specified error
		/// message.
		/// </summary>
		public InvalidCoordinatesException(string message) : base(message) { }

		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="InvalidCoordinatesException"/> class with a specified error
		/// message and a reference to the inner exception that is the cause of
		/// this exception.
		/// </summary>
		public InvalidCoordinatesException(string message, Exception innerException) : base(message, innerException) { }
	}
}