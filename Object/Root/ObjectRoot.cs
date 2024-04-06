﻿using GameSystem.Core.Component.Animation;
using GameSystem.Core.Component.FiniteStateMachine;
using GameSystem.Core.Data;
using GameSystem.Core.Utils;
using Godot;

namespace GameSystem.Core.Object.Root;

public partial class ObjectRoot<TData, TBody> : Root<TData, TBody>, IAnimated, IContainerized
	where TData : ObjectData where TBody : Node2D
{
	public virtual void PlayAnimation()
	{
		SpriteSheet!.Animate(Information!);
	}

	public virtual void UpdateData(double delta)
	{
		Information!.CurrentState = StateMachine!.CurrentState;
		Information.Location = Position + Body!.Position;
	}

	public virtual void InitData()
	{
		YSortEnabled = true;
		StateMachine = this.GetFirstChild<StateMachine>();
		SpriteSheet = Body!.GetFirstChild<SpriteSheet>();
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