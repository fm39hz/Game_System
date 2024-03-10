using GameSystem.Utils;
using Godot;

namespace GameSystem.Data.Instance;

public sealed class DirectionData
{
	public DirectionData()
	{
		SetDirection(0);
		IsFourDirection = true;
	}

	public DirectionData(int direction, bool isFourDirection)
	{
		SetDirection(direction);
		IsFourDirection = isFourDirection;
	}

	public DirectionData(Vector2 direction)
	{
		SetDirection(direction);
	}

	public int AsNumber { get; private set; }
	public Vector2 AsVector { get; private set; }
	public float AsRadiant { get; private set; }
	public bool IsTransitioning { get; set; }
	public bool IsFourDirection { get; set; }

	public void SetDirection(int input)
	{
		AsNumber = input;
		AsVector = Direction.ToDirection(input);
		AsRadiant = Direction.ToRadian(input);
	}

	public void SetDirection(Vector2 input)
	{
		AsVector = input.Normalized();
		AsNumber = Direction.ToDirection(input);
		AsRadiant = Direction.ToRadian(AsNumber);
	}

	public int GetDirectionAsNumber()
	{
		if (AsNumber is < 0 or > 7)
		{
			throw new IndexOutOfRangeException("Direction must be in range 0-7");
		}
		if (IsFourDirection)
		{
			return AsNumber switch
			{
				0 => 0,
				1 => 1,
				2 => 2,
				3 => 3,
				4 => 1,
				5 => 1,
				6 => 3,
				7 => 3,
				_ => 0
			};
		}

		return AsNumber;
	}
}