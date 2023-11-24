using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindSetting : MonoBehaviour
{
        //Wind variables
        [SerializeField][Range(0.0F, 5.0F)] private float force = 1.0f;
        [SerializeField][Range(0.0F, 5.0F)] private float speed = 1.0f;
        [SerializeField][Range(0.0F, 5.0F)] private float wavesScale = 1.0f;

        void Update()
        {
            //Set wind settings
            Shader.SetGlobalFloat("RAYGlobalWindForce", force);
            Shader.SetGlobalFloat("RAYGlobalWindSpeed", speed);
            Shader.SetGlobalFloat("RAYGlobalWavesScale", wavesScale);
        }
}
