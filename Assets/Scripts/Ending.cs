using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{

	[SerializeField]
	Text win;

	IEnumerator blinkEnumerator;

	// Use this for initialization
	void Start()
	{
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}

	public void FlashStartMassage()
	{
		blinkEnumerator = BlinkTitleText("TAP TO START!!!"); 
		StartCoroutine(blinkEnumerator);
	}

	public void StopBlink()
	{
		if (blinkEnumerator != null)
		{
			StopCoroutine(blinkEnumerator);
			win.text = "";
		}
	}

	public void FlashYouWin()
	{
		StartCoroutine(BlinkTitleText("YOU WIN!!!"));
	}

	public void FlashYouLose()
	{
		StartCoroutine(BlinkTitleText("You Lose!!!"));
	}

	IEnumerator BlinkTitleText(string title)
	{
		while (true)
		{
			win.text = "";
			yield return new WaitForSeconds(0.3f);
			win.text = title;
			yield return new WaitForSeconds(0.5f);
		}
	}
}
