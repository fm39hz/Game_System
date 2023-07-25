using System.Collections.Generic;
using GameSystem.Component.DamageSystem;
using Godot;

namespace GameSystem.Data.Instance;
    public abstract partial class DamageData : Node{
        [Export] public float Value { get; set; }
        public List<Effect> EffectsValue { get; set; } = new();
        }
