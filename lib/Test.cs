using NUnit.Framework;
using System;

using System.Collections.Generic;
using System.Collections;

namespace lib
{
	[TestFixture ()]
	public class Test
	{
		[Test ()]
		public void TestToString()
		{
			PriorityQueue<Char> queue = new PriorityQueue<Char>();

			queue.Enqueue ('a', 1);
			queue.Enqueue ('c', 1);
			queue.Enqueue ('c', 1);
			queue.Enqueue ('d', 1);

			String output = queue.ToString();

			System.Console.WriteLine(output);

			Assert.IsTrue ("[ 1. a, 1. c, 1. c, 1. d ]".Equals(output));
		}

		//Tests para comprobar el correcto funcionamiento del metodo Enqueue
		[Test ()]
		public void TestEnqueueEmptyQueue()
		{
			PriorityQueue<Char> queue = new PriorityQueue<Char>();

			queue.Enqueue ('a', 1);

			String output = queue.ToString();

			Assert.IsTrue ("[ 1. a ]".Equals(output));
		}

		[Test ()]
		public void TestFirstTakePrecedence1()
		{
			PriorityQueue<Char> queue = new PriorityQueue<Char>();

			queue.Enqueue ('b', 1);
			queue.Enqueue ('a', 0);

			String output = queue.ToString();

			Assert.IsTrue ("[ 0. a, 1. b ]".Equals(output));
		}

		[Test ()]
		public void TestFirstTakePrecedence2()
		{
			PriorityQueue<Char> queue = new PriorityQueue<Char>();

			queue.Enqueue ('d', 3);
			queue.Enqueue ('b', 2);
			queue.Enqueue ('c', 2);
			queue.Enqueue ('a', 1);

			String output = queue.ToString();

			Assert.IsTrue ("[ 1. a, 2. b, 2. c, 3. d ]".Equals(output));
		}


		//El nuevo elemento de menos prioridad y prioridad intermedia ya se ha comprobado a su vez en los test de mas arriba.
		[Test ()]
		public void TestLessPriority()
		{
			PriorityQueue<Char> queue = new PriorityQueue<Char>();

			queue.Enqueue ('a', 1);
			queue.Enqueue ('b', 1);
			queue.Enqueue ('c', 1);
			queue.Enqueue ('d', 1);

			String output = queue.ToString();

			Assert.IsTrue ("[ 1. a, 1. b, 1. c, 1. d ]".Equals(output));
		}

		//Tests para comprobar el correcto funcionamiento del metodo Dequeue
		[Test ()]
		public void TestDequeueEmptyQueue()
		{
			PriorityQueue<Char> queue = new PriorityQueue<Char>();

			try {
				queue.Dequeue();
			} catch (Exception e) {
				Assert.IsInstanceOf<QueueException>(e);
			}
		}

		[Test ()]
		public void TestDequeueNotEmptyQueue()
		{
			PriorityQueue<Char> queue = new PriorityQueue<Char>();

			queue.Enqueue ('a', 1);
			queue.Enqueue ('b', 1);
			queue.Enqueue ('c', 1);
			queue.Enqueue ('d', 1);

			Char firstElement = queue.Dequeue();

			String output = queue.ToString();

			Assert.IsTrue ('a' == firstElement);
			Assert.IsTrue ("[ 1. b, 1. c, 1. d ]".Equals(output));
		}

		//Tests para comprobar que la cola PriorityQueue implementa IEnumerator
		[Test ()]
		public void TestToList()
		{
			PriorityQueue<Char> queue = new PriorityQueue<Char>();
			Object enumerator = queue.GetEnumerator ();
			Assert.NotNull(enumerator);
			Assert.IsTrue(enumerator is IEnumerator);
		}

	}
}

