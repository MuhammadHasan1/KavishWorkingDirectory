using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detect : MonoBehaviour
{
    // Start is called before the first frame update
    public Node node;
    [SerializeField] string text;
    List<detect> objects;
    void Start()
    {
        node = new Node(text);
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        var connectingNode = collision.gameObject.GetComponent<detect>().node;
        if (!this.node.connected || !connectingNode.connected)
        {
            if (collision.GetType() == typeof(BoxCollider))
            {

                //Debug.Log(collision.gameObject.GetComponent<detect>().node.code);
                this.node.connected = true;
                connectingNode.connected = true;
                node.down = connectingNode;
                // Node connection
                Debug.Log("connected");
            }



            else if (collision.GetType() == typeof(CapsuleCollider))
            {

                this.node.connected = true;
                connectingNode.connected = true;
                node.right = connectingNode;
                Debug.Log("connected2");
                // do stuff only for the circle collider
            }

        }


    }

    private void OnTriggerStay(Collider collision)
    {

        var connectingNode = collision.gameObject.GetComponent<detect>().node;
        if (!this.node.connected || !connectingNode.connected)
        {
            if (collision.GetType() == typeof(BoxCollider))
            {

                //Debug.Log(collision.gameObject.GetComponent<detect>().node.code);
                this.node.connected = true;
                connectingNode.connected = true;
                node.down = connectingNode;
                // Node connection
                Debug.Log("connected");
            }



            else if (collision.GetType() == typeof(CapsuleCollider))
            {
                this.node.connected = true;
                connectingNode.connected = true;
                node.right = connectingNode;
                Debug.Log("connected2");
                // do stuff only for the circle collider
            }

        }




    }

    public void OnTriggerExit(Collider collision)
    {
        var connectingNode = collision.gameObject.GetComponent<detect>().node;

        if (collision.GetType() == typeof(BoxCollider))
        {
            Debug.Log("exited1");
            node.down = null;
        }

        else if (collision.GetType() == typeof(CapsuleCollider))
        {
            Debug.Log("exited2");
            node.right = null;
        }

        node.connected = false;
        connectingNode.connected = false;

    }


    void Update()
    {
        
    }
    

}
