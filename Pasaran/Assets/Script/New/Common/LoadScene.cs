using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//シーン切り替え
//共通で使いまわしたい
public class LoadScene : MonoBehaviour {

	public string sceneName = "";

	public void LoadInputedNameScene()
	{
		Resources.UnloadUnusedAssets();
		SceneManager.LoadScene(sceneName);
	}
}
