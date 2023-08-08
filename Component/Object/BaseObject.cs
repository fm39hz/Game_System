using System;
using Godot;

namespace GameSystem.Component.Object;

[GlobalClass]
/// <summary>
/// Đối tượng Cơ sở của các đối tượng tương tác
/// </summary>
public partial class BaseObject : CharacterBody2D
{
	/// <summary>
	/// Điều kiện quyết định đối tượng có được di chuyển hay không
	/// </summary>
	public bool IsMoveable { get; set; } = true;

	/// <summary>
	/// Trả về node con đầu tiên có type T
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <returns>Node con đầu tiên có type T, hoặc null nếu không tìm thấy</returns>
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
	/// Trả về node đầu tiên có type T trong node Cha, ở cùng cấp với node hiện tại
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <returns>Node đầu tiên có type T ở cùng cấp, hoặc null nếu không tìm thấy</returns>
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