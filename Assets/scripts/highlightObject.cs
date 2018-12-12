using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class highlightObject : MonoBehaviour {
    public float animationTime = 1f;
    public float colourThreshold = 1.5f;

    private highlightController controller;
    private Material material;
    private Color normalColour;
    private Color selectedColour;

    private void Awake() {
        material = GetComponent<MeshRenderer>().material;
        controller = FindObjectOfType<highlightController>();

        normalColour = material.color;
        selectedColour = new Color(
            Mathf.Clamp01(normalColour.r * colourThreshold),
            Mathf.Clamp01(normalColour.g * colourThreshold),
            Mathf.Clamp01(normalColour.b * colourThreshold)
            );
    }

    public void StartHighlight() {
        iTween.ColorTo(gameObject, iTween.Hash(
            "color", selectedColour,
            "time", animationTime,
            "easetype", iTween.EaseType.linear,
            "looptype", iTween.LoopType.pingPong
        ));
    }
    public void StopHighlight() {
        iTween.Stop(gameObject);
        material.color = normalColour;
    }

    private void OnTriggerEnter(Collider other)
    {
        controller.SelectObject(this);
    }
    private void OnTriggerExit(Collider other)
    {
        
    }
}
