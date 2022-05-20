using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using Microsoft.Win32;
using Microsoft.Win32.SafeHandles;

namespace IDKShopSpoofer
{
	// Token: 0x02000003 RID: 3
	internal class Helpers
	{
		// Token: 0x06000008 RID: 8 RVA: 0x00002254 File Offset: 0x00000454
		public static bool IsAdministrator()
		{
			return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002278 File Offset: 0x00000478
		public static string GenerateString(int size)
		{
			char[] array = new char[size];
			for (int i = 0; i < size; i++)
			{
				array[i] = "ABCDEF0123456789"[Helpers.rand.Next("ABCDEF0123456789".Length)];
			}
			return new string(array);
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000022C4 File Offset: 0x000004C4
		public static void SpoofMacAddress()
		{
			Console.WriteLine("");
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write("[*] - ");
			Console.ForegroundColor = ConsoleColor.Magenta;
			Console.Write("Current MAC Address: " + Helpers.CurrentMAC());
			Console.WriteLine("");
			string value = "00" + Helpers.GenerateString(10);
			RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4D36E972-E325-11CE-BFC1-08002BE10318}\\0012", true);
			registryKey.SetValue("NetworkAddress", value);
			registryKey.Close();
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write("[*] - ");
			Console.ForegroundColor = ConsoleColor.Magenta;
			Console.Write("MAC address changed to: " + Helpers.CurrentMAC());
			Console.WriteLine("");
		}

		// Token: 0x0600000B RID: 11 RVA: 0x0000237C File Offset: 0x0000057C
		public static string CurrentMAC()
		{
			RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4D36E972-E325-11CE-BFC1-08002BE10318}\\0012", true);
			string result = (string)registryKey.GetValue("NetworkAddress");
			registryKey.Close();
			return result;
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000023B4 File Offset: 0x000005B4
		public static void SpoofGUID()
		{
			Console.WriteLine("");
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write("[*] - ");
			Console.ForegroundColor = ConsoleColor.Magenta;
			Console.Write("Current GUID: " + Helpers.CurrentGUID());
			Console.WriteLine("");
			string value = Guid.NewGuid().ToString();
			RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
			registryKey = registryKey.OpenSubKey("SOFTWARE\\Microsoft\\Cryptography", true);
			registryKey.SetValue("MachineGuid", value);
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write("[*] - ");
			Console.ForegroundColor = ConsoleColor.Magenta;
			Console.Write("GUID changed to: " + Helpers.CurrentGUID());
			Console.WriteLine("");
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002474 File Offset: 0x00000674
		public static string CurrentGUID()
		{
			string text = "SOFTWARE\\Microsoft\\Cryptography";
			string text2 = "MachineGuid";
			string result;
			using (RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
			{
				using (RegistryKey registryKey2 = registryKey.OpenSubKey(text))
				{
					if (registryKey2 == null)
					{
						throw new KeyNotFoundException(string.Format("Key Not Found: {0}", text));
					}
					object value = registryKey2.GetValue(text2);
					if (value == null)
					{
						throw new IndexOutOfRangeException(string.Format("Index Not Found: {0}", text2));
					}
					result = value.ToString();
				}
			}
			return result;
		}

		// Token: 0x0600000E RID: 14 RVA: 0x0000251C File Offset: 0x0000071C
		public static void SpoofProductID()
		{
			Console.WriteLine("");
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write("[*] - ");
			Console.ForegroundColor = ConsoleColor.Magenta;
			Console.Write("Current ProductID: " + Helpers.CurrentProductID());
			Console.WriteLine("");
			string value = string.Concat(new string[]
			{
				Helpers.GenerateString(5),
				"-",
				Helpers.GenerateString(5),
				"-",
				Helpers.GenerateString(5),
				"-",
				Helpers.GenerateString(5)
			});
			RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
			registryKey = registryKey.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", true);
			registryKey.SetValue("ProductID", value);
			registryKey.Close();
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write("[*] - ");
			Console.ForegroundColor = ConsoleColor.Magenta;
			Console.Write("ProductID changed to: " + Helpers.CurrentProductID());
			Console.WriteLine("");
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002618 File Offset: 0x00000818
		public static string CurrentProductID()
		{
			string text = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion";
			string text2 = "ProductID";
			string result;
			using (RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
			{
				using (RegistryKey registryKey2 = registryKey.OpenSubKey(text))
				{
					if (registryKey2 == null)
					{
						throw new KeyNotFoundException(string.Format("Key Not Found: {0}", text));
					}
					object value = registryKey2.GetValue(text2);
					if (value == null)
					{
						throw new IndexOutOfRangeException(string.Format("Index Not Found: {0}", text2));
					}
					result = value.ToString();
				}
			}
			return result;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x000026C0 File Offset: 0x000008C0
		public static string GenerateDate(int size)
		{
			char[] array = new char[size];
			for (int i = 0; i < size; i++)
			{
				array[i] = "abcdef0123456789"[Helpers.random.Next("abcdef0123456789".Length)];
			}
			return new string(array);
		}

		// Token: 0x06000011 RID: 17 RVA: 0x0000270C File Offset: 0x0000090C
		public static void SpoofInstallTime()
		{
			Console.WriteLine("");
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write("[*] - ");
			Console.ForegroundColor = ConsoleColor.Magenta;
			Console.Write("Current install time: " + Helpers.CurrentInstallTime());
			Console.WriteLine("");
			string value = Helpers.GenerateDate(15);
			RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
			registryKey = registryKey.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", true);
			registryKey.SetValue("InstallTime", value);
			registryKey.Close();
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write("[*] - ");
			Console.ForegroundColor = ConsoleColor.Magenta;
			Console.Write("Install time changed to: " + Helpers.CurrentInstallTime());
			Console.WriteLine("");
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000027C8 File Offset: 0x000009C8
		public static string CurrentInstallTime()
		{
			string text = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion";
			string text2 = "InstallTime";
			string result;
			using (RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
			{
				using (RegistryKey registryKey2 = registryKey.OpenSubKey(text))
				{
					if (registryKey2 == null)
					{
						throw new KeyNotFoundException(string.Format("Key Not Found: {0}", text));
					}
					object value = registryKey2.GetValue(text2);
					if (value == null)
					{
						throw new IndexOutOfRangeException(string.Format("Index Not Found: {0}", text2));
					}
					result = value.ToString();
				}
			}
			return result;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002870 File Offset: 0x00000A70
		public static void SpoofInstallDate()
		{
			Console.WriteLine("");
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write("[*] - ");
			Console.ForegroundColor = ConsoleColor.Magenta;
			Console.Write("Current install date: " + Helpers.CurrentInstallDate());
			Console.WriteLine("");
			string value = Helpers.GenerateDate(8);
			RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
			registryKey = registryKey.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", true);
			registryKey.SetValue("InstallDate", value);
			registryKey.Close();
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write("[*] - ");
			Console.ForegroundColor = ConsoleColor.Magenta;
			Console.Write("New Install Date: " + Helpers.CurrentInstallDate());
			Console.WriteLine("");
		}

		// Token: 0x06000014 RID: 20 RVA: 0x0000292C File Offset: 0x00000B2C
		public static string CurrentInstallDate()
		{
			string text = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion";
			string text2 = "InstallDate";
			string result;
			using (RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
			{
				using (RegistryKey registryKey2 = registryKey.OpenSubKey(text))
				{
					if (registryKey2 == null)
					{
						throw new KeyNotFoundException(string.Format("Key Not Found: {0}", text));
					}
					object value = registryKey2.GetValue(text2);
					if (value == null)
					{
						throw new IndexOutOfRangeException(string.Format("Index Not Found: {0}", text2));
					}
					result = value.ToString();
				}
			}
			return result;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x000029D4 File Offset: 0x00000BD4
		public static void SpoofHwProfileGUID()
		{
			Console.WriteLine("");
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write("[*] - ");
			Console.ForegroundColor = ConsoleColor.Magenta;
			Console.Write("Current HwProfileGUID: " + Helpers.CurrentHwProfileGUID());
			Console.WriteLine("");
			string value = "{" + Guid.NewGuid().ToString() + "}";
			RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
			registryKey = registryKey.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\IDConfigDB\\Hardware Profiles\\0001", true);
			registryKey.SetValue("HwProfileGUID", value);
			registryKey.Close();
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write("[*] - ");
			Console.ForegroundColor = ConsoleColor.Magenta;
			Console.Write("New HwProfileGUID: " + Helpers.CurrentHwProfileGUID());
			Console.WriteLine("");
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002AAC File Offset: 0x00000CAC
		public static string CurrentHwProfileGUID()
		{
			string text = "SYSTEM\\CurrentControlSet\\Control\\IDConfigDB\\Hardware Profiles\\0001";
			string text2 = "HwProfileGUID";
			string result;
			using (RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
			{
				using (RegistryKey registryKey2 = registryKey.OpenSubKey(text))
				{
					if (registryKey2 == null)
					{
						throw new KeyNotFoundException(string.Format("Key Not Found: {0}", text));
					}
					object value = registryKey2.GetValue(text2);
					if (value == null)
					{
						throw new IndexOutOfRangeException(string.Format("Index Not Found: {0}", text2));
					}
					result = value.ToString();
				}
			}
			return result;
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002B54 File Offset: 0x00000D54
		public static void ChangeSerialNumber(char volume, uint newSerial)
		{
			var source = new <> f__AnonymousType0<string, int, int>[]
			{
				new
				{
					Name = "FAT32",
					NameOffs = 82,
					SerialOffs = 67
				},
				new
				{
					Name = "FAT",
					NameOffs = 54,
					SerialOffs = 39
				},
				new
				{
					Name = "NTFS",
					NameOffs = 3,
					SerialOffs = 72
				}
			};
			using (Helpers.Disk disk = new Helpers.Disk(volume))
			{
				byte[] sector = new byte[512];
				disk.ReadSector(0U, sector);
				var<> f__AnonymousType = source.FirstOrDefault(f => Helpers.Strncmp(f.Name, sector, f.NameOffs));
				if (<> f__AnonymousType == null)
				{
					throw new NotSupportedException("This file system is not supported");
				}
				uint num = newSerial;
				int i = 0;
				while (i < 4)
				{
					sector[<> f__AnonymousType.SerialOffs + i] = (byte)(num & 255U);
					i++;
					num >>= 8;
				}
				disk.WriteSector(0U, sector);
			}
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002C48 File Offset: 0x00000E48
		public static bool Strncmp(string str, byte[] data, int offset)
		{
			for (int i = 0; i < str.Length; i++)
			{
				if (data[i + offset] != (byte)str[i])
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002C84 File Offset: 0x00000E84
		public static void SpoofHWIDserial()
		{
			string text = Helpers.GenerateString(8);
			uint newSerial = uint.Parse(text, NumberStyles.HexNumber);
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("");
			Console.Write("[*] - ");
			Console.ForegroundColor = ConsoleColor.Magenta;
			Console.Write("HDD serial changing to: " + text + " - " + newSerial.ToString());
			Console.WriteLine("");
			Helpers.ChangeSerialNumber('C', newSerial);
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002CF4 File Offset: 0x00000EF4
		public static void SpoofPCName()
		{
			Console.WriteLine("");
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write("[*] - ");
			Console.ForegroundColor = ConsoleColor.Magenta;
			Console.Write("Current PC name: " + Helpers.CurrentPCName());
			Console.WriteLine("");
			RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
			registryKey = registryKey.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\ComputerName\\ActiveComputerName", true);
			registryKey.SetValue("ComputerName", "DESKTOP-" + Helpers.GenerateString(15));
			registryKey.Close();
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write("[*] - ");
			Console.ForegroundColor = ConsoleColor.Magenta;
			Console.Write("PC name spoofed to: " + Helpers.CurrentPCName());
			Console.WriteLine("");
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002DB8 File Offset: 0x00000FB8
		public static string CurrentPCName()
		{
			string text = "SYSTEM\\CurrentControlSet\\Control\\ComputerName\\ActiveComputerName";
			string text2 = "ComputerName";
			string result;
			using (RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
			{
				using (RegistryKey registryKey2 = registryKey.OpenSubKey(text))
				{
					if (registryKey2 == null)
					{
						throw new KeyNotFoundException(string.Format("Key Not Found: {0}", text));
					}
					object value = registryKey2.GetValue(text2);
					if (value == null)
					{
						throw new IndexOutOfRangeException(string.Format("Index Not Found: {0}", text2));
					}
					result = value.ToString();
				}
			}
			return result;
		}

		// Token: 0x04000004 RID: 4
		public static Random rand = new Random();

		// Token: 0x04000005 RID: 5
		public const string Alphabet = "ABCDEF0123456789";

		// Token: 0x04000006 RID: 6
		public static Random random = new Random();

		// Token: 0x04000007 RID: 7
		public const string Alphabet1 = "abcdef0123456789";

		// Token: 0x02000004 RID: 4
		private class Disk : IDisposable
		{
			// Token: 0x0600001E RID: 30 RVA: 0x00002E60 File Offset: 0x00001060
			public Disk(char volume)
			{
				IntPtr preexistingHandle = Helpers.Disk.CreateFile(string.Format("\\\\.\\{0}:", volume), FileAccess.ReadWrite, FileShare.ReadWrite, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero);
				this.handle = new SafeFileHandle(preexistingHandle, true);
				if (this.handle.IsInvalid)
				{
					Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
				}
			}

			// Token: 0x0600001F RID: 31 RVA: 0x00002EBC File Offset: 0x000010BC
			public void ReadSector(uint sector, byte[] buffer)
			{
				if (buffer == null)
				{
					throw new ArgumentNullException("buffer");
				}
				if (Helpers.Disk.SetFilePointer(this.handle, sector, IntPtr.Zero, Helpers.Disk.EMoveMethod.Begin) == 4294967295U)
				{
					Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
				}
				uint num;
				if (!Helpers.Disk.ReadFile(this.handle, buffer, buffer.Length, out num, IntPtr.Zero))
				{
					Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
				}
				if ((ulong)num != (ulong)((long)buffer.Length))
				{
					throw new IOException();
				}
			}

			// Token: 0x06000020 RID: 32 RVA: 0x00002F34 File Offset: 0x00001134
			public void WriteSector(uint sector, byte[] buffer)
			{
				if (buffer == null)
				{
					throw new ArgumentNullException("buffer");
				}
				if (Helpers.Disk.SetFilePointer(this.handle, sector, IntPtr.Zero, Helpers.Disk.EMoveMethod.Begin) == 4294967295U)
				{
					Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
				}
				uint num;
				if (!Helpers.Disk.WriteFile(this.handle, buffer, buffer.Length, out num, IntPtr.Zero))
				{
					Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
				}
				if ((ulong)num != (ulong)((long)buffer.Length))
				{
					throw new IOException();
				}
			}

			// Token: 0x06000021 RID: 33 RVA: 0x000020A3 File Offset: 0x000002A3
			public void Dispose()
			{
				this.Dispose(true);
				GC.SuppressFinalize(this);
			}

			// Token: 0x06000022 RID: 34 RVA: 0x00002FAC File Offset: 0x000011AC
			protected virtual void Dispose(bool disposing)
			{
				if (disposing && this.handle != null)
				{
					this.handle.Dispose();
				}
			}

			// Token: 0x06000023 RID: 35
			[DllImport("Kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
			public static extern IntPtr CreateFile(string fileName, [MarshalAs(UnmanagedType.U4)] FileAccess fileAccess, [MarshalAs(UnmanagedType.U4)] FileShare fileShare, IntPtr securityAttributes, [MarshalAs(UnmanagedType.U4)] FileMode creationDisposition, int flags, IntPtr template);

			// Token: 0x06000024 RID: 36
			[DllImport("Kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
			private static extern uint SetFilePointer([In] SafeFileHandle hFile, [In] uint lDistanceToMove, [In] IntPtr lpDistanceToMoveHigh, [In] Helpers.Disk.EMoveMethod dwMoveMethod);

			// Token: 0x06000025 RID: 37
			[DllImport("kernel32.dll", SetLastError = true)]
			private static extern bool ReadFile(SafeFileHandle hFile, [Out] byte[] lpBuffer, int nNumberOfBytesToRead, out uint lpNumberOfBytesRead, IntPtr lpOverlapped);

			// Token: 0x06000026 RID: 38
			[DllImport("kernel32.dll")]
			private static extern bool WriteFile(SafeFileHandle hFile, [In] byte[] lpBuffer, int nNumberOfBytesToWrite, out uint lpNumberOfBytesWritten, [In] IntPtr lpOverlapped);

			// Token: 0x04000008 RID: 8
			private SafeFileHandle handle;

			// Token: 0x04000009 RID: 9
			private const uint INVALID_SET_FILE_POINTER = 4294967295U;

			// Token: 0x02000005 RID: 5
			private enum EMoveMethod : uint
			{
				// Token: 0x0400000B RID: 11
				Begin,
				// Token: 0x0400000C RID: 12
				Current,
				// Token: 0x0400000D RID: 13
				End
			}
		}
	}
}
