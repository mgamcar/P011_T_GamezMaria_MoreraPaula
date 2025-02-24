using System;
using UnityEngine;

public class ButtonsTeleportControl : MonoBehaviour

{   
    [Header("Player")]
    [SerializeField] GameObject Player;

    [Header("CoordenadasTP1")]
    public int coord1X = 10;
    public int coord1Y = 1;

    [Header("CoordenadasTP2")]
    public int coord2X = 10;
    public int coord2Y = 1;

    [Header("CoordenadasTP3")]
    public int coord3X = 10;
    public int coord3Y = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToZone1(){
        Player.transform.position=new Vector2(coord1X,coord1Y);
    }

    public void GoToZone2(){
        Player.transform.position=new Vector2(coord2X,coord2Y);
    }

    public void GoToZone3(){
        Player.transform.position=new Vector2(coord3X,coord3Y);
    }
}
