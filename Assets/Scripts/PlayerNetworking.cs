﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNetworking : MonoBehaviour {


	[SerializeField]private MonoBehaviour[] scriptsToIgnore;


	private PhotonView photonView;

	// Use this for initialization
	void Start () {
		photonView = GetComponent<PhotonView> ();
		Initialize ();
	}
	void Initialize(){
		if (photonView.isMine) {

		} else {
			foreach (MonoBehaviour item in scriptsToIgnore) {
				item.enabled=false;
			}
		}
	}
}
