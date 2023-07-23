using System.Dynamic;
using System;
using System.Collections.Generic;
using Godot;

namespace GameSystem.Component.DamageSystem;
    public partial class Hitbox : Node{
        public List<Area2D> HitZone { get; set; }
    public override void _Ready(){
        this.HitZone = new List<Area2D>(8);
        for (int i = 0; i < 8; i++){
            this.HitZone.Add(new Area2D(){
                
                });
            }
        }
    }
