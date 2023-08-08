using GameSystem.Component.FiniteStateMachine;
using Godot;

namespace GameSystem.Data.Instance;

[GlobalClass]
public partial class ObjectData : Node
{
	public State CurrentState { get; set; }
	public DirectionData Direction { get; protected set; }
	public DirectionData OldDirection { get; set; }
	[Export] public bool IsFourDirection { get; set; } = true;
	public bool Transitioning { get; set; }

	public override void _EnterTree()
	{
		CurrentState = new State();
		Direction = new DirectionData();
		OldDirection = new DirectionData();
		IsFourDirection = true;
	}
	public void SetDirection(int input)
	{
		OldDirection = Direction;
		Direction.SetDirection(input);
	}

	public void SetDirection(Vector2 input)
	{
		OldDirection = Direction;
		Direction.SetDirection(input);
	}

	public int GetDirectionAsNumber()
	{
		if (Direction.AsNumber > 3 && IsFourDirection)
		{
			switch (Direction.AsNumber)
			{
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

	public Vector2 GetDirectionAsVector()
	{
		return Direction.AsVector.Normalized();
	}
}