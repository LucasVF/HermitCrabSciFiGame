using UnityEngine;

//Base Class for every View class 
public abstract class BaseView : MonoBehaviour, IView {
    public abstract void SetUpView();
    public abstract ViewNames GetName();
    public void DisplayView() => gameObject.SetActive(true);
    public void HideView() => gameObject.SetActive(false);
}