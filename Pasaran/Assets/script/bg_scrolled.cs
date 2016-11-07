using UnityEngine;
using System.Collections;

public class bg_scrolled : MonoBehaviour {

	public Transform player;
	private Renderer rend;

	// Use this for initialization
	void Start () {

		rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {

		rend.material.mainTextureOffset = new Vector2(0, player.transform.position.y * 0.02f);
	}
}
