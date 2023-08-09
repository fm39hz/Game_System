using GameSystem.Component.Object;
using Godot;
using GameSystem.Utility;

namespace GameSystem.Data.Instance;

[GlobalClass]
public partial class DirectionData : Node
{
	public int AsNumber { get; private set; }
	public Vector2 AsVector { get; private set; }
	public float AsRadiant { get; private set; }

	public override void _EnterTree()
	{
		SetDirection(GetOwner<BaseObject>().Velocity);
	}

	public void SetDirection(int input)
	{
		AsNumber = input;
		AsVector = Direction.ToDirection(input);
		AsRadiant = Direction.ToRadian(input);
	}

	public void SetDirection(Vector2 input)
	{
		AsVector = input;
		AsNumber = Direction.ToDirection(input);
		AsRadiant = Direction.ToRadian(AsNumber);
	}
}