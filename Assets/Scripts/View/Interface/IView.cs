using System;

//Interface to be used for every view, so ViewController is able to deal with every view
public interface IView {
    public ViewNames GetName();
    public void SetUpView();
    public void DisplayView();
    public void HideView();
}

[Serializable]
public enum ViewNames{
    Game,
    MainMenu,
    Results
}

