using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour
{

    [SerializeField]
    List<BaseView> _views;

    Dictionary<ViewNames, IView> _dictViews = new Dictionary<ViewNames, IView>();
    IView _curentView;

    void Start(){
        foreach(IView view in _views){
            view.HideView();
            if(_dictViews.ContainsKey(view.GetName())){
                Debug.Log("Duplicated View");
            }else{
                _dictViews.Add(view.GetName(), view);
            }            
        }
        AudioSingleton.Instance.TriggerThemeAudio();
        ChangeViewTo(ViewNames.MainMenu);
    }

    public void GoToGame() => ChangeViewTo(ViewNames.Game);
    public void GoToMainMenu() => ChangeViewTo(ViewNames.MainMenu);
    public void GoToResults() => ChangeViewTo(ViewNames.Results);

    void ChangeViewTo(ViewNames viewName){
        if(_dictViews != null && _dictViews.ContainsKey(viewName)){
            _curentView?.HideView();
            _curentView = _dictViews[viewName];
            _curentView.SetUpView();
            _curentView.DisplayView();
        }else{
            Debug.Log("View not available");
        }
    }
}
