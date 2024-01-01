using System;
using GameSystem.Object.Root;
using Godot;

namespace GameSystem.Component.FiniteStateMachine;

[GlobalClass]
public partial class DynamicState : State
{
	public override void _EnterTree()
	{
		base._EnterTree();
		try
		{
			Root = GetOwner<ObjectRoot>();
		}
		catch (NullReferenceException)
		{
			GD.Print("Cannot find any Root");
			throw;
		}
	}
}