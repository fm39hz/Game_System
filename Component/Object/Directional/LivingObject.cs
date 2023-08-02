using GameSystem.Component.DamageSystem;
using GameSystem.Data.Instance;
using Godot;

namespace GameSystem.Component.Object.Directional;
    public partial class LivingObject : DynamicObject{
		[Export] public float Health { get; set; }
        public new LivingObjectData Information { get; set; }
        public HurtBox Hurtbox { get; set; }
        }