using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class BoardManager : MonoBehaviour
{
    [SerializeField]
    public GameObject pawn, startPosition, playingField;
    private float boardWidth, fieldWidth;
    private Dictionary<String, Field> fieldDict;
    private int colCount = 8;


    void Start()
    {
        boardWidth = playingField.GetComponent<BoxCollider>().size.x;
        fieldWidth = boardWidth / 8;
        fieldDict = new Dictionary<string, Field>();
        initializeBoard();
    }
    
    public void initializeBoard()
    {
        Vector3 startPos = startPosition.transform.position;
        // für alle Buchstaben
        for (int i = 0; i <= colCount; i++)
        {
            // 
            for (int j = 1; j <= colCount; j++)
            {
                String currentCode = "";
                currentCode += (char)(65+i);
                currentCode += i.ToString();

                Vector3 currentPosition = new Vector3(startPos.x + (fieldWidth * +(j-1)), startPos.y, startPos.z);
                fieldDict[currentCode] = new Field(currentPosition, currentCode);
                if (i == 1)
                {
                    fieldDict[currentCode].initializeFigure(new Pawn(FColor.white));
                }
                else if (i == 6)
                {
                    fieldDict[currentCode].initializeFigure(new Pawn(FColor.black));
                }
            }
            startPos.z += fieldWidth;
        }
    }

    private class Field
    {
        private Vector3 worldPosition;
        private String code;
        private Figure figure = null;

        public Field(Vector3 position, String code) {
            this.worldPosition = position;
            this.code = code;
        }

        public void initializeFigure(Figure figure)
        {
            this.figure = figure;
            figure.getGameObject().transform.position = worldPosition;
        }
    }
}
