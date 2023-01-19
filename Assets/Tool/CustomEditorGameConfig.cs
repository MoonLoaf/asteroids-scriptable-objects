using System;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using UnityEngine;

#if true

[CustomEditor(typeof(GameConfig))]
public class CustomEditorGameConfig : Editor
{
    [SerializeField] private VisualTreeAsset UXML = default;

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

        var foldout = new Foldout() { viewDataKey = "GameConfigFullInspectorFoldout", text = "Full Inspector" };
        InspectorElement.FillDefaultInspector(foldout, serializedObject, this);
        _root.Add(foldout);
        
        return _root;
    }
}

#endif
