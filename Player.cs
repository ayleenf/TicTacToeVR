using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour {

    public Action onSelectedPiece;

    public bool locked = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //replace input with GvrViewer.Instance.Triggered for VR
        if (Input.GetKeyDown("space")) {
            RaycastHit hit;
            //places piece based on raycast
            if (Physics.Raycast(transform.position, transform.forward, out hit)) {
                if (hit.transform.GetComponent<Piece>() != null) {
                    Piece piece = hit.transform.GetComponent<Piece>();

                    if (locked == false && piece.defined == false)  {
                        piece.PlayerSelect();
                        onSelectedPiece();
                        //see Piece code

                    }
                }
            }
        }
	}
}
