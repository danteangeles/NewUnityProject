using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DestroyBomb : MonoBehaviour {

	public bool isTouchedGround;

	// Use this for initialization
	void Start () {
		isTouchedGround = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Bomb")
		{
			coll.gameObject.GetComponent<Bomb>().StartExplodeAnimation();
			Debug.Log("Touched ground!");
			isTouchedGround = true;
		}

	}
}
