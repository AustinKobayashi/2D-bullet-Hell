﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public abstract class AbstractProjectileMovement : NetworkBehaviour {

    public float Speed;
    public float LifeSpan;
	public string TargetTag;
    private float _timer;
	private Rigidbody2D _rigid;
	public int Damage;
	public GameObject Player;

	// Update is called once per frame
	void Update () {

        _timer += Time.deltaTime;
        if (_timer >= LifeSpan)
            Destroy(this.gameObject);

	}

    public void SetTarget(Vector2 target)
    {
		_rigid = GetComponent<Rigidbody2D> ();
		_rigid.velocity = target.normalized * Speed;
    }


	void OnTriggerEnter2D(Collider2D coll) {
		if (!coll.CompareTag(TargetTag) || coll.isTrigger) return;
		hit(coll);
		Destroy (this.gameObject);
	}
	
	public void SetDamage(int damage) {
		this.Damage = damage;
	}

	public void SetShooter(GameObject player) {
		this.Player = player;
	}

	public virtual void hit(Collider2D coll)
	{
	}

}
