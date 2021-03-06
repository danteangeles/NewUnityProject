using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Scene1 : MonoBehaviour {

	[SerializeField]
	Button myButtonA, myButtonB;

	[SerializeField]
	Text myTextCounter;

	[SerializeField]
	GameObject buttonPrefab;

	private int counter, interval;

	// Use this for initialization
	void Start () {
		counter = 0;
		interval = 1;

		if (myButtonB)
		{
			myButtonB.gameObject.SetActive(false);
		}

		buttonPrefab = Resources.Load<GameObject>("Prefabs/ButtonC");
		Debug.Log("done");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TaskOnClick(){
		Debug.Log ("You have clicked the button!");
		counter = counter + interval;
		myTextCounter.text = counter.ToString(); 

		if (counter == 10)
		{
			myButtonB.gameObject.SetActive(true);
		} else if (counter == 15){
			var newButton = Instantiate(buttonPrefab) as GameObject;
			newButton.transform.SetParent(GameObject.FindWithTag("Canvas").transform, false);
		}
					
	}

	public void ChangeButtonColorToBlue(){
		Debug.Log ("Button C clicked!");
		GameObject.Find("Canvas").transform.FindChild("ButtonB").GetComponent<Button>().image.color = Color.blue;
	}

	public void ChangeButtonAsColorToRed(){
		//transform.parent.FindChild("ButtonA").GetComponent<Button>().image.color = Color.red;
		GameObject.Find("Canvas").transform.FindChild("ButtonA").GetComponent<Button>().image.color = Color.red;
	}
		
	public void loadSceneTwo(){
		SceneManager.LoadScene("Scene2");
	}

}
