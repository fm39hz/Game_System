using GameSystem.Core.Component.DamageSystem.Base;
using GameSystem.Core.Data.Base;
using GameSystem.Core.Data.Concrete;
using GameSystem.Core.Object.PhysicsBody.Base;
using GameSystem.Core.Utils;
using Godot;

namespace GameSystem.Core.Object.Root.Base;

public abstract partial class BaseCreatureRoot : BaseObjectRoot<BaseCreatureData, BaseCreature>
{
	[Export] public float Health { get; set; }
	public BaseHurtBox? Hurtbox { get; set; }

	public override void _Ready()
	{
		base._Ready();
		Hurtbox = Body!.GetFirstChild<BaseHurtBox>();
		SpriteSheet!.PolygonChanged += Hurtbox.UpdateCollision;
	}

	public override void InitInformation()
	{
		var _bitmap = new Bitmap();
		_bitmap.CreateFromImageAlpha(SpriteSheet!.Texture.GetImage());
		Information = new CreatureData
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