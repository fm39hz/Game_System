using Godot;

namespace GameSystem.Core.Data.Constant;

public enum InputMappedEnum
{
	Left,
	Right,
	Up,
	Down,
	Action
}

public static class InputMapped
{
	private static readonly string[] KeyMap =
	[
		"ui_left",
		"ui_right",
		"ui_up",
		"ui_down",
		"ui_accept"
	];

	public static string GetMappingValue(InputMappedEnum input)
	{
		return input switch
		{
			InputMappedEnum.Left => KeyMap[0],
			InputMappedEnum.Right => KeyMap[1],
			InputMappedEnum.Up => KeyMap[2],
			InputMappedEnum.Down => KeyMap[3],
			InputMappedEnum.Action => KeyMap[4],
			_ => throw new NotImplementedException()
		};
	}

	public static bool IsPressed(InputMappedEnum input)
	{
		return Input.IsActionPressed(GetMappingValue(input));
	}

	public static bool IsJustPressed(InputMappedEnum input)
	{
		return Input.IsActionJustPressed(GetMappingValue(input));
	}

	public static Vector2 GetVector()
	{
		return Input.GetVector(
			GetMappingValue(InputMappedEnum.Left),
			GetMappingValue(InputMappedEnum.Right),
			GetMappingValue(InputMappedEnum.Up),
			GetMappingValue(InputMappedEnum.Down));
	}

	public static float GetHorizontalAxis()
	{
		return Input.GetAxis(
			GetMappingValue(InputMappedEnum.Left),
			GetMappingValue(InputMappedEnum.Right));
	}

	public static float GetVerticalAxis()
	{
		return Input.GetAxis(
			GetMappingValue(InputMappedEnum.Up),
			GetMappingValue(InputMappedEnum.Down));
	}
}