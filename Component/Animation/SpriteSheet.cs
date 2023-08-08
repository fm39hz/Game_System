using Godot;
using GameSystem.Data.Instance;
using GameSystem.Data.Global;

namespace GameSystem.Component.Animation;

[GlobalClass]
public partial class SpriteSheet : Sprite2D
{
	/// <summary>
	/// Signal được kích khi Chủ thể không loop và chạy xong animation
	/// </summary>
	[Signal]
	public delegate void AnimationFinishedEventHandler();

	/// <summary>
	/// Frame hiện tại
	/// </summary>
	private int CurrentFrame { get; set; }

	/// <summary>
	/// Bộ đếm frame thực
	/// </summary>
	private double FrameCounter { get; set; }

	/// <summary>
	/// Chạy animation của Sprite Sheet Dữ liệu của đối tượng được truyền vào
	/// </summary>
	/// <param name="frameInfo">Thông tin frame hiện tại</param>
	/// <param name="objectData">Metadata của chủ thể</param>
	public void Animate(FrameData frameInfo, ObjectData objectData)
	{
		var _relativeResponseTime = GetNode<Metadata>("/root/Metadata").RelativeResponseTime;
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