using UnityEngine;
using System.Collections;

//カメラはプレイヤーを少し遅れて追従する
public class Camera : MonoBehaviour {

	public Transform followedObj;

	private Vector3 offsetPos;
	private Vector3 newPos;

	void Start()
	{
		offsetPos = transform.position + followedObj.transform.position;
	}

	//上方向のみ追いかけて、左右下手前奥方向は追いかけない
	void Update()
	{
		newPos.y = followedObj.transform.position.y - offsetPos.y;
		newPos.x = transform.position.x;
		newPos.z = transform.position.z;

		if (newPos.y > transform.position.y)
		{
			transform.position = Vector3.Lerp(transform.position, newPos, 0.8f * Time.deltaTime);
		}
	}
}
