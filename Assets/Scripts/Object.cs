using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Text;
using UnityEngine;
using UCompile;

public class Object : MonoBehaviour
{
    //public string a;
    void Start()
    {

   
    }

    public void func(string code)
    {
        var assembly = Compile(@"
		using UnityEngine;
        using System;
        using System.Collections;
        using System.Collections.Generic;
        
		public class Test: MonoBehaviour
		{
                bool routineRunning;
                public Transform Dragon;
                public float moveSpeed = 0.5F;
    
           
                public GameObject canvas;
                void Start()
                {
                   var Level = GameObject.Find(""Level"");
                   Dragon = Level.transform.Find(""Dragon 1"");
                }
                IEnumerator RotateMe(Vector3 byAngles, float inTime)
                {
                    while (routineRunning)
                    {
                        yield return new WaitForSeconds(0.1f);
                    }
                    routineRunning = true;
                    var fromAngle = Dragon.transform.rotation;
                    var toAngle = Quaternion.Euler(Dragon.eulerAngles + byAngles);
                    for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
                    {
                        Dragon.transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
                        yield return null;
                    }
                    Dragon.transform.rotation = toAngle;
                    routineRunning = false;
                }
                IEnumerator MoveMe(float inTime)
                {
                    while (routineRunning)
                    {
                        yield return new WaitForSeconds(0.1f);
                    }
                    routineRunning = true;
                    for (var t = 0f; t < 0.0899; t += Time.deltaTime / inTime)
                    {
                        Debug.Log(""MoveMeCalled"");
                        Dragon.transform.Translate(Vector3.forward * Mathf.Clamp(1 * 6, -1, 1) * moveSpeed * Time.deltaTime);
                        yield return null;
                    }
                    routineRunning = false;
                }
                void  MoveForward()
                {
                    Debug.Log(""MoveForwardCalled"");
                    StartCoroutine(MoveMe(0.8f));
                }

                void RotateRight()
                {
                    StartCoroutine(RotateMe(Vector3.up * 90, 0.8f));

                }

                void RotateLeft()
                {       
                        StartCoroutine(RotateMe(Vector3.up * -90, 0.8f));
                }
            
          
			    public void Foo()
			    {"
                   + code +
               @"}
        }");

        var method = assembly.GetType("Test").GetMethod("Foo");
        var del = (Action)Delegate.CreateDelegate(typeof(Action), method);
        del.Invoke();
    }

    public static Assembly Compile(string source)
    {
        var provider = new CSharpCodeProvider();
        var param = new CompilerParameters();
        Debug.Log(AppDomain.CurrentDomain.GetAssemblies());

        // Add ALL of the assembly references
        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            param.ReferencedAssemblies.Add(assembly.Location);
        }

        // Add specific assembly references
        param.ReferencedAssemblies.Add("System.dll");
        //param.ReferencedAssemblies.Add("C:/Program Files/Unity/Hub/Editor/2019.2.0f1/Editor/Data/Managed/UnityEngine.dll");
        

        // Generate a dll in memory
        param.GenerateExecutable = false;
        param.GenerateInMemory = true;

        // Compile the source
        var result = provider.CompileAssemblyFromSource(param, source);

        if (result.Errors.Count > 0)
        {
            var msg = new StringBuilder();
            foreach (CompilerError error in result.Errors)
            {
                msg.AppendFormat("Error ({0}): {1}\n",
                    error.ErrorNumber, error.ErrorText);
            }
            throw new Exception(msg.ToString());
        }

        // Return the assembly
        return result.CompiledAssembly;
    }
}
