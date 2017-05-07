using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	//プレイヤーの行動可能な幅範囲を設定
	private float maxLeftActionWidthRange  = -5.2f; 
	private float maxRightActionWidthRange =  5.2f;

	private int playerLife = 3;
	private Life life;

	private int collectedItemsNum = 0;
	private int continueCollectedItemNum = 0;

	public GameObject scoreManager;

	//アイテムの総取得回数を返す
	public int GetCollectedItemsNum(){
		return collectedItemsNum;
	}

	//アイテムの連続取得回数を返す
	public int GetContinueCollectedItemNum(){
		return continueCollectedItemNum;
	}

	// Use this for initialization
	void Start () {
		//プレイヤーのライフを設定
		life = GetComponent<Life>();
		life.SetLife(playerLife);
	}
	
	// Update is called once per frame
	void Update () {

		float posX = transform.position.x;

		//プレイヤーが画面左端を超えたら右端に移動、右端を超えたら左端に移動
		if(posX >= maxRightActionWidthRange){
			
			transform.position = new Vector2(maxLeftActionWidthRange,transform.position.y);

		}else if(posX <= maxLeftActionWidthRange){

			transform.position = new Vector2(maxRightActionWidthRange,transform.position.y);

		}
	}

	void OnCollisionEnter2D(Collision2D collision){
		//ダメージ判定
		if (collision.gameObject.tag == "enemy")
		{
			int damege = collision.gameObject.GetComponent<Enemy>().GetDamage();
			life.ControllLife(damege);
			//アイテム連続取得回数を初期化
			continueCollectedItemNum = 0;
		}
	}

	void OnTriggerEnter2D(Collider2D collision){
		//スコア加算
		if (collision.gameObject.tag == "smallItem" || collision.gameObject.tag == "bigItem")
		{
			int points = collision.gameObject.GetComponent<Item>().GetPoints();
			scoreManager.GetComponent<Score>().AddSocre(points);
			//アイテム連続取得回数を加算
			continueCollectedItemNum++;
			//アイテム取得総回数を加算
			collectedItemsNum++;
			Debug.Log(collectedItemsNum);
		}
	}

}
