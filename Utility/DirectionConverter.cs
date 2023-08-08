using System;
using Godot;
using GameSystem.Data.Instance;

namespace GameSystem.Utility.Direction;

public static class DirectionConverter
{
	public static int ToDirection(Vector2 input)
	{
		var _directionMap = new DirectionData().DirectionContainer;
		var _target = 0;
		foreach (var _direction in _directionMap)
		{
			if (MathF.Abs(MathF.Round(input.AngleTo(_direction.Value))) <= 2)
			{
				_target = _direction.Key;
				break;
			}
		}

		return _target;
	}

	public static Vector2 ToDirection(int input)
	{
		var _directionMap = new DirectionData().DirectionContainer;
		var _target = Vector2.Zero;
		if (input < 0 || input > 7)
		{
			return _target;
		}

		foreach (var _direction in _directionMap)
		{
			if (input == _direction.Key)
			{
				_target = _direction.Value.Normalized();
				break;
			}
		}

		return _target;
	}

	public static float ToRadiant(int input)
	{
		var _radiantMap = new DirectionData().RadiantContainer;
		var _target = 0.0f;
		foreach (var _radian in _radiantMap)
		{
			if (input == _radian.Key)
			{
				_target = _radian.Value;
			}
		}

		return _target;
	}
}