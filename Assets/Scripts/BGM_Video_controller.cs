using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class BGM_VIDEO_controller : MonoBehaviour
{
    [SerializeField]
    AudioSource bgm_source;
    [SerializeField]
    VideoPlayer videoPlayer;
    [SerializeField]
    float timeForVideo;
    float elapsedTime = 0;
    [SerializeField]
    Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.loopPointReached += LoopPointReached;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= timeForVideo)
        {
            StartOPMovie();
        }
    }

    void StartOPMovie()
    {
        canvas.enabled = false;
        bgm_source.Stop();
        videoPlayer.Play();
    }

    void EndOPMovie()
    {
        canvas.enabled = true;
        elapsedTime = 0;
        bgm_source.Play();
    }

    public void LoopPointReached(VideoPlayer vp)
    {
        EndOPMovie();
    }
}
