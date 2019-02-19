using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public Player player;
    public Piece[] pieces;
    public TextMesh InfoText;

    public bool isGameOver = false;
    private float resetTimer = 3f;


    // Use this for initialization
    void Start()
    {
        //when player selects a piece, we call this method
        player.onSelectedPiece = () =>
        {
            OnPlayerSelected();
        };

        //make all of them disappear when the game starts
        foreach (Piece piece in pieces)
        {
            piece.CleanSelection();

        }

        PickRandomPiece();
    }

    // Update is called once per frame
    void Update() {
        if (isGameOver == true) {
            player.locked = true;

            resetTimer -= Time.deltaTime;
            if (resetTimer <= 0f) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        } else {
            InfoText.text = "Beat the computer!";
        }
    }

    //every time after the player picks a piece, the computer picks one
    void OnPlayerSelected(){
        CheckBoard();

        if (isGameOver == false) {
            PickRandomPiece();
            CheckBoard();
        }
    }


    void PickRandomPiece(){
        //detects how many empty spaces there are
        int availablePieces = 0;
        int tieCheck = 0;
        foreach (Piece piece in pieces) {
            if (piece.defined == false)
            {
                availablePieces++;
            }
        }
        //chooses random location for computer placement
        if (availablePieces > 0) {
            Piece randomPiece = pieces[Random.Range(0, pieces.Length)];
            while (randomPiece.defined == true)
            {
                randomPiece = pieces[Random.Range(0, pieces.Length)];
            }

            randomPiece.ComputerSelect();
        } 
        foreach (Piece piece in pieces) {
            if (piece.defined == true) {
                tieCheck++;
            }
        }
        if (tieCheck == 9 && isGameOver == false) {
            InfoText.text = "It's a tie!";
            isGameOver = true;

        }
    }

    void CheckBoard()
    {
        //horizontal check
        for (int y = 0; y < 3; y++) //checks different rows (by height)
        {
            Piece pieceCheck = null;
            int matches = 0;

            for (int x = 0; x < 3; x++) {
                Piece currentPiece = pieces[y * 3 + x];//checks the pieces in order

                if (pieceCheck == null)
                {
                    if (currentPiece.value != 0)
                    {
                        pieceCheck = currentPiece;
                        matches++; //variable matches checks if we have full horizontal match
                    }
                }
                else if (currentPiece.value == pieceCheck.value)
                {
                    matches++;
                }
            }

            if (matches == 3)
            {
                if (pieceCheck.value == 1)
                {
                    InfoText.text = "You win!";
                }
                else
                {
                    InfoText.text = "You lose!";
                }
                isGameOver = true;
                return;
            }
        }
        //vertical check
        for (int y = 0; y < 3; y++)
        {
            Piece pieceCheck = null;
            int matches = 0;

            for (int x = 0; x < 3; x++)
            {
                Piece currentPiece = pieces[x * 3 + y];//same as above, swapped x and y

                if (pieceCheck == null)
                {
                    if (currentPiece.value != 0)
                    {
                        pieceCheck = currentPiece;
                        matches++; 
                    }
                }
                else if (currentPiece.value == pieceCheck.value)
                {
                    matches++;
                }
            }

            if (matches == 3)
            {
                if (pieceCheck.value == 1)
                {
                    InfoText.text = "You win!";
                }
                else
                {
                    InfoText.text = "You lose!";
                }
                isGameOver = true;
                return;
            }
        }
    }
}
