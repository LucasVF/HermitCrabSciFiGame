using System;

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

