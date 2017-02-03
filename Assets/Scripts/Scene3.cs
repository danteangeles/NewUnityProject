using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene3 : MonoBehaviour
{

	enum GameStatus
	{
		Title,
		Playing,
		Result
	}

	GameStatus currentGameStatus = GameStatus.Title;

	[SerializeField]
	Text counterText, scoreNum;

	[SerializeField]
	GameObject bombs, ground, box;

	private int counter, score;

	Ending ending;

	//NOTE:use abridgement name is no good. And DestroyBomb not need here because it is already attached at ground.
	//DestroyBomb db;

	Vector3 mousePosition, targetPosition;

	// Use this for initialization
	void Start()
	{
		counter = 10;
		counterText.text = counter.ToString();

		score = 0;
		scoreNum.text = score.ToString();

		instantiateBox();

		ending = Camera.main.GetComponent<Ending>();
		ending.FlashStartMassage();
	}
	
	// Update is called once per frame
	void Update()
	{
		switch (currentGameStatus)
		{
			case GameStatus.Title:
				if (Input.GetMouseButtonDown(0))
				{
					ending.StopBlink();
					currentGameStatus = GameStatus.Playing;
				}
				break;
			case GameStatus.Playing:
				if (Input.GetMouseButtonDown(0) && counter > 0)
				{
					Debug.Log("Pressed left click.");

					counter--;
					counterText.text = counter.ToString();

					var bomb = Instantiate(bombs, bombs.transform.position, bombs.transform.rotation) as GameObject;
					mousePosition = Input.mousePosition;
					targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 1f));
					bomb.transform.position = targetPosition;

					var bombComponent = bomb.GetComponent<Bomb>();
					bombComponent.OnHit = (point) =>
					{
						score += point;
						scoreNum.text = string.Format("{0}", score);
					};

					bombComponent.OnDestroy = (point) =>
					{
						score += point;
						scoreNum.text = string.Format("{0}", point);
						ending.gameObject.GetComponent<Ending>().FlashYouWin();
						currentGameStatus = GameStatus.Result;
						Debug.Log("Game Clear");
					};


					if (counter == 0)
					{
						bombComponent.OnFallDownGround = () =>
						{
							if (counter == 0)
							{
								ending.gameObject.GetComponent<Ending>().FlashYouLose();
								currentGameStatus = GameStatus.Result;
								Debug.Log("Game Lose");
							}
						};	
					}
				}
				if (Input.GetMouseButtonDown(1))
				{
					Debug.Log("Pressed right click.");
				}

				if (Input.GetMouseButtonDown(2))
				{
					Debug.Log("Pressed middle click.");
				}
				
				break;
			case GameStatus.Result:
				if (Input.GetMouseButtonDown(0))
				{
					SceneManager.LoadScene("Scene3");
				}
				break;
		}
	}

	public void backToPreviousScene()
	{
		SceneManager.LoadScene("Scene2");
	}

	private void instantiateBox()
	{
		Vector3 position = new Vector3(Random.Range(-2.5f, 2.5f), -4.2f, 1f);
		Instantiate(box, position, box.transform.rotation);
	}



}
