using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	private int score = 0;

	public void AddSocre(int Points){
		score += Points;
		Debug.Log(score);
		return;
	}
}
