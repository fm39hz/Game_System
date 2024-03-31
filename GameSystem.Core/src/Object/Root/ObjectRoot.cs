using GameSystem.Core.Component.Animation;
using GameSystem.Core.Component.FiniteStateMachine;
using GameSystem.Core.Data;
using GameSystem.Core.Utils;
using Godot;

namespace GameSystem.Core.Object.Root;

public abstract partial class ObjectRoot<TData, TBody> : Root<TData, TBody>
	where TData : ObjectData where TBody : Node2D
{
	public override void _Ready()
	{
		YSortEnabled = true;
		StateMachine = this.GetFirstChild<StateMachine>();
		SpriteSheet = Body!.GetFirstChild<SpriteSheet>();
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