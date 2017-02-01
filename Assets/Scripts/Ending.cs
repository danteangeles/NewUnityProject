using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ending : MonoBehaviour {

	[SerializeField]
	Text win;

	private bool isBlinkWinRunning;

	// Use this for initialization
	void Start () {
		isBlinkWinRunning = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void FlashYouWin() {
		StartCoroutine(BlinkWin());
		isBlinkWinRunning = true;
	}

	public IEnumerator BlinkWin(){
		while(true){
			win.text = "";
			yield return new WaitForSeconds(0.3f);
			win.text = "YOU WIN!!!";
			yield return new WaitForSeconds(0.5f);
		}
	}

	public void FlashYouLose() {
		if (!isBlinkWinRunning){
			StartCoroutine(BlinkLose());
		}
	}

	public IEnumerator BlinkLose(){
		Debug.Log("before_loosing");
		while(true){
			Debug.Log("loosing");
			win.text = "";
			yield return new WaitForSeconds(0.3f);
			win.text = "You Lose!!!";
			yield return new WaitForSeconds(0.5f);
		}
	}
}
