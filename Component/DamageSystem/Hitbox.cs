using GameSystem.Core.Utils;
using Godot;
using CreatureRoot = GameSystem.Core.Object.Root.CreatureRoot;
using Weapon = GameSystem.Core.Object.Root.Concrete.Weapon;

namespace GameSystem.Core.Component.DamageSystem;

[GlobalClass]
public partial class Hitbox : Marker2D, IHitbox
{
	[Export] public float ShapeRadius { get; set; }
	[Export] public float ShapeHeight { get; set; }
	[Export] public float ShapeSpacing { get; set; }
	public Weapon Target { get; set; }
	public HurtBox OwnerHurtbox { get; set; }

	public virtual void HurtboxEnter(Area2D target)
	{
		if (target is not HurtBox _target) return;
		if (_target != OwnerHurtbox)
		{
			Target!.ApplyDamage += _target.TakeDamage;
		}
	}

	public virtual void HurtBoxExit(Area2D target)
	{
		if (target is not HurtBox _target) return;
		if (_target != OwnerHurtbox)
		{
			Target!.ApplyDamage -= _target.TakeDamage;
		}
	}

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
}