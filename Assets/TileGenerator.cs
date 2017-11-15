using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour {

	public GameObject water;
	public GameObject ground;
	public GameObject tree;

	HexMap<GameObject> map;

	float[,] weights = new float[3, 10];
	float[,] offsets = new float[3, 10];

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 10; j++) {
				weights [i, j] = (UnityEngine.Random.value - 0.5f); //* (float) Math.Sqrt(j);
				offsets [i, j] = (UnityEngine.Random.value * j);
			}
		}
//		TilePosition p1 = new TilePosition (0, 0, 0);
//		TilePosition p2 = new TilePosition (0, 1, -1);
//		TilePosition p3 = new TilePosition (1, 0, -1);
//
//		GameObject o1 = Instantiate (water);
//		o1.transform.position = new Vector3 (p1.cartesian ().x, 0, p1.cartesian ().y);
//		GameObject o2 = Instantiate (water);
//		o2.transform.position = new Vector3 (p2.cartesian ().x, 0, p2.cartesian ().y);
//		GameObject o3 = Instantiate (water);
//		o3.transform.position = new Vector3 (p3.cartesian ().x, 0, p3.cartesian ().y);
//
		for (int i = 0; i < 20; i++) {
			for (int j = 0; j < 20; j++) {
				//(+, -, +-)
				TilePosition p = new TilePosition (x: i, y: -j);
				Vector2 cartesian = p.cartesian ();
				GameObject o = byHeight (p);//isLand(i, -j, j - i) ? Instantiate (ground) : Instantiate (water);
				o.transform.position = new Vector3 (cartesian.x, 0, cartesian.y);
				//(+-, +, -)
				TilePosition p2 = new TilePosition (y: i, z: -j);
				Vector2 cartesian2 = p2.cartesian ();
				GameObject o2 = byHeight (p2);//isLand(j - i, i, -j) ? Instantiate (ground) : Instantiate (water);
				o2.transform.position = new Vector3 (cartesian2.x, 0, cartesian2.y);
				//(-, +- +)
				TilePosition p3 = new TilePosition (x: -j, z: i);
				Vector2 cartesian3 = p3.cartesian ();
				GameObject o3 = byHeight (p3);//isLand(-j, j - i, i) ? Instantiate (ground) : Instantiate (water);
				o3.transform.position = new Vector3 (cartesian3.x, 0, cartesian3.y);
			}
		}
//		int size = 20;
//		for (int i = 0; i < size; i++) {
//			for (int j = 0; j < size - i; j++) {
//				TilePosition[] p = new TilePosition[6];
//				p [0] = new TilePosition (i, j, -i - j);
//				p [1] = new TilePosition (i, -i - j, j);
//				p [2] = new TilePosition (-i - j, i, j);
//				p [3] = new TilePosition (-i, -j, i + j);
//				p [4] = new TilePosition (-i, i + j, -j);
//				p [5] = new TilePosition (i + j, -i, -j);
//				for (int k = 0; k < 6; k++) {
//					Vector2 cartesian = p [k].cartesian ();
//					GameObject o = isLand (p [k]) ? Instantiate (ground) : Instantiate (water);
//					o.transform.position = new Vector3 (cartesian.x, 0, cartesian.y);
//				}
//			}
//		}
//
//		print(water.transform.lossyScale.x);
//
//		for (int i = 0; i < map.Length; i++) {
//			map [i] = new int[map_width];
//		}
//
//		print (map);
//
//		for (int i = 0; i < map.Length; i++) {
//			for (int j = 0; j < map [i].Length; i++) {
//				double d = Mathf.PerlinNoise (i, j);
//				if (d < 0.5) {
//					map [i][j] = 0;
//				} else {
//					map [i][j] = 1;
//				}
//			}
//		}
//
//		for (int i = 0; i < map.Length; i++) {
//			for (int j = 0; j < map [i].Length; i++) {
//				GameObject g = Instantiate (water);
//				Vector3 scale = new Vector3 (tile_width, 160, tile_width);
//				g.transform.localScale = scale;
//
//				g.transform.position = new Vector3 (tile_width, 0, tile_width);
//			}
//		}
//
	}

	public GameObject byHeight(TilePosition p) {
		float sum = 0.0f;
		for (int i = 0; i < 10; i++) {
			sum += weights [0, i] * (float) Math.Sin ((float) (p.GetX() - offsets[0, i]) / (i + 1));
			sum += weights [1, i] * (float) Math.Sin ((float) (p.GetY() - offsets[1, i]) / (i + 1));
			sum += weights [2, i] * (float) Math.Sin ((float) (p.GetZ() - offsets[2, i]) / (i + 1));
		}
		if (sum > 1.8 || sum < -1.8) {
			return Instantiate (tree);
		} else if (sum > 1.0 || sum < -1.0) {
			return Instantiate(ground);
		} else {
			return Instantiate(water);
		}
	}

	bool isLand(TilePosition p){
		return isLand ((int) p.GetX (), (int) p.GetY (), (int) p.GetZ ());
	}

	bool isLand(int x, int y, int z) {
		float sum = 0.0f;
		for (int i = 0; i < 10; i++) {
			sum += weights [0, i] * (float) Math.Sin ((float) (x - offsets[0, i]) / (i + 1));
			sum += weights [1, i] * (float) Math.Sin ((float) (y - offsets[1, i]) / (i + 1));
			sum += weights [2, i] * (float) Math.Sin ((float) (z - offsets[2, i]) / (i + 1));
		}
		print (sum);
		return sum > 1.0;
		//return Math.Sin ((float) x / 3) + Math.Sin ((float) y / 5) + Math.Sin ((float) z / 7) > 0.4;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
