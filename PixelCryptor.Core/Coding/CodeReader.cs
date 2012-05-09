#region Using directives
using System;
using System.Globalization;
using System.IO;
using System.Text;
using PixelCryptor.Core.Structure;
#endregion

namespace PixelCryptor.Core.Coding {
	internal class CodeReader : IDisposable	{
		#region Fields
		private Protocol _protocol;
		private Coder _coder;
		private FileStream _codeStream;
		private byte[] _buffer;
		private Decoder _decoder;
		private int _maxCharSize;
		#endregion

		#region Properties
		/// <summary>
		/// Gets the protocol associated with this reader.
		/// </summary>
		internal Protocol Protocol {
			get { return this._protocol; }
		}

		/// <summary>
		/// Gets or sets the current reading position of the stream.
		/// </summary>
		internal long CurrentPosition {
			get { return this._codeStream.Position; }
			set { this._codeStream.Position = value; }
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Creates a CodeReader for the given parameters.
		/// </summary>
		internal CodeReader(string keyPath, string codeFilePath) {
			// Open stream
			this._codeStream = File.Open(codeFilePath, FileMode.Open, FileAccess.Read);

			// Get protocol
			this._coder = Coder.GetCoder(CoderVersion.Fox, keyPath);
			this._protocol = Protocol.GetProtocol(this, keyPath);
			this._coder = this._protocol.Coder;

			// Get encoding to use
			Encoding encodingToUse = new UTF8Encoding();
			this._decoder = encodingToUse.GetDecoder();
			this._maxCharSize = encodingToUse.GetMaxCharCount(0x80);
		}

		/// <summary>
		/// Disposes the CodeReader, closes any open streams.
		/// </summary>
		public void Dispose() {
			// Clear the code stream
			if (this._codeStream != null)
				this._codeStream.Close();
		}
		#endregion

		#region Methods
		/// <summary>
		/// Returns the next byte from the stream.
		/// </summary>
		private byte Read() {
			return this._coder.Recode((byte) this._codeStream.ReadByte());
		}

		/// <summary>
		/// Returns bytes from the stream.
		/// </summary>
		internal byte[] Read(int count) {
			byte[] result = new byte[count];
			this._codeStream.Read(result, 0, count);
			for (int i = 0; i < count; i++)
				result[i] = this._coder.Recode(result[i]);

			return result;
		}

		/// <summary>
		/// Fills the buffer with the requested amount of bytes.
		/// </summary>
		private void FillBuffer(int count) {
			this._buffer = this.Read(count);
		}
		#endregion

		#region Type Methods
		/// <summary>
		/// Reads a 7bit encoded int from the string.
		/// </summary>
		private Int32 Read7BitEncodedInt() {
			int num1 = 0;
			int num2 = 0;
			byte num3;

			while (true) {
				if (num2 == 35)
					throw new FormatException("Ahoengha, 7bit to Int32 failed...");

				num3 = this.Read();
				num1 |= (num3 & 127) << (num2 & 31);
				num2 += 7;
				if ((num3 & 128) == 0)
					return num1;
			}
		}

		/// <summary>
		/// Reads and decodes an int from the stream.
		/// </summary>
		internal virtual Int32 ReadInt32() {
			this.FillBuffer(4);
			return (((this._buffer[0] | (this._buffer[1] << 8)) | (this._buffer[2] << 0x10)) | (this._buffer[3] << 0x18));
		}

		/// <summary>
		/// Reads and decodes a long from the stream.
		/// </summary>
		internal virtual Int64 ReadInt64() {
			return Convert.ToInt64(this.ReadString());
		}

		/// <summary>
		/// Reads a string from the stream.
		/// </summary>
		internal virtual string ReadString() {
			// Get the amount of bytes in this string
			int bytesInString = this.Read7BitEncodedInt();

			// Fill the buffer with the bytes associated with the string
			this.FillBuffer(bytesInString);

			// Create string result array
			char[] chars = new char[this._decoder.GetCharCount(this._buffer, 0, bytesInString)];

			// Get chars
			this._decoder.GetChars(this._buffer, 0, bytesInString, chars, 0, true);

			// Return result
			return new String(chars);
		}

		/// <summary>
		/// Reads and decodes an unsigned short from the stream.
		/// </summary>
		internal virtual UInt16 ReadUInt16() {
			this.FillBuffer(2);
			return (ushort)(this._buffer[0] | (this._buffer[1] << 8));
		}

		/// <summary>
		/// Reads and decodes an unsigned int from the stream.
		/// </summary>
		internal virtual UInt32 ReadUInt32() {
			this.FillBuffer(4);
			return (uint)(((this._buffer[0] | (this._buffer[1] << 8)) | (this._buffer[2] << 0x10)) | (this._buffer[3] << 0x18));
		}
		#endregion
	}
}
