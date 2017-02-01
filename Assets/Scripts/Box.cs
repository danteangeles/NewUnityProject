using UnityEngine;
using System.Collections;

public class Box : MonoBehaviour {

	[SerializeField]
	GameObject boxes;

	[SerializeField]
	Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		//this.GetComponent().velocity = Vector2();
		rb2d.GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {
		rb2d.transform.position = new Vector3(PingPong(Time.time*3,-3,3),rb2d.transform.position.y, rb2d.transform.position.z);
	}

	float PingPong(float t, float minLength, float maxLength)
	{
		return Mathf.PingPong(t, maxLength - minLength) + minLength;
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Bomb")
		{
			//coll.gameObject.GetComponent<Bomb>().AddScore();
			coll.gameObject.GetComponent<Bomb>().OnHitEnemy(100);
			Destroy(coll.gameObject);
			Destroy(this.gameObject);
			Debug.Log("Monster Hit!");
		}

	}



}
