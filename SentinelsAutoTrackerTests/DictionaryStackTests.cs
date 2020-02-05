//----------------------------------------------------
// Copyright 2019 Epic Systems Corporation
//----------------------------------------------------

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SentinelsAutoTrackerEngine;

namespace CustomDataStructuresTests
{
	[TestClass]
	public class DictionaryStackTests
	{
		[TestMethod]
		public void PushOneTest()
		{
			DictionaryStack<int, string> dictStack = new DictionaryStack<int, string>();
			try
			{

				dictStack.Push(0, "name1");

				string expectedValue = "name1";
				string actualValue1 = dictStack.Peek();
				string actualValue2 = dictStack[0];
				Assert.IsTrue(expectedValue == actualValue1, $"Peek values did not match. Expected {expectedValue}, actually {actualValue1}");
				Assert.IsTrue(expectedValue == actualValue2, $"Indexing  values did not match. Expected {expectedValue}, actually {actualValue2}");

			}
			catch (Exception e)
			{
				Assert.Fail("Test failed: " + e);
			}
		}

		[TestMethod]
		public void PushTwoTest()
		{
			DictionaryStack<int, string> dictStack = new DictionaryStack<int, string>();
			try
			{

				dictStack.Push(0, "name1");
				dictStack.Push(1, "name2");

				string expectedValue = "name2";
				string actualValue1 = dictStack.Peek();
				string actualValue2 = dictStack[1];
				Assert.IsTrue(expectedValue == actualValue1, $"Peek values did not match. Expected {expectedValue}, actually {actualValue1}");
				Assert.IsTrue(expectedValue == actualValue2, $"Indexing  values did not match. Expected {expectedValue}, actually {actualValue2}");

			}
			catch (Exception e)
			{
				Assert.Fail("Test failed: " + e);
			}
		}
	}
}
