using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene3 : MonoBehaviour {

	[SerializeField]
	Text counterText, scoreNum;

	[SerializeField]
	GameObject bombs, ground, box;

	private int counter, score;

	public bool isBoxPresent;

	Ending ending;

	Vector3 mousePosition, targetPosition;

	// Use this for initialization
	void Start () {
		//Instantiate(ground, new Vector3(0, -4.2f, 1) , ground.transform.rotation);
		counter = 10;
		counterText.text = counter.ToString();

		score = 0;
		scoreNum.text = score.ToString();

		instantiateBox();

		ending = Camera.main.GetComponent<Ending>();
	}
	
	// Update is called once per frame
	void Update () {

		if (!isBoxPresent){
			instantiateBox();
		}

		mousePosition = Input.mousePosition;

		targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 1f));

		bombs.transform.position = targetPosition;

		if (counter >= 1)
		{
			if (Input.GetMouseButtonDown(0))
			{
				Debug.Log("Pressed left click.");

				counter--;
				counterText.text = counter.ToString();
				var bomb = Instantiate(bombs, bombs.transform.position, bombs.transform.rotation) as GameObject;
				var bombComponent = bomb.GetComponent<Bomb>();
				bombComponent.OnHit = (point) =>
				{
					score += point;
					scoreNum.text = string.Format("{0}", score);
					if (score < 300)
					{
						isBoxPresent = false;
					}
					else
					{
						// call FlashWinner
						ending.gameObject.GetComponent<Ending>().FlashYouWin();
					}

				};

				bombComponent.OnDestroy = (point) =>
				{
					score += point;
					scoreNum.text = string.Format("{0}", point);

					Debug.Log("Game Clear");
				};

				bombComponent.OnHitBombEvent += (point) =>
				{
					score += point;
					scoreNum.text = string.Format("{0}", point);

					Debug.Log("Game Clear");
				};
						
			


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
		else
		{
			ending.gameObject.GetComponent<Ending>().FlashYouLose();
		}
			
	}

	public void backToPreviousScene(){
		SceneManager.LoadScene("Scene2");
	}

	private void instantiateBox(){
		Vector3 position = new Vector3(Random.Range(-2.5f,2.5f), -4.2f, 1f);
		Instantiate(box,position,box.transform.rotation);
		isBoxPresent = true;
	}



}
