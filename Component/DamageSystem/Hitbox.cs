using GameSystem.Component.Object.Equipment;
using Godot;

namespace GameSystem.Component.DamageSystem;
    public partial class Hitbox : Area2D{
        public Weapon Target { get; set; }
        public override void _EnterTree(){
            this.Target = GetOwner<Weapon>();
            }
        public override void _PhysicsProcess(double delta){
            }
        public void HurtboxEnter(HurtBox target){
            Target.ApplyDamage += target.TakeDamage;
            }
        public void HurtBoxExit(HurtBox target){
            Target.ApplyDamage -= target.TakeDamage;
            }
        }
