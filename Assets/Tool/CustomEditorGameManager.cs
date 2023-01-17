using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using UnityEngine;

#if true

[CustomEditor(typeof(GameManager))]
public class CustomEditorGameManager : Editor
{
    [SerializeField] private VisualTreeAsset UXML = default;
    
    public override VisualElement CreateInspectorGUI()
    {
        UXML = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Tool/GameGonfig.uxml");
        
        var root = new VisualElement();
        UXML.CloneTree(root);

        var foldout = new Foldout() { viewDataKey = "GameConfigFullInspectorFoldout", text = "Full Inspector" };
        InspectorElement.FillDefaultInspector(foldout, serializedObject, this);
        root.Add(foldout);

        return root;
    }
}

#endif
