using System.Dynamic;
using Godot;

namespace GameSystem.Component.DamageSystem;
    [GlobalClass]
    public partial class HurtBox : Node{
        public DynamicObject Target { get; set; }
        public Area2D HurtZone { get; set; }
        public override void _EnterTree(){
            this.HurtZone = new(){
                CollisionLayer = 2
                };
            }
        public void EnterHitZone(){
            
            }
    }
