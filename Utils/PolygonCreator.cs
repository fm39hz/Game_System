using System.Collections.Generic;
using GameSystem.Component.Animation;
using Godot;

namespace GameSystem.Utils;

public static class PolygonCreator
{
	public static Dictionary<int, CollisionPolygon2D> GetCoveredPolygon(Sprite2D spriteSheet, Bitmap bitmap, string name)
	{
		var _texture = spriteSheet.Texture;
		var _width = _texture.GetWidth() / spriteSheet.Hframes;
		var _height = _texture.GetHeight() / spriteSheet.Vframes;
		var _shapePool = new Dictionary<int, CollisionPolygon2D>();
		for (int _frame = 0, _state = 0; _frame < spriteSheet.Hframes * spriteSheet.Vframes; _frame++)
		{
			var _horizontalIndex = _frame * _width - _texture.GetWidth() * _state;
			var _verticalIndex = _state * _height;
			var _position = new Vector2I(_horizontalIndex, _verticalIndex);
			var _polys = bitmap.OpaqueToPolygons(new Rect2I(_position, _width, _height), 0.42f);
			foreach (var _poly in _polys)
			{
				for (var _i = 0; _i < _poly.Length; _i++)
				{
					_poly[_i] += spriteSheet.Position;
				}
				var _shapeName = name + "_" + _frame;
				var _shape = new CollisionPolygon2D
				{
					Polygon = _poly,
					Name = _shapeName
				};
				_shapePool.TryAdd(_frame, Insert(_poly, spriteSheet.Position, _shapeName));
			}
			if (_frame == spriteSheet.Hframes * (_state + 1) - 1)
			{
				_state++;
			}
		}
		return _shapePool;

	}
	private static CollisionPolygon2D Insert(Vector2[] poly, Vector2 position, string name)
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
