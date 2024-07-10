using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public abstract class Screen : MonoBehaviour
{
    private readonly float _onAlphaValue = 1.0f;
    private readonly float _offAlphaValue = 0.0f;

    private CanvasGroup _group;

    private void Awake()
    {
        _group = GetComponent<CanvasGroup>();
    }

    public void Open()
    {
        _group.alpha = _onAlphaValue;
        _group.interactable = true;
        _group.blocksRaycasts = true;
    }

    public void Close()
    {
        _group.alpha = _offAlphaValue;
        _group.interactable = false;
        _group.blocksRaycasts = false;
    }

    public void Quit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
