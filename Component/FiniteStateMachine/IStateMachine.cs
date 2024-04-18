﻿namespace GameSystem.Core.Component.FiniteStateMachine;

public interface IStateMachine
{
	protected void Init();

	protected void SelectState();

	protected void CheckingCondition();
}