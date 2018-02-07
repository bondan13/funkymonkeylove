using System;
using UnityEngine;

public class Direction{

	public static Vector2 run(Vector2 pos, Vector2 objectPos){
		float x = 0f;
		float y = 0f;
		float xa = pos.x - objectPos.x;
		float ya = pos.y - objectPos.y;
		float abs_xa = Math.Abs (xa);
		float abs_ya = Math.Abs (ya);
		if (abs_xa > abs_ya) {
			y = abs_ya / abs_xa;
			x = 1f;
		} else {
			x = abs_xa / abs_ya;
			y = 1f;
		}
		x = (Direction.sign (xa) * x);
		y = (Direction.sign (ya) * y);
		return new Vector2 (x, y);
	}

	public static string direction(Vector2 pos){
		return "U";
	}

	public static int sign(float x_axis){
		int s = 1;
		if (x_axis > 0f) {
			s = -1;
		}
		return s;
	}
}
