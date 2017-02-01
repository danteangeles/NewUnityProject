using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using UnityEngine.Events;

public class Bomb : MonoBehaviour {
	SpriteRenderer bombSprite;

	[SerializeField]
	List<Sprite> explodeAnimationList;

	delegate int scoreVal(int i); 
	scoreVal myDelegate = hit => hit * 100;

	public delegate void OnHitBombListner(int point);
	OnHitBombListner onHit;
	public OnHitBombListner OnHit{ set { onHit = value; } }
	public event OnHitBombListner OnHitBombEvent;
	OnHitBombListner onDestroy;
	public OnHitBombListner OnDestroy{ set{ onDestroy = value;}}

	public UnityEvent MyUnityEvent;

	// Use this for initialization
	void Start () {
		bombSprite = transform.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void StopMoving(){
		GetComponent<Collider2D>().enabled = false;
		//GetComponent<Rigidbody2D>().
	}

	public void StartExplodeAnimation(){
		StopMoving();
		var coroutine = StartCoroutine(ExplodeAnimation());
		//StopCoroutine(coroutine);
	}

	IEnumerator ExplodeAnimation(){
		foreach (var sprite in explodeAnimationList)
		{
			bombSprite.sprite = sprite;
			yield return new WaitForSeconds(0.1f);
		}
		Destroy(gameObject);
	}

	public void AddScore()
	{
		int sc = myDelegate(1);
		Debug.Log("score: "+sc);
	}

	public void OnHitEnemy(int point){
		if (onHit != null)
		{
			onHit(point);
		}
	}
}