using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class BoardManager : MonoBehaviour
{
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
        Vector3 startPosition = playingField.transform.position;
        // für alle Buchstaben
        for (int i = 0; i <= colCount; i++)
        {
            // 
            for (int j = 1; j <= colCount; j++)
            {
                String currentCode = "";
                currentCode += (char)(65+i);
                currentCode += i.ToString();

                Vector3 currentPosition = new Vector3(startPosition.x + (fieldWidth * -(j-1)), startPosition.y, startPosition.z);
                fieldDict[currentCode] = new Field(currentPosition, currentCode);
                if(i == 1)
                {
                    fieldDict[currentCode].addFigure(Figure.Pawn, Team.white, pawn);
                }
                else if(i == 6)
                {
                    fieldDict[currentCode].addFigure(Figure.Pawn, Team.black, pawn);
                }
            }
            startPosition.z -= fieldWidth;
        }
    }

    public void intitializePieces(){

        for (int i = 1; i < colCount; i++)
        {

        }
    }
    private class Field
    {
        private Vector3 position;
        private String code;
        private Team teamColor; 
        private Figure figure;
        private GameObject obj = null;

        public Field(Vector3 position, String code) {
            this.position = position;
            this.code = code;
        }

        public void addFigure(Figure figure, Team teamColor, GameObject obj){
            this.figure = figure;
            this.teamColor = teamColor;
            obj = GameObject.Instantiate(obj, position, obj.transform.rotation);

            if(teamColor == Team.black){
                obj.GetComponent<MeshRenderer>().material.SetColor("_Color", new UnityEngine.Color(0.2f,0.2f,0.2f));
                obj.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", new UnityEngine.Color(0.2f, 0.2f, 0.2f));
            }
        }
    }

    private enum Team
    {
        white,
        black
    }

    private enum Figure
    {
        Pawn,
        Tower,
        Knight,
        Bishop,
        Queen,
        King
    }

}
