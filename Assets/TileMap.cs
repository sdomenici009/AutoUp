using UnityEngine;
using System.Collections;

public class TileMap : MonoBehaviour {
	
	public int width;
	public int height;
	private float camHalfHeight;
	private float camHalfWidth;
	private GameObject tileAnchorPrefab;
	
	float xPos;
	float zPos;
	
	void Start () {
		camHalfHeight = Camera.main.orthographicSize;
    	camHalfWidth = Camera.main.aspect * camHalfHeight; 
		tileAnchorPrefab = (GameObject)Resources.Load ("Prefabs/TileAnchorPlane");
		StartCoroutine(GenerateAnchors());
		Debug.Log ("HEYO");
	}
	
	IEnumerator GenerateAnchors()
	{
		for(int i=0; i < width; i++)
		{
			for(int j=0; j < height; j++)
			{
				xPos = this.transform.position.x - width/2f + i + .5f;
				zPos = this.transform.position.y + height/2f - j - .5f;
				GameObject tileAnchor = (GameObject)Instantiate(tileAnchorPrefab, new Vector3(xPos, this.transform.position.y, zPos), Quaternion.Euler(new Vector3(0, 0, 0)));
				tileAnchor.transform.parent = this.transform;
			}
			yield return null;
		}
	}
	
	void Update () {
	
	}
}
