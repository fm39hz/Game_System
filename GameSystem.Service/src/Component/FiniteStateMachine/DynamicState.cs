using GameSystem.Core.Component.FiniteStateMachine.Base;
using GameSystem.Core.Data.Base;
using GameSystem.Core.Object.Root.Base;
using Godot;

namespace GameSystem.Service.Component.FiniteStateMachine;

[GlobalClass]
public abstract partial class DynamicState : BaseState
{
	public override void _EnterTree()
	{
		base._EnterTree();
		Root = GetOwner<BaseObjectRoot<BaseObjectData, Node2D>>();
	}
}