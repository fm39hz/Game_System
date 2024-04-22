using GameSystem.Core.Component.DamageSystem;
using GameSystem.Core.Data;
using GameSystem.Core.Object.PhysicsBody;
using Godot;

namespace GameSystem.Core.Object.Root;

[GlobalClass]
public partial class CreatureRoot : ObjectRoot<CreatureData, Creature>
{
	public HurtBox Hurtbox { get; set; }

	public override void UpdateData(double delta)
	{
		base.UpdateData(delta);
		if (!Body!.Velocity.IsEqualApprox(Vector2.Zero))
		{
			Information!.Direction!.SetDirection(Body.Velocity);
		}
	}
}