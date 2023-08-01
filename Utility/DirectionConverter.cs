using Godot;
using System.Collections.Generic;
using GameSystem.Data.Instance;

namespace GameSystem.Utility.Direction;
		public static class DirectionConverter{
			public static int ToDirection(Vector2 input){
				var _directionMap = new DirectionData().DirectionContainer;
				var _target = 0;
					foreach (var direction in _directionMap){
						if (input.AngleTo(direction.Value) == 0){
							_target = direction.Key;
							break;
							}
						}
				return _target;
				}
			public static Vector2 ToDirection(int input){
				var _directionMap = new DirectionData().DirectionContainer;
				var _target = Vector2.Zero;
					if (input < 0 || input > 7){
						return _target;
						}
					foreach (var direction in _directionMap){
						if (input == direction.Key){
							_target = direction.Value.Normalized();
							break;
							}
						}
				return _target;
				}
			public static float ToRadiant(int input){
				var _radiantMap = new DirectionData().RadiantContainer;
				var _target = 0.0f;
					foreach (var radiant in _radiantMap){
						if (input == radiant.Key){
							_target = radiant.Value;
							}
						}
				return _target;
				}
			}
