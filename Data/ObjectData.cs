using GameSystem.Component.FiniteStateMachine;
using Godot;

namespace GameSystem.Data.Instance;
    public class ObjectData{
        public State CurrentState { get; set; }
        public DirectionData Direction { get; protected set; }
        public DirectionData OldDirection { get; set; }
        public bool IsFourDirection { get; set; }
        public bool Transitioning { get; set; }
        public ObjectData(){
            CurrentState = new();
            Direction = new();
            OldDirection = new();
            IsFourDirection = true;
            }
        public void SetDirection(int input){
            OldDirection = Direction;
            Direction.SetDirection(input);
            }
        public void SetDirection(Vector2 input){
            OldDirection = Direction;
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
