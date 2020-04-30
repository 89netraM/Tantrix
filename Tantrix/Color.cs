using System;

namespace Tantrix
{
	/// <summary>
	/// Specifies constants that define the colors avalible in a Tantrix game.
	/// </summary>
	[Flags]
	public enum Color : byte
	{
		Red    = 0b0001,
		Green  = 0b0010,
		Blue   = 0b0100,
		Yellow = 0b1000
	}
}