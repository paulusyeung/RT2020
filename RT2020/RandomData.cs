using System;
using System.Drawing;
using System.Collections;
using System.Reflection;
using System.Drawing.Design;
using System.ComponentModel;

namespace RT2020
{
	/// <summary>
	/// Summary description for RandomData.
	/// </summary>
	//[Serializable()]
	public class RandomData
	{
		private Random mobjRandom;


		public RandomData()
		{
			mobjRandom = new Random(0);
		}

		public bool GetBoolean()
		{
			
			return mobjRandom.NextDouble()>0.5;
		}

		public string GetSize()
		{
			return mobjRandom.Next(1,2000).ToString()+"kb";
		}

		public DateTime GetDate()
		{
			return DateTime.Now.AddDays((double)mobjRandom.Next(-100,100));
		}


		public int GetInteger(int intMin, int intMax)
		{
			return mobjRandom.Next(intMin,intMax);
		}

		public string[] GetStrings(int intMax)
		{
			return this.GetStrings("String ","",intMax);
		}

		public string[] GetStrings(string strPrefix,int intMax)
		{
			return this.GetStrings(strPrefix,"",intMax);
		}

		public string[] GetStrings(string strPrefix,string strSufix,int intMax)
		{
			ArrayList objStrings = new ArrayList();
			for(int i=0;i<intMax;i++)
			{
				objStrings.Add(string.Concat(strPrefix,i.ToString(),strSufix));
			}
			return (string[])objStrings.ToArray(typeof(string));
		}

        public string[] GetAlphabeticOrderedStrings(int intMax)
        {
            int         intLength       = 0;
            SortedList  colStrings      = new SortedList(intMax);
            string      strPreviousWord = "A";
            string      strCurrentWord  = "A";

            if(intMax>0)
            {
                // Create the first word (as "A")
                colStrings.Add(strCurrentWord, null);
            }

            // Build the requested number of words (minus the one pre-created)
            for (int i = 1; i < intMax; i++)
            {
                int     j               = intLength;
                bool    blnAdvanced     = false;

                // Build a word
                for (j = intLength; j >= 0 && !blnAdvanced; j--)
                {
                    // In case the current letter is Z, restart with A
                    if (strPreviousWord[j] == 'Z')
                    {
                        strCurrentWord = strCurrentWord.Insert(j, "A").Remove(j + 1, 1);

                        // In case the restarted letter was the first -> extend the string
                        if (j == 0)
                        {
                            intLength++;
                            strCurrentWord = string.Format("A{0}", strCurrentWord);
                        }
                    }
                    else
                    {
                        // Replace the old letter with an advanced one ('A'->'B', 'B'->'C' etc)
                        strCurrentWord = strCurrentWord.Insert(j, ((char)((int)strPreviousWord[j] + 1)).ToString()).Remove(j + 1, 1);

                        // Cause loop stop, since building word is done
                        blnAdvanced = true;
                    }
                }

                // Save as previous word
                strPreviousWord = strCurrentWord;

                // Append to list
                colStrings.Add(strCurrentWord,null);
            }

            // Create the sorted keys as ArrayList
            ArrayList colKeys = new ArrayList(colStrings.Keys);

            // Convert the ArrayList to string[] and return
            return (string[])colKeys.ToArray(typeof(string));
        }

        public static Color[] GetWebColors()
		{
			return GetConstants(typeof(Color));
		}

		public static Color[] GetSystemColors()
		{
			return GetConstants(typeof(SystemColors));
		}

		private static Color[] GetConstants(Type enumType)
		{
			MethodAttributes attributes1 = MethodAttributes.Static | MethodAttributes.Public;
			PropertyInfo[] infoArray1 = enumType.GetProperties();
			ArrayList list1 = new ArrayList();
			for (int num1 = 0; num1 < infoArray1.Length; num1++)
			{
				PropertyInfo info1 = infoArray1[num1];
				if (info1.PropertyType == typeof(Color))
				{
					MethodInfo info2 = info1.GetGetMethod();
					if ((info2 != null) && ((info2.Attributes & attributes1) == attributes1))
					{
						object[] objArray1 = null;
						list1.Add(info1.GetValue(null, objArray1));
					}
				}
			}
			return (Color[])list1.ToArray(typeof(Color));
		}
	}
}
