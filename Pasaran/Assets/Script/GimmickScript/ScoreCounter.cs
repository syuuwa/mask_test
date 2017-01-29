using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreCounter : MonoBehaviour
{
	public GameObject scoreObj;
	private Text scoreText;
	public int score = 0;

	public int pointSmall = 10;
	public int pointBig = 50;

	// Use this for initialization
	void Start()
	{
		scoreText = scoreObj.GetComponent<Text>();
		scoreText.text = score.ToString();
	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnCollisionEnter(Collision col)
	{
		//enemyに当たったらLifeDownを実行
		if (col.gameObject.tag == "smallStar")
		{
			score += pointSmall;
			scoreText.text = score.ToString();
		}else if(col.gameObject.tag == "bigStar"){
			score += pointBig;
			scoreText.text = score.ToString();
		}
	}
}
