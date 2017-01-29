using UnityEngine;
using System.Collections;

public class GimmickLoader : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject gimmick = (GameObject)Resources.Load("Prefab/GimmicksA");
		Instantiate(gimmick);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
