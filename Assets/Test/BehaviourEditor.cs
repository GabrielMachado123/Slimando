using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using UnityEditor.Callbacks;

public class BehaviourEditor : EditorWindow
{
    BehaviourTreeView2 treeView;
    InspectorView inspectorView;



    [MenuItem("BehaviourEditor/Editor")]
    public static void OpenWindow()
    {
        BehaviourEditor wnd = GetWindow<BehaviourEditor>();
        wnd.titleContent = new GUIContent("BehaviourEditor");
    }

    [OnOpenAsset]
    public static bool OnOpenAsset(int instanceId, int line)
    {
        if(Selection.activeObject is BehaviorTree)
        {
            OpenWindow();
            return true;
        }
        return false;
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

      

        // Import UXML
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Test/BehaviourEditor.uxml");
        visualTree.CloneTree(root);

        // A stylesheet can be added to a VisualElement.
        // The style will be applied to the VisualElement and all of its children.
        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Test/BehaviourEditor.uss");
     
    
        root.styleSheets.Add(styleSheet);

        treeView = root.Q<BehaviourTreeView2>();
        inspectorView = root.Q<InspectorView>();

        treeView.OnNodeSelected = OnNodeSelectedChanged;

        OnSelectionChange();
    }

    private void OnSelectionChange()
    {
        BehaviorTree tree = Selection.activeObject as BehaviorTree;
        if(tree && AssetDatabase.CanOpenAssetInEditor(tree.GetInstanceID()))
        {
            treeView.PopulateView(tree);
        }
    }

    void OnNodeSelectedChanged(NodeView node)
    {
        inspectorView.UpdateSelection(node);
    }

}