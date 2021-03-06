using System;
using System.Collections.Generic;
using System.Text;

namespace lib
{

	public class PriorityQueue<T>
	{
		QueueElement last = null;
		QueueElement first = null;

		public PriorityQueue () {
		}

		public void Enqueue(T data, int priority) {
			QueueElement iterator = last;

			while (iterator != null && iterator.GetPriority() > priority) {
				iterator = iterator.GetNext();
			}

			QueueElement element = new QueueElement(data, priority);

			// actualizar: first, last, element.prev, element.next, iterator.prev.next, iterator.prev

			if (last == null) {					// Primer elemento en cola
				last = first = element;
			} else {
				if (iterator == null) {			// Elemento nuevo con mayor prioridad
					element.SetPrev(first);
					first.SetNext(element);
					first = element;
				} else {
					if (iterator == first) {	// Elemento nuevo es el segundo elemento en cola, de igual o mayor prioridad que el primero
						if (iterator == last) {
							element.SetNext (first);
							first.SetPrev (element);
							last = element;
						} else {
							element.SetPrev (first.GetPrev ());
							element.SetNext (first);
							first.GetPrev ().SetNext (element);
							first.SetPrev (element);
						}
					} else {					
						if (iterator == last) {	// Elemento nuevo es el ultimo elemento en cola	
							element.SetNext(last);
							last.SetPrev(element);
							last = element;

						} else {				// Elemento nuevo es elemento intermendio en cola
							element.SetPrev(first.GetPrev());
							element.SetNext(first);
							first.GetPrev().SetNext(element);
							first.SetPrev(element);
						}
					}


				}
			}

		}

		public T Dequeue() {
			
			if (first == null) {
				throw new QueueException();
			} else {
				T data = first.GetData ();
				first = first.GetPrev();
				first.SetNext (null);
				return data;
			}
		}

		public override String ToString(){
			QueueElement iterator = first;

			StringBuilder builder = new StringBuilder();

			builder.Append("[");

			if (iterator != null) {
				builder.Append(" ");
				builder.Append (iterator.GetPriority ());
				builder.Append(". "); 
				builder.Append(iterator.GetData());

				iterator = iterator.GetPrev ();

				while ( iterator != null ) {
					builder.Append(", ");
					builder.Append (iterator.GetPriority ());
					builder.Append(". "); 
					builder.Append(iterator.GetData());

					iterator = iterator.GetPrev ();
				}
				builder.Append (" ");
			}

			builder.Append ("]");

			return builder.ToString ();
		}

		public ICollection<T> ToList(){
			LinkedList<T> list = new LinkedList<T> ();
			QueueElement iterator = first;
			while (iterator != null) {
				list.AddLast (iterator.GetData());
				iterator = iterator.GetPrev();
			}

			return list;
		}

		public IEnumerator<T> GetEnumerator() {
			return ToList().GetEnumerator();
		}

		// Constructor  
		private class QueueElement {
			public T data;
			public int priority;

			private QueueElement next = null;
			private QueueElement prev = null;

			public QueueElement(T data, int priority) {
				this.data = data;
				this.priority = priority;
			}

		//Getters & Setters
		public T GetData() { return data; }

		public int GetPriority() { return priority; }

		public QueueElement GetNext () { return next; }
		public void SetNext(QueueElement next) { this.next = next; }

		public QueueElement GetPrev () { return prev; }
		public void SetPrev(QueueElement prev) { this.prev = prev; }
		}
	}
}


