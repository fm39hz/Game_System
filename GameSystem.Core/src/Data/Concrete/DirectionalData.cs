using GameSystem.Core.Data.Base;
using GameSystem.Core.Utils;
using Godot;

namespace GameSystem.Core.Data.Concrete;

public sealed class DirectionalData : BaseDirectionalData
{
	public DirectionalData()
	{
		SetDirection(0);
		IsFourDirection = true;
	}

	public DirectionalData(int direction, bool isFourDirection)
	{
		SetDirection(direction);
		IsFourDirection = isFourDirection;
	}

	public DirectionalData(Vector2 direction)
	{
		SetDirection(direction);
	}

	public override void SetDirection(int input)
	{
		AsNumber = input;
		AsVector = Direction.ToDirection(input);
		AsRadiant = Direction.ToRadian(input);
	}

	public override void SetDirection(Vector2 input)
	{
		AsVector = input.Normalized();
		AsNumber = Direction.ToDirection(input);
		AsRadiant = Direction.ToRadian(AsNumber);
	}

	public override int GetDirectionAsNumber()
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