using GameSystem.Component.DamageSystem;
using GameSystem.Data;
using GameSystem.Object.PhysicsBody;
using Godot;

namespace GameSystem.Object.Root;

[GlobalClass]
public partial class CreatureRoot : ObjectRoot<CreatureData, Creature>
{
	public HurtBox Hurtbox { get; set; }

	public override void UpdateData(double delta)
	{
		base.UpdateData(delta);
		if (!Body.Velocity.IsEqualApprox(Vector2.Zero))
		{
			Information.Direction.SetDirection(Body.Velocity);
		}
	}
}