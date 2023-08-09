using Godot;
using System;

namespace GameSystem.Utility;

public static class GodotNodeInteractive
{
	/// <summary>
	/// Get the first child node of type T
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <returns>The first node of type T</returns>
	public static T GetFirstChildOfType<T>(Node target) where T : Node
	{
		T _targetChild = null;
		for (var i = 0; i < target.GetChildCount(); i++)
		{
			if (target.GetChildOrNull<T>(i) != null)
			{
				_targetChild = target.GetChild<T>(i);
				break;
			}
		}

		if (_targetChild == null)
		{
			throw new Exception("Cannot find any child of type " + typeof(T));
		}
		return _targetChild;
	}

	/// <summary>
	/// Get the first node of type T, at the same level with current node
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <returns>The first Sibling of type T</returns>
	public static T GetFirstSiblingOfType<T>(Node target) where T : Node
	{
		var _parent = target.GetParent();
		T _targetSibling = null;
		for (var i = 0; i < _parent.GetChildCount(); i++)
		{
			if (_parent.GetChildOrNull<T>(i) != null)
			{
				_targetSibling = _parent.GetChild<T>(i);
				break;
			}
		}

		if (_targetSibling == null)
		{
			throw new Exception("Cannot find any sibling of type " + typeof(T));
		}
		return _targetSibling;
	}
}