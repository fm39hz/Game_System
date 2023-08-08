using Godot;
using GameSystem.Data.Instance;
using GameSystem.Data.Global;

namespace GameSystem.Component.Animation;

[GlobalClass]
public partial class SpriteSheet : Sprite2D
{
	/// <summary>
	/// Signal trigger when the Sheet finished
	/// </summary>
	[Signal]
	public delegate void AnimationFinishedEventHandler();

	/// <summary>
	/// The current frame, show by int
	/// </summary>
	private int CurrentFrame { get; set; }

	/// <summary>
	/// Realframe counter
	/// </summary>
	private double FrameCounter { get; set; }

	/// <summary>
	/// Run the Animation based on the data provided
	/// </summary>
	/// <param name="frameInfo">Current Frame data</param>
	/// <param name="objectData">Owner Data</param>
	public void Animate(FrameData frameInfo, ObjectData objectData)
	{
		var _relativeResponseTime = GetNode<GlobalData>("/root/GlobalData").RelativeResponseTime;
		var _direction = objectData.GetDirectionAsNumber(); //Lấy hướng nhìn của đối tượng
		var _firstFrame = frameInfo.Length * _direction++;  //Lấy frame bắt đầu của animation
		var _nextFrame = frameInfo.Length * _direction;     //Lấy frame bắt đầu của hướng kế tiếp
			if (objectData.Transitioning)
			{
				_nextFrame = frameInfo.Length * _direction + frameInfo.TransitionFrame;
			}
			if (_firstFrame <= CurrentFrame && CurrentFrame < _nextFrame)
			{
				FrameCounter += _relativeResponseTime; //Tạo bộ đếm frame(thực)
			}
			if (FrameCounter >= 60 * _relativeResponseTime / frameInfo.Speed)
			{
				if (CurrentFrame == _nextFrame - 1)
				{
					if (!objectData.CurrentState.IsLoop)
					{
						EmitSignal(SignalName.AnimationFinished);
					}
					CurrentFrame = _firstFrame; //Reset về frame bắt đầu khi tới frame cuối
				}
				else if (CurrentFrame < _nextFrame)
				{
					CurrentFrame++; //Tăng frame lên 1 khi chưa chạm tới frame cuối
				}
				FrameCounter = 0; //Reset bộ đếm frame(thực)
			}
			if (CurrentFrame < _firstFrame || CurrentFrame > _nextFrame)
			{
				CurrentFrame = _firstFrame; //Chuyển tiếp frame tới vị trí mới
			}
			GD.Print(CurrentFrame + " " + objectData.CurrentState.ID);
		FrameCoords = new Vector2I(CurrentFrame, objectData.CurrentState.ID);
	}
}