using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;

public class taskTest : MonoBehaviour

{


    public Transform Cube;



    void Start()
    {
        RotateCube();
        
    }

    private async void RotateCube()
    {
        Task newTask = Task.Run(() => Rotate360(Vector3.up));
        await newTask;

        Task newTask2 = Task.Run(() => Rotate360(Vector3.down));
        await newTask;

        Task newTask3 = Task.Run(()=> Rotate360(Vector3.right));
        await newTask;
    }


    private void Rotate360(Vector3 axis)
    {
        for (int i = 0; i < 9; i++)
        {
            Debug.Log(i);
            MainThreadDispatcher.Instance.InvokeInMainThread(() =>
            {
                Cube.transform.Rotate(axis, 10);

            });
            Thread.Sleep(1000);


        }
    }


    private void Count()
    {


        MainThreadDispatcher.Instance.InvokeInMainThread(() =>
        {
            Debug.Log("Invoke this in thread 1");
        });
        Thread.Sleep(1000);

        MainThreadDispatcher.Instance.InvokeInMainThread(() =>
        {
            Debug.Log("Invoke this in thread 2");
        });
        Thread.Sleep(1000);

        MainThreadDispatcher.Instance.InvokeInMainThread(() =>
        {
            Debug.Log("Invoke this in thread 3");
        });
        


    }
}
