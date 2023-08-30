using System;
using System.Text;
using GameSystem.Utils;
using GameSystem.Component.DamageSystem;
using GameSystem.Component.Object.Composition;
using GameSystem.Data.Instance;
using Godot;

namespace GameSystem.Component.Object.Compositor;

[GlobalClass]
public partial class CreatureCompositor : ObjectCompositor
{
	[Export] public float Health { get; set; }
	public HurtBox Hurtbox { get; set; }

	public override void _Ready()
	{
		base._Ready();
		if (Target is not Creature _target)
		{
			throw new InvalidCastException("Target must be Creature");
		}
		Hurtbox = _target.GetFirstChild<HurtBox>();
		SpriteSheet.PolygonChanged += Hurtbox.UpdateCollision;
	}

	protected override void InformationInit()
	{
		Information = new CreatureData
		{
			Health = Health
		};
		HurtboxInit();
	}

	public void HurtboxInit()
	{
		if (Information is not CreatureData _information)
		{
			throw new InvalidCastException("Cannot implicity Object data");
		}

		var _texture = SpriteSheet.Texture;
		var _width = _texture.GetWidth() / SpriteSheet.Hframes;
		var _height = _texture.GetHeight() / SpriteSheet.Vframes;
		var _bitmap = new Bitmap();
		_bitmap.CreateFromImageAlpha(_texture.GetImage());
		for (int _frame = 0, _state = 0; _frame < SpriteSheet.Hframes * SpriteSheet.Vframes; _frame++)
		{
			var _horizontalIndex = _frame * _width - _texture.GetWidth() * _state;
			var _verticalIndex = _state * _height;
			var _position = new Vector2I(_horizontalIndex, _verticalIndex);
			var _polys = _bitmap.OpaqueToPolygons(new Rect2I(_position, _width, _height), 0.42f);
				foreach (var _poly in _polys)
				{
					for (var _i = 0; _i < _poly.Length; _i++)
					{
						_poly[_i] += SpriteSheet.Position;
					}
					var _shapeName = Name + "_" + _frame;
					var _shape = new CollisionPolygon2D
					{
						Polygon = _poly,
						Name = _shapeName
					};
					_information.ShapePool.TryAdd(_frame, _shape);
				}
				if (_frame == SpriteSheet.Hframes * (_state + 1) - 1)
				{
					_state++;
				}
		}
	}

	protected override void InformationUpdate()
	{
		base.InformationUpdate();
		var _target = (Creature)Target;
		if (!_target.Velocity.IsEqualApprox(Vector2.Zero))
		{
			Information.Direction.SetDirection(_target.Velocity);
		}
	}
}