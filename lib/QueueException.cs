using System;

namespace lib
{
	class QueueException : Exception {
		public QueueException () : base("Error: Queue is empty") {
		}	
	}

}

