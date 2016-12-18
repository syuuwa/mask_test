using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GimmickLoader : MonoBehaviour {

	private float loadInterval = 14;
	private float loadPos = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//ギミックシーンを呼び出して、loadPosを更新する
		if(transform.position.y > loadPos){
			SceneManager.LoadScene("GimmickB", LoadSceneMode.Additive);
			loadPos += loadInterval;
		}
	}
}
