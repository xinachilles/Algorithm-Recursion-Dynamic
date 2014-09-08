using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm_Dynamic
{
    public class MyEqualityComparer : IEqualityComparer<int[]>
    {
        public bool Equals(int[] x, int[] y)
        {
            if (x.Length != y.Length)
            {
                return false;
            }
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] != y[i])
                {
                    return false;
                }
            }
            return true;
        }

        public int GetHashCode(int[] obj)
        {
            int result = 17;
            for (int i = 0; i < obj.Length; i++)
            {
                unchecked
                {
                    result = result * 23 + obj[i];
                }
            }
            return result;
        }

    }
    public class Dynamic
    {

        #region conins collection
        //Given a list of N coins, their values (V1, V2, ... , VN), and the total sum S. Find the minimum number of coins the sum of which is S
        //(we can use as many coins of one type as we want), or report that it's not possible to select coins in such a way that they sum up to S.

        /// <summary>
        ///  
        /// </summary>
        /// <param name="coins"> </param>
        /// <param name="result_coin"> </param>
        /// 

        public int FindCoins(int[] coins, int sum)
        {

            // min[i]  if total sum is i, we MIN need min[i] numbers coins
            int[] min = new int[sum + 1];
            int[] track = new int[sum + 1];

            for (int i = 1; i < min.Length; i++)
            {
                min[i] = int.MaxValue;
            }

            for (int i = 0; i <= sum; i++)
            {


                for (int j = 0; j < coins.Length; j++)
                {
                    int coin = coins[j];

                    if (i >= coin && min[i - coin] + 1 < min[i])
                    {
                        min[i] = min[i - coin] + 1;
                        track[i] = coin;
                    }
                }
            }

            return min[sum];

        }

        /*
         not correct, conins may not only 1,3,5 ....
         */
        public int FindConinsTwo(int[] coins, int sum)
        {

            int min = int.MaxValue;
            for (int i = 0; i <= sum; i++)
            {
                // for 1 
                for (int j = 0; j <= sum / 3; j++)
                {
                    // 3 

                    for (int k = 0; k <= sum / 5; k++)
                    {
                        int value = i + 3 * j + k * 5;
                        int number = i + j + k;
                        if (value == sum && value < min)
                        {
                            min = number;
                        }

                    }
                }
            }

            return min;
        }

        #endregion

        #region Longest increasing subsequence
        //longest increasing subsequence
        //d(i) = from 0 to i the length of logest increase subsequence 
        //d(i) = max{d(j)}+1, (j<i,A[j]<=A[i])
        public int LongIncreaseSubsequece(int[] array)
        {
            int[] result = new int[array.Length];
            int length = 1;
            // result
            for (int i = 0; i < array.Length; i++)
            {
                result[i] = 1;
                for (int j = 0; j < i; j++)
                {
                    if (array[j] < array[i] && result[i] < result[j] + 1)
                    {
                        result[i] = result[j] + 1;
                    }

                    if (length < result[i]) { length = result[i]; }
                }
            }

            return length;
        }


        #endregion

        #region apple collection
        //A table composed of N x M cells, each having a certain quantity of apples, is given. 
        //You start from the upper-left corner. At each step you can go down or right one cell. Find the maximum number of apples you can collect. 

        // current the "certain quantity" is 1, we also can use int[,] value instead 
        public int CollectApple(int[,] mattrix)
        {
            int row = mattrix.GetLength(0);
            int col = mattrix.GetLength(1);
            // result[i,j] means from 0,0 to i,j the maximum number of apples we can collect
            int[,] result = new int[row, col];
            for (int i = 0; i < row; i++)
            {
                result[i, 0] = 1;
            }

            for (int j = 0; j < col; j++)
            {
                result[0, j] = 1;
            }


            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    result[i, j] = Math.Max(result[i - 1, j], result[i, j - 1]) + 1;
                }
            }

            return 0;
        }
        #endregion

        #region 2.7
        //2.7 Implement a function to check if a linked list is a palindrome
        public bool IsPalindrome(LinkedListNode<int> head)
        {
            LinkedListNode<int> fast = head;
            LinkedListNode<int> slow = head;


            Stack<int> stack = new Stack<int>();

            /* Push elements from first half of linked list onto stack. When
             * fast runner (which is moving at 2x speed) reaches the end of
             * the linked list, then we know we're at the middle */
            while (fast != null && fast.Next != null)
            {
                stack.Push(slow.Value);
                slow = slow.Next;
                fast = fast.Next.Next;

            }

            /* Has odd number of elements, so skip the middle element */
            if (fast != null)
            {
                slow = slow.Next;
            }

            while (slow != null)
            {
                int top = stack.Pop();

                /* If values are different, then it's not a palindrome */
                if (top != slow.Value)
                {
                    return false;
                }
                slow = slow.Next;
            }
            return true;
        }
        private class Result
        {
            public LinkedListNode<int> node;
            public bool result;
            public Result(LinkedListNode<int> n, bool r)
            {
                result = r;
                node = n;
            }
        }
        private Result IsPalindromeRecurse(LinkedListNode<int> head, int length)
        {

            if (head == null || length == 0)
            {
                return new Result(null, true);
            }
            else if (length == 1)
            {
                return new Result(head.Next, true);
            }
            else if (length == 2)
            {
                return new Result(head.Next.Next,
                 head.Value == head.Next.Value);
            }
            Result res = IsPalindromeRecurse(head.Next, length - 2);
            if (!res.result || res.node == null)
            {
                return res;
            }
            else
            {
                res.result = (head.Value == res.node.Value);
                res.node = res.node.Next;
                return res;
            }
        }

        public bool IsPalindromeWithRecurse(int length, LinkedList<int> l)
        {
            Result p = IsPalindromeRecurse(l.First, length);
            return p.result;
        }
        #endregion

        #region leet Triangle
        /*
         Given a triangle, find the minimum path sum from top to bottom. Each step you may move to adjacent numbers on the row below.

         For example, given the following triangle
         [
           [2],
          [3,4],
         [6,5,7],
        [4,1,8,3]
        ]
        
        The minimum path sum from top to bottom is 11 (i.e., 2 + 3 + 5 + 1 = 11).
        Note: Bonus point if you are able to do this using only O(n) extra space, where n is the total number of rows in the triangle.
         */

        /*Normal way, Top-Down Approach just go through all paths and find the minimum one */
        /*for the col is not correct,d */
        public void MinimumTotal(List<List<int>> triangle)
        {
            int count = triangle[triangle.Count - 1].Count;
            int col = 0;
            int total = 2;



            for (int row = 1; row < triangle.Count; row++)
            {
                if (col - 1 >= 0 && col + 1 < triangle[row].Count)
                {
                    total = Math.Min(triangle[row][col], Math.Min(triangle[row][col - 1], triangle[row][col + 1])) + total;

                    col = triangle[row][col] > triangle[row][col - 1] ? col - 1 : col;

                }
                else if (col - 1 < 0 && col + 1 < triangle[row].Count)
                {
                    total = Math.Min(triangle[row][col], triangle[row][col + 1]) + total;

                    col = triangle[row][col] > triangle[row][col + 1] ? col + 1 : col;


                }
                else if (col - 1 >= 0 && col + 1 >= triangle[row].Count)
                {
                    total = Math.Min(triangle[row][col - 1], triangle[row][col]) + total;

                    col = triangle[row][col] > triangle[row][col - 1] ? col - 1 : col;

                }

            }


        }

        /*Bottom-Up dymatic way */
        public int MinimumTotalDymatic(List<List<int>> triangle)
        {

            int[] total = new int[triangle.Count];
            int l = triangle.Count - 1;

            for (int i = 0; i < triangle[l].Count; i++)
            {
                total[i] = triangle[l][i];
            }

            // iterate from last second row
            for (int i = triangle.Count - 2; i >= 0; i--)
            {
                for (int j = 0; j < triangle[i + 1].Count - 1; j++)
                {
                    total[j] = triangle[i][j] + Math.Min(total[j], total[j + 1]);
                }
            }

            return total[0];
        }
        /*from note 8/15 not correct */
        public int MinimumTotalDymatic2(List<List<int>> triangle) { 
            if (triangle == null)
	{
		 return 0;
	}
            int count = triangle.Count;

            int [] result = new int[triangle[count-1].Count];
            for (int i = count-1; i >=0; i--)
			{
			 for (int j = 0; j < triangle[i].Count-1; j++)
			{
			 result[j] = result[j] + Math.Min(triangle[i][j],triangle[i][j+1]);
			}
               
			}

            
           return result[0];
        }

        #endregion

        #region leet Best Time to Buy and Sell Stock
        /* 
         * Say you have an array for which the ith element is the price of a given stock on day i.
           If you were only permitted to complete at most one transaction (ie, buy one and sell one share of the stock), design an algorithm to find the maximum profit.
         
         */

        public int MaxProfit1(List<int> prices)
        {
            int max_profit = int.MinValue;
            for (int i = 0; i < prices.Count; i++)
            {
                for (int j = i + 1; j < prices.Count; j++)
                {
                    int profit = prices[j] - prices[i];

                    if (max_profit < profit)
                    {
                        max_profit = profit;

                    }


                }

            }

            return max_profit;
        }

        /*another way only use O(n):
         * 
         * Scan from left to right. And keep track the minimal price in left. So, each step, only calculate the difference between current price and minimal price.
           If this diff large than the current max difference, replace it.
         */

        public int MaxProfit12(List<int> prices)
        {

            int min_value = int.MaxValue;
            int max = 0;
            int diff = 0;
            for (int i = 0; i < prices.Count; i++)
            {
                if (prices[i] < min_value) min_value = prices[i];
                diff = prices[i] - min_value;
                if (max < diff)
                    max = diff;
            }
            return max;
        }
        #endregion

        #region leet Best Time to Buy and Sell Stock II
        ///* Say you have an array for which the ith element is the price of a given stock on day i.
        //   Design an algorithm to find the maximum profit. You may complete as many transactions as you like (ie, buy one and sell one share of the stock multiple times).  
        //   However, you may not engage in multiple transactions at the same time (ie, you must sell the stock before you buy again).
        // */

        /*bad throught: using dymatic fucntion  */
        // /*
        //    M[i]  is the max profit we can get at i day
        //  * P[i]  is the price at i day
        //  * M[i] = P[k] - p[j]  i>=k>j
        //  * M[i] = Max( P[k] - p[j]) + Max(M[0...j-1])
        //  */

        // public int MaxProfitTwo(List<int> prices)
        //{
        //    int c = prices.Count;
        //    int[] m = new int[c];
        //    int min_value = int.MinValue; 


        //    for (int i = 0; i < prices.Count; i++)
        //    {

        //    }

        //}

        /*A bit different with previous one. Since we can make unlimited transactions, this question turns to sum all the positive price difference.
         * So, scan from left to right, and add all positive diff value. */
        public int MaxProfit2(List<int> prices)
        {

            // int max=0;  
            int sum = 0;
            for (int i = 1; i < prices.Count; i++)
            {
                int diff = prices[i] - prices[i - 1];
                if (diff > 0)
                    sum += diff;
            }
            return sum;

        }
        #endregion

        #region leet Best Time to Buy and Sell Stock III

        /* Say you have an array for which the ith element is the price of a given stock on day i.
Design an algorithm to find the maximum profit. You may complete at most two transactions.*/
        /*
        One dimensional dynamic planning.Given an i, split the whole array into two parts:
        [0,i] and [i+1, n], it generates two max value based on i, Max(0,i) and Max(i+1,n)
        So, we can define the transformation function as:
        Maxprofix = max(Max(0,i) + Max(i+1, n))  0<=i<n
        Pre-processing Max(0,i) might be easy, but I didn't figure an efficient way to generate Max(i+1,n) in one pass.
        http://fisherlei.blogspot.com/2013/01/leetcode-best-time-to-buy-and-sell_3958.html
         
         */
        public int MaxProfit3(List<int> prices)
        {
            int[,] max = new int[prices.Count, prices.Count];
            for (int i = 0; i < prices.Count; i++)
            {
                for (int j = 0; j < prices.Count; j++)
                {
                    max[i, j] = int.MinValue;
                }
            }
            Dictionary<int[], int[]> track = new Dictionary<int[], int[]>(new MyEqualityComparer());


            for (int i = 0; i < prices.Count; i++)
            {

                for (int k = i; k < prices.Count; k++)
                {

                    for (int h = k; h < prices.Count; h++)
                    {
                        for (int j = h; j < prices.Count; j++)
                        {


                            int p = ((prices[k] - prices[i]) + (prices[j] - prices[h]));

                            if (max[i, j] < p)
                            {
                                max[i, j] = p;
                                int[] key = { i, j };
                                int[] value = { k, h };
                                if (track.ContainsKey(key))
                                {
                                    track[key] = value;
                                }
                                else
                                {
                                    track.Add(key, value);

                                }
                            }
                        }

                    }
                }
            }
            return max[0, 4];
        }




        public static int MaxProfit32(List<int> prices)
        {
            if (prices.Count < 2) return 0;
            int min = prices[0];
            int max = prices[prices.Count - 1];

            int maxprofit = 0;
            int[] left = new int[prices.Count];
            int[] right = new int[prices.Count];

            left[0] = 0;
            right[prices.Count - 1] = 0;

            for (int i = 1; i < prices.Count; i++)
            {
                left[i] = Math.Max(left[i - 1], prices[i] - min);
                min = Math.Min(min, prices[i]);
            }

            for (int i = prices.Count - 2; i >= 0; i--)
            {
                right[i] = Math.Max(right[i + 1], max - prices[i]);
                max = Math.Max(max, prices[i]);
            }

            for (int i = 0; i < prices.Count; i++)
            {
                maxprofit = Math.Max(maxprofit, left[i] + right[i]);
            }
            return maxprofit;
        }
        #endregion

        #region Leet Distinct Subsequences
        /*
         Distinct Subsequences

        Given a string S and a string T, count the number of distinct subsequences of T in S.
        A subsequence of a string is a new string which is formed from the original string by deleting some (can be none) of the characters without disturbing the relative positions of the remaining characters. (ie, "ACE" is a subsequence of "ABCDE"while "AEC" is not).
        Here is an example:
        S = "rabbbit", T = "rabbit"
        Return 3.
         
         */

        /*
         go through all subset in T, find out wheather the those subets are in S or not , same as 9.4 
         */
        // Note: The Solution object is instantiated only once and is reused by each test case.

        /*dp[i][j] stands for the number of distince subsequences of T(First i characters) in S(First j characters)...*/

        /*
         if S[i] == T[j] { dp[i][j] = dp[i-1][j] (with s[i]) + dp[i-1][j-1] ( without s[i]) }  ;
         
         */
        public int NumDistinct(string S, string T)
        {
            int si = S.Length;
            int ti = T.Length;

            if (si <= 0 || ti <= 0 || si < ti) return 0;

            int[,] dptable = new int[si + 1, ti + 1];
            //if (S[0] == T[0])
            //    dptable[0, 0] = 1;
            //else
            //    dptable[0, 0] = 0;

            for (int i = 0; i <= si; i++)
            {
                dptable[0, i] = 1;
            }

            for (int i = 0; i < ti; i++)
            {
                dptable[i, 0] = 0;
            }

            for (int j = 0; j <= ti; ++j)
            {
                for (int i = 0; i <= si; ++i)
                {
                    dptable[i, j] = dptable[i - 1, j];
                    if (S[i] == T[j])
                    {
                        //if (j == 0)
                        //    dptable[i, j] += 1;
                        //else
                        dptable[i, j] += dptable[i - 1, j - 1];
                    }
                }
            }

            return dptable[si - 1, ti - 1];
        }



        #endregion

        #region  Decoding Ways
        /*
         
           A message containing letters from A-Z is being encoded to numbers using the following mapping:
            'A' -> 1
            'B' -> 2
            ...
            'Z' -> 26
            Given an encoded message containing digits, determine the total number of ways to decode it.
            For example,
            Given encoded message "12", it could be decoded as "AB" (1 2) or "L" (12).
            The number of ways decoding "12" is 2.
         
         */
        /*not correct  */
        public int NumDecodings(string s)
        {
            int result = 0;
            for (int i = 1; i < s.Length; i = i + 2)
            {
                if (valid(s[i].ToString()))
                {
                    result = result + 1;
                }
                if (i < s.Length - 1 && s[i] != '0')
                {
                    if (valid(s.Substring(i - 1, 2)))
                    {

                        result = result + 1;
                    }
                }
            }

            return result;
        }

        private bool valid(string s)
        {
            if (s.Length == 0) { return false; }
            if (s[0] == '0') { return false; }
            if (s.Length == 2)
            {
                if (s[0] > '2' || (s[0] == '2' && s[1] > '6')) { return false; }
            }
            return true;
        }

        public int NumDecodings2(string s)
        {

            if (s == null || s.Length == 0)
            {
                return 0;
            }

            int[] result = new int[s.Length + 1];

            if (s[0] != '0')
            {
                result[0] = 1;
            }

            if (s.Length == 1)
            {
                return result[0];
            }

            if (valid(s.Substring(0, 2)))
            {
                result[1]++;
            } //set res[1]

            if (s[0] != '0' && s[1] != '0')
            {
                result[1]++;
            } //set res[1]

            //DP
            for (int i = 2; i <= s.Length; i++)
            {
                if (s[i - 1] != '0') { result[i] += result[i - 1]; }
                if (i < s.Length)
                {


                    if (valid(s.Substring(i - 1, 2)))
                    {
                        result[i] += result[i - 2];
                    }
                }
            }

            return result[s.Length];

        }

        #endregion

        #region Leet Word Break
        /*        Given a string s and a dictionary of words dict, determine if s can be segmented into a space-separated sequence of one or more dictionary words.

        For example, given
        s = "leetcode",
        dict = ["leet", "code"].

        Return true because "leetcode" can be segmented as "leet code".*/

        public bool WordBreak(string s, List<string> dict)
        {
            foreach (string item in dict)
            {
                if (s.Contains(item))
                {
                    s = s.Remove(s.IndexOf(item), item.Length);

                }
                else
                {

                    return false;
                }
            }
            return true;
        }

        /*dymatic*/
        public bool WordBreakI(string s, List<string> dic)
        {
            /**/
            bool[] result = new bool[s.Length + 1];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = false;
            }

            result[0] = true;

            for (int i = 0; i < s.Length; i++)
            {


                for (int j = 0; j <= i - 1; j++)
                {
                    if (result[j] == true && DicContains(s.Substring(j + 1, i - j), dic))
                    {
                        result[i + 1] = true;
                        break;
                    }

                }
            }

            return result[result.Length - 1];
        }

        private bool DicContains(string s, List<string> dic)
        {
            foreach (string item in dic)
            {
                if (item.Contains(s))
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region word break II
        public List<string> WordBreakII(string s, List<string> dic)
        {
            if (dic == null || dic.Count == 0)
            {
                return null;
            }


            List<string> result = new List<string>();

            WordBreakIIhelper(s, dic, "", result, 0, 0);

            return result;
        }

        private void WordBreakIIhelper(string s, List<string> dic, string solution, List<string> result, int level, int len)
        {

            //if (level >= s.Length)
            //{
            //    return;
            //}
            if (level >= s.Length)
            {
                result.Add(solution);
                return;
            }
            string str = "";
            for (int i = level; i < s.Length; i++)
            {

                str = str + s[i];
                if (dic.Contains(str))
                {
                    len = str.Length;
                    solution = solution.Length == 0 ? (solution + str) : solution + " " + str;
                    WordBreakIIhelper(s, dic, solution, result, i + 1, len);
                    solution = solution.Remove(solution.Length - len, len);
                    if (solution.Length > 0)
                        solution = solution.Remove(solution.Length - 1);

                }


            }

        }



        public List<string> WordBreakII2(string s, List<string> dict)
        {
            List<String> results = new List<String>();
            string re = null;
            helper(results, re, s, dict, 0, 0);
            return results;
        }

        public void helper(List<string> results, String re, String s, List<String> dict, int start, int step)
        {
            if (start == s.Length)
            {
                results.Add(re);
                return;
            }
            foreach (string e in dict)
            {
                int len = e.Length;
                int end = start + len;
                if (end > s.Length) continue;
                string sub = s.Substring(start, len);
                if (sub.Equals(e))
                {
                    if (step != 0)
                        re = re + " ";
                    re = re + sub;
                    helper(results, re, s, dict, end, step + 1);
                    re = re.Remove(re.Length - len, len);
                    if (step != 0)
                        re = re.Remove(re.Length - 1);
                }
            }

        #endregion

        }


        public List<string> WordBreakDP(string s, List<string> dict)
        {
            List<string> results = new List<string>();
            string re = "";
            List<List<int>> dp = new List<List<int>>();
            for (int i = 0; i < s.Length + 1; i++)
            {
                dp.Add(new List<int>());
            }
            for (int i = 0; i < s.Length; i++)
            {
                if (i > 0 && dp[i].Count == 0) continue;
                foreach (string e in dict)
                {
                    int end = i + e.Length;
                    if (end > s.Length) continue;
                    String sub = s.Substring(i, e.Length);
                    if (sub.Equals(e))
                        dp[end].Add(i);
                }
            }
            helper(results,  re, s, dict, dp, s.Length, 0);
            return results;
        }
        public void helper(List<string> results,  string re, string s, List<string> dict, List<List<int>> dp, int cur, int step)
        {
            if (cur == 0)
            {
                results.Add(re);
                return;
            }
            foreach (int p in dp[cur])
            {
                if (step > 0) re =re.Insert(0, " ");
                re =re.Insert(0, s.Substring(p, cur-p));
                helper(results, re, s, dict, dp, p, step + 1);
                re =re.Remove(0, cur - p);
                if (step != 0) re.Remove(0);

               
            }
        }


        #region Interleaving String
        /*
                 Given s1, s2, s3, find whether s3 is formed by the interleaving of s1 and s2.
        For example,
        Given:
        s1 = "aabcc",
        s2 = "dbbca",
        When s3 = "aadbbcbcac", return true.
        When s3 = "aadbbbaccc", return false.
         */
   

        #endregion


    }

}


