using System.Collections.Generic;
using GameSystem.Component.DamageSystem;
using GameSystem.Component.FiniteStateMachine;
using Godot;

namespace GameSystem.Data.Instance;
    public class DynamicObjectData{
        public DynamicState CurrentState { get; set; }
        public DirectionData Direction { get; protected set; }
        public float Health { get; set; }
        public bool IsFourDirection { get; set; }
        public List<Effect> Effected { get; set; }
        public DynamicObjectData(){
            CurrentState = new();
            Direction = new();
            IsFourDirection = true;
            Effected = new();
            Health = 0;
            }
        public void TakeDamage(DamageData damage) {
            Health -= damage.Value;
            foreach (var effect in damage.EffectsValue) {
                Effected.Add(effect);
                effect.Apply();
                }
            }
        public void SetDirection(int input){
            Direction.SetDirection(input);
            }
        public void SetDirection(Vector2 input){
            Direction.SetDirection(input);
            }
        public int GetDirectionAsNumber(){
            if (Direction.AsNumber > 3 && IsFourDirection){
                switch (Direction.AsNumber){
                    case 4:
                        return 1;
                    case 5:
                        return 1;
                    case 6:
                        return 3;
                    case 7:
                        return 3;
                    }
                }
            return Direction.AsNumber;
            }
        public Vector2 GetDirectionAsVector(){
            return Direction.AsVector.Normalized();
            }
        }
