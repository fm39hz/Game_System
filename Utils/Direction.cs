using System;
using System.Collections.Generic;
using Godot;

namespace GameSystem.Utils;

public static class Direction {
	private static readonly Dictionary<int, Vector2> DirectionContainer = new(8) {
		{ 0, Vector2.Down },
		{ 1, Vector2.Right },
		{ 2, Vector2.Up },
		{ 3, Vector2.Left },
		{ 4, Vector2.Down + Vector2.Right },
		{ 5, Vector2.Right + Vector2.Up },
		{ 6, Vector2.Up + Vector2.Left },
		{ 7, Vector2.Left + Vector2.Down }
	};

	private static readonly Dictionary<int, float> RadianContainer = new(8) {
		{ 0, Mathf.Pi / 2 },
		{ 1, 0 },
		{ 2, -Mathf.Pi / 2 },
		{ 3, 2 * Mathf.Pi },
		{ 4, Mathf.Pi / 4 },
		{ 5, -Mathf.Pi / 4 },
		{ 6, -3 * Mathf.Pi / 4 },
		{ 7, 3 * Mathf.Pi / 4 }
	};

	public static int ToDirection(Vector2 input) {
		var _target = 0;
		foreach (var _direction in DirectionContainer) {
			if (MathF.Round(input.AngleTo(_direction.Value)) == 0) {
				_target = _direction.Key;
				break;
			}
		}

		return _target;
	}

	public static Vector2 ToDirection(int input) {
		var _target = Vector2.Zero;
		if (input < 0 || input > 7) {
			return _target;
		}

		foreach (var _direction in DirectionContainer) {
			if (input == _direction.Key) {
				_target = _direction.Value.Normalized();
				break;
			}
		}

		return _target.Normalized();
	}

	public static float ToRadian(int input) {
		var _target = 0.0f;
		foreach (var _radian in RadianContainer) {
			if (input == _radian.Key) {
				_target = _radian.Value;
			}
		}

		return _target;
	}
}