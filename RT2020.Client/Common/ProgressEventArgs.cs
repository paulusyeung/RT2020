using System;
using System.Collections.Generic;
using System.Text;

namespace RT2020.Client.Common
{
	public class ProgressUpdateEventArgs : EventArgs
	{
		private string _message;
		private int _position;
		private int _total;

		public string Message
		{
			get
			{
				return _message;
			}
			set
			{
				_message = value;
			}
		}

		public int Position
		{
			get
			{
				return _position;
			}
			set
			{
				_position = value;
			}
		}

		public int Total
		{
			get
			{
				return _total;
			}
			set
			{
				_total = value;
			}
		}

		public ProgressUpdateEventArgs()
		{
		}

		public ProgressUpdateEventArgs(string message, int position, int total)
		{
			_message = message;
			_position = position;
			_total = total;
		}
	}
}
