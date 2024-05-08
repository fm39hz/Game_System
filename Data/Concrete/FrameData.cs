namespace GameSystem.Data.Concrete;

/// <summary>
///     Chứa thông tin về frame của 1 đối tượng
/// </summary>
public class FrameData(int frameNumber, double speed, int transitionFrame)
{
	/// <summary>
	///     Số frame của SpriteSheetPlayer
	/// </summary>
	/// <value></value>
	public int Length { get; set; } = frameNumber;

	public int TransitionFrame { get; set; } = transitionFrame;

	/// <summary>
	///     Tốc độ của SpriteSheetPlayer
	/// </summary>
	/// <value></value>
	public double Speed { get; set; } = speed;
}