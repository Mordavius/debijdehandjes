using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLevel : Level {

    public override void Start()
    {
        base.Start();
        PlayBackground(true);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlayFeedback();
        }
    }


}
