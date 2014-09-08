using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TestProject
{
    
    
    /// <summary>
    ///This is a test class for RecursionTest and is intended
    ///to contain all RecursionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RecursionTest
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
        ///A test for CountWays
        ///</summary>
        [TestMethod()]
        public void CountWaysTest()
        {
            Recursion target = new Recursion(); // TODO: Initialize to an appropriate value
            int n = 5; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.CountWays(n);
            Assert.AreEqual(expected, actual); 
        }

        /// <summary>
        ///A test for CountWaysDP2
        ///</summary>
        [TestMethod()]
        public void CountWaysDP2Test()
        {
            Recursion target = new Recursion();
            int n = 5;
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.CountWaysDP2(n);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CountWaysThree
        ///</summary>
        [TestMethod()]
        public void CountWaysThreeTest()
        {
            Recursion target = new Recursion(); // TODO: Initialize to an appropriate value
            int n = 5; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.CountWaysThree(n);
            Assert.AreEqual(expected, actual);
           
        }

        /// <summary>
        ///A test for GetPath
        ///</summary>
        [TestMethod()]
        public void GetPathTest()
        {
            Recursion target = new Recursion(); // TODO: Initialize to an appropriate value
            int x = 5; // TODO: Initialize to an appropriate value
            int y = 5; // TODO: Initialize to an appropriate value
            
            ArrayList path = new ArrayList();
            ArrayList path_except = new ArrayList();
            bool expected, actual;
            expected = target.GetPathOne(x, y, path);
            actual = target.GetPathOneProved(x, y, path_except);
         
            
        }



     

        /// <summary>
        ///A test for GetSubsets
        ///</summary>
        [TestMethod()]
        public void GetSubsetsTest()
        {
            Recursion target = new Recursion(); // TODO: Initialize to an appropriate value
            int[] set = { 1, 2, 3 };
            int index = 0; // TODO: Initialize to an appropriate value
            ArrayList expected = null; // TODO: Initialize to an appropriate value
            ArrayList actual;
            actual = target.GetSubsets(set, index);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for GetSubsets2
        ///</summary>
        [TestMethod()]
        public void GetSubsets2Test()
        {
            Recursion target = new Recursion(); // TODO: Initialize to an appropriate value
            int[] set = { 1, 2, 3 };
            ArrayList expected = null; // TODO: Initialize to an appropriate value
            ArrayList actual;
            actual = target.GetSubsets2(set);
            Assert.AreEqual(expected, actual);
           
        }


        /// <summary>
        ///A test for GetPerms
        ///</summary>
        [TestMethod()]
        public void GetPermsTest()
        {
            Recursion target = new Recursion(); // TODO: Initialize to an appropriate value
            string str = "huxin";
            ArrayList expected = null; // TODO: Initialize to an appropriate value
            ArrayList actual;
            actual = target.GetPerms(str);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for GetPermsIteration
        ///</summary>
        [TestMethod()]
        public void GetPermsIterationTest()
        {
            Recursion target = new Recursion(); // TODO: Initialize to an appropriate value
            string str = "huxin";
            List <string> expected = null; // TODO: Initialize to an appropriate value
            List<string> actual;
            actual = target.GetPermsIteration(str);
            Assert.AreEqual(expected, actual);
                    }

        /// <summary>
        ///A test for GenerateParens
        ///</summary>
        [TestMethod()]
        public void GenerateParensTest()
        {
            Recursion target = new Recursion(); // TODO: Initialize to an appropriate value
            int remaining = 3;
            HashSet<string> expected = null; // TODO: Initialize to an appropriate value
            HashSet<string> actual;
            actual = target.GenerateParens(remaining);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for GenerateParensTwo
        ///</summary>
        [TestMethod()]
        public void GenerateParensTwoTest()
        {
            Recursion target = new Recursion(); // TODO: Initialize to an appropriate value
            int count = 3; // TODO: Initialize to an appropriate value
            List<string> expected = null; // TODO: Initialize to an appropriate value
            List<string> actual;
            actual = target.GenerateParensTwo(count);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for MakeChange
        ///</summary>
        [TestMethod()]
        public void MakeChangeTest()
        {
            Recursion target = new Recursion(); // TODO: Initialize to an appropriate value
            int n = 17; // TODO: Initialize to an appropriate value
            int denom = 25; // TODO: Initialize to an appropriate value
           
            int actual;
            actual = target.MakeChange(n, denom);
           
           
        }

        /// <summary>
        ///A test for MakeChangeTwo
        ///</summary>
        [TestMethod()]
        public void MakeChangeTwoTest()
        {
            Recursion target = new Recursion(); // TODO: Initialize to an appropriate value
            int sum = 0; // TODO: Initialize to an appropriate value
            int c = 25; // TODO: Initialize to an appropriate value
            int n = 17; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.MakeChangeTwo(sum, c, n);
           
          
        }

        /// <summary>
        ///A test for MakeChangeThree
        ///</summary>
        [TestMethod()]
        public void MakeChangeThreeTest()
        {
            Recursion target = new Recursion(); // TODO: Initialize to an appropriate value
            int sum = 0; // TODO: Initialize to an appropriate value
            int c = 25; // TODO: Initialize to an appropriate value
            int n = 17; // TODO: Initialize to an appropriate value
            target.MakeChangeThree(sum, c, n);
            
        }

        /// <summary>
        ///A test for PlaceQueens
        ///</summary>
        [TestMethod()]
        public void PlaceQueensTest()
        {
            Recursion target = new Recursion(); // TODO: Initialize to an appropriate value
            int grid_size = 8; // TODO: Initialize to an appropriate value
            int row = 0; // TODO: Initialize to an appropriate value
            int[] columns = new int[8];
            ArrayList results = null; // TODO: Initialize to an appropriate value
            ArrayList resultsExpected = null; // TODO: Initialize to an appropriate value
            target.PlaceQueens(grid_size, row, columns, ref results);
            Assert.AreEqual(resultsExpected, results);
           
        }



        /// <summary>
        ///A test for MakeChangeFour
        ///</summary>
        [TestMethod()]
        public void MakeChangeFourTest()
        {
            Recursion target = new Recursion(); // TODO: Initialize to an appropriate value
            Recursion actual = new Recursion();

            int target_result = target.MakeChangeFour(17);   
            int actual_result = actual.MakeChange(17,25);
            Assert.AreEqual(target_result, actual_result);
            }

        /// <summary>
        ///A test for CoutWayTwo
        ///</summary>
        [TestMethod()]
        public void CoutWayTwoTest()
        {
            Recursion target = new Recursion(); // TODO: Initialize to an appropriate value
            Recursion actual = new Recursion();

            int n = 4; // TODO: Initialize to an appropriate value
            int actual_result = target.CountWaysThree(n);
            int target_result = target.CountWays(n);

            Assert.AreEqual(actual_result, target_result);
           
        }

         
        /// <summary>
        ///A test for GetPathThree
        ///</summary>
        [TestMethod()]
        public void GetPathThreeTest()
        {
            Recursion target = new Recursion(); // TODO: Initialize to an appropriate value
         
            int x = 8;
            int y = 8;
           
            
            int target_result = target.GetPathThree(x, y);
            int actual_result =target.GetPath(x, y);
            Assert.AreEqual(target_result, actual_result);
            
        }

        /// <summary>
        ///A test for GetPathFour
        ///</summary>
        [TestMethod()]
        public void GetPathFourTest()
        {
            Recursion target = new Recursion(); // TODO: Initialize to an appropriate value
          
            int x = 3;
            int y = 3;
            int target_result = 0;
            ArrayList path = new ArrayList();

            target.GetPathOne(x, y, path);
            int actual_result = target.GetPath(x, y);
            Assert.AreEqual(target_result, actual_result);
           
        }

        /// <summary>
        ///A test for GetPathDynamic
        ///</summary>
        [TestMethod()]
        public void GetPathDynamicTest()
        {
            Recursion target = new Recursion(); // TODO: Initialize to an appropriate value
            int x = 8; // TODO: Initialize to an appropriate value
            int y = 8; // TODO: Initialize to an appropriate value
            ArrayList path = new ArrayList(); // TODO: Initialize to an appropriate value
            ArrayList path_target = new ArrayList();
            //Hashtable cache = new Hashtable(); // TODO: Initialize to an appropriate value
            
            bool actual;
            actual = target.GetPathDynamic(x, y, path);
            int target_result =target.GetPath(x, y);
            
            Assert.AreEqual(target_result, path.Count);
            
        }



        /// <summary>
        ///A test for PartitionForLoop
        ///</summary>
        [TestMethod()]
        public void PartitionForLoopTest()
        {
            Recursion target = new Recursion(); // TODO: Initialize to an appropriate value
            string s = "aab"; // TODO: Initialize to an appropriate value
            Stack<Stack<string>> expected = null; // TODO: Initialize to an appropriate value
            Stack<Stack<string>> actual;
            actual = target.PartitionForLoop(s);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

   

        /// <summary>
        ///A test for GetSubsetsForLoop
        ///</summary>
        [TestMethod()]
        public void GetSubsetsForLoopTest()
        {
            Recursion target = new Recursion(); // TODO: Initialize to an appropriate value
            int[] set = {1,2,3}; // TODO: Initialize to an appropriate value
            ArrayList expected = null; // TODO: Initialize to an appropriate value
            ArrayList actual;
            actual = target.GetSubsetsForLoop(set);
            expected = target.GetSubsets(set);

            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetSubsetsXin
        ///</summary>
        [TestMethod()]
        public void GetSubsetsXinTest()
        {
            Recursion target = new Recursion(); // TODO: Initialize to an appropriate value
            string set = "123";
            List<string> expected = null; // TODO: Initialize to an appropriate value
            List<string> actual;
            actual = target.GetSubsetsXin(set);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for NumDistinct
        ///</summary>
        [TestMethod()]
        public void NumDistinctTest()
        {
            Recursion target = new Recursion(); // TODO: Initialize to an appropriate value
            string s = "rabbbit"; // TODO: Initialize to an appropriate value
            string t = "rabbit"; // TODO: Initialize to an appropriate value
            
            int actual = target.NumDistinct(s, t);
            
        }


        /// <summary>
        ///A test for LetterCombinations
        ///</summary>
        [TestMethod()]
        public void LetterCombinationsTest()
        {
            Recursion target = new Recursion(); // TODO: Initialize to an appropriate value
            string digits = "23";
            string[] expacted_array = new[] { "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf" };
            List<string> expected = expacted_array.ToList<String>(); // TODO: Initialize to an appropriate value
            List<string> actual;
            actual = target.LetterCombinations(digits);
            Assert.AreEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for LetterCombinationsTwo
        ///</summary>
        [TestMethod()]
        public void LetterCombinationsTwoTest()
        {
            Recursion target = new Recursion(); // TODO: Initialize to an appropriate value
            string digits = "23";
            string[] expacted_array = new[] { "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf" };
            List<string> expected = expacted_array.ToList<String>(); // TODO: Initialize to an appropriate value
            List<string> actual;
            actual = target.LetterCombinationsTwo(digits);
        }



        /// <summary>
        ///A test for LetterCombinationsRecur
        ///</summary>
        [TestMethod()]
        public void LetterCombinationsRecurTest()
        {
            Recursion target = new Recursion(); // TODO: Initialize to an appropriate value
            string digits = "23"; // TODO: Initialize to an appropriate value
            string[] expected = new[] { "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf" }; // TODO: Initialize to an appropriate value
            string[] actual;
            actual = target.LetterCombinationsRecur(digits);
            
        }

        /// <summary>
        ///A test for LargestRectangleAreaSolution3
        ///</summary>
        [TestMethod()]
        public void LargestRectangleAreaSolution3Test()
        {
            Recursion target = new Recursion(); // TODO: Initialize to an appropriate value
            int[] height_array = { 2, 1, 5, 6, 2, 3 };
            List<int> height = height_array.ToList<int>(); // TODO: Initialize to an appropriate value
            int expected = 10; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.LargestRectangleAreaSolution3(height);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for LargestRectangleAreaSolution4
        ///</summary>
        [TestMethod()]
        public void LargestRectangleAreaSolution4Test()
        {
            Recursion target = new Recursion(); // TODO: Initialize to an appropriate value
            int[] height_array = { 2, 1, 5, 6, 2, 3 };
            List<int> height = height_array.ToList<int>(); // TODO: Initialize to an appropriate value
            int expected = 10; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.LargestRectangleAreaSolution4(height);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Search
        ///</summary>
        [TestMethod()]
        public void SearchTest()
        {
            Recursion target = new Recursion(); // TODO: Initialize to an appropriate value
            List<string> board = new List<string>();
            board.Add("ABCE"); //
            board.Add("SFCS");
            board.Add("ADEE");

            string str = "SEE"; // TODO: Initialize to an appropriate value
            bool actual1 = target.Search(board, str);

            Assert.AreEqual(actual1, true);
        
        }

        /// <summary>
        ///A test for Combine
        ///</summary>
        [TestMethod()]
        public void CombineTest()
        {
            Recursion target = new Recursion(); // TODO: Initialize to an appropriate value
           
            List<List<int>> expected = null; // TODO: Initialize to an appropriate value
            List<List<int>> actual;
            actual = target.Combine(4, 2);
            Assert.AreEqual(expected, actual);
            
        }



        /// <summary>
        ///A test for Partition
        ///</summary>
        [TestMethod()]
        public void PartitionTest()
        {
            Recursion target = new Recursion(); // TODO: Initialize to an appropriate value
            string s = "aab"; // TODO: Initialize to an appropriate value
            Stack<Stack<string>> expected = null; // TODO: Initialize to an appropriate value
            Stack<Stack<string>> actual;
            actual = target.Partition(s);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CombineWhileLoop
        ///</summary>
        [TestMethod()]
        public void CombineWhileLoopTest()
        {
            Recursion target = new Recursion(); // TODO: Initialize to an appropriate value
            int n = 4; // TODO: Initialize to an appropriate value
            int k = 2; // TODO: Initialize to an appropriate value
            List<Stack<int>> expected = null; // TODO: Initialize to an appropriate value
            List<Stack<int>> actual;
            actual = target.CombineWhileLoop(n, k);
            Assert.AreEqual(expected, actual);
           
        }

        /// <summary>
        ///A test for MinWindow
        ///</summary>
        [TestMethod()]
        public void MinWindowTest()
        {
            Recursion target = new Recursion(); // TODO: Initialize to an appropriate value
            string s = "ADOBECODEBANC"; // TODO: Initialize to an appropriate value
            string t = "ABC"; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.MinWindow(s, t);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }



        /// <summary>
        ///A test for MinWindow3
        ///</summary>
        [TestMethod()]
        public void MinWindow3Test()
        {
            Recursion target = new Recursion(); // TODO: Initialize to an appropriate value
            string s = "acbbaca"; // TODO: Initialize to an appropriate value
            string t = "aba"; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.MinWindow3(s, t);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }



        /// <summary>
        ///A test for CountWayDP3
        ///</summary>
        [TestMethod()]
        public void CountWaysDP3Test()
        {
            Recursion target = new Recursion(); // TODO: Initialize to an appropriate value
            int n = 5; // TODO: Initialize to an appropriate value
          
            int actual;
            actual = target.CountWaysDP3(n);
          
        }

        /// <summary>
        ///A test for Concatenation
        ///</summary>
        [TestMethod()]
        public void ConcatenationTest()
        {
            Recursion target = new Recursion(); // TODO: Initialize to an appropriate value
            string s ="barfoothefoobarman"; // TODO: Initialize to an appropriate value
            string[] words =  {"foo", "bar"}; // TODO: Initialize to an appropriate value
            List<int> expected = null; // TODO: Initialize to an appropriate value
            List<int> actual;
            actual = target.Concatenation(s, words);
            Assert.AreEqual(expected, actual);
           
        }

        /// <summary>
        ///A test for Concatenation2
        ///</summary>
        [TestMethod()]
        public void Concatenation2Test()
        {
            Recursion target = new Recursion(); // TODO: Initialize to an appropriate value
            string s = "barfoothefoobarman"; // TODO: Initialize to an appropriate value
            string[] words = { "foo", "bar" }; ; // TODO: Initialize to an appropriate value
            List<int> expected = null; // TODO: Initialize to an appropriate value
            List<int> actual;
            actual = target.Concatenation2(s, words);
        
        }

        /// <summary>
        ///A test for RestoreIpAddresses
        ///</summary>
        [TestMethod()]
        public void RestoreIpAddressesTest()
        {
            Recursion target = new Recursion(); // TODO: Initialize to an appropriate value
            string s = "25525511135";
            List<string> expected = null; // TODO: Initialize to an appropriate value
            List<string> actual;
            actual = target.RestoreIpAddresses(s);
         
        }
    }
}
