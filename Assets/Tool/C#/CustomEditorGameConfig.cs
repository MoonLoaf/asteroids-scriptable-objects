using System;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using UnityEngine;

#if true

[CustomEditor(typeof(GameConfig))]
public class CustomEditorGameConfig : Editor
{
    [SerializeField] private VisualTreeAsset UXML;

    public GameConfig Config;
    private VisualElement _root;

    private void OnEnable()
    {
        _root = new VisualElement();
        Config = AssetDatabase.LoadAssetAtPath<GameConfig>("Assets/Tool/GameConfig.asset");
        var SO = new SerializedObject(Config);
        _root.Bind(SO);
    }
    
    public override VisualElement CreateInspectorGUI()
    {
        UXML = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Tool/UXML/GameConfig.uxml");
        UXML.CloneTree(_root);

        var sizeVisualElement = _root.Q<VisualElement>("SizeElement");

        
        //Size Threshold Slider
        var csharpSlider = new Slider("Size Threshold", Config.MinSize, Config.MaxSize);
        csharpSlider.SetEnabled(true);
        csharpSlider.AddToClassList("unity-base-slider");
        csharpSlider.showInputField = true;
        
        sizeVisualElement.Add(csharpSlider);

        //HelpBox for slider
        var csharpHelpBox = new HelpBox("Asteroids larger than the size threshold will split when hit, if the slider goes outside the min/max size you may need to re-enter the inspector.", HelpBoxMessageType.Info);
        csharpHelpBox.AddToClassList("unity-base-help-box");
        sizeVisualElement.Add(csharpHelpBox);
        
        
        // var foldout = new Foldout() { viewDataKey = "GameConfigFullInspectorFoldout", text = "Full Inspector" };
        // InspectorElement.FillDefaultInspector(foldout, serializedObject, this);
        // _root.Add(foldout);
        
        return _root;
    }
}

#endif
