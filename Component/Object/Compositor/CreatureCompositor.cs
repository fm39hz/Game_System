using GameSystem.Component.DamageSystem;
using GameSystem.Component.Object.Composition;
using GameSystem.Data.Instance;
using Godot;

namespace GameSystem.Component.Object.Compositor;
[GlobalClass]
public partial class CreatureCompositor : ObjectCompositor
{
	public HurtBox Hurtbox { get; set; }
	public override void _Ready()
	{
		base._Ready();
		Information = new CreatureData();
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