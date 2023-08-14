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

	public override void InformationInit()
	{
		Information = new CreatureData
		{
			Health = Health
		};
	}

	protected override void UpdateInformation()
	{
		base.UpdateInformation();
		if (Target is Creature _creature)
		{
			if (!_creature.Velocity.IsEqualApprox(Vector2.Zero))
			{
				Information.Direction.SetDirection(_creature.Velocity);
			}
		}
	}
}