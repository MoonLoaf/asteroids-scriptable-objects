using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

#if true

[CustomEditor(typeof(GameManager))]
public class CustomEditorGameManager : Editor
{
    public VisualTreeAsset UXML;
    
    public override VisualElement CreateInspectorGUI()
    {
        var root = new VisualElement();
        UXML.CloneTree(root);

        return root;
    }
}

#endif
