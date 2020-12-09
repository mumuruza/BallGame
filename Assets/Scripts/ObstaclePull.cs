using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class ObstaclePull : MonoBehaviour
{
    public static ObstaclePull Instance { get => instance; }
    private static ObstaclePull instance;

    [SerializeField]
    private List<Obstacle> obstacleTypes;

    [SerializeField]
    private int pullSize; 

    private List<Obstacle> pull;

    private int index; 

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }

        index = 0;

        pull = new List<Obstacle>(); 
        for(var i=0; i<pullSize*obstacleTypes.Count; i++)
        {
            foreach (var o in obstacleTypes)
            {
                Obstacle tmp = Instantiate(o);
                tmp.gameObject.SetActive(false);
                pull.Add(tmp);
            }
            
        }

        pull.Shuffle();
    }

    public Obstacle GetNext ()
    {
        index = (index + 1) % pull.Count;
        return pull[index]; 
    }
}
