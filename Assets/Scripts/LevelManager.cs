using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public int mark;
    public int score;
    public int globalSlots;
    public Text scoreText;
    public GameObject blockWithSlots;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        blockWithSlots = GameObject.FindGameObjectWithTag("Block");
        globalSlots += blockWithSlots.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = ( score / (globalSlots / 3) ).ToString();
    }
}
