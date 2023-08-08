using Godot;
using System;
using GameSystem.Data.Instance;
using GameSystem.Component.Animation;
using GameSystem.Component.FiniteStateMachine;
using GameSystem.Component.Manager;
using GameSystem.Component.Object.Equipment;

namespace GameSystem.Component.Object.Directional;

[GlobalClass]
public partial class DynamicObject : BaseObject
{
	/// <summary>
	/// Kiểm soát signal từ input
	/// </summary>
	public InputManager InputManager { get; protected set; }

	/// <summary>
	/// Sprite Sheet của đối tượng
	/// </summary>
	public SpriteSheet Sheet { get; protected set; }

	/// <summary>
	/// State Machine của đối tượng
	/// </summary>
	public StateMachine StateMachine { get; protected set; }

	/// <summary>
	/// Metadata, chứa thông tin về State ID, hướng nhìn của object, Animation có loop hay không,...
	/// </summary>
	public ObjectData Information { get; protected set; }

	public override void _EnterTree()
	{
		try
		{
			Sheet = GetFirstChildOfType<SpriteSheet>();
			InputManager = GetFirstChildOfType<InputManager>();
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
			StateMachine = GetFirstChildOfType<StateMachine>();
			Information = GetFirstChildOfType<ObjectData>();
		}
		catch (InvalidCastException _cannotGetStateMachine)
		{
			GD.Print(_cannotGetStateMachine.Message);
			throw;
		}
	}

	public override void _PhysicsProcess(double delta)
	{
		UpdateMetadata();
		ActiveAnimation();
		MoveAndSlide();
	}

	/// <summary>
	/// Cập nhật Metadata của đối tượng
	/// </summary>
	protected void UpdateMetadata()
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
		GD.Print(Information.Transitioning);
	}

	/// <summary>
	/// Animate Sprite Sheet dựa trên thông tin lấy được từ method UpdateMetadata
	/// </summary>
	protected void ActiveAnimation()
	{
		var _state = StateMachine.CurrentState;
		var _frame = _state.Frame;
		Sheet.Animate(_frame, Information);
	}
}