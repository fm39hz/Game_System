using System;
using GameSystem.Component.FiniteStateMachine;
using Godot;

namespace GameSystem.Core.Component.FiniteStateMachine;

[GlobalClass]
public partial class StaticState : State, IMachinary
{
	[ExportCategory("Motion")]
	[Export] public float MaxSpeed { get; protected set; }
	[Export] public float Acceleration { get; protected set; }
	[Export] public float Friction { get; protected set; }

	public void EnteredMachine()
	{
		throw new NotImplementedException();
	}

	public void ExitMachine()
	{
		throw new NotImplementedException();
	}
}