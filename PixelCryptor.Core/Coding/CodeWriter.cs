#region Using directives
using System;
using System.Globalization;
using System.IO;
using System.Text;
using PixelCryptor.Core.Structure;
#endregion

namespace PixelCryptor.Core.Coding {
	internal class CodeWriter : IDisposable	{
		#region Fields
		private Protocol _protocol;
		private Coder _coder;
		private FileStream _codeStream;
		private byte[] _buffer;
		private Encoder _encoder;
		#endregion

		#region Properties
		/// <summary>
		/// Gets the protocol associated with this reader.
		/// </summary>
		internal Protocol Protocol {
			get { return this._protocol; }
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Creates a CodeWriter for the given parameters.
		/// </summary>
		internal CodeWriter(ProtocolVersion protocolVersion, string keyPath, string codeFilePath) {
			// Delete any existing code files
			if (File.Exists(codeFilePath))
				File.Delete(codeFilePath);

			// Open stream
			_codeStream = File.OpenWrite(codeFilePath);

			// Write protocol version
			_coder = Coder.GetDefaultCoder(keyPath);
			Protocol.SaveProtocol(protocolVersion, this);

			// Get protocol and coder
			_protocol = new Protocol(protocolVersion, keyPath);
			_coder = this._protocol.Coder;

			// Get encoding to use
			UTF8Encoding encodingToUse = new UTF8Encoding();
			_encoder = encodingToUse.GetEncoder();
		}

		/// <summary>
		/// Disposes the CodeWriter, closes any open streams.
		/// </summary>
		public void Dispose() {
			// Clear the code stream
			if (this._codeStream != null) {
				this._codeStream.Flush();
				this._codeStream.Close();
			}
		}
		#endregion

		#region Methods
		/// <summary>
		/// Writes and encodes the buffer to the stream.
		/// </summary>
		private void Write() {
			Write(_buffer);
		}

		/// <summary>
		/// Writes and encodes an array of bytes to the stream.
		/// </summary>
		internal void Write(byte[] bytes) {
			for (int i = 0; i < bytes.Length; i++)
				bytes[i] = _coder.Recode(bytes[i]);
			_codeStream.Write(bytes, 0, bytes.Length);
			_codeStream.Flush();
		}

		/// <summary>
		/// Writes and encodes a byte to the stream.
		/// </summary>
		private void Write(byte value) {
			_codeStream.WriteByte(_coder.Recode(value));
			_codeStream.Flush();
		}
		#endregion

		#region Type Methods
		/// <summary>
		/// Writes a 7bit encoded int from the string.
		/// </summary>
		private void Write7BitEncodedInt(Int32 value) {
			uint num1 = (uint)value;
			while (num1 >= 0x80) {
				this.Write((byte)(num1 | 0x80));
				num1 = num1 >> 7;
			}
			this.Write((byte)num1);
		}

		/// <summary>
		/// Writes and encodes an int to the stream.
		/// </summary>
		internal virtual void Write(Int32 value) {
			this._buffer = new byte[4];
			this._buffer[0] = (byte) value;
			this._buffer[1] = (byte) (value >> 8);
			this._buffer[2] = (byte) (value >> 0x10);
			this._buffer[3] = (byte) (value >> 0x18);
			this.Write();
		}

		/// <summary>
		/// Writes and encodes a long to the stream.
		/// </summary>
		internal virtual void Write(Int64 value) {
			this.Write(value.ToString());
		}

		/// <summary>
		/// Writes and encodes a string to the stream.
		/// </summary>
		internal virtual void Write(String value) {
			// Validate input
			if (value == null)
				throw new ArgumentNullException("value");

			// Create char array for string
			char[] chars = value.ToCharArray();

			// Get the amount of bytes in this string
			int bytesInString = this._encoder.GetByteCount(chars, 0, chars.Length, true);

			// Write the amount of bytes in the string, for proper decoding
			this.Write7BitEncodedInt(bytesInString);

			// Create right sized buffer for result
			this._buffer = new byte[bytesInString];

			// Fill buffer with string
			this._encoder.GetBytes(chars, 0, chars.Length, this._buffer, 0, true);

			// Write buffer to stream
			this.Write();
		}

		/// <summary>
		/// Writes and encodes an unsigned short to the stream.
		/// </summary>
		internal virtual void Write(UInt16 value) {
			this._buffer = new byte[2];
			this._buffer[0] = (byte)value;
			this._buffer[1] = (byte)(value >> 8);
			this.Write();
		}

		/// <summary>
		/// Writes and encodes an unsigned int to the stream.
		/// </summary>
		internal virtual void Write(UInt32 value) {
			this._buffer = new byte[4];
			this._buffer[0] = (byte)value;
			this._buffer[1] = (byte)(value >> 8);
			this._buffer[2] = (byte)(value >> 0x10);
			this._buffer[3] = (byte)(value >> 0x18);
			this.Write();
		}
		#endregion
	}
}
