using UnityEngine;
using System.Collections;

//ギミックシーンの呼び出し回数を保持
public class Count{

	public readonly static Count Instance = new Count();

	public int loadCounter = 1;
}
