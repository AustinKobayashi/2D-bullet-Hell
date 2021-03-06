﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WizardAttack : AbstractPlayerAttack {

    public GameObject bullet;

	// Use this for initialization
	void Start () {
		stats = GetComponent<PlayerWizardStatsTest> ();
		AttackCooldown = 1f / (1.5f + 6.5f * (stats.GetDexterity () / 75f));
	}

	public override void attack(Vector2 target) {
		if (!isLocalPlayer) return;
		CmdAttack(target, transform.position);
	}

	// Create a bullet and assign the appropriate fields
	[Command]
    void CmdAttack(Vector2 target, Vector2 position)
    {
		GameObject tempBullet = Instantiate(bullet, position, Quaternion.identity) as GameObject;
	    tempBullet.GetComponent<BasicAttackMovement>()
		    .SetDamage((int) (stats.GetWpnDamage() * (0.5f + stats.GetStrength() / 50f)));
	    tempBullet.GetComponent<BasicAttackMovement>().SetTarget(target);
	    tempBullet.GetComponent<BasicAttackMovement>().SetShooter(gameObject);
	    NetworkServer.Spawn(tempBullet);
    }
}
