using System;
using UnityEngine;

public class TilePosition
{
	public const float SIZE = 3.168f; //distance from center to vertex
	float SQRT3 = (float) Math.Sqrt(3);

	private float x, y;

	public TilePosition(float x = float.NaN, float y = float.NaN, float z = float.NaN){
		this.x = float.IsNaN (x) ? -(y + z) : x;
		this.y = float.IsNaN (y) ? -(x + z) : y;
	}

	public float GetX(){
		return x;
	}

	public float GetY(){
		return y;
	}

	public float GetZ(){
		return -(x + y);
	}

	public float Distance(TilePosition other){
		return Math.Abs (GetX () - other.GetX ()) + Math.Abs (GetY () - other.GetY ()) + Math.Abs (GetZ () - other.GetZ ());
	}

	public Vector2 cartesian(){
		return new Vector2(SIZE * SQRT3 * (GetX() + GetY()/2), SIZE * 3 / 2 * GetY());
	}

	public TilePosition Round(){
		int rx = (int) Math.Round (GetX());
		int ry = (int) Math.Round (GetY());
		int rz = (int) Math.Round (GetZ());
		float dx = Math.Abs (GetX() - rx);
		float dy = Math.Abs (GetY() - ry);
		float dz = Math.Abs (GetZ() - rz);
		if (dx > dy && dx > dz)
			rx = -ry - rz;
		else if (dy > dz)
			ry = -rx - rz;
		else
			rz = -rx - ry;
		return new TilePosition (rx, ry, rz);
	}
}

