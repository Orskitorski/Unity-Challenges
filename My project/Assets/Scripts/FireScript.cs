using UnityEngine;
using System;
using Unity.VectorGraphics;
using UnityEngine.UIElements;
using System.Numerics;

public class FireScript : MonoBehaviour
{
    void Start()
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();
        var psShape = ps.shape.scale;

        psShape.x = transform.parent.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    
    void Update()
    {
        
    }
}
