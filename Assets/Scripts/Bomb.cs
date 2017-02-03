using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using UnityEngine.Events;

public class Bomb : MonoBehaviour
{
	SpriteRenderer bombSprite;

	[SerializeField]
	List<Sprite> explodeAnimationList;

	delegate int scoreVal(int i);

	scoreVal myDelegate = hit => hit * 100;

	public delegate void OnHitBombListner(int point);

	OnHitBombListner onHit;

	public OnHitBombListner OnHit{ set { onHit = value; } }
	//public event OnHitBombListner OnHitBombEvent;

	OnHitBombListner onDestroy;

	public OnHitBombListner OnDestroy{ set { onDestroy = value; } }

	UnityAction onFallDownGround;

	public UnityAction OnFallDownGround{ set { onFallDownGround = value; } }

	//public UnityEvent MyUnityEvent;

	// Use this for initialization
	void Start()
	{
		bombSprite = transform.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update()
	{
	
	}

	void StopMoving()
	{
		GetComponent<Collider2D>().enabled = false;
	}

	public void StartExplodeAnimation()
	{
		StopMoving();
		var coroutine = StartCoroutine(ExplodeAnimation());
		if (onFallDownGround != null)
		{
			onFallDownGround();	
		}
	}

	IEnumerator ExplodeAnimation()
	{
		foreach (var sprite in explodeAnimationList)
		{
			bombSprite.sprite = sprite;
			yield return new WaitForSeconds(0.1f);
		}
		Destroy(gameObject);
	}

	public void OnHitEnemy(int point)
	{
		if (onHit != null)
		{
			onHit(point);
		}
	}

	public void OnDestroyEnemy(int point)
	{
		if (onDestroy != null)
		{
			onDestroy(point);
		}
	}
}