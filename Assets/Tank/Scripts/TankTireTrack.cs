using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankTireTrack : MonoBehaviour
{
    public GameObject tireTrackPreFab;
    public GameObject track1;
    public GameObject track2;
    [Range(0f, 30f)] [SerializeField] float drawGap = 6.8f;
    [Range(0f, 3f)] [SerializeField] float destroyGap = 0.85f;

    float val = 0;

    private void FixedUpdate()
    {
        Debug.Log(val);

        if (val > drawGap)
        {

            drawTrack();
            val = 0;
        }
        val++;
    }
    private void drawTrack()
    {
        Destroy(Instantiate(tireTrackPreFab, new Vector2(track1.transform.position.x,track1.transform.position.y), transform.rotation), destroyGap);
        Destroy(Instantiate(tireTrackPreFab, new Vector2(track2.transform.position.x,track2.transform.position.y), transform.rotation), destroyGap);
    }
}
