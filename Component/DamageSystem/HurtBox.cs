using GameSystem.Component.Object;
using Godot;

namespace GameSystem.Component.DamageSystem;
    [GlobalClass]
    public partial class HurtBox : Area2D{
        public DynamicObject Target { get; set; }
        public override void _EnterTree(){
            this.Target = this.GetOwner<DynamicObject>();
            }
        public void EnterHitZone(){
            
            }
        }
