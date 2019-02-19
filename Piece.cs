using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour {

    public GameObject pieceX;
    public GameObject pieceO;

    public bool defined;
    public int value = 0;

    // Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //makes board empty in beginning
    public void CleanSelection (){
        defined = false;
        value = 0;
        pieceX.SetActive(false);
        pieceO.SetActive(false);
    }

    //makes X appear
    public void PlayerSelect () {
        defined = true;
        value = 1;
        pieceX.SetActive(true);
    }
    //computer selects PieceO position
    public void ComputerSelect () {
        defined = true;
        value = 2;
        pieceO.SetActive(true);
    }
}
