using UnityEngine;
using System.Collections;

public class Life : MonoBehaviour
{
	private int life;

	public int SetLife(int Life){
		life = Life;
		return life;
	}

	public int GetLife(){
		return life;
	}

	public void ControllLife(int Damage){

		life -= Damage;

		if(life == 0){
			Debug.Log("Game Over");
		}

		return;
	}
}
