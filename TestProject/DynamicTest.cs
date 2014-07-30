using Algorithm_Dynamic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestProject
{


    /// <summary>
    ///This is a test class for DynamicTest and is intended
    ///to contain all DynamicTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DynamicTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for FindCoins
        ///</summary>
        [TestMethod()]
        public void FindCoinsTest()
        {
            Dynamic target = new Dynamic(); // TODO: Initialize to an appropriate value
            int[] coins = { 1, 3, 5 }; // TODO: Initialize to an appropriate value
            int sum = 4; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.FindCoins(coins, sum);
            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        ///A test for LongIncreaseSubsequece
        ///</summary>
        [TestMethod()]
        public void LongIncreaseSubsequeceTest()
        {
            Dynamic target = new Dynamic(); // TODO: Initialize to an appropriate value
            int[] array = { 5, 2, 8, 6, 3, 5, 6,9,7 };
          
            int actual;
            actual = target.LongIncreaseSubsequece(array);

        }

        /// <summary>
        ///A test for FindConinsTwo
        ///</summary>
        [TestMethod()]
        public void FindConinsTwoTest()
        {
            Dynamic target = new Dynamic(); // TODO: Initialize to an appropriate value
            int[] coins = { 1, 3, 5 }; // TODO: Initialize to an appropriate value
            int sum = 35; // TODO: Initialize to an appropriate value
            int expected = target.FindCoins(coins, sum);
            int actual = target.FindConinsTwo(coins, sum);
            Assert.AreEqual(expected, actual);

        }

        /// <summary>
        ///A test for MinimumTotal
        ///</summary>
        [TestMethod()]
        public void MinimumTotalTest()
        {
            Dynamic target = new Dynamic(); // TODO: Initialize to an appropriate value
            List<List<int>> triangle = new List<List<int>>();
            triangle.Add(new List<int> { 2 });
            triangle.Add(new List<int> { 3, 4 });
            triangle.Add(new List<int> { 6, 5, 7 });
            triangle.Add(new List<int> { 4, 1, 8, 3 });

            
            //int actual;
            target.MinimumTotal(triangle);
            //Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for MinimumTotalDymatic
        ///</summary>
        [TestMethod()]
        public void MinimumTotalDymaticTest()
        {
            Dynamic target = new Dynamic(); // TODO: Initialize to an appropriate value
            List<List<int>> triangle = new List<List<int>>();
            int expected = 0;
            triangle.Add(new List<int> { 2 });
            triangle.Add(new List<int> { 3, 4 });
            triangle.Add(new List<int> { 6, 5, 7 });
            triangle.Add(new List<int> { 4, 1, 8, 3 });
            int actual = target.MinimumTotalDymatic(triangle);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for NumDistinct
        ///</summary>
        [TestMethod()]
        public void NumDistinctTest()
        {
            Dynamic target = new Dynamic(); // TODO: Initialize to an appropriate value
            string S = "aabb"; // TODO: Initialize to an appropriate value
            string T = "aab"; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.NumDistinct(S, T);
            Assert.AreEqual(expected, actual);
            }

        /// <summary>
        ///A test for MaxProfit3
        ///</summary>
        [TestMethod()]
        public void MaxProfit3Test()
        {
            Dynamic target = new Dynamic(); // TODO: Initialize to an appropriate value
            int[] test_array = { 4, 5, 6, 3, 2 }; 
            List<int> prices = new List<int>(test_array); // TODO: Initialize to an appropriate value
            int actual = 0;
           actual= target.MaxProfit3(prices);
            
        }

        /// <summary>
        ///A test for MaxProfit32
        ///</summary>
        [TestMethod()]
        public void MaxProfit32Test()
        {
            int[] test_array = { 4, 5, 6, 3, 2 };
            List<int> prices = new List<int>(test_array); // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = Dynamic.MaxProfit32(prices);
            Assert.AreEqual(expected, actual);
            
        }



        /// <summary>
        ///A test for NumDecodings
        ///</summary>
        [TestMethod()]
        public void NumDecodingsTest()
        {
            Dynamic target = new Dynamic(); // TODO: Initialize to an appropriate value
            string s = "12345678"; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            int actual1;
            actual = target.NumDecodings(s);
            actual1 = target.NumDecodings2(s);
                   }

        /// <summary>
        ///A test for WordBreak
        ///</summary>
        [TestMethod()]
        public void WordBreakTest()
        {
            Dynamic target = new Dynamic(); // TODO: Initialize to an appropriate value
            string[] a =  {"leet", "code"};
            string s = "leetcode"; // TODO: Initialize to an appropriate value
            List<string> dict = new List<string>(a); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.WordBreak(s, dict);
           
        }

        /// <summary>
        ///A test for WordBreakII
        ///</summary>
        [TestMethod()]
        public void WordBreakITest()
        {
            Dynamic target = new Dynamic(); // TODO: Initialize to an appropriate value
            string[] a = { "leet", "code" };
            string s = "leetcode"; // TODO: Initialize to an appropriate value
            List<string> dic = new List<string>(a);  // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.WordBreakI(s, dic);
            
        }

        /// <summary>
        ///A test for WorkBreakII
        ///</summary>
        [TestMethod()]
        public void WordBreakIITest()
        {
            Dynamic target = new Dynamic(); // TODO: Initialize to an appropriate value
            string[] a = {"cat", "cats", "and", "sand", "dog" };
            string s = "catsanddog"; // TODO: Initialize to an appropriate value
            List<string> dic = new List<string>(a);  // TODO: Initialize to an appropriate value
            List<string> expected = null; // TODO: Initialize to an appropriate value
            List<string> actual;
            actual = target.WordBreakII(s, dic);
            
        }

        /// <summary>
        ///A test for WordBreakDP
        ///</summary>
        [TestMethod()]
        public void WordBreakDPTest()
        {
            Dynamic target = new Dynamic(); // TODO: Initialize to an appropriate value
            string[] a = { "cat", "cats", "and", "sand", "dog" };
            string s = "catsanddog"; // TODO: Initialize to an appropriate value
            List<string> dict = new List<string>(a);  // TODO: Initialize to an appropriate value
            List<string> expected = null; // TODO: Initialize to an appropriate value
            List<string> actual;
            actual = target.WordBreakDP(s, dict);
         
        }
    }
}
