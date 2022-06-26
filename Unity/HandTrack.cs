using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTrack : MonoBehaviour
{
    // Start is called before the first frame update
    public UDPReceive udpReceive;
    public GameObject[] handPoints;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string data = udpReceive.data;

        data = data.Replace('[', ' ');
        data = data.Replace(']', ' ');

        string[] points = data.Split(',');

        //x1 y1 z1 x2 y2 z2
        for (int i = 0; i < 21; i++)
        {
            float x = float.Parse(points[i * 3])/100;
            float y = float.Parse(points[i * 3 + 1]) / 100;
            float z = float.Parse(points[i * 3 + 2]) / 100;

            handPoints[i].transform.localPosition = new Vector3(x, y, z);
            float scale = 0.2F;
            handPoints[i].transform.localScale = new Vector3(scale, scale, scale);
        }
    }
}
