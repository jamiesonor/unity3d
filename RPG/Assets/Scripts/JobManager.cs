using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//just a proxy object
public class JobManager : MonoBehaviour {

    static JobManager instance = null;
    public static JobManager Instance
    {
        get
        {
            if (!instance)
            {
                instance = FindObjectOfType(typeof(JobManager)) as JobManager;
                if (!instance)
                {
                    var obj = new GameObject("JobManager");
                    instance = obj.AddComponent<JobManager>();
                }
            }
            return instance;
        }
    }

    void OnApplicationQuit()
    {
        instance = null;
    }

}
public class Job
{
    public event System.Action<bool> jobComplete;   //an event called jobComplete of type action(bool)

    private bool _isRunning;
    public bool IsRunning { get { return _isRunning; } }

    private bool _isPaused;
    public bool IsPaused { get { return _isPaused; } }

    private IEnumerator _coroutine;
    private bool _jobWasKilled;
    private Stack<Job> _childJobStack;  //for child jobs

    public Job(IEnumerator coroutine) : this(coroutine, true) { }

    public Job(IEnumerator coroutine, bool shouldStart)
    {
        _coroutine = coroutine;
        if (shouldStart)
        {
            StartJob();
        }
    }

    public static Job Make(IEnumerator coroutine)
    {
        return new Job(coroutine);
    }

    public static Job Make(IEnumerator coroutine, bool shouldStart)
    {
        return new Job(coroutine, shouldStart);
    }

    //Public API
    public Job CreateAndAddChildJob(IEnumerator coroutine)
    {
        var j = new Job(coroutine, false);
        AddChildJob(j);
        return j;
    }

    public void AddChildJob(Job childJob)
    {
        if (_childJobStack == null)
        {
            _childJobStack = new Stack<Job>();
        }
        _childJobStack.Push(childJob);
    }

    public void removeChildJob(Job childJob)
    {
        if (_childJobStack.Contains(childJob))
        {
            var childStack = new Stack<Job>(_childJobStack.Count - 1);
            var allCurrentChildren = _childJobStack.ToArray();
            System.Array.Reverse(allCurrentChildren);
            for(int i = 0; i < allCurrentChildren.Length; i++)
            {
                var j = allCurrentChildren[i];
                if (j != childJob)
                {
                    childStack.Push(j);
                }
            }

            //assign new stack
            _childJobStack = childStack;
        }
    }

    public void StartJob()
    {
        _isRunning = true;
        JobManager.Instance.StartCoroutine(DoWork());
    }

    public IEnumerator StartAsCoroutine()
    {
        _isRunning = true;
        yield return JobManager.Instance.StartCoroutine(DoWork());
    }

    public void PauseJob()
    {
        _isPaused = true;
    }

    public void UnPauseJob()
    {
        _isPaused = false;
    }

    public void KillJob()
    {
        _jobWasKilled = true;
        _isRunning = false;
        _isPaused = false;
    }

    public void KillJob(float delayInSeconds)
    {
        var delay = (int)(delayInSeconds * 1000);
        new System.Threading.Timer(obj =>
        {
            lock (this)
            {
                KillJob();
            }
        }, null, delay, System.Threading.Timeout.Infinite);
    }

    private IEnumerator DoWork()
    {
        //null out the first time through in case we start paused
        yield return null;

        while(_isRunning)
        {
            if (_isPaused)
            {
                yield return null;
            }
            else
            {
                if (_coroutine.MoveNext())
                {
                    yield return _coroutine.Current;
                }
                else
                {
                    if (_childJobStack != null)
                        yield return JobManager.Instance.StartCoroutine(RunChildJobs());
                    _isRunning = false;
                }
            }
        }

        if (jobComplete != null)
        {
            jobComplete(_jobWasKilled);
        }
    }

    private IEnumerator RunChildJobs()
    {
        if (_childJobStack != null && _childJobStack.Count > 0)
        {
            do
            {
                Job childJob = _childJobStack.Pop();
                yield return JobManager.Instance.StartCoroutine(childJob.StartAsCoroutine());
            } while (_childJobStack.Count > 0);
        }
    }
}