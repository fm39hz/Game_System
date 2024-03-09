using GameSystem.Object.Root;
using GameSystem.Object.Root.Equipment;
using GameSystem.Utils;
using Godot;

namespace GameSystem.Component.DamageSystem;

[GlobalClass]
public partial class Hitbox : Marker2D
{
	[Export] public float ShapeRadius { get; set; }
	[Export] public float ShapeHeight { get; set; }
	[Export] public float ShapeSpacing { get; set; }
	public Weapon Target { get; set; }
	public HurtBox? OwnerHurtbox { get; set; }

	public override void _EnterTree()
	{
		Target = GetParent<Weapon>();
		OwnerHurtbox = Target.GetOwner<CreatureRoot>().GetFirstChild<HurtBox>();
		var _hitboxZone = new Area2D
		{
			CollisionLayer = 2,
			CollisionMask = 2
		};
		_hitboxZone.AddChild(new CollisionShape2D
		{
			Shape = new CapsuleShape2D
			{
				Radius = ShapeRadius,
				Height = ShapeHeight
			},
			Rotation = Mathf.Pi / 2,
			Position = new Vector2(0, ShapeSpacing)
		});
		_hitboxZone.AreaEntered += HurtboxEnter;
		_hitboxZone.AreaExited += HurtBoxExit;
		AddChild(_hitboxZone, true);
	}

	public override void _PhysicsProcess(double delta)
	{
		// Rotation = Root.Information.Direction.AsRadiant;
	}

	public void HurtboxEnter(Area2D target)
	{
		if (target is HurtBox _target)
		{
			if (_target != OwnerHurtbox)
			{
				Target.ApplyDamage += _target.TakeDamage;
			}
		}
	}

	public void HurtBoxExit(Area2D target)
	{
		if (target is HurtBox _target)
		{
			if (_target != OwnerHurtbox)
			{
				Target.ApplyDamage -= _target.TakeDamage;
			}
		}
	}
}