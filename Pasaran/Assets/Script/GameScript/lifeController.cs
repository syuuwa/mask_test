using UnityEngine;
using System.Collections;

public class lifeController : MonoBehaviour {

	private RectTransform rt;

	// Use this for initialization
	void Start () {
		rt = GetComponent<RectTransform>();
	}

	public void LifeDown (int onelife) {
		//RectTransFormのサイズを取得して、ライフ１つ分減らす
		rt.sizeDelta -= new Vector2(onelife,0);
	}

}
