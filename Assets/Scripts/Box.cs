using UnityEngine;
using System.Collections;

public class Box : MonoBehaviour
{

	[SerializeField]
	GameObject boxes;

	[SerializeField]
	Rigidbody2D rb2d;

	int power;

	// Use this for initialization
	void Start()
	{
		power = 3;
		rb2d.GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		rb2d.transform.position = new Vector3(PingPong(Time.time * 3, -3, 3), rb2d.transform.position.y, rb2d.transform.position.z);
	}

	float PingPong(float t, float minLength, float maxLength)
	{
		return Mathf.PingPong(t, maxLength - minLength) + minLength;
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Bomb")
		{
			power--;

			var bomb = coll.gameObject.GetComponent<Bomb>();

			if (power == 0)
			{
				Destroy(this.gameObject);
				const int BonusPoint = 300;
				bomb.OnDestroyEnemy(BonusPoint);
			}
			else
			{
				const int point = 100;
				bomb.OnHitEnemy(point);
			}

			Destroy(coll.gameObject);
			Debug.Log("Monster Hit!");
		}

	}



}
