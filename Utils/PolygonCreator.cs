using System.Collections.Generic;
using Godot;

namespace GameSystem.Utils;

public static class PolygonCreator
{
	private const float AccurateValue = 0.42f;
	public static Dictionary<int, CollisionPolygon2D> GetPolygonArea(Sprite2D spriteSheet, Bitmap bitmap, string name)
	{
		var _shapePool = new Dictionary<int, CollisionPolygon2D>();
		var _texture = spriteSheet.Texture;
		var _width = _texture.GetWidth() / spriteSheet.Hframes;
		var _height = _texture.GetHeight() / spriteSheet.Vframes;
		for (int _frame = 0, _state = 0; _frame < spriteSheet.Hframes * spriteSheet.Vframes; _frame++)
		{
			var _horizontalIndex = _frame * _width - _texture.GetWidth() * _state;
			var _verticalIndex = _state * _height;
			var _position = new Vector2I(_horizontalIndex, _verticalIndex);
			var _polys = bitmap.OpaqueToPolygons(new Rect2I(_position, _width, _height), AccurateValue);
			foreach (var _poly in _polys)
			{
				_shapePool.TryAdd(_frame, ConfigPolygon(_poly, spriteSheet.Position, name + "_" + _frame));
			}
			if (_frame == spriteSheet.Hframes * (_state + 1) - 1)
			{
				_state++;
			}
		}
		return _shapePool;

	}
	private static CollisionPolygon2D ConfigPolygon(Vector2[] poly, Vector2 position, string name)
	{
		for (var _i = 0; _i < poly.Length; _i++)
		{
			poly[_i] += position;
		}
		var _shape = new CollisionPolygon2D
		{
			Polygon = poly,
			Name = name
		};
		return _shape;
	}
}
