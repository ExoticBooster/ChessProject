using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Rendering;

public class BoardManager : MonoBehaviour
{
    public GameObject pawn;
    private float boardWidth, fieldWidth;
    private GameObject playingField;
    private Dictionary<String, field> fieldDict;
    private int colCount = 8;
    // Start is called before the first frame update
    void Start()
    {
        playingField = this.transform.GetChild(1).gameObject;
        boardWidth = playingField.GetComponent<BoxCollider>().size.x;
        fieldWidth = boardWidth / 8;
        fieldDict = new Dictionary<string, field>();

        //for (int i = 0; i < 8; i++)
        //{
        //    GameObject created = Instantiate(pawn, playingField.transform);
        //    created.transform.localPosition = new Vector3(0 + (fieldWidth * -i ), 0, -fieldWidth);
        //}
        initializeBoard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void initializeBoard()
    {
        Vector3 startPosition = playingField.transform.position;
        for (int i = 0; i < colCount; i++)
        {
            for (int j = 0; j < colCount; j++)
            {
                String currentCode = "";
                currentCode += i.ToString();
                currentCode += (char)(65+j);

                Vector3 currentPosition = new Vector3(startPosition.x + (fieldWidth * -j), startPosition.y, startPosition.z);
                fieldDict[currentCode] = new field(currentPosition, currentCode);
                if(i == 1)
                {
                    fieldDict[currentCode].addFigure(Figure.Pawn, team.white, pawn);
                }
                else if(i == 6)
                {
                    fieldDict[currentCode].addFigure(Figure.Pawn, team.black, pawn);
                }
            }
            startPosition.z -= fieldWidth;
        }
    }
    private class field
    {
        private Vector3 position;
        private String code;
        private team teamColor;
        private Figure figure;
        private GameObject obj = null;

        public field(Vector3 position, String code) {
            this.position = position;
            this.code = code;
        }

        public void addFigure(Figure figure, team teamColor, GameObject obj){
            this.figure = figure;
            this.teamColor = teamColor;
            obj = GameObject.Instantiate(obj, position, obj.transform.rotation);

            if(teamColor == team.black){
                obj.GetComponent<MeshRenderer>().material.SetColor("_Color", UnityEngine.Color.black);
                obj.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", UnityEngine.Color.black);
            }
        }
    }

    private enum team
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
