using Godot;
using System;
using GameSystem.Data.Instance;
using GameSystem.Component.Animation;
using GameSystem.Component.FiniteStateMachine;
using GameSystem.Component.Manager;
using GameSystem.Utility;

namespace GameSystem.Component.Object.Directional;

[GlobalClass]
public partial class DynamicObject : BaseObject
{
	/// <summary>
	/// Manage the Input Signal
	/// </summary>
	public InputManager InputManager { get; protected set; }

	/// <summary>
	/// Object SpriteSheet
	/// </summary>
	public SpriteSheet Sheet { get; protected set; }

	/// <summary>
	/// Object state machine, control the State data
	/// </summary>
	public StateMachine StateMachine { get; protected set; }

	/// <summary>
	/// Object information
	/// </summary>
	public ObjectData Information { get; protected set; }

	public override void _EnterTree()
	{
		try
		{
			Sheet = GodotNodeInteractive.GetFirstChildOfType<SpriteSheet>(this);
			InputManager = GodotNodeInteractive.GetFirstChildOfType<InputManager>(this);
		}
		catch (InvalidCastException _cannotGetSpriteSheet)
		{
			GD.Print(_cannotGetSpriteSheet.Message);
			throw;
		}
	}

	public override void _Ready()
	{
		try
		{
			StateMachine = GodotNodeInteractive.GetFirstChildOfType<StateMachine>(this);
			Information = GodotNodeInteractive.GetFirstChildOfType<ObjectData>(this);
		}
		catch (InvalidCastException _cannotGetStateMachine)
		{
			GD.Print(_cannotGetStateMachine.Message);
			throw;
		}
	}

	public override void _PhysicsProcess(double delta)
	{
		ObjectUpdate();
		ActiveAnimation();
		MoveAndSlide();
	}

	/// <summary>
	/// Method to update Object data
	/// </summary>
	protected void ObjectUpdate()
	{
		Information.CurrentState = StateMachine.CurrentState;
		if (!Velocity.IsEqualApprox(Vector2.Zero))
		{
			Information.SetDirection(Velocity);
		}
	}

	public void Transition()
	{
		Information.Transitioning = !Information.Transitioning;
		GD.Print(Name + " is Transition");
	}

	/// <summary>
	/// Play the animation based on sheet and current state
	/// </summary>
	protected void ActiveAnimation()
	{
		var _state = Information.CurrentState;
		var _frame = _state.Frame;
		Sheet.Animate(_frame, Information);
	}
}