using Godot;

namespace GameSystem.Component.DamageSystem;
    [GlobalClass]
    public partial class HurtBox : Area2D{
        public override void _EnterTree(){
            CollisionLayer = 2;
            }
    }
