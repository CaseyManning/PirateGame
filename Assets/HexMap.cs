using System;
using System.Collections;
using UnityEngine;

public class HexMap<T> : IEnumerable
{
	private int size;
	private T origin;
	private T[,] axes;
	private T[,,] thirds;

	public HexMap (int size)
	{
		this.size = size;
//		origin = null;
		axes = new T[3, size];
		thirds = new T[3, size, size];
	}

	public T this[int x, int y, int z] {
		get {
			if (x == 0 && y == 0 && z == 0) {
				return origin;
			} else if (x > 0 && y < 0) {
				return thirds [0, x - 1, -y - 1];
			} else if (y > 0 && z < 0) {
				return thirds [1, y - 1, -z - 1];
			} else if (z > 0 && x < 0) {
				return thirds [2, z - 1, -x - 1];
			} else if (x == 0) {
				return axes [0, z - 1];
			} else if (y == 0) {
				return axes [1, x - 1];
			} else if (z == 0) {
				return axes [2, y - 1];
			} else {
				throw new ArgumentException ("Illegal position");
			}
		}

		set {
			if (x == 0 && y == 0 && z == 0) {
				origin = value;
			} else if (x > 0 && y < 0) {
				thirds [0, x - 1, -y - 1] = value;
			} else if (y > 0 && z < 0) {
				thirds [1, y - 1, -z - 1] = value;
			} else if (z > 0 && x < 0) {
				thirds [2, z - 1, -x - 1] = value;
			} else if (x == 0) {
				axes [0, z - 1] = value;
			} else if (y == 0) {
				axes [1, x - 1] = value;
			} else if (z == 0) {
				axes [2, y - 1] = value;
			} else {
				throw new ArgumentException ("Illegal position");
			}
		}
	}

	public T this[TilePosition p] {
		get {
			TilePosition rounded = p.Round ();
			return this [(int) rounded.GetX (), (int) rounded.GetY (), (int) rounded.GetZ ()];
		}
		set {
			TilePosition rounded = p.Round ();
			this [(int) rounded.GetX (), (int) rounded.GetY (), (int) rounded.GetZ ()] = value;
		}
	}

	public IEnumerator GetEnumerator() {
		yield return origin;
		for (int i = 0; i < size; i++) {
			for (int j = 0; j < 3; j++) {
				yield return axes [j, i];
				for (int k = 0; k < i; k++) {
					yield return thirds [j, k, i];
				}
				for (int k = i; k >= 0; k--) {
					yield return thirds [j, i, k];
				}
			}
		}
	}

	public int Area(){
		return 1 + 3 * size * (size + 1);
	}
}

