using UnityEngine;
using System.Collections;

public class GimmickGenerator : MonoBehaviour {

	private int[] gimmickPositionsX = new int[7]; //ギミックの配置は一列に7箇所
	private int   gimmickPositionY  = 7;
	private int   interval          = 5; //ギミックが生成される縦位置間隔

	public GameObject[] enemies;
	public GameObject   scoreItem;

	public GameObject playerOgj;

	void Awake () {

		//ギミックのX座標は-3〜3
		int gimmickPositionX = -3;

		for (int i = 0; i < 7; i++)
		{
			gimmickPositionsX[i] = gimmickPositionX;
			gimmickPositionX++;
		}
	}

	void Update(){
		//ギミックはゲーム内に5個まで
		if(transform.childCount < 5){
			GenerateGimmick(); 
		}
	}

	//アイテムの生成する位置をランダムで決定
	Vector2 DecisionPosition(){

		int randomIndex = Random.Range(0, gimmickPositionsX.Length);

		Vector2 randomPosition = new Vector2(gimmickPositionsX[randomIndex], gimmickPositionY);

		gimmickPositionY += interval;

		return randomPosition;
	}



	public void GenerateGimmick(){
		
		Vector2 gimmickPosition = DecisionPosition();

		if(Random.Range(0,4) == 0){
			GameObject enemy = Instantiate(enemies[0], gimmickPosition, Quaternion.identity) as GameObject;

			enemy.transform.parent = transform;
			enemy.name = "Enemy";
		}else{

			GameObject ScoreItem = Instantiate(scoreItem, gimmickPosition, Quaternion.identity) as GameObject;

			ScoreItem.transform.parent = transform;
			ScoreItem.name = "Item";

		}
	}

}
