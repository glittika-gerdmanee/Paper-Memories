using UnityEngine;

public class highlightController : MonoBehaviour {
    private highlightObject highlightObject;

    public void SelectObject(highlightObject highlightObject) {

        if(this.highlightObject != null) {
            this.highlightObject.StopHighlight();
        }

        this.highlightObject = highlightObject;
        this.highlightObject.StartHighlight();

    }
}
