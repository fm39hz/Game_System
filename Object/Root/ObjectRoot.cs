using GameSystem.Component.Animation;
using GameSystem.Component.FiniteStateMachine;
using GameSystem.Data;
using GameSystem.Utils;
using Godot;
using Prototype.GameSystem.Object;

namespace GameSystem.Object.Root;

public partial class ObjectRoot<TData, TBody> : Root<TData, TBody>, IAnimated, IDynamicContainer
	where TData : ObjectData where TBody : Node2D
{
	public virtual void PlayAnimation()
	{
		SpriteSheet.Animate(Information);
	}

	public virtual void UpdateData(double delta)
	{
		Information.CurrentState = StateMachine.CurrentState;
		Information.Location = Position + Body.Position;
	}

	public virtual void InitData()
	{
		YSortEnabled = true;
		StateMachine = this.GetFirstChild<StateMachine>();
		SpriteSheet = Body.GetFirstChild<SpriteSheet>();
		if (Body is IContainer _body)
		{
			_body.InitData();
		}
	}

	public override void _Ready()
	{
		InitData();
	}

	public override void _PhysicsProcess(double delta)
	{
		UpdateData(delta);
		PlayAnimation();
	}
}