using GameSystem.Component.Object;
using GameSystem.Data.Instance;
using Godot;

namespace GameSystem.Component.DamageSystem;
    [GlobalClass]
    public partial class HurtBox : Area2D{
        public DynamicObject Target { get; set; }
        public override void _EnterTree(){
            Target = GetOwner<DynamicObject>();
            }
        public void TakeDamage(DamageData damage){
            foreach (var target in damage.Target){
                if (Target.GetType().IsAssignableTo(target.GetType())){
                    Target.Metadata.TakeDamage(damage);
                    return;
                    }
                }
            }
        }
