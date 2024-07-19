using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField]
    GameManager gm;
    private TileLoader tl;

    void Start()
    {
        tl = GetComponent<TileLoader>();
    }

    void Update()
    {
        

    }
    

}
