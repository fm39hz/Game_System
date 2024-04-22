using Godot;
using Timer = Godot.Timer;

namespace GameSystem.Core.Component.DamageSystem;

[GlobalClass]
public partial class Effect : Node, IEffect
{
	[Signal] public delegate void EffectAppliedEventHandler();

	[Signal] public delegate void EffectDiscardedEventHandler();

	[Export] public double CountDown { get; set; }
	protected Timer Timer { get; set; }

	public virtual void Apply()
	{
		EmitSignal(SignalName.EffectApplied);
		Timer.Start(CountDown);
	}

	public virtual void Discard()
	{
		EmitSignal(SignalName.EffectDiscarded);
	}

	public override void _EnterTree()
	{
		Timer.ProcessCallback = Timer.TimerProcessCallback.Idle;
		Timer.OneShot = true;
		Timer.Timeout += Discard;
	}
}