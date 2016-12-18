using UnityEngine;
using System.Collections;

//ロードしたギミックシーンのポジションをセット
public class OffsetPosition : MonoBehaviour {

	public float gimmickInterval;
	int multipleNum;
	Vector3 pos;

	void Awake () {
		//ゲーム開始からギミックシーンをロードした回数を取得
		multipleNum = Count.Instance.loadCounter;
		//ギミック同士の間隔に呼び出し回数おかける
		pos.y = gimmickInterval * multipleNum;
		//ポジションをセット
		transform.position = pos;

		//呼び出し回数を加算
		Count.Instance.loadCounter += 1;
	}
}
