using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorTreeRunner : MonoBehaviour
{
    public BehaviorTree tree;
    void Start()
    {
        tree = tree.Clone();
    }

    // Update is called once per frame
    void Update()
    {
        tree.Update();
    }
}
