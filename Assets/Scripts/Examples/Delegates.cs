using UnityEngine;
using System;
using System.Collections.Generic;

public class Delegates
{
	#region ConfigurablePattern
	delegate void RobotAction();
	RobotAction myRobotAction;

	void Start()
	{
		myRobotAction = RobotWalk;
	}

	void Update()
	{
		myRobotAction ();
	}

	public void DoRobotWalk()
	{
		myRobotAction = RobotWalk;
	}

	public void RobotWalk()
	{
		Debug.Log ("Robot walking");
	}

	public void DoRobotRun()
	{
		myRobotAction = RobotRun;
	}

	public void RobotRun()
	{
		Debug.Log ("Robot running");
	}
	#endregion

	#region DelgationPattern
	public class Worker
	{
		List<string> WorkCompletedFor = new List<string>();
		public void DoSomething(string managerName, Action myDelegate)
		{
			WorkCompletedFor.Add (managerName);
			myDelegate ();
		}
	}

	public class Manager
	{
		private Worker myWorker = new Worker();

		public void PeiceOfWork1()
		{
			Debug.Log ("Doing peice of work 1");
		}

		public void PeiceOfWork2()
		{
			Debug.Log ("Doeing peice of work 2");
		}

		public void DoWork()
		{
			myWorker.DoSomething ("Manager1", PeiceOfWork1);
			myWorker.DoSomething ("Manager2", PeiceOfWork1);
		}

		public void DoWork2()
		{
			myWorker.DoSomething ("Manager1", () => {
				Debug.Log ("Doing peice of work 1");
			});

			myWorker.DoSomething ("Manager2", () => {
				Debug.Log ("Doeing peice of work 2");
			});
		}
	}
	#endregion

	#region CompoundDelegates
	public class WorkerManager
	{
		void DoWork()
		{
			DoJob1 ();
			DoJob2 ();
			DoJob3 ();
		}

		private void DoJob1()
		{
			Debug.Log ("Doing job 1");
		}

		private void DoJob2()
		{
			Debug.Log ("Doing job 2");
		}

		private void DoJob3()
		{
			Debug.Log ("Doing job 3");
		}
	}

	public class WorkerManager2
	{
		delegate void MyDelegateHook();
		MyDelegateHook actionsToDo;

		public string WorkerType = "Peon";

		void Start()
		{
			if (WorkerType == "Peon") {
				actionsToDo += DoJob1;
				actionsToDo += DoJob2;
			} else {
				actionsToDo += DoJob3;
			}
		}

		public void Update()
		{
			actionsToDo ();
		}

		private void DoJob1()
		{
			Debug.Log ("Doing job 1");
		}

		private void DoJob2()
		{
			Debug.Log ("Doing job 2");
		}

		private void DoJob3()
		{
			Debug.Log ("Doing job 3");
		}
	}

	#endregion
}
