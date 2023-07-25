using GameSystem.Component.Object;
using GameSystem.Data.Instance;
using Godot;

namespace GameSystem.Component.DamageSystem;
    [GlobalClass]
    public partial class HurtBox : Area2D{
        public DynamicObject Target { get; set; }
        public override void _EnterTree(){
            this.Target = this.GetOwner<DynamicObject>();
            }
        public void TakeDamage(DamageData damage){
            this.Target.Metadata.Health -= damage.Value;
            }
        }
