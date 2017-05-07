using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

	private int smallPoints = 1;

	private bool _isRendered = false;
	private bool _isFirstRendered = false;

	private GameObject playerObj;
	private Player player;

	private SpriteRenderer spriteRend;

	public Sprite[] scoreItemSprite;
	public Sprite[] collectionItemSprite;

	public int GetPoints(){
		return smallPoints;
	}

	void Awake(){
		playerObj = GameObject.FindGameObjectWithTag("player");
		player = playerObj.GetComponent<Player>();
		spriteRend = GetComponent<SpriteRenderer>();
	}

	void Update()
	{
		//Debug.Log("取得回数" + player.GetContinueCollectedItemNum());
		if (_isFirstRendered)
		{
			if(player.GetCollectedItemsNum() == 20){

				RandamGenerateCollectionItem();

			}else if(player.GetContinueCollectedItemNum() >= 10 && player.GetCollectedItemsNum() != 20){
				spriteRend.sprite = scoreItemSprite[1];
				gameObject.tag = "bigItem";
			}else{
				spriteRend.sprite = scoreItemSprite[0];
				gameObject.tag = "smallItem";
			}

			_isFirstRendered = false;
		}
	}

	void RandamGenerateCollectionItem()
	{
		int randomIndex = Random.Range(0, collectionItemSprite.Length);

		spriteRend.sprite = collectionItemSprite[randomIndex];
		gameObject.tag = "collectionItem";

		return;
	}

	void OnWillRenderObject()
	{
		if(_isRendered){
			return;	
		}

		_isFirstRendered = true;
		_isRendered      = true;
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "player")
		{
			Destroy(this.gameObject);
		}
	}
}
