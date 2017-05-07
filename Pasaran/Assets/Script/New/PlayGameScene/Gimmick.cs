using UnityEngine;
using System.Collections;

public class Gimmick : MonoBehaviour {

	private bool _isRendered = false;

	void Update(){

		if(_isRendered){
			DestroyGimmick();
		}
	}

	void OnWillRenderObject(){

		_isRendered = true;
	}

	void DestroyGimmick(){

		if (!GetComponent<Renderer>().isVisible)
		{
			Destroy(this.gameObject);
		}
	}
}
