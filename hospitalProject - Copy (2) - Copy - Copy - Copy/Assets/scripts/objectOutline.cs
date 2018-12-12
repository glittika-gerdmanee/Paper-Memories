using System.Collections;
using UnityEngine;

public class objectOutline : MonoBehaviour
{
    //public Material material;
    public Material material;


    private void OnTriggerEnter(Collider other)
    {
       
        gameObject.GetComponent<MeshRenderer>().material = material;
        material.shader = Shader.Find("Outlined/Uniform");
        Debug.Log("Outline ^o^"); //Message display for mouse hovering over GameObjects

    }
    private void OnTriggerExit(Collider other)
        {
            gameObject.GetComponent<MeshRenderer>().material = material;
            material.shader = Shader.Find("Standard");
            Debug.Log("No outline ;w;"); //Message display for mouse not hovering over GameObject
        }

    void Update()
    {
    }
}
