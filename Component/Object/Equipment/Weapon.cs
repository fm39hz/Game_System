using System;
using GameSystem.Component.DamageSystem;
using GameSystem.Data.Instance;
using Godot;

namespace GameSystem.Component.Object.Equipment;
    public abstract partial class Weapon : BaseObject{
        [Signal] public delegate void ApplyDamageEventHandler(DamageData damage);
        public Hitbox Hitbox { get; set; }
        public DamageData Damage { get; set; }
        public DynamicObject Target { get; set; }
        public override void _EnterTree(){
            Target = GetOwner<DynamicObject>();
            Damage = GetFirstChildOfType<DamageData>();
            }
        }
