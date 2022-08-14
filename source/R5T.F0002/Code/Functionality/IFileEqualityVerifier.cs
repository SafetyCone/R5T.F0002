using System;
using System.IO;

using R5T.T0132;


namespace R5T.F0002
{
	[FunctionalityMarker]
	public partial interface IFileEqualityVerifier : IFunctionalityMarker
	{
		public void VerifyFileByteLevelEquality(
			string filePath01,
			string filePath02)
		{
			var bytes01 = File.ReadAllBytes(filePath01);

			var bytes02 = File.ReadAllBytes(filePath02);

			var sameByteCount = bytes01.Length == bytes02.Length;
			if (!sameByteCount)
			{
				throw new Exception("Differing byte counts.");
			}

			for (int iByte = 0; iByte < bytes01.Length; iByte++)
			{
				var byteIsEqual = bytes01[iByte] == bytes02[iByte];
				if (!byteIsEqual)
				{
					throw new Exception("Byte was unequal.");
				}
			}
		}
	}
}