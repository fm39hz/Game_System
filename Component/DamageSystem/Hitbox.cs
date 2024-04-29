﻿using GameSystem.Utils;
using Godot;
using Concrete_Weapon = GameSystem.Object.Root.Concrete.Weapon;
using Root_CreatureRoot = GameSystem.Object.Root.CreatureRoot;

namespace GameSystem.Component.DamageSystem;

[GlobalClass]
public partial class Hitbox : Marker2D, IHitbox
{
	[Export] public float ShapeRadius { get; set; }
	[Export] public float ShapeHeight { get; set; }
	[Export] public float ShapeSpacing { get; set; }
	public Concrete_Weapon Target { get; set; }
	public HurtBox OwnerHurtbox { get; set; }

	public virtual void HurtboxEnter(Area2D target)
	{
		if (target is not HurtBox _target) return;
		if (_target != OwnerHurtbox)
		{
			Target.ApplyDamage += _target.TakeDamage;
		}
	}

	public virtual void HurtBoxExit(Area2D target)
	{
		if (target is not HurtBox _target) return;
		if (_target != OwnerHurtbox)
		{
			Target.ApplyDamage -= _target.TakeDamage;
		}
	}

	public override void _EnterTree()
	{
		Target = GetParent<Concrete_Weapon>();
		OwnerHurtbox = Target.GetOwner<Root_CreatureRoot>().GetFirstChild<HurtBox>();
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