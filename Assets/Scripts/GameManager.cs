using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject rootPrefab;
    [SerializeField] Camera mainCamera;

    public static GameObject root;

    [SerializeField] int maxHealth;
    private int health;


    void Start()
    {
        health = maxHealth;
		root = rootPrefab;

		InvokeRepeating("gameUpdate", 0, 1);
	}

    void Update()
    {
        
    }

    void gameUpdate()
    {
        Debug.Log("XD");
    }
}
