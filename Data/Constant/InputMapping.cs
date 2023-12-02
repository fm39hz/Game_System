using Godot;

namespace GameSystem.Data.Constant;

public enum MappedKey
{
	Left,
	Right,
	Up,
	Down,
	Action
}

public static class InputMapping
{
	private static readonly string[] KeyMap =
	{
		"ui_left",
		"ui_right",
		"ui_up",
		"ui_down",
		"ui_accept"
	};

	public static string GetMappingValue(MappedKey input)
	{
		return input switch
		{
			MappedKey.Left => KeyMap[0],
			MappedKey.Right => KeyMap[1],
			MappedKey.Up => KeyMap[2],
			MappedKey.Down => KeyMap[3],
			MappedKey.Action => KeyMap[4],
			_ => null
		};
	}

	public static bool IsPressed(MappedKey input)
	{
		return Input.IsActionPressed(GetMappingValue(input));
	}

	public static bool IsJustPressed(MappedKey input)
	{
		return Input.IsActionJustPressed(GetMappingValue(input));
	}

	public static Vector2 GetVector()
	{
		return Input.GetVector(
			GetMappingValue(MappedKey.Left),
			GetMappingValue(MappedKey.Right),
			GetMappingValue(MappedKey.Up),
			GetMappingValue(MappedKey.Down));
	}

	public static float GetHorizontalAxis()
	{
		return Input.GetAxis(
			GetMappingValue(MappedKey.Left),
			GetMappingValue(MappedKey.Right));
	}

	public static float GetVerticalAxis()
	{
		return Input.GetAxis(
			GetMappingValue(MappedKey.Up),
			GetMappingValue(MappedKey.Down));
	}
}