//----------------------------------------------------
// Copyright 2019 Epic Systems Corporation
//----------------------------------------------------

using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SentinelsAutoTrackerEngine;

namespace CustomDataStructuresTests
{
	[TestClass]
	public class MultiKeyedDictionaryTest
	{
		[TestMethod]
		public void AddDifferentKeys()
		{
			MultiKeyedDictionary<int, string> multiKeyedDictionary = new MultiKeyedDictionary<int, string>(); 
			try
			{

				multiKeyedDictionary.Add(0, "a");
				multiKeyedDictionary.Add(1, "b");

				
				List<string> actualResult = multiKeyedDictionary[0];

				Assert.IsTrue(actualResult.Contains("a"), $"Value at 0 doesn't contain expected value 'a'.");
				
				actualResult = multiKeyedDictionary[1];
				Assert.IsTrue(actualResult.Contains("b"), $"Value at 1 doesn't contain expected value 'b'.");


			}
			catch (Exception e)
			{
				Assert.Fail("Test failed: " + e);
			}
		}

		[TestMethod]
		public void AddSameKeys()
		{
			MultiKeyedDictionary<int, string> multiKeyedDictionary = new MultiKeyedDictionary<int, string>();
			try
			{

				multiKeyedDictionary.Add(0, "a");
				multiKeyedDictionary.Add(0, "b");


				List<string> actualResult = multiKeyedDictionary[0];

				Assert.IsTrue(actualResult.Contains("a"), $"Value at 0 doesn't contain expected value 'a'.");
				Assert.IsTrue(actualResult.Contains("b"), $"Value at 0 doesn't contain expected value 'b'.");


			}
			catch (Exception e)
			{
				Assert.Fail("Test failed: " + e);
			}
		}
	}
}
