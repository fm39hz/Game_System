using Godot;
using GameSystem.Data.Instance;
using GameSystem.Component.Object.Directional;
using GameSystem.Component.Object;

namespace GameSystem.Component.FiniteStateMachine;

[GlobalClass]
public partial class DynamicState : State
{
	public new DynamicObject Object { get; protected set; }
	[ExportCategory("Motion")] [Export] public float MaxSpeed { get; protected set; }
	[Export] public float Acceleration { get; protected set; }
	[Export] public float Friction { get; protected set; }

	public override void _EnterTree()
	{
		base._EnterTree();
		Object = GetOwner<DynamicObject>();
	}
}