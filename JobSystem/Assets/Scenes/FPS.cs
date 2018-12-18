using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPS : MonoBehaviour {

    public Text m_countEnermy;
    public Text m_fps;

    private double lastinterval = 0;
    private int frames = 0;
    private float fps = 0;

    private void Start() {
        lastinterval = Time.realtimeSinceStartup;
    }

    private void Update() {
        ++frames;
        float timeNow = Time.realtimeSinceStartup;
        if (timeNow - lastinterval > 0.1f) {
            fps = (float)(frames / (timeNow - lastinterval));
            m_fps.text = "FPS: " + fps.ToString("f0") + " (" + fps + ")";
            frames = 0;
            lastinterval = timeNow;
        }
    }

    public void SetCount(int count) {
        m_countEnermy.text = "EnermyShip Count: " + count;
    }
}
