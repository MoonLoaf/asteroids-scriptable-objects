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
        var serializedObject = new SerializedObject(Config);
        _root.Bind(serializedObject);
    }
    
    public override VisualElement CreateInspectorGUI()
    {
        UXML = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Tool/GameGonfig.uxml");
        UXML.CloneTree(_root);

        // Get a reference to the slider from UXML and assign it its value.
        var sizeVisualElement = _root.Q<VisualElement>("SizeElement");
        var uxmlSlider = _root.Q<Slider>("SizeThreshold");
        uxmlSlider.value = 42.2f;

        // Create a new slider, disable it, and give it a style class.
        var csharpSlider = new Slider("Size Threshold", Config.MinSize, Config.MaxSize);
        csharpSlider.SetEnabled(true);
        csharpSlider.AddToClassList("some-styled-slider");
        csharpSlider.value = uxmlSlider.value;
        csharpSlider.showInputField = true;
        sizeVisualElement.hierarchy.Add(csharpSlider);
        
        sizeVisualElement.Add(csharpSlider);

        // Mirror value of uxml slider into the C# field.
        uxmlSlider.RegisterCallback<ChangeEvent<float>>((evt) =>
        {
            csharpSlider.value = evt.newValue;
        });

        var foldout = new Foldout() { viewDataKey = "GameConfigFullInspectorFoldout", text = "Full Inspector" };
        InspectorElement.FillDefaultInspector(foldout, serializedObject, this);
        _root.Add(foldout);
        
        return _root;
    }
}

#endif
