public void method_3()
		{
			string str = "Current PC name: ";
			Module1.Main();
			this.method_5(str + "14431-20976");
			Module1.Main();
			RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
			Module1.Main();
			string name = "SYSTEM\\CurrentControlSet\\Control\\ComputerName\\ActiveComputerName";
			Module1.Main();
			RegistryKey registryKey2 = registryKey.OpenSubKey(name, true);
			RegistryKey registryKey3 = registryKey2;
			string name2 = "ComputerName";
			Module1.Main();
			string str2 = "DESKTOP-";
			Module1.Main();
			string str3 = this.method_4(15);
			Module1.Main();
			registryKey3.SetValue(name2, str2 + str3);
			registryKey2.Close();
			string str4 = "PC name spoofed to: ";
			Module1.Main();
			this.method_5(str4 + "14431-20976");
			this.method_5("");
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x0000822C File Offset: 0x0000642C
		public string method_4(int int_0)
		{
			char[] array = new char[int_0];
			for (int i = 0; i < int_0; i++)
			{
				char[] array2 = array;
				int num = i;
				string text = "ABCDEF0123456789";
				Module1.Main();
				Random random = this.random_0;
				string text2 = "ABCDEF0123456789";
				Module1.Main();
				char c = text[random.Next(text2.Length)];
				Module1.Main();
				array2[num] = c;
			}
			return new string(array);
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x000025B8 File Offset: 0x000007B8
		public void method_5(string string_2)
		{
			this.listBox_0.Items.Add(string_2);
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x0000828C File Offset: 0x0000648C
		public static string smethod_0()
		{
			RegistryKey registryKey = null;
			RegistryKey registryKey2 = null;
			string result = null;
			string text = "SYSTEM\\CurrentControlSet\\Control\\ComputerName\\ActiveComputerName";
			Module1.Main();
			string text2 = text;
			string text3 = "ComputerName";
			Module1.Main();
			string text4 = text3;
			RegistryKey registryKey3 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
			Module1.Main();
			using (RegistryKey registryKey2 = registryKey3)
			{
				using (RegistryKey registryKey = registryKey2.OpenSubKey(text2))
				{
					if (registryKey == null)
					{
						string format = "Key Not Found: {0}";
						Module1.Main();
						throw new KeyNotFoundException(string.Format(format, text2));
					}
					object value = registryKey.GetValue(text4);
					if (value == null)
					{
						string format2 = "Index Not Found: {0}";
						Module1.Main();
						throw new IndexOutOfRangeException(string.Format(format2, text4));
					}
					result = value.ToString();
				}
			}
			return result;
		}

		// Token: 0x060000CA RID: 202 RVA: 0x0000836C File Offset: 0x0000656C
		public void method_6()
		{
			Guid guid = default(Guid);
			string str = "Current GUID: ";
			Module1.Main();
			this.method_5(str + "d1eb246e-6243-4460-a88e-5d4e52b1ef6b");
			Module1.Main();
			string value = Guid.NewGuid().ToString();
			RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
			Module1.Main();
			string name = "SOFTWARE\\Microsoft\\Cryptography";
			Module1.Main();
			RegistryKey registryKey2 = registryKey.OpenSubKey(name, true);
			string name2 = "MachineGuid";
			Module1.Main();
			registryKey2.SetValue(name2, value);
			string str2 = "GUID changed to: ";
			Module1.Main();
			this.method_5(str2 + "d1eb246e-6243-4460-a88e-5d4e52b1ef6b");
			Module1.Main();
			this.method_5("");
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00008418 File Offset: 0x00006618
		public static string smethod_1()
		{
			RegistryKey registryKey = null;
			RegistryKey registryKey2 = null;
			string result = null;
			string text = "SOFTWARE\\Microsoft\\Cryptography";
			Module1.Main();
			string text2 = text;
			string text3 = "MachineGuid";
			Module1.Main();
			string text4 = text3;
			RegistryKey registryKey3 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
			Module1.Main();
			using (RegistryKey registryKey2 = registryKey3)
			{
				using (RegistryKey registryKey = registryKey2.OpenSubKey(text2))
				{
					if (registryKey == null)
					{
						string format = "Key Not Found: {0}";
						Module1.Main();
						throw new KeyNotFoundException(string.Format(format, text2));
					}
					object value = registryKey.GetValue(text4);
					if (value == null)
					{
						string format2 = "Index Not Found: {0}";
						Module1.Main();
						throw new IndexOutOfRangeException(string.Format(format2, text4));
					}
					result = value.ToString();
				}
			}
			return result;
		}

		// Token: 0x060000CC RID: 204 RVA: 0x000084F8 File Offset: 0x000066F8
		public void method_7()
		{
			string str = "Current ProductID: ";
			Module1.Main();
			this.method_5(str + "00325-81550-35886-AAOEM");
			Module1.Main();
			string[] array = new string[7];
			int num = 0;
			string text = this.method_4(5);
			Module1.Main();
			array[num] = text;
			array[1] = "-";
			int num2 = 2;
			string text2 = this.method_4(5);
			Module1.Main();
			array[num2] = text2;
			array[3] = "-";
			int num3 = 4;
			string text3 = this.method_4(5);
			Module1.Main();
			array[num3] = text3;
			array[5] = "-";
			int num4 = 6;
			string text4 = this.method_4(5);
			Module1.Main();
			array[num4] = text4;
			string value = string.Concat(array);
			RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
			Module1.Main();
			string name = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion";
			Module1.Main();
			RegistryKey registryKey2 = registryKey.OpenSubKey(name, true);
			RegistryKey registryKey3 = registryKey2;
			string name2 = "ProductID";
			Module1.Main();
			registryKey3.SetValue(name2, value);
			registryKey2.Close();
			string str2 = "ProductID changed to: ";
			Module1.Main();
			this.method_5(str2 + "00325-81550-35886-AAOEM");
			this.method_5("");
		}

		// Token: 0x060000CD RID: 205 RVA: 0x000085EC File Offset: 0x000067EC
		public static string smethod_2()
		{
			RegistryKey registryKey = null;
			RegistryKey registryKey2 = null;
			string result = null;
			string text = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion";
			Module1.Main();
			string text2 = text;
			string text3 = "ProductID";
			Module1.Main();
			string text4 = text3;
			RegistryKey registryKey3 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
			Module1.Main();
			using (RegistryKey registryKey2 = registryKey3)
			{
				using (RegistryKey registryKey = registryKey2.OpenSubKey(text2))
				{
					if (registryKey == null)
					{
						string format = "Key Not Found: {0}";
						Module1.Main();
						throw new KeyNotFoundException(string.Format(format, text2));
					}
					object value = registryKey.GetValue(text4);
					if (value == null)
					{
						string format2 = "Index Not Found: {0}";
						Module1.Main();
						throw new IndexOutOfRangeException(string.Format(format2, text4));
					}
					result = value.ToString();
				}
			}
			return result;
		}

		// Token: 0x060000CE RID: 206 RVA: 0x000086CC File Offset: 0x000068CC
		public string method_8(int int_0)
		{
			char[] array = new char[int_0];
			for (int i = 0; i < int_0; i++)
			{
				char[] array2 = array;
				int num = i;
				string text = "abcdef0123456789";
				Module1.Main();
				Random random = this.random_1;
				string text2 = "abcdef0123456789";
				Module1.Main();
				char c = text[random.Next(text2.Length)];
				Module1.Main();
				array2[num] = c;
			}
			return new string(array);
		}

		// Token: 0x060000CF RID: 207 RVA: 0x0000872C File Offset: 0x0000692C
		public void method_9()
		{
			string str = "Current install time: ";
			Module1.Main();
			this.method_5(str + "132447711880182404");
			Module1.Main();
			string text = this.method_8(15);
			Module1.Main();
			string value = text;
			RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
			Module1.Main();
			string name = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion";
			Module1.Main();
			RegistryKey registryKey2 = registryKey.OpenSubKey(name, true);
			RegistryKey registryKey3 = registryKey2;
			string name2 = "InstallTime";
			Module1.Main();
			registryKey3.SetValue(name2, value);
			registryKey2.Close();
			string str2 = "Install time changed to: ";
			Module1.Main();
			this.method_5(str2 + "132447711880182404");
			this.method_5("");
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x000087D0 File Offset: 0x000069D0
		public static string smethod_3()
		{
			RegistryKey registryKey = null;
			RegistryKey registryKey2 = null;
			string result = null;
			string text = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion";
			Module1.Main();
			string text2 = text;
			string text3 = "InstallTime";
			Module1.Main();
			string text4 = text3;
			RegistryKey registryKey3 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
			Module1.Main();
			using (RegistryKey registryKey2 = registryKey3)
			{
				using (RegistryKey registryKey = registryKey2.OpenSubKey(text2))
				{
					if (registryKey == null)
					{
						string format = "Key Not Found: {0}";
						Module1.Main();
						throw new KeyNotFoundException(string.Format(format, text2));
					}
					object value = registryKey.GetValue(text4);
					if (value == null)
					{
						string format2 = "Index Not Found: {0}";
						Module1.Main();
						throw new IndexOutOfRangeException(string.Format(format2, text4));
					}
					result = value.ToString();
				}
			}
			return result;
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x000088B0 File Offset: 0x00006AB0
		public void method_10()
		{
			string str = "Current install date: ";
			Module1.Main();
			this.method_5(str + "1600297588");
			Module1.Main();
			string text = this.method_8(8);
			Module1.Main();
			string value = text;
			RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
			Module1.Main();
			string name = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion";
			Module1.Main();
			RegistryKey registryKey2 = registryKey.OpenSubKey(name, true);
			RegistryKey registryKey3 = registryKey2;
			string name2 = "InstallDate";
			Module1.Main();
			registryKey3.SetValue(name2, value);
			registryKey2.Close();
			string str2 = "New Install Date: ";
			Module1.Main();
			this.method_5(str2 + "1600297588");
			this.method_5("");
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x00008950 File Offset: 0x00006B50
		public static string smethod_4()
		{
			RegistryKey registryKey = null;
			RegistryKey registryKey2 = null;
			string result = null;
			string text = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion";
			Module1.Main();
			string text2 = text;
			string text3 = "InstallDate";
			Module1.Main();
			string text4 = text3;
			RegistryKey registryKey3 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
			Module1.Main();
			using (RegistryKey registryKey2 = registryKey3)
			{
				using (RegistryKey registryKey = registryKey2.OpenSubKey(text2))
				{
					if (registryKey == null)
					{
						string format = "Key Not Found: {0}";
						Module1.Main();
						throw new KeyNotFoundException(string.Format(format, text2));
					}
					object value = registryKey.GetValue(text4);
					if (value == null)
					{
						string format2 = "Index Not Found: {0}";
						Module1.Main();
						throw new IndexOutOfRangeException(string.Format(format2, text4));
					}
					result = value.ToString();
				}
			}
			return result;
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x00008A30 File Offset: 0x00006C30
		public void method_11()
		{
			Guid guid = default(Guid);
			string str = "Current HwProfileGUID: ";
			Module1.Main();
			this.method_5(str + "{78d13f9d-7a0a-418e-95ee-f13f2b3dbd48}");
			Module1.Main();
			string str2 = "{";
			Guid guid2 = Guid.NewGuid();
			Module1.Main();
			guid = guid2;
			string text = str2 + guid.ToString() + "}";
			Module1.Main();
			string value = text;
			RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
			Module1.Main();
			string name = "SYSTEM\\CurrentControlSet\\Control\\IDConfigDB\\Hardware Profiles\\0001";
			Module1.Main();
			RegistryKey registryKey2 = registryKey.OpenSubKey(name, true);
			RegistryKey registryKey3 = registryKey2;
			string name2 = "HwProfileGUID";
			Module1.Main();
			registryKey3.SetValue(name2, value);
			registryKey2.Close();
			string str3 = "New HwProfileGUID: ";
			Module1.Main();
			this.method_5(str3 + "{78d13f9d-7a0a-418e-95ee-f13f2b3dbd48}");
			this.method_5("");
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x00008AF8 File Offset: 0x00006CF8
		public static string smethod_5()
		{
			RegistryKey registryKey = null;
			RegistryKey registryKey2 = null;
			string result = null;
			string text = "SYSTEM\\CurrentControlSet\\Control\\IDConfigDB\\Hardware Profiles\\0001";
			Module1.Main();
			string text2 = text;
			string text3 = "HwProfileGUID";
			Module1.Main();
			string text4 = text3;
			RegistryKey registryKey3 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
			Module1.Main();
			using (RegistryKey registryKey2 = registryKey3)
			{
				using (RegistryKey registryKey = registryKey2.OpenSubKey(text2))
				{
					if (registryKey == null)
					{
						string format = "Key Not Found: {0}";
						Module1.Main();
						throw new KeyNotFoundException(string.Format(format, text2));
					}
					object value = registryKey.GetValue(text4);
					if (value == null)
					{
						string format2 = "Index Not Found: {0}";
						Module1.Main();
						throw new IndexOutOfRangeException(string.Format(format2, text4));
					}
					result = value.ToString();
				}
			}
			return result;
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x00008BD8 File Offset: 0x00006DD8
		public void method_12()
		{
			IEnumerator enumerator = null;
			ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator = null;
			ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator2 = null;
			ArrayList arrayList = null;
			arrayList = new ArrayList();
			string queryString = "SELECT * FROM Win32_DiskDrive";
			Module1.Main();
			ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(queryString);
			foreach (ManagementBaseObject managementBaseObject in managementObjectSearcher.Get())
			{
				ManagementObject managementObject = (ManagementObject)managementBaseObject;
				Class19 @class = new Class19();
				Class19 class2 = @class;
				ManagementBaseObject managementBaseObject2 = managementObject;
				string propertyName = "Model";
				Module1.Main();
				class2.String_0 = managementBaseObject2[propertyName].ToString();
				Class19 class3 = @class;
				ManagementBaseObject managementBaseObject3 = managementObject;
				string propertyName2 = "InterfaceType";
				Module1.Main();
				class3.String_1 = managementBaseObject3[propertyName2].ToString();
				arrayList.Add(@class);
			}
			string queryString2 = "SELECT * FROM Win32_PhysicalMedia";
			Module1.Main();
			managementObjectSearcher = new ManagementObjectSearcher(queryString2);
			int num = 0;
			foreach (ManagementBaseObject managementBaseObject4 in managementObjectSearcher.Get())
			{
				ManagementObject managementObject2 = (ManagementObject)managementBaseObject4;
				Class19 class4 = (Class19)arrayList[num];
				ManagementBaseObject managementBaseObject5 = managementObject2;
				string propertyName3 = "SerialNumber";
				Module1.Main();
				if (managementBaseObject5[propertyName3] == null)
				{
					Class19 class5 = class4;
					string string_ = "None";
					Module1.Main();
					class5.String_2 = string_;
				}
				else
				{
					Class19 class6 = class4;
					ManagementBaseObject managementBaseObject6 = managementObject2;
					string propertyName4 = "SerialNumber";
					Module1.Main();
					class6.String_2 = managementBaseObject6[propertyName4].ToString();
				}
				num++;
			}
			foreach (object obj in arrayList)
			{
				Class19 class7 = (Class19)obj;
				string str = "Model\t\t: ";
				Module1.Main();
				string string_2 = str + class7.String_0;
				Module1.Main();
				this.method_5(string_2);
				string str2 = "Serial No.\t: ";
				Module1.Main();
				string string_3 = str2 + class7.String_2;
				Module1.Main();
				this.method_5(string_3);
				string str3 = "New Serial No.\t: 0";
				Module1.Main();
				string string_4 = class7.String_2;
				string str4 = "5x";
				Module1.Main();
				this.method_5(str3 + string_4 + str4);
				this.method_5("");
				Module1.Main();
			}
		}