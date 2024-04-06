using GameSystem.Core.Component.DamageSystem;
using GameSystem.Core.Data;
using GameSystem.Core.Object.PhysicsBody;
using GameSystem.Core.Utils;
using Godot;

namespace GameSystem.Core.Object.Root;

[GlobalClass]
public abstract partial class CreatureRoot : ObjectRoot<CreatureData, Creature>
{
	[Export] public float Health { get; set; }
	public HurtBox Hurtbox { get; set; }

	public override void InitData()
	{
		base.InitData();
		Hurtbox = Body!.GetFirstChild<HurtBox>();
		SpriteSheet!.PolygonChanged += Hurtbox.UpdateCollision;
		var _bitmap = new Bitmap();
		_bitmap.CreateFromImageAlpha(SpriteSheet!.Texture.GetImage());
		Information = new Data.Concrete.CreatureData
		{
			Health = Health,
			ShapePool = PolygonCreator.GetArea(SpriteSheet, _bitmap, Name)
		};
	}

	public override void UpdateData(double delta)
	{
		base.UpdateData(delta);
		if (!Body!.Velocity.IsEqualApprox(Vector2.Zero))
		{
			Information!.Direction!.SetDirection(Body.Velocity);
		}
	}
}