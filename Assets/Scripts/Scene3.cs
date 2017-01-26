using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene3 : MonoBehaviour {

	[SerializeField]
	Text counterText;

	[SerializeField]
	GameObject stamp;

	private int counter;

	Vector3 mousePosition, targetPosition;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		mousePosition = Input.mousePosition;

		targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 1f));

		stamp.transform.position = targetPosition;

		if (Input.GetMouseButtonDown(0))
		{
			Debug.Log("Pressed left click.");

			Instantiate(stamp,stamp.transform.position,stamp.transform.rotation);

			counter++;
			counterText.text = counter.ToString();

		}
		if (Input.GetMouseButtonDown(1))
		{
			Debug.Log("Pressed right click.");
		}

		if (Input.GetMouseButtonDown(2))
		{
			Debug.Log("Pressed middle click.");
		}
	}

	public void backToPreviousScene(){
		SceneManager.LoadScene("Scene2");
	}

}
