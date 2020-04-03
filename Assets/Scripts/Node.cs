using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public Node right;
    public Node down;
    public string code;
    public bool connected;
    public Node(string code)
    {
        this.code = code;
        this.right = null;
        this.down = null;
        this.connected = false;
    }
    


    // Start is called before the first frame update
    
}
