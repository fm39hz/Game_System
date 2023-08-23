using Godot;

namespace GameSystem.Component.DamageSystem;

[GlobalClass]
public partial class Effect : Node {
	[Signal]
	public delegate void EffectAppliedEventHandler();

	[Signal]
	public delegate void EffectDiscardedEventHandler();

	[Export] public double CountDown { get; set; }
	private Timer Timer { get; set; }


	public override void _EnterTree() {
		Timer.ProcessCallback = Timer.TimerProcessCallback.Idle;
		Timer.OneShot = true;
		Timer.Timeout += Discard;
	}

	public virtual void Apply() {
		EmitSignal(SignalName.EffectApplied);
		Timer.Start(CountDown);
	}

	public virtual void Discard() {
		EmitSignal(SignalName.EffectDiscarded);
	}
}