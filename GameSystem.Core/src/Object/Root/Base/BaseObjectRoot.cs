using GameSystem.Core.Component.Animation.Base;
using GameSystem.Core.Component.FiniteStateMachine.Base;
using GameSystem.Core.Data.Base;
using GameSystem.Core.Utils;
using Godot;

namespace GameSystem.Core.Object.Root.Base;

public abstract partial class BaseObjectRoot<TData, TBody> : BaseRoot<TData, TBody>
	where TData : BaseObjectData where TBody : Node2D
{
	public override void _Ready()
	{
		YSortEnabled = true;
		StateMachine = this.GetFirstChild<BaseStateMachine>();
		SpriteSheet = Body!.GetFirstChild<BaseSpriteSheet>();
		InitInformation();
	}

	public override void _PhysicsProcess(double delta)
	{
		UpdateInformation();
		PlayAnimation();
	}

	public override void PlayAnimation()
	{
		SpriteSheet!.Animate(Information!);
	}

	public override void UpdateInformation()
	{
		Information!.CurrentState = StateMachine!.CurrentState;
		Information.Location = Position + Body!.Position;
	}
}