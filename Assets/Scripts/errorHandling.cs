using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class errorHandling : MonoBehaviour
{
    public bool StatementError(Node inputNode)
    {
        string[] _statements = { "moveForward()", "moveBackward()", "rotateRight()", "rotateLeft()", "jump()", "swipe()" };
        List<string> statements = new List<string>(_statements);

        string a = inputNode.code;
        if (statements.Contains(a))
        {
            if (inputNode.right != null)
            {
                Debug.LogError("Nothing is expected on the right of this statement.");
                //return "Statement Error";
                return false;
            }
        }
        return true;    
    }

    public bool IFerrors(Node inputNode)
    {
        string[] _if_errors = { "MoveForward()", "MoveBackward()", "RotateRight()", "RotateLeft()", "Jump()", "Swipe()", "Else","Loop",
                                "Count", "if"};
        List<string> if_errors = new List<string>(_if_errors);

        for (int i = 0; i < if_errors.Count; i++)
        {
            if (inputNode.right.code == if_errors[i])
            {
                Debug.LogError("This is not expected on the right of this IF statement.");
                return false;
            }
        }
        return true;
    }

    public bool elseErrors(Node inputNode)
    {
        string[] _else_errors = { "else", "tree", "hole", "stone", "Spikes", "barrier", "count" };
        List<string> else_errors = new List<string>(_else_errors);

        for (int i = 0; i < else_errors.Count; i++)
        {
            if (inputNode.right.code == else_errors[i])
            {
                Debug.LogError("This is not expected on the right of ELSE statement.");
                return false;
            }
        }
        return true;
    }
    public bool loopErrors(Node inputNode)
    {
        string[] _loop_errors = { "moveForward()", "moveBackward()", "rotateRight()", "rotateLeft()", "jump()", "swipe()", "tree", "hole",
                                  "stone", "Spikes", "barrier", "if", "else", "Loop" };
        List<string> loop_errors = new List<string>(_loop_errors);
        for (int i = 0; i < loop_errors.Count; i++)
        {
            if (inputNode.right.code == loop_errors[i])
            {
                Debug.LogError("This is not expected on the right of Loop.");
                return false;
            }
        }
        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
