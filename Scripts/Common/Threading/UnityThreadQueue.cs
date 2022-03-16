using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine.Assertions;

namespace Common.Unity.Scripts.Common
{
	public class UnityThreadQueue
	{
		private class ActionCommand
		{
			public Action Action;

			public float DelayTimeSeconds;
			public float ElapsedTime;
		}

		private Stack<ActionCommand> _actionPool;
		private Queue<ActionCommand> _commandQueue;
		private Stopwatch _executeLimitStopwatch;
		public bool IsEmpty => _commandQueue.Count == 0;

		public UnityThreadQueue()
		{
			_actionPool = new Stack<ActionCommand>();
			_commandQueue = new Queue<ActionCommand>();
			_executeLimitStopwatch = new Stopwatch();
		}

		/// <summary>
		/// Be aware that actions using variables... they may change in time when delay applied.
		/// So it is good to create local variable just before running the method.
		/// </summary>
		/// <param name="action"></param>
		/// <param name="delayTimeSeconds"></param>
		public void SetAction(Action action, float delayTimeSeconds = 0)
		{
			Assert.IsTrue(action != null);

			ActionCommand cmd = GetFromPool(_actionPool);
			cmd.Action = action;
			cmd.DelayTimeSeconds = delayTimeSeconds;
			cmd.ElapsedTime = 0;

			QueueCommand(cmd);
		}

		public void Execute(int maxMilliseconds, float deltaTimeSeconds)
		{
			Assert.IsTrue(maxMilliseconds > 0);

			_executeLimitStopwatch.Reset();
			_executeLimitStopwatch.Start();
			while (_executeLimitStopwatch.ElapsedMilliseconds < maxMilliseconds)
			{
				ActionCommand command;
				lock (_commandQueue)
				{
					if (_commandQueue.Count == 0)
					{
						break;
					}

					command = _commandQueue.Dequeue();
					if (command.DelayTimeSeconds != 0)
					{
						command.ElapsedTime += deltaTimeSeconds;
						if (command.ElapsedTime < command.DelayTimeSeconds)
                        {
							_commandQueue.Enqueue(command);
							break;
						}
					}
				}

				Action action = command.Action;

				action?.Invoke();

				command.Action = null;
				command.ElapsedTime = 0;
				command.DelayTimeSeconds = 0;
				ReturnToPool(_actionPool, command);

				break;
			}
		}

		private static T GetFromPool<T>(Stack<T> pool)
			where T : new()
		{
			lock (pool)
			{
				if (pool.Count > 0)
				{
					return pool.Pop();
				}
			}

			return new T();
		}

		private static void ReturnToPool<T>(Stack<T> pool, T obj)
		{
			lock (pool)
			{
				pool.Push(obj);
			}
		}

		private void QueueCommand(ActionCommand cmd)
		{
			lock (_commandQueue)
			{
				_commandQueue.Enqueue(cmd);
			}
		}
	}
}
