using System;
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
		Hurtbox = SpriteSheet.GetFirstChildOfType<HurtBox>();
	}
    public override void InformationInit()
	{
		if (Target is Creature)
		{
			Information = new CreatureData
			{
				Health = Health
			};
		}
		else
		{
			throw new Exception("Target must be Creature");
		}
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