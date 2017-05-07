using UnityEngine;
using System.Collections;

public class PlayerHand : MonoBehaviour {

	public Transform playerBody;

	private Vector3 offsetPos;
	private Vector3 newPos;

	private float followArea = 5.0f;

	void Start()
	{
		offsetPos = transform.position + playerBody.transform.position;
	}

	void Update()
	{
		float bodyPosX = Mathf.Abs(playerBody.transform.position.x);

		//上下左右方向のみ追いかけて,手前奥方向は追いかけない
		newPos.y = playerBody.transform.position.y + offsetPos.y;
		newPos.x = playerBody.transform.position.x + offsetPos.x;
		newPos.z = transform.position.z;

		if(bodyPosX < followArea){
			//playerBodyに少し遅れてついてくる
			transform.position = Vector3.Lerp(transform.position, newPos, 8.0f * Time.deltaTime);

		}else{
			//followArea外の場合、遅れず固定の位置へ移動
			transform.position = new Vector2(newPos.x,newPos.y);
		}


	}
}
