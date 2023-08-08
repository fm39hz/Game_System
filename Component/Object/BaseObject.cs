using System;
using Godot;

namespace GameSystem.Component.Object;

[GlobalClass]
public partial class BaseObject : CharacterBody2D
{
	/// <summary>
	/// Condition allow Object to Move
	/// </summary>
	public bool IsMoveable { get; set; } = true;

	/// <summary>
	/// Get the first child node of type T
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <returns>The first node of type T</returns>
	public T GetFirstChildOfType<T>() where T : Node
	{
		T _targetChild = null;
		for (var i = 0; i < GetChildCount(); i++)
		{
			if (GetChildOrNull<T>(i) != null)
			{
				_targetChild = GetChild<T>(i);
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
	public T GetFirstSiblingOfType<T>() where T : Node
	{
		var _parent = GetParent();
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