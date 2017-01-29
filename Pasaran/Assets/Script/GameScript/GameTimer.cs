using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour {

	private float time = 60;
	private Text timer;
	private Text gameEndText;
	public GameObject gameEnd;
	public GameObject life;
	private RectTransform rt;
	private bool isRunning = false;

	// Use this for initialization
	void Start () {
		gameEndText = gameEnd.GetComponent<Text>();
		rt = life.GetComponent<RectTransform>();
		//初期値を表示
		//int型にキャストからString型に変換
		timer = this.GetComponent<Text>(); 
		timer.text = ((int)time).ToString();
		//finishのテキストを非表示にする
		gameEnd.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
		time -= Time.deltaTime;
		timer.text = ((int)time).ToString();

		if (time < 0.9f){
			time = 0;
			timer.text = ((int)time).ToString();

			StartCoroutine("Finish", "Finish!!");
		}else if(rt.sizeDelta.x < 0){

			StartCoroutine("Finish", "GameOver!");
		}
	}

	IEnumerator Finish (string GameEndText){
		//一度だけリザルトダイアログをロードする
		if (isRunning)
		{
			yield break;
		}
		isRunning = true;
		gameEndText.text = GameEndText;
		gameEnd.SetActive(true);
		yield return new WaitForSeconds(2.0f);
		SceneManager.LoadScene("ResultDialog", LoadSceneMode.Additive); 
	}
}
