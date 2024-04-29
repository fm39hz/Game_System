using GameSystem.Component.DamageSystem;
using GameSystem.Data;
using GameSystem.Object.Root;
using GameSystem.Utils;
using Godot;
using Prototype.GameSystem.Object;

namespace GameSystem.Object.PhysicsBody;

[GlobalClass]
public partial class Creature : CharacterBody2D, IContainer
{
	[Export] public CreatureData Information { get; set; } = new();
	public CreatureRoot Root { get; set; }

	public void InitData()
	{
		var _spriteSheet = Root.SpriteSheet;
		Root.Hurtbox = this.GetFirstChild<HurtBox>();
		var _bitmap = new Bitmap();
		Root.SpriteSheet.PolygonChanged += Root.Hurtbox.UpdateCollision;
		_bitmap.CreateFromImageAlpha(_spriteSheet.Texture.GetImage());
		Information.ShapePool = PolygonCreator.GetArea(_spriteSheet, _bitmap, Name);
		Root.Information = Information;
	}

	public override void _EnterTree()
	{
		Root = GetParent<CreatureRoot>();
	}

	public override void _PhysicsProcess(double delta)
	{
		MoveAndSlide();
	}
}