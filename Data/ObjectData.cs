using GameSystem.Component.FiniteStateMachine;
using GameSystem.Utility;
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

	public override void _Ready()
	{
		CurrentState = new State();
		Direction = GodotNodeInteractive.GetFirstChildOfType<DirectionData>(this);
		OldDirection = Direction;
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
		if (Direction.AsNumber > 3 || IsFourDirection)
		{
			return Direction.AsNumber;
		}

		return Direction.AsNumber switch
		{
			4 => 1,
			5 => 1,
			6 => 3,
			7 => 3,
			_ => 0
		};
	}

	public Vector2 GetDirectionAsVector()
	{
		return Direction.AsVector.Normalized();
	}
}