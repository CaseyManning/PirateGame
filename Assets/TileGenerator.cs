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

		for (int i = 0; i < map.Length; i++) {
			map [i] = new int[map_width];
		}

		print (map);

		for (int i = 0; i < map.Length; i++) {
			for (int j = 0; j < map [i].Length; i++) {
				double d = Mathf.PerlinNoise (i, j);
				if (d < 0.5) {
					map [i][j] = 0;
				} else {
					map [i][j] = 1;
				}
			}
		}

		for (int i = 0; i < map.Length; i++) {
			for (int j = 0; j < map [i].Length; i++) {
				GameObject g = Instantiate (water);
				Vector3 scale = new Vector3 (tile_width, 160, tile_width);
				g.transform.localScale = scale;

				g.transform.position = new Vector3 (tile_width, 0, tile_width);
			}
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
