using Godot;
using System;

namespace GameSystem.Utils;

public static class NodeExtension
{
	/// <summary>
	/// Get the first child node of type T
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <returns>The first node of type T</returns>
	public static T GetFirstChildOfType<T>(this Node target) where T : Node
	{
		T _targetChild = null;
		for (var _i = 0; _i < target.GetChildCount(); _i++)
		{
			if (target.GetChildOrNull<T>(_i) != null)
			{
				_targetChild = target.GetChild<T>(_i);
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
	public static T GetFirstSiblingOfType<T>(this Node target) where T : Node
	{
		var _parent = target.GetParent();
		T _targetSibling = null;
		for (var _i = 0; _i < _parent.GetChildCount(); _i++)
		{
			if (_parent.GetChildOrNull<T>(_i) != null)
			{
				_targetSibling = _parent.GetChild<T>(_i);
				break;
			}
		}

		if (_targetSibling == null)
		{
			throw new Exception("Cannot find any sibling of type " + typeof(T));
		}
		return _targetSibling;
	}

	public static void RemoveAllChild(this Node target)
	{
		for (var _i = 0; _i < target.GetChildCount(); _i++)
		{
			target.RemoveChild(target.GetChild(_i));
		}
	}
}