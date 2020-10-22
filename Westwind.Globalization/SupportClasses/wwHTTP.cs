/*

West Wind HTTP Access class

This class is a full featured wrapper around the native .NET WebRequest
class to provide a simpler front end. It supports easier POST mechanisms
(UrlEncoded, Multi-Part Form, XML and raw) and the ability to directly
retrieve HTTP content into strings, files with minimal lines of code.

The class also provides automated cookie and state handling and simplified
proxy and authentication mechanisms to provide a simple single level class
interface. The underlying WebRequest is also exposed so you will not loose
any functionality in that existing .NET BCL class.

Copyright 2002-2005, West Wind Technologies
Author: Rick Strahl
West Wind Technologies
http://www.west-wind.com/

*/


using System;

using System.Net;
using System.IO;
using System.Text;
using System.Threading;


namespace Westwind.InternetTools
{
	/// <summary>
	/// An HTTP wrapper class that abstracts away the common needs for adding post keys
	/// and firing update events as data is received. This class is real easy to use
	/// with many operations requiring single method calls.
	/// </summary>
	internal class wwHttp
	{
		/// <summary>
		/// Determines how data is POSTed when when using AddPostKey() and other methods
		/// of posting data to the server. Support UrlEncoded, Multi-Part, XML and Raw modes.
		/// </summary>
		public HttpPostMode PostMode 
		{
			get { return this._PostMode; }
			set { this._PostMode = value; }
		}

		/// <summary>
		///  User name used for Authentication. 
		///  To use the currently logged in user when accessing an NTLM resource you can use "AUTOLOGIN".
		/// </summary>
		public string Username 
		{
			get { return this._Username; }
			set { _Username = value; }
		}

		/// <summary>
		/// Password for Authentication.
		/// </summary>
		public string Password 
		{
			get {return this._Password;}
			set {this._Password = value;}
		}

		/// <summary>
		/// Address of the Proxy Server to be used.
		/// Use optional DEFAULTPROXY value to specify that you want to IE's Proxy Settings
		/// </summary>
		public string ProxyAddress 	
		{
			get {return this._ProxyAddress;}
			set {this._ProxyAddress = value;}
		}

		/// <summary>
		/// Semicolon separated Address list of the servers the proxy is not used for.
		/// </summary>
		public string ProxyBypass 
		{
			get {return this._ProxyBypass;}
			set {this._ProxyBypass = value;}
		}

		/// <summary>
		/// Username for a password validating Proxy. Only used if the proxy info is set.
		/// </summary>
		public string ProxyUsername 
		{
			get {return this._ProxyUsername;}
			set {this._ProxyUsername = value;}
		}
		/// <summary>
		/// Password for a password validating Proxy. Only used if the proxy info is set.
		/// </summary>
		public string ProxyPassword 
		{
			get {return this._ProxyPassword;}
			set {this._ProxyPassword = value;}
		}

		/// <summary>
		/// Timeout for the Web request in seconds. Times out on connection, read and send operations.
		/// Default is 30 seconds.
		/// </summary>
		public int Timeout 
		{
			get {return this._ConnectTimeout; }
			set {this._ConnectTimeout = value; }
		}

		/// <summary>
		/// Returns whether the last request was cancelled through one of the
		/// events.
		/// </summary>
		public bool Cancelled
		{
			get { return this._Cancelled; }
			set { this._Cancelled = value; }
		}
		bool _Cancelled;

		/// <summary>
		/// Error Message if the Error Flag is set or an error value is returned from a method.
		/// </summary>
		public string ErrorMessage 
		{
			get { return this._ErrorMessage; } 
			set { this._ErrorMessage = value; }
		}
		
		/// <summary>
		/// Error flag if an error occurred.
		/// </summary>
		public bool Error
		{
			get { return this._Error; } 
			set { this._Error = value; }
		}

		/// <summary>
		/// Determines whether errors cause exceptions to be thrown. By default errors 
		/// are handled in the class and the Error property is set for error conditions.
		/// (not implemented at this time).
		/// </summary>
		public bool ThrowExceptions 
		{
			get { return _ThrowExceptions; }
			set { this._ThrowExceptions = value;}
		} 

		/// <summary>
		/// If set to a non-zero value will automatically track cookies.
		/// </summary>
		public bool HandleCookies
		{
			get { return this._HandleCookies; }
			set { this._HandleCookies = value; }
		}

		/// <summary>
		/// Holds the internal Cookie collection before or after a request. This 
		/// collection is used only if HandleCookies is set to .t. which also causes it
		///  to capture cookies and repost them on the next request.
		/// </summary>
		public CookieCollection Cookies 
		{
			get 
			{
				if (this._Cookies == null)
					this.Cookies = new CookieCollection();
					  
				return this._Cookies; 
			}
			set { this._Cookies = value; }
		}

		/// <summary>
		/// WebResponse object that is accessible after the request is complete and 
		/// allows you to retrieve additional information about the completed request.
		/// 
		/// The Response Stream is already closed after the GetUrl methods complete 
		/// (except GetUrlResponse()) but you can access the Response object members 
		/// and collections to retrieve more detailed information about the current 
		/// request that completed.

		/// </summary>
		public HttpWebResponse WebResponse  
		{
			get { return this._WebResponse;}
			set { this._WebResponse = value; }
		}

		/// <summary>
		/// WebRequest object that can be manipulated and set up for the request if you
		///  called .
		/// 
		/// Note: This object must be recreated and reset for each request, since a 
		/// request's life time is tied to a single request. This object is not used if
		///  you specify a URL on any of the GetUrl methods since this causes a default
		///  WebRequest to be created.
		/// </summary>
		public HttpWebRequest WebRequest  
		{
			get { return this._WebRequest; }
			set { this._WebRequest = value; }
		}

		/// <summary>
		/// The buffersize used for the Send and Receive operations
		/// </summary>
		public int BufferSize 
		{
			get { return this._BufferSize; }
			set { this._BufferSize = value; }
		}
		int _BufferSize = 100;

		/// <summary>
		/// Lets you specify the User Agent  browser string that is sent to the server.
		///  This allows you to simulate a specific browser if necessary.
		/// </summary>
		public string UserAgent 
		{
			get { return _UserAgent; }
			set { _UserAgent = value; }
		}
		string _UserAgent = "West Wind HTTP .NET Client";

		
		// *** member properties
		//string cPostBuffer = "";
		MemoryStream _PostStream;
		BinaryWriter _PostData;

		HttpPostMode _PostMode = HttpPostMode.UrlEncoded;

		int _ConnectTimeout = 30;

		string _Username = "";
		string _Password = "";

		string _ProxyAddress = "";
		string _ProxyBypass = "";
		string _ProxyUsername = "";
		string _ProxyPassword = "";

		bool _ThrowExceptions = false;
		bool _HandleCookies = false;
	
		string _ErrorMessage = "";
		bool _Error = false;
		
		HttpWebResponse _WebResponse;
		HttpWebRequest _WebRequest;
		CookieCollection _Cookies;

		string _MultiPartBoundary = "-----------------------------" + DateTime.Now.Ticks.ToString("x");

		/// <summary>
		/// The wwHttp Default Constructor
		/// </summary>
		public void wwHTTP()
		{
		}

		/// <summary>
		/// Creates a new WebRequest instance that can be set prior to calling the 
		/// various Get methods. You can then manipulate the WebRequest property, to 
		/// custom configure the request.
		/// 
		/// Instead of passing a URL you  can then pass null.
		/// 
		/// Note - You need a new Web Request for each and every request so you need to
		///  set this object for every call if you manually customize it.
		/// </summary>
		/// <param name="String Url">
		/// The Url to access with this WebRequest
		/// </param>
		/// <returns>Boolean</returns>
		public bool CreateWebRequestObject(string Url) 
		{
			try 
			{
				this.WebRequest =  (HttpWebRequest) System.Net.WebRequest.Create(Url);
			}
			catch (Exception ex)
			{
				this.ErrorMessage = ex.Message;
				return false;
			}

			return true;
		}

		/// <summary>
		/// Adds POST form variables to the request buffer.
		/// PostMode determines how parms are handled.
		/// </summary>
		/// <param name="Key">Key value or raw buffer depending on post type</param>
		/// <param name="Value">Value to store. Used only in key/value pair modes</param>
		public void AddPostKey(string Key, byte[] Value)
		{
			
			if (this._PostData == null) 
			{
				this._PostStream = new MemoryStream();
				this._PostData = new BinaryWriter(this._PostStream);
			}
			
			if (Key == "RESET") 
			{
				this._PostStream = new MemoryStream();
				this._PostData = new BinaryWriter(this._PostStream);
			}

			switch(this._PostMode)
			{
				case HttpPostMode.UrlEncoded:
					this._PostData.Write( Encoding.GetEncoding(1252).GetBytes(Key + "=" +
						wwHttpUtils.UrlEncode(Encoding.GetEncoding(1252).GetString(Value)) +
						"&") );
					break;
				case HttpPostMode.MultiPart:
					this._PostData.Write( Encoding.GetEncoding(1252).GetBytes(
						"--" + this._MultiPartBoundary + "\r\n" + 
						"Content-Disposition: form-data; name=\"" +Key+"\"\r\n\r\n") );
					
					this._PostData.Write( Value );

					this._PostData.Write( Encoding.GetEncoding(1252).GetBytes("\r\n") );
					break;
				default:  // Raw or Xml modes
					this._PostData.Write( Value );
					break;
			}
		}

		/// <summary>
		/// Adds POST form variables to the request buffer.
		/// PostMode determines how parms are handled.
		/// </summary>
		/// <param name="Key">Key value or raw buffer depending on post type</param>
		/// <param name="Value">Value to store. Used only in key/value pair modes</param>
		public void AddPostKey(string Key, string Value)
		{
			this.AddPostKey(Key,Encoding.GetEncoding(1252).GetBytes(Value));
		}

		/// <summary>
		/// Adds a fully self contained POST buffer to the request.
		/// Works for XML or previously encoded content.
		/// </summary>
		/// <param name="FullPostBuffer">String based full POST buffer</param>
		public void AddPostKey(string FullPostBuffer) 
		{
			this.AddPostKey(null,FullPostBuffer );
		}

		/// <summary>
		/// Adds a fully self contained POST buffer to the request.
		/// Works for XML or previously encoded content.
		/// </summary>
		/// <param name="PostBuffer">Byte array of a full POST buffer</param>
		public void AddPostKey(byte[] FullPostBuffer) 
		{
			this.AddPostKey(null,FullPostBuffer);
		}

		/// <summary>
		/// Allows posting a file to the Web Server. Make sure that you 
		/// set PostMode
		/// </summary>
		/// <param name="Key"></param>
		/// <param name="FileName"></param>
		/// <returns></returns>
		public bool AddPostFile(string Key,string FileName) 
		{
			byte[] lcFile;	

			if (this._PostMode != HttpPostMode.MultiPart) 
			{
				this._ErrorMessage = "File upload allowed only with Multi-part forms";
				this._Error = true;
				return false;
			}

			try 
			{			
				FileStream loFile = new FileStream(FileName,System.IO.FileMode.Open,System.IO.FileAccess.Read);

				lcFile = new byte[loFile.Length];
				loFile.Read(lcFile,0,(int) loFile.Length);
				loFile.Close();
			}
			catch(Exception e) 
			{
				this._ErrorMessage = e.Message;
				this._Error = true;
				return false;
			}

			if (this._PostData == null) 
			{
				this._PostStream = new MemoryStream();
				this._PostData = new BinaryWriter(this._PostStream);
			}

			this._PostData.Write( Encoding.GetEncoding(1252).GetBytes(
				"--" + this._MultiPartBoundary + "\r\n"  + 
				"Content-Disposition: form-data; name=\"" + Key + "\"; filename=\"" + 
				new FileInfo(FileName).Name + "\"\r\n\r\n") );

			this._PostData.Write( lcFile );

			this._PostData.Write( Encoding.GetEncoding(1252).GetBytes("\r\n")) ;

			return true;
		}

		/// <summary>
		/// Return a the result from an HTTP Url into a StreamReader.
		/// Client code should call Close() on the returned object when done reading.
		/// </summary>
		/// <param name="Url">Url to retrieve.</param>
		/// <param name="WebRequest">An HttpWebRequest object that can be passed in with properties preset.</param>
		/// <returns></returns>
		public StreamReader GetUrlStream(string Url) 
		{
			Encoding enc;

			HttpWebResponse Response = this.GetUrlResponse(Url);
			if (Response == null)
				return null;
			
			try 
			{
				if (!string.IsNullOrEmpty(Response.CharacterSet) )
					enc = Encoding.GetEncoding(Response.CharacterSet);
				else
					enc = Encoding.GetEncoding(1252);
			}
			catch
			{
				// *** Invalid encoding passed
				enc = Encoding.GetEncoding(1252); 
			}
			
			// *** drag to a stream
			StreamReader strResponse = new StreamReader(Response.GetResponseStream(),enc); 
			return strResponse;
		}

		/// <summary>
		/// Return an HttpWebResponse object for a request. You can use the Response to
		/// read the result as needed. This is a low level method. Most of the other 'Get'
		/// methods call this method and process the results further.
		/// </summary>
		/// <remarks>Important: The Response object's Close() method must be called when you are done with the object.</remarks>
		/// <param name="Url">Url to retrieve.</param>
		/// <returns>An HttpWebResponse Object</returns>
		public HttpWebResponse GetUrlResponse(string Url)
		{
			this.Cancelled = false;
		
			try 
			{
				this._Error = false;
				this._ErrorMessage = "";
				this._Cancelled = false;

				if (this.WebRequest == null) 
				{
					this.WebRequest =  (HttpWebRequest) System.Net.WebRequest.Create(Url);
					this.WebRequest.Headers.Add("Cache","no-cache");
				}

				
				this.WebRequest.UserAgent = this._UserAgent;
				this.WebRequest.Timeout = this._ConnectTimeout * 1000;

				// *** Handle Security for the request
				if (this._Username.Length > 0) 
				{
					if (this._Username=="AUTOLOGIN")
						this.WebRequest.Credentials = CredentialCache.DefaultCredentials;
					else
						this.WebRequest.Credentials = new NetworkCredential(this._Username,this._Password);
				}

				// *** Handle Proxy Server configuration
				if (this._ProxyAddress.Length > 0) 
				{
					if (this._ProxyAddress == "DEFAULTPROXY") 
					{
                        this.WebRequest.Proxy = HttpWebRequest.DefaultWebProxy;
					}
					else 
					{
                        WebProxy Proxy = new WebProxy(this._ProxyAddress,true);
            
						if (this._ProxyBypass.Length > 0) 
						{
							Proxy.BypassList = this._ProxyBypass.Split(';');
						}

						if (this._ProxyUsername.Length > 0)
							Proxy.Credentials = new NetworkCredential(this._ProxyUsername,this._ProxyPassword);

						this.WebRequest.Proxy = Proxy;
					}
				}
				
				// *** Handle cookies - automatically re-assign 
				if (this._HandleCookies || (this._Cookies != null && this._Cookies.Count > 0)  )
				{
					this.WebRequest.CookieContainer = new CookieContainer();
					if (this._Cookies != null && this._Cookies.Count > 0) 
					{
						this.WebRequest.CookieContainer.Add(this._Cookies);
					}
				}

				// *** Deal with the POST buffer if any
				if (this._PostData != null) 
				{
					this.WebRequest.Method = "POST";
					switch (this._PostMode) 
					{
						case HttpPostMode.UrlEncoded:
							this.WebRequest.ContentType = "application/x-www-form-urlencoded";
							break;
						case HttpPostMode.MultiPart:
							this.WebRequest.ContentType = "multipart/form-data; boundary=" + this._MultiPartBoundary;
							this._PostData.Write( Encoding.GetEncoding(1252).GetBytes( "--" + this._MultiPartBoundary + "--\r\n" ) );
							break;
						case HttpPostMode.Xml:
							this.WebRequest.ContentType = "text/xml";
							break;
						case HttpPostMode.Raw:
							this.WebRequest.ContentType = "application/octet-stream";
							break;
						default:
							goto case HttpPostMode.UrlEncoded;
					}
					

					Stream loPostData = this.WebRequest.GetRequestStream();
					
					if (this.SendData == null)
						this._PostStream.WriteTo(loPostData);  // Simplest version - no events
					else 
						this.StreamPostBuffer(loPostData);     // Send in chunks and fire events

					//*** Close the memory stream
					this._PostStream.Close();
					this._PostStream = null;

					//*** Close the Binary Writer
					this._PostData.Close();
					this._PostData = null;

					//*** Close Request Stream
					loPostData.Close();

					// *** If user cancelled the 'upload' exit
					if (this.Cancelled) 
					{
						this.ErrorMessage = "HTTP Request was cancelled.";
						this.Error = true;
						return null;
					}
				}
		
				// *** Retrieve the response headers 
				HttpWebResponse Response = null;
				try
				{
					Response = (HttpWebResponse) this.WebRequest.GetResponse();
				}
				catch(WebException ex)
				{
					// *** Check for 500 error return - if so we still want to return a response
					// *** Client can check oHttp.WebResponse.StatusCode
					if (ex.Status == WebExceptionStatus.ProtocolError) 
					{
						Response = (HttpWebResponse) ex.Response;
					}
					else
						throw;
				}

				this._WebResponse = Response;
				
				// *** Close out the request - it cannot be reused
				this.WebRequest = null;

				// ** Save cookies the server sends
				if (this._HandleCookies)  
				{
					if (Response.Cookies.Count > 0)  
					{
						if (this._Cookies == null)  
						{
							this._Cookies = Response.Cookies;
						}
						else 
						{
							// ** If we already have cookies update the list
							foreach (Cookie oRespCookie in Response.Cookies)  
							{
								bool bMatch = false;
								foreach(Cookie oReqCookie in this._Cookies)  
								{
									if (oReqCookie.Name == oRespCookie.Name)  
									{
										oReqCookie.Value = oRespCookie.Value;
										bMatch = true;
										break; // 
									}
								} // for each ReqCookies
								if (!bMatch)
									this._Cookies.Add(oRespCookie);
							} // for each Response.Cookies
						}  // this.Cookies == null
					} // if Response.Cookie.Count > 0
				}  // if this.bHandleCookies = 0

				
				return Response;
			}
			catch(Exception e) 
			{
				if (this._ThrowExceptions) 
					throw e;

				this._ErrorMessage = e.Message;
				this._Error = true;
				return null;
			}
		}

		/// <summary>
		/// Sends the Postbuffer to the server
		/// </summary>
		/// <param name="PostData"></param>
		protected void StreamPostBuffer(Stream PostData) 
		{

				if ( this._PostStream.Length < this.BufferSize) 
				{
					this._PostStream.WriteTo(PostData);

					// *** Handle Send Data Even
					// *** Here just let it know we're done
					if (this.SendData != null) 
					{
						ReceiveDataEventArgs Args = new ReceiveDataEventArgs();
						Args.CurrentByteCount = this._PostStream.Length;
						Args.Done = true;
						this.SendData(this,Args);
					}
				}
				else 
				{
					// *** Send data up in 8k blocks
					byte[] Buffer = this._PostStream.GetBuffer();
					int lnSent = 0;
					int lnToSend = (int)  this._PostStream.Length;
					int lnCurrent = 1;
					while (true) 
					{
						if (lnToSend < 1 || lnCurrent < 1) 
						{
							if (this.SendData != null) 
							{
								ReceiveDataEventArgs Args = new ReceiveDataEventArgs();
								Args.CurrentByteCount = lnSent;
								Args.TotalBytes = Buffer.Length;
								Args.Done = true;
								this.SendData(this,Args);
							}
							break;
						}

						lnCurrent = lnToSend;

						if (lnCurrent > this.BufferSize) 
						{
							lnCurrent = BufferSize;
							lnToSend = lnToSend - lnCurrent;
						}
						else 
						{
							lnToSend = lnToSend - lnCurrent;
						}

						PostData.Write(Buffer,lnSent,lnCurrent);

						lnSent = lnSent + lnCurrent;

						if (this.SendData != null) 
						{
							ReceiveDataEventArgs Args = new ReceiveDataEventArgs();
							Args.CurrentByteCount = lnSent;
							Args.TotalBytes = Buffer.Length;
							if (Buffer.Length == lnSent) 
							{
								Args.Done = true;
								this.SendData(this,Args);
								break;
							}
							this.SendData(this,Args);

							if (Args.Cancel) 
							{
								this.Cancelled = true;
								break;
							}
						}
					}
				}
		}

		/// <summary>
		/// Retrieves the content of a Url into a string.
		/// </summary>
		/// <remarks>Fires the ReceiveData event</remarks>
		/// <param name="Url">Url to retrieve</param>
		/// <returns></returns>
		public string GetUrl(string Url) 
		{
			return this.GetUrl(Url,8192);
		}

		/// <summary>
		/// Retrieves the content of a Url into a string.
		/// </summary>
		/// <remarks>Fires the ReceiveData event</remarks>
		/// <param name="Url">Url to retrieve</param>
		/// <param name="BufferSize">Optional ReadBuffer Size</param>
		/// <returns></returns>
		public string GetUrl(string Url,long BufferSize) 
		{

			StreamReader oHttpResponse = this.GetUrlStream(Url);
			if (oHttpResponse == null)
				return "";

			long Size = this.BufferSize;
			if (this._WebResponse.ContentLength > 0)
				Size = this._WebResponse.ContentLength;
			else
				Size = 0;

			StringBuilder Writer = new StringBuilder((int) Size);
						
			char[] lcTemp = new char[BufferSize];

			ReceiveDataEventArgs Args = new ReceiveDataEventArgs();
			Args.TotalBytes = Size;

			Size = 1;
			int lnCount = 0;
			long lnTotalBytes = 0;

			while (Size > 0) 
			{
				Size = oHttpResponse.Read(lcTemp,0,(int) BufferSize);
				if (Size > 0) 
				{
					Writer.Append( lcTemp,0,(int) Size );
					lnCount++;
					lnTotalBytes += Size;

					// *** Raise an event if hooked up
					if (this.ReceiveData != null) 
					{
						/// *** Update the event handler
						Args.CurrentByteCount = lnTotalBytes;
						Args.NumberOfReads = lnCount;
						Args.CurrentChunk = lcTemp;
						this.ReceiveData(this,Args);

						// *** Check for cancelled flag
						if (Args.Cancel) 
						{
							this._Cancelled = true;
							goto CloseDown;
						}
					}
				}
				// Thread.Sleep(1);  // Give up a timeslice
			} // while


			CloseDown:
				oHttpResponse.Close();

			// *** Send Done notification
			if (this.ReceiveData != null && !Args.Cancel) 
			{
				// *** Update the event handler
				Args.Done = true;
				this.ReceiveData(this,Args);
			}

			return Writer.ToString();
		}

        /// <summary>
        /// Returns a partial response from the URL by specifying only 
        /// given number of bytes to retrieve. This can reduce network
        /// traffic and keep string formatting down if you are only 
        /// interested a small port at the top of the page. Also 
        /// returns full headers.
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="Size"></param>
        /// <returns></returns>
        public string GetUrlPartial(string Url, int Size)
        {
            StreamReader sr = GetUrlStream(Url);
            if (sr == null)
                return null;

            char[] InBuffer = new char[Size];

            sr.Read(InBuffer, 0, Size);
            sr.Close();

            return new string(InBuffer);
        }



		/// <summary>
		/// Retrieves URL into an Byte Array.
		/// </summary>
		/// <remarks>Fires the ReceiveData Event</remarks>
		/// <param name="Url">Url to read</param>
		/// <param name="BufferSize">Size of the buffer for each read. 0 = 8192</param>
		/// <returns></returns>
		public byte[] GetUrlBytes(string Url,long BufferSize) 
		{
			HttpWebResponse Response = this.GetUrlResponse(Url);
            if (Response == null)
                return null;

			BinaryReader oHttpResponse = 
				new BinaryReader(Response.GetResponseStream()); 
			
			if (oHttpResponse == null)
				return null;

			if (BufferSize < 1)
				BufferSize = 8192;

			long lnSize = BufferSize;
			if (Response.ContentLength > 0)
				lnSize = this._WebResponse.ContentLength;
			else
				lnSize = 0;

			byte[] Result = new byte[lnSize];
			byte[] lcTemp = new byte[BufferSize];

			ReceiveDataEventArgs oArgs = new ReceiveDataEventArgs();
			oArgs.TotalBytes = lnSize;

			lnSize = 1;
			int lnCount = 0;
			long lnTotalBytes = 0;

			while (lnSize > 0) 
			{
				if (lnTotalBytes + BufferSize >  this._WebResponse.ContentLength)
					BufferSize = this._WebResponse.ContentLength - lnTotalBytes; 

				lnSize = oHttpResponse.Read(Result,(int) lnTotalBytes,(int) BufferSize);
				if (lnSize > 0) 
				{
					lnCount++;
					lnTotalBytes += lnSize;

					// *** Raise an event if hooked up
					if (this.ReceiveData != null) 
					{
						/// *** Update the event handler
						oArgs.CurrentByteCount = lnTotalBytes;
						oArgs.NumberOfReads = lnCount;
						oArgs.CurrentChunk = null;  // don't send anything here
						this.ReceiveData(this,oArgs);

						// *** Check for cancelled flag
						if (oArgs.Cancel) 
						{
							this._Cancelled = true;
							goto CloseDown;
						}
					}
				}
			} // while


			CloseDown:
				oHttpResponse.Close();

			// *** Send Done notification
			if (this.ReceiveData != null && !oArgs.Cancel) 
			{
				// *** Update the event handler
				oArgs.Done = true;
				this.ReceiveData(this,oArgs);
			}

			return Result;
		}

		/// <summary>
		/// Writes the output from the URL request to a file firing events.
		/// </summary>
		/// <param name="Url">Url to fire</param>
		/// <param name="BufferSize">Buffersize - how often to fire events</param>
		/// <param name="OutputFile">File to write response to</param>
		/// <returns>true or false</returns>
		public bool GetUrlFile(string Url,long BufferSize,string OutputFile) 
		{
			byte[] Result = this.GetUrlBytes(Url,BufferSize);
			if (Result == null)
				return false;

			FileStream File = new FileStream(OutputFile,FileMode.OpenOrCreate,FileAccess.Write);
			File.Write(	Result,0,(int)this.WebResponse.ContentLength);
			File.Close();

			return true;
		}

		#region Events and Event Delegates and Arguments

		/// <summary>
		/// Fires progress events when receiving data from the server
		/// </summary>
		public event ReceiveDataDelegate ReceiveData;
		public delegate void ReceiveDataDelegate(object sender, ReceiveDataEventArgs e);

		/// <summary>
		/// Fires progress events when using GetUrlEvents() to retrieve a URL.
		/// </summary>
		public event ReceiveDataDelegate SendData;
		
		/// <summary>
		/// Event arguments passed to the ReceiveData event handler on each block of data sent
		/// </summary>
		public class ReceiveDataEventArgs 
		{
			/// <summary>
			/// Size of the cumulative bytes read in this request
			/// </summary>
			public long CurrentByteCount=0;

			/// <summary>
			/// The number of total bytes of this request
			/// </summary>
			public long TotalBytes = 0;

			/// <summary>
			/// The number of reads that have occurred - how often has this event been called.
			/// </summary>
			public int NumberOfReads = 0;
			
			/// <summary>
			/// The current chunk of data being read
			/// </summary>
			public char[] CurrentChunk;
			
			/// <summary>
			/// Flag set if the request is currently done.
			/// </summary>
			public bool Done = false;

			/// <summary>
			/// Flag to specify that you want the current request to cancel. This is a write-only flag
			/// </summary>
			public bool Cancel = false;
		}
		#endregion

	}

	/// <summary>
	/// Enumeration of the various HTTP POST modes supported by wwHttp
	/// </summary>
	
	public enum HttpPostMode 
	{
		UrlEncoded,
		MultiPart,
		Xml,
		Raw
	};


}
