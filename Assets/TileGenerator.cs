using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour {

	public GameObject water;
	public GameObject ground;

	int map_width = 100;
	int map_height = 100;

	int[][] map = new int[100][];

	int tile_width = 250;

	// Use this for initialization
	void Start () {
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
		for (int i = 0; i < 50; i++) {
			for (int j = 0; j < 50; j++) {
				TilePosition p = new TilePosition (i, j);
				Vector2 cartesian = p.cartesian ();
				GameObject o = true || isLand(i, j, -i - j) ? Instantiate (ground) : Instantiate (water);
				o.transform.position = new Vector3 (cartesian.x, 0, cartesian.y);
			}
		}
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

	bool isLand(int x, int y, int z) {
		return Math.Sin (x / 3) + Math.Sin (y / 5) + Math.Sin (z / 7) > 0.4;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
