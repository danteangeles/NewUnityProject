using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Scene2 : MonoBehaviour {

	[SerializeField]
	Text myCounter, buttonA_Text, buttonB_Text, buttonC_Text, buttonGo_Text;

	[SerializeField]
	Button buttonA, buttonB, buttonC, buttonGo;

	private int counterTotal, counterA, counterB, counterC, interval;

	// Use this for initialization
	void Start () {
		counterTotal = 0;
		counterA = 0;
		counterB = 0;
		counterC = 0;
		interval = 1;
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void OnClick_Button(Button button){
		Debug.Log ("You have clicked the button!");

		if (button.tag == "ButtonA"){
			counterA = counterA + interval;
			buttonA_Text.text = counterA.ToString();
			if (counterA >= 3)
			{
				buttonA.GetComponent<Button>().interactable = false;
			}
		}


		if (button.tag == "ButtonB"){
			counterB = counterB + interval;
			buttonB_Text.text = counterB.ToString();
			if (counterB >= 4)
			{
				buttonB.GetComponent<Button>().interactable = false;
			}
		}

		if (button.tag == "ButtonC"){
			counterC = counterC + interval;
			buttonC_Text.text = counterC.ToString(); 
			if (counterC >= 2)
			{
				buttonC.GetComponent<Button>().interactable = false;
			}
		}

		counterTotal = counterA + counterB + counterC;
		myCounter.text = counterTotal.ToString();

	}

	public void OnLCick_Go(){
		if (counterTotal >= 9)
		{
			SceneManager.LoadScene("Scene3");
		}
		else
		{
			SceneManager.LoadScene("Scene1");
		}

	}


}
