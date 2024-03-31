using GameSystem.Core.Component.DamageSystem;
using GameSystem.Core.Object.PhysicsBody.Base;
using GameSystem.Core.Utils;
using Godot;
using CreatureData = GameSystem.Core.Data.CreatureData;

namespace GameSystem.Core.Object.Root;

public abstract partial class CreatureRoot : ObjectRoot<CreatureData, Creature>
{
	[Export] public float Health { get; set; }
	public HurtBox? Hurtbox { get; set; }

	public override void _Ready()
	{
		base._Ready();
		Hurtbox = Body!.GetFirstChild<HurtBox>();
		SpriteSheet!.PolygonChanged += Hurtbox.UpdateCollision;
	}

	public override void InitInformation()
	{
		var _bitmap = new Bitmap();
		_bitmap.CreateFromImageAlpha(SpriteSheet!.Texture.GetImage());
		Information = new Data.Concrete.CreatureData
		{
			Health = Health,
			ShapePool = PolygonCreator.GetArea(SpriteSheet, _bitmap, Name)
		};
	}

	public override void UpdateInformation()
	{
		if (!Body!.Velocity.IsEqualApprox(Vector2.Zero))
		{
			Information!.Direction!.SetDirection(Body.Velocity);
		}
	}
}