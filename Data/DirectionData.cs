using System;
using Godot;
using GameSystem.Utility;

namespace GameSystem.Data.Instance;

public class DirectionData
{
	public int AsNumber { get; private set; }
	public Vector2 AsVector { get; private set; }
	public float AsRadiant { get; private set; }
	public bool IsTransitioning { get; set; }
	public bool IsFourDirection { get; set; }
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
	public void SetDirection(int input)
	{
		AsNumber = input;
		AsVector = Direction.ToDirection(input);
		AsRadiant = Direction.ToRadian(input);
	}

	public void SetDirection(Vector2 input)
	{
		AsVector = input;
		AsNumber = Direction.ToDirection(input);
		AsRadiant = Direction.ToRadian(AsNumber);
	}	
	public int GetDirectionAsNumber()
	{
		if (AsNumber > 3 || IsFourDirection)
		{
			return AsNumber;
		}

		return AsNumber switch
		{
			4 => 1,
			5 => 1,
			6 => 3,
			7 => 3,
			_ => 0
		};
	}
}