using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class mapManagerScript : MonoBehaviour
{
    public int numGenerate=4;
    public GameObject[] possibleFabs;
    // Start is called before the first frame update
    void Start()
    {
        int fabSize = 20;
        int pos = fabSize;

        //Random.seed = (int)(Time.time*256);
        for(int i = 0; i < numGenerate; i++)
        {

            GameObject temp = Instantiate(possibleFabs[Random.Range(0, possibleFabs.Length)]);
            temp.transform.position = new Vector3(pos,0, 0);
            pos += fabSize;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
