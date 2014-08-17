using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Drawing;


namespace ClassLibrary
{


    class Recursion
    {

        #region 9.1
        //A child is running up a staircase with n steps, and can hop either 1 step, 2 steps, or
        //3 steps at a time. Implement a method to count how many possible ways the child
        //can run up the stairs.


        public int CountWays(int n)
        {
            if (n < 0)
            {
                return 0;
            }
            else if (n == 0)
            {
                return 1;
            }
            else
            {
                return CountWays(n - 1) + CountWays(n - 2) +
               CountWays(n - 3);
            }
        }


        /*iteration*/
        // did not correct since we did not consider about the sequence: for example 
        // 2+1+1 and 1+2+1 are different in this case 
        public int CoutWayTwo(int n)
        {
            int count = 0;
            for (int i = 0; i <= n / 3; i++)
            {
                for (int j = 0; j <= n / 2; j++)
                {
                    if (i * 3 + j * 2 <= n)
                    {
                        count++;
                    }

                }



            }

            return count;
        }
        /*end iteration*/

        /*interation two not correnct */
        public int CountWaysThree(int n)
        {
            int count = 0;
            for (int i = n; i >= 0; i--)
            {
                count++;
            }

            for (int i = n; i >= 0; i = i - 2)
            {
                count++;
            }

            for (int i = n; i >= 0; i = i - 3)
            {
                count++;
            }

            return count;
        }
        /*end interation two*/

        /*dynamic*/
        public int CountWaysDP(int n, int[] map)
        {
            if (n < 0)
            {
                return 0;
            }
            else if (n == 0)
            {
                return 1;
            }
            else if (map[n] > -1)
            {
                return map[n];
            }
            else
            {
                map[n] = CountWaysDP(n - 1, map) +
                CountWaysDP(n - 2, map) +
                CountWaysDP(n - 3, map);
                return map[n];
            }
        }
        /*end dynamic */

        /*another dynamic like Fibonacci number */
        public int CountWaysDP2(int n)
        {
            int[] map = new int[n + 1];


            map[0] = 1;
            map[1] = 1;
            map[2] = 2;


            for (int i = 3; i <= n; i++)
            {
                map[i] = map[i - 1] + map[i - 2] + map[i - 3];
            }

            return map[n];
        }

        public int CountWaysDP3(int n)
        {

            int[] map = new int[3 + 1];
            map[0] = 1;
            map[1] = 1;
            map[2] = 2;

            for (int i = 3; i <= n; i++)
            {
                map[i % 4] = map[(i - 1) % 4] + map[(i - 2) % 4] + map[(i - 3) % 4];
            }
            return map[n % 4];
        }

        /*end Fibonacci number*/

        #endregion 9.1

        #region 9.2
        //Imagine a robot sitting on the upper left comer of an X by Ygrid. The robot can only
        //move in two directions: right and down. How many possible paths are there for the
        //robot to go from (0, 0) to (X, Y) ?
        public int GetPath(int x, int y)
        {
            if (x == 1 || y == 1) return 1;
            //if (x == 0 && y == 0) return 1; 
            else
            {
                return GetPath(x - 1, y) + GetPath(x, y - 1);
            }

        }
        //FOLLOW UP
        //Imagine certain spots are "off limits," such that the robot cannot step on them.
        //Design an algorithm to find a path for the robot from the top left to the bottom right.

        public class pointR : IEqualityComparer<pointR>
        {
            int x;
            int y;
            public pointR(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
            public pointR()
            { }

            public bool Equals(pointR b1, pointR b2)
            {
                if (b1.x == b2.x & b1.y == b2.y)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }



            public int GetHashCode(pointR bx)
            {
                return bx.x ^ bx.y;
            }




        }



        public Boolean GetPathOne(int x, int y, ArrayList path)
        {
            pointR point = new pointR(x, y);
            path.Add(point);

            if (x == 0 && y == 0)
            {
                return true;
            }
            bool succ = false;

            if (x >= 1) { succ = GetPathOne(x - 1, y, path); }
            if (y >= 1 && !succ) { succ = GetPathOne(x, y - 1, path); }

            if (succ) { path.Add(point); }

            return succ;

        }

        public Boolean GetPathOneProved(int x, int y, ArrayList path)
        {
            pointR point = new pointR(x, y);
            path.Add(point);

            if (x == 0 && y == 0)
            {
                return true;
            }
            bool succ = false;

            if (x >= 1) { succ = GetPathOneProved(x - 1, y, path); }
            if (y >= 1 && !succ) { succ = GetPathOneProved(x, y - 1, path); }

            if (!succ) { path.Remove(point); }

            return succ;

        }



        #region dynamic solution
        Dictionary<pointR, bool> cache = new Dictionary<pointR, bool>(new pointR());


        public Boolean GetPathDynamic(int x, int y, ArrayList path)
        {
            // if (cache == null) { cache = new Hashtable(); }
            // if (path == null) { path = new ArrayList(); }

            pointR point = new pointR(x, y);

            if (cache.ContainsKey(point))
            {
                return (bool)cache[point];
            }

            if (x == 0 && y == 0) return true;
            bool succ = false;

            if (x >= 1) { succ = GetPathDynamic(x - 1, y, path); }

            //we need find a path to either (x-1,y) or ( x, y-1)
            if (y >= 1 && !succ) { succ = GetPathDynamic(x, y - 1, path); }

            if (succ)
            {

                path.Add(point);
            }

            cache.Add(point, succ);

            return succ;

        }// end function
        #endregion dymatic

        #region iteration
        // not correct current 
        public int GetPathThree(int x, int y)
        {
            int count = 0;
            for (int i = x; i >= 0; i--)
            {
                for (int j = y; j >= 0; j--)
                {
                    if (x == 0 && y == 0) { count++; }
                }
            }

            return count;
        }

        #endregion iteration

        #endregion

        #region 9.3
        // A magic index in an array A[l.. .n-l] is defined to be an index such that A[i] =
        //i. Given a sorted array of distinct integers, write a method to find a magic index, if
        // one exists, in array A.
        //FOLLOW UP
        // What if the values are not distinct

        // if the element is distinct 
        public int MagicFasDistinct(int[] data, int end, int start)
        {
            if (end < start || start < 0 || end > data.Length - 1) return -1;
            int med = (start + end) / 2;
            if (data[med] == med) { return med; }
            if (med > data[med])
            {
                // go to right side 
                return MagicFasDistinct(data, (med + 1), end);

            }
            else
            {

                return MagicFasDistinct(data, start, (med - 1));
            }



        }

        //-10,-5.2,2,2,3,4,7,9,12,13
        // 0, 1, 2,3,4,5,6,7,8,9,10 

        // if the element is not distinct



        public int MagicFast(int[] data, int end, int start)
        {
            if (end < start || start < 0 || end > data.Length - 1) return -1;

            int med_index = (start + end) / 2;
            int med_value = data[med_index];
            if (med_index == med_value) { return med_index; }

            // search left side
            int left_index = Math.Min(med_index - 1, med_value);

            int left = MagicFast(data, start, left_index);
            if (left > 0) return left;

            // search right side
            int right_index = Math.Max(med_index + 1, med_value);
            int right = MagicFast(data, right_index, end);

            return right;

        }
        #endregion

        #region 9.4

        //9.4 Write a method to return all subsets of a set.

        //Solution #1:  Recurision

        public ArrayList GetSubsets(int[] set, int index = 0)
        {
            ArrayList allsubsets;
            //if (index >= set.Length) return null;

            if (index == set.Length)
            { // Base case - add empty set
                allsubsets = new ArrayList();
                allsubsets.Add(new ArrayList()); // Empty set
            }
            else
            {
                allsubsets = GetSubsets(set, index + 1);
                int item = set[index];
                ArrayList moresubsets = new ArrayList();
                foreach (ArrayList i in allsubsets)
                {
                    ArrayList newsubset = new ArrayList();
                    newsubset.AddRange(i);
                    newsubset.Add(item);
                    moresubsets.Add(newsubset);
                }
                allsubsets.AddRange(moresubsets);
            }
            return allsubsets;
        }

        // solution #1.1 Also is Recurision, Changed by Xin
        public List<string> GetSubsetsXin(string set)
        {
            List<string> result = new List<string>();
            result.Add("");
            GetSubsetsXinHelp(set, result, 0);
            return result;
        }

        private void GetSubsetsXinHelp(string set, List<string> result, int index)
        {

            if (index < set.Length)
            {


                string s = set[index].ToString();
                List<string> temp = new List<string>();
                foreach (string item in result)
                {
                    temp.Add(item + s);

                }

                result.AddRange(temp);
                GetSubsetsXinHelp(set, result, index + 1);
            }
        }


        #region interation
        public ArrayList GetSubsetsForLoop(int[] set)
        {
            ArrayList allsubsets = new ArrayList();
            //if (index >= set.Length) return null;

            for (int index = 0; index < set.Length; index++)
            {
                int item = set[index];
                ArrayList moresubsets = new ArrayList();

                if (allsubsets.Count == 0)
                {

                    allsubsets.Add(new ArrayList()); // Empty set
                }
                foreach (ArrayList i in allsubsets)
                {
                    ArrayList newsubset = new ArrayList();
                    newsubset.AddRange(i);
                    newsubset.Add(item);
                    moresubsets.Add(newsubset);
                }
                allsubsets.AddRange(moresubsets);


            }




            return allsubsets;
        }
        #endregion interation
        //Solution #2: Combinatorics
        //1) the element is in the set (the "yes" state) or 
        //2) the element is not in the set (the "no" state).

        //        ArrayList getSubsets2(ArrayList set) {
        //        ArrayList allsubsets = new ArrayList ();
        //        int max = 1 « set.Capacity(); /* Compute 2An */
        //5 for (int k = 0; k < max; k++) {
        //6 ArrayList<Integer> subset = convert!ntToSet(kj set);
        //7 allsubsets.add(subset);
        //8 }
        //9 return allsubsets;
        //10 }

        #region second solution

        public ArrayList GetSubsets2(int[] set)
        {
            ArrayList allsubsets = new ArrayList();
            int max = 1 << set.Length; /* Compute 2^n */
            for (int k = 0; k < max; k++)
            {
                ArrayList subset = convertIntToSet(k, set);
                allsubsets.Add(subset);
            }
            return allsubsets;
        }

        private ArrayList convertIntToSet(int x, int[] set)
        {
            ArrayList subset = new ArrayList();
            int index = 0;

            for (int k = x; k > 0; k = k >> 1)
            {
                if ((k & 1) == 1)
                {
                    subset.Add(set[index]);
                }
                index++;
            }
            return subset;
        }

        #endregion second solution
        #endregion

        #region 9.5
        //Write a method to compute all permutations of a string
        public ArrayList GetPerms(String str)
        {
            if (str == null)
            {
                return null;
            }
            ArrayList permutations = new ArrayList();
            if (str.Length == 0)
            { // base case
                permutations.Add("");
                return permutations;
            }

            char first = str[0]; // get the first character
            String remainder = str.Substring(1); // remove the 1st character
            ArrayList words = GetPerms(remainder);
            foreach (string word in words)
                for (int j = 0; j <= word.Length; j++)
                {
                    String s = insertCharAt(word, first, j);
                    permutations.Add(s);
                }
            return permutations;
        }


        #region iterative solution
        public List<string> GetPermsIteration(String str)
        {
            if (str == null)
            {
                return null;
            }
            List<string> permutations = new List<string>();
            permutations.Add("");

            foreach (char item in str)
            {
                List<string> newStr = new List<string>();
                foreach (string word in permutations)
                {


                    for (int j = 0; j <= word.Length; j++)
                    {
                        String s = insertCharAt(word, item, j); // hu, uh
                        //string s = word + item;
                        newStr.Add(s);

                    }

                }
                permutations.Clear();// don`t need in recursive function 
                permutations.AddRange(newStr);


            }



            return permutations;
        }


        #endregion iterative soltion


        public string insertCharAt(string word, char c, int i)
        {
            string start = word.Substring(0, i);
            string end = word.Substring(i);
            return start + c + end;
        }

        #endregion

        #region 9.6

        //    Implement an algorithm to print all valid (i.e., properly opened and closed) combinations of n-pairs of parentheses.
        //()().....
        #region  first solution

        public HashSet<string> GenerateParens(int remaining)
        {
            HashSet<string> set = new HashSet<String>();
            if (remaining == 0)
            {
                set.Add("");
            }
            else
            {
                HashSet<string> prev = GenerateParens(remaining - 1);

                foreach (string str in prev)
                {


                    for (int i = 0; i < str.Length; i++)
                    {
                        if (str[i] == '(')
                        {
                            String s = insertInside(str, i);
                            /* Add s to set if it's not already in there. Note:
                            * HashSet automatically checks for duplicates before
                            * adding, so an explicit check is not necessary. */
                            set.Add(s);
                        }
                    }
                    if (!set.Contains("()" + str))
                    {
                        set.Add("()" + str);
                    }
                }
            }
            return set;
        }

        private String insertInside(String str, int leftlndex)
        {
            String left = str.Substring(0, leftlndex + 1);
            String right = str.Substring(leftlndex + 1);
            return left + "()" + right;
        }

        #endregion

        #region  second solution

        private void addParen(List<string> list, int leftRem, int rightRem, char[] str, int count)
        {
            if (leftRem < 0 || rightRem < leftRem) return; // invalid state

            if (leftRem == 0 && rightRem == 0)
            { /* no more parens left */
                String s = new string(str);
                list.Add(s);
            }
            else
            {
                /* Add left paren, if there are any left parens remaining. */
                if (leftRem > 0)
                {
                    str[count] = '(';
                    addParen(list, leftRem - 1, rightRem, str, count + 1);
                }

                /* Add right paren., if expression is valid */
                if (rightRem > leftRem)
                {
                    str[count] = ')';
                    addParen(list, leftRem, rightRem - 1, str, count + 1);
                }
            }
        }

        public List<string> GenerateParensTwo(int count)
        {
            char[] str = new char[count * 2];
            List<string> list = new List<string>();
            addParen(list, count, count, str, 0);
            return list;
        }
        #endregion second solution
        #endregion

        #region 9.7
        // have issure about the two conditions
        // 1. if (screen[x, y] == ocolor)
        // 2.  if (screen[x, y] == ncolor) 



        //Implement the "paint fill" function that one might see on many image editing
        //programs. That is, given a screen (represented by a two-dimensional array of colors),
        //a point, and a new color, fill in the surrounding area until the color changes from the
        //original color

        private bool PaintColor(Color[,] screen, int x, int y, Color ocolor, Color ncolor)
        {
            if (
                  (x >= 0 && x >= screen.GetLength(0))
                    ||
                  (y > 0 && y >= screen.GetLength(1))
                )
            {
                return false;
            }

            if (screen[x, y] == ocolor)
            {

                screen[x, y] = ncolor;
                // left 
                PaintColor(screen, x - 1, y, ocolor, ncolor);
                //right
                PaintColor(screen, x + 1, y, ocolor, ncolor);
                //upper
                PaintColor(screen, x, y - 1, ocolor, ncolor);
                //down
                PaintColor(screen, x, y + 1, ocolor, ncolor);

            }

            return true;
        }


        public bool PaintColor(Color[,] screen, int x, int y, Color ncolor)
        {
            if (screen[x, y] == ncolor)
            {
                return false;
            }
            else
            {
                return PaintColor(screen, x, y, ncolor);
            }

        }



        #endregion

        #region 9.8

        // Given an infinite number of quarters (25 cents), dimes (10 cents), nickels (5 cents)
        // and pennies (1 cent), write code to calculate the number of ways of representing n
        // cents

        // we need make sure what is the first one( 25, 10,5 or 1) 

        public int MakeChange(int n, int denom)
        {
            int next_denom = 0;

            switch (denom)
            {
                case 25:
                    next_denom = 10;
                    break;
                case 10:
                    next_denom = 5;
                    break;
                case 5:
                    next_denom = 1;
                    break;
                case 1:
                    return 1;
            }

            int ways = 0;
            for (int i = 0; i * denom <= n; i++)
            {
                ways += MakeChange(n - i * denom, next_denom);

            }
            return ways;
        }


        public int MakeChangeTwo(int sum, int c, int n)
        {


            int ways = 0;
            if (sum <= n)
            {
                if (sum == n) return 1;
                if (c >= 25)
                    ways += MakeChangeTwo(sum + 25, 25, n);
                if (c >= 10)
                    ways += MakeChangeTwo(sum + 10, 10, n);
                if (c >= 5)
                    ways += MakeChangeTwo(sum + 5, 5, n);
                if (c >= 1)
                    ways += MakeChangeTwo(sum + 1, 1, n);
            }
            return ways;
        }


        int cnt = 0;
        public void MakeChangeThree(int sum, int c, int n)
        {
            if (sum >= n)
            {
                if (sum == n) ++cnt;
                return;
            }
            else
            {
                if (c >= 25)
                    MakeChangeThree(sum + 25, 25, n);
                if (c >= 10)
                    MakeChangeThree(sum + 10, 10, n);
                if (c >= 5)
                    MakeChangeThree(sum + 5, 5, n);
                if (c >= 1)
                    MakeChangeThree(sum + 1, 1, n);
            }
        }


        public int MakeChangeFour(int n)
        {
            int count = 0;
            for (int i = 0; i <= n / 25; i++)
                for (int j = 0; j <= n / 10; j++)
                    for (int k = 0; k <= n / 5; k++)
                    //for (int l = 0; l <= n; l++)
                    {
                        // int v = i * 25 + j * 10 + k * 5 + l;
                        int v = i * 25 + j * 10 + k * 5;
                        if (v <= n)
                            count++;
                        else if (v > n)
                            break;
                    }
            return count;
        }



        #endregion

        #region 9.10
        //You have a stack of n boxes, with widths w., heights l\ and depths dr The boxes
        // cannot be rotated and can only be stacked on top of one another if each box in the
        // stack is strictly larger than the box above it in width, height, and depth. Implement
        //a method to build the tallest stack possible, where the heigh t of a stack is the sum of
        //the heights of each box.


        #endregion

        #region 9.9

        // Write an algorithm to prim all ways of arranging eight queens on an 8x8 chess
        // board so that none of them share the same row, column or diagonal. In this case,
        //"diagonal" means all diagonals, not just the two that bisect the board.

        public void PlaceQueens(int grid_size, int row, int[] columns, ref ArrayList results)
        {
            if (row == grid_size)
            {
                results.Add(columns.Clone());
            }
            else
            { // Found valid placement

                for (int col = 0; col < grid_size; col++)
                {
                    if (checkValid(columns, row, col))
                    {
                        columns[row] = col; // Place queen
                        PlaceQueens(grid_size, row + 1, columns, ref results);
                    }
                }
            }


        }

        /* Check if (rowl, columnl) is a valid spot for a queen by checking
        * if there is a queen in the same column or diagonal. We don't
        * need to check it for queens in the same row because the calling
        * placeQueen only attempts to place one queen at a time. We know
        * this row is empty. */

        private bool checkValid(int[] columns, int row1, int column1)
        {
            for (int row2 = 0; row2 < row1; row2++)
            {
                int column2 = columns[row2];
                /* Check if (row2, column2) invalidates (rowl, columnl) as a queen spot. */

                /* Check if rows have a queen in the same column */
                if (column1 == column2)
                {
                    return false;
                }

                /* Check diagonals: if the distance between the columns equals the distance between the rows, then they're in the
                same diagonal. */
                int columnDistance = Math.Abs(column2 - column1);

                /* rowl > row2, so no need for abs */
                int rowDistance = row1 - row2;
                if (columnDistance == rowDistance)
                {
                    return false;
                } // end if 
            }// end for
            return true;

        }

        #endregion

        #region 11.7
        // A circus is designing a tower routine consisting of people standing atop one another's
        //shoulders. For practical and aesthetic reasons, each person must be both shorter
        //and lighter than the person below him or her. Given the heights and weights of
        //each person in the circus, write a method to compute the largest possible number
        //of people in such a tower.

        /*
         1. sort the array, (compared the height first, then compared the wid
         2. find the logest increst subsequence for each item 
             2.1 if the there exist (isbeofre() item from 0 - (i-1) ), the find the LIS from( 0- (i-1)) 
         3. find the logest increst subsequence for the whole array
         */

        public List<HtWt> GetIncreasingSequence(List<HtWt> items)
        {
            items.Sort();
            return longestIncreasingSubsequence(items);
        } // end getIncrease

        private void longestIncreasingSubsequence(List<HtWt> array,
        ref List<HtWt>[] solutions, int current_index)
        {
            if (current_index >= array.Count || current_index < 0) return;
            HtWt current_element = (HtWt)array[current_index];

            /* Find longest sequence we can append current_element to */
            List<HtWt> best_sequence = null;
            for (int i = 0; i < current_index; i++)
            {
                if (((HtWt)array[i]).isBefore(current_element))
                {
                    best_sequence = seqWithMaxLength(best_sequence, solutions[i]);
                }
            }

            /* Append current_element */
            List<HtWt> new_solution = new List<HtWt>();
            if (best_sequence != null)
            {
                new_solution.AddRange(best_sequence);
            }
            new_solution.Add(current_element);

            /* Add to list and recurse */
            solutions[current_index] = new_solution;
            longestIncreasingSubsequence(array, ref solutions, current_index + 1);




        } // end longestIncrease


        private List<HtWt> longestIncreasingSubsequence(List<HtWt> array)
        {
            List<HtWt>[] solutions = new List<HtWt>[array.Count];
            longestIncreasingSubsequence(array, ref solutions, 0);

            List<HtWt> best_sequence = null;
            for (int i = 0; i < array.Count; i++)
            {
                best_sequence = seqWithMaxLength(best_sequence, solutions[i]);
            }

            return best_sequence;
        }


        /* Returns longer sequence */
        private List<HtWt> seqWithMaxLength(List<HtWt> seql, List<HtWt> seq2)
        {
            if (seql == null) return seq2;
            if (seq2 == null) return seql;
            return seql.Count > seq2.Count ? seql : seq2;
        }

        public class HtWt : IComparable
        {
            /* declarations, etc */
            public int Ht;
            public int Wt;

            /* used for sort method */
            public int CompareTo(Object s)
            {
                HtWt second = (HtWt)s;
                if (this.Ht != second.Ht)
                {
                    return ((int)this.Ht).CompareTo(second.Ht);
                }
                else
                {
                    return ((int)this.Wt).CompareTo(second.Wt);
                }
            } // end compareTo

            /* Returns true if "this" should be lined up before "other."
               Note that it's possible that this.isBefore(other) and
               other.isBefore(this) are both false. This is different from
               the compareTo method, where if a < b then b > a. */

            public bool isBefore(HtWt other)
            {
                if (this.Ht < other.Ht && this.Wt < other.Wt) return true;
                else return false;
            }

            public HtWt(int h, int w)
            {
                Ht = h;
                Wt = w;

            }


        } // end class




        #endregion




        #region Leet Palindrome Partitioning
        /*
         Given a string s, partition s such that every substring of the partition is a palindrome.
         Return all possible palindrome partitioning of s.
         For example, given s = "aab",
         Return
        [
            ["aa","b"],
            ["a","a","b"]
        ]         
         */

        public Stack<Stack<string>> Partition(string s)
        {
            Stack<string> r = new Stack<string>();
            Stack<Stack<string>> res = new Stack<Stack<string>>();
            PartitionHelpFun(s, r, res, 0);
            return res;

        }

        private bool VaildPartition(string s, int st, int end)
        {
            while (st < end)
            {
                if (s[st] != s[end])
                {
                    return false;
                }
                else
                {
                    st++;
                    end--;
                }
            }
            return true;
        }


        private void PartitionHelpFun(string s, Stack<string> r, Stack<Stack<string>> res, int st)
        {
            if (st >= s.Length)
            {
                Stack<string> copy_r = new Stack<string>(r);
                res.Push(copy_r);
            }
            else
            {

                for (int i = st; i < s.Length; i++)
                {
                    if (VaildPartition(s, st, i))
                    {
                        r.Push(s.Substring(st, i - st + 1));
                        PartitionHelpFun(s, r, res, i + 1);
                        r.Pop(); // the differet recursive and for loop, compared with r.clear since it is recurise 
                    }
                }
            }

        }
        #endregion

        #region Leet Palindrome Partitioning for loop

        public Stack<Stack<string>> PartitionForLoop(string s)
        {
            Stack<string> r = new Stack<string>();
            Stack<Stack<string>> res = new Stack<Stack<string>>();
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i; j < s.Length; j++)
                {
                    if (VaildPartition(s, i, j))
                    {
                        r.Push(s.Substring(i, j - i + 1));

                    }

                }
                Stack<string> copy_r = new Stack<string>(r);
                res.Push(copy_r);
                r.Clear();//the differet recursive and for loop

            }



            return res;

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
            1. understand the question 
         
         */

        /*
         go through all subset in S(should not in  T) , find out how many subets are in S are equal to T as 9.4 
         */

        public int NumDistinct(string s, string t)
        {
            List<string> result = GetSubsetsXin(s);
            int count = 0;
            foreach (string item in result)
            {
                if (item == t)
                {
                    count++;
                }
            }
            // remove the empty 
            return count;
        }
        #endregion

        #region Leet Decoding Ways
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
        /*recursive ways */
        /* find all subsets of number*/

        public int NumDecodings(String s)
        {
            int result = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (VaildChar(s[i]))
                {
                    result = result + 1;
                }

                for (int j = i + 1; j < s.Length; j++)
                {
                    if (VaildChar(s[i], s[j]))
                    {
                        result = result + 1;
                    }
                }

            }

            return result;
        }

        /*Recursion Way*/
        public int NumDecodingsRecur(String s)
        {
            int result = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (VaildChar(s[i]))
                {
                    result = result + 1;
                }

                NumDecodingsRecurHelp(s, i + 1, s[i], ref result);
            }

            return result;
        }

        private void NumDecodingsRecurHelp(string s, int index, char start, ref int result)
        {
            if (index < s.Length)
            {

                if (VaildChar(start, s[index]))
                {
                    result = result + 1;
                }

                NumDecodingsRecurHelp(s, index + 1, start, ref result);
            }


        }
        /**/




        public bool VaildChar(char c)
        {
            return true;
        }

        public bool VaildChar(char c1, char c2)
        {
            return true;
        }
        #endregion

        #region Leet Letter Combinations of a Phone Number
        /*Given a digit string, return all possible letter combinations that the number could represent.
        A mapping of digit to letters (just like on the telephone buttons) is given below.
        
         * Input:Digit string "23"
        Output: ["ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"].
         * 
        */
        public List<string> LetterCombinations(string digits)
        {
            List<string> LetterList = new List<string>();
            List<string> result = new List<string>();

            for (int i = 0; i < digits.Length; i++)
            {
                int n = 0;
                if (int.TryParse(digits[i].ToString(), out n))
                {
                    string temp = CoverNumber(n);
                    if (temp != null)
                    {
                        LetterList.Add(temp);
                    }

                }

            }
            /*following commented by me is not correct, look at the LetterCombinationsTwo */

            //for (int i = 0; i < 4; i++)
            //{


            //    string temp = null;
            //    foreach (string item in resultList)
            //   {


            //            if (i < item.Length)
            //            {
            //            temp = temp + item[i];
            //            }

            //        }

            //        resultList.Add(temp);
            //    }

            foreach (string item in LetterList)
            {
                foreach (char c in item)
                {


                }

            }


            return result;
        }
        private string CoverNumber(int n)
        {
            string[] trans = { "", " ", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };
            if (n < trans.Length)
            {
                return trans[n];
            }
            else
            {

                return null;
            }


        }
        public String[] digitToString()
        {
            String[] res = new String[8];
            char start = 'a';

            for (int i = 0; i < 8; i++)
            {
                int count = (i == 5 || i == 7) ? 4 : 3;
                StringBuilder temp = new StringBuilder("");
                for (int j = 0; j < count; j++)
                {
                    temp.Append((char)(start + j));
                }
                start = (char)(start + count);
                res[i] = temp.ToString();
            }
            return res;
        }
        public List<string> LetterCombinationsTwo(String digits)
        {
            // Start typing your Java solution below
            // DO NOT write main() function
            List<string> res = new List<string>();
            res.Add("");
            if (digits == null) return res;
            String[] table = digitToString();
            for (int i = 0; i < digits.Length; i++)
            {
                List<string> cur = new List<string>();
                char c = digits[i];
                if (c >= '2' && c <= '9')
                {
                    foreach (String temp in res)
                    {
                        for (int j = 0; j < table[c - '2'].Length; j++)
                        {
                            cur.Add(temp + table[c - '2'][j]);
                        }
                    }
                }
                res = new List<string>(cur);
            }
            return res;
        }
        /*
         recursive 
        */
        public string[] LetterCombinationsRecur(string digits)
        {
            string[] trans = digitToString();
            List<string> set = new List<string>();
            set.Add("");

            LetterCombinationsRecurHelp(trans, digits, 0, ref set);
            return set.ToArray();
        }

        private void LetterCombinationsRecurHelp(string[] trans, string digits, int deep, ref List<string> set)
        {
            if (deep < digits.Length)
            {
                int curDig = int.Parse(digits[deep].ToString());


                List<string> cur = new List<string>();
                for (int i = 0; i < trans[curDig - 2].Length; i++)
                {
                    foreach (string item in set)
                    {
                        cur.Add(item + trans[curDig - 2][i]);



                    }

                }

                set = new List<string>(cur);
                LetterCombinationsRecurHelp(trans, digits, deep + 1, ref set);
            }
        }
        #endregion

        #region Leet Gray Code
        /*The gray code is a binary numeral system where two successive values differ in only one bit.
            Given a non-negative integer n representing the total number of bits in the code, print the sequence of gray code. A gray code sequence must begin with 0.
            For example, given n = 2, return [0,1,3,2]. Its gray code sequence is:*/

        /*
         00 - 0
         01 - 1
         11 - 3
         10 - 2
         */
        /*   Note:
           For a given n, a gray code sequence is not uniquely defined.
           For example, [0,2,3,1] is also a valid gray code sequence according to the above definition.
           For now, the judge is able to judge based on one instance of gray code sequence. Sorry about that.*/

        /*
            thought: like the "letter combination of a phone number" if n =2 we can find all possibility that 0 and 1 can be made
         *           00, 01 , 10, 11 ... then trnasfer sets to the number
         *           
         * 
         *  look at some solutions in web, the Gray code must begin from 0 --- 00 then plus 1 -- 01 then p
                http://yucoding.blogspot.com/2013/01/leetcode-question-33-gary-code.html
         */
        #endregion

        #region Leet Largest Rectangle in Histogram
        /*
             Given n non-negative integers representing the histogram's bar height where the width of each bar is 1, find the area of largest rectangle in the histogram.
             */


        /*1*/
        public int LargestRectangleAreaSolution1(List<int> height)
        {
            int max_value = 0;
            for (int i = 0; i < height.Count; i++)
            {
                int min_value = height[i];
                for (int j = i; j >= 0; j--)
                {
                    min_value = Math.Min(min_value, height[j]);
                    int area = min_value * (i - j + 1);
                    if (area > max_value)
                        max_value = area;
                }
            }
            return max_value;
        }
        /*end 1*/

        /*2*/
        public int LargestRectangleAreaSolution2(List<int> height)
        {
            int maxV = 0;
            for (int i = 0; i < height.Count; i++)
            {
                if (i + 1 < height.Count && height[i] <= height[i + 1]) // if not peak node, skip it  
                    continue;
                int minV = height[i];
                for (int j = i; j >= 0; j--)
                {
                    minV = Math.Min(minV, height[j]);
                    int area = minV * (i - j + 1);
                    if (area > maxV)
                        maxV = area;
                }
            }
            return maxV;
        }
        /*end 2*/

        /*3*/
        public int LargestRectangleAreaSolution3(List<int> height)
        {

            Stack<int> max_height_stack = new Stack<int>();
            Stack<int> width = new Stack<int>();
            if (height.Count == 0) return 0;
            int area = int.MinValue;
            int newHeight;
            for (int i = 0; i <= height.Count; i++)
            {
                if (i < height.Count) newHeight = height[i];
                else newHeight = -1;


                if (max_height_stack.Count == 0 || newHeight >= max_height_stack.Peek())
                {

                    max_height_stack.Push(newHeight);
                    width.Push(1);
                }
                else
                {
                    int minV = int.MaxValue;
                    int wid = 0;

                    while (max_height_stack.Peek() > newHeight)
                    {


                        minV = Math.Min(minV, max_height_stack.Peek());
                        wid += width.Peek();
                        area = Math.Max(area, minV * (wid));
                        max_height_stack.Pop();
                        if (max_height_stack.Count == 0) break;
                    }

                    max_height_stack.Push(newHeight);
                    width.Push(wid + 1);
                }
            }
            return area;
        }
        /*end solution 3*/

        /*4*/

        public int LargestRectangleAreaSolution4(List<int> h)
        {
            Stack<int> S = new Stack<int>();
            h.Add(0);
            int sum = 0;
            for (int i = 0; i < h.Count; i++)
            {
                if (S.Count == 0 || h[i] > h[S.Peek()]) S.Push(i);
                else
                {
                    int tmp = S.Peek();
                    S.Pop();
                    sum = Math.Max(sum, h[tmp] * (S.Count == 0 ? i : i - S.Peek() - 1));
                    i--;
                }
            }
            return sum;
        }
        /*end solution*/


        #endregion

        #region Leet Word Search

        /*Given a 2D board and a word, find if the word exists in the grid.
        The word can be constructed from letters of sequentially adjacent cell, where "adjacent" cells are those horizontally or vertically neighboring. The same letter cell may not be used more than once.
        For example,
        Given board =
        [
          ["ABCE"],
          ["SFCS"],
          ["ADEE"]
        ]
        word = "ABCCED", -> returns true,
        word = "SEE", -> returns true,
        word = "ABCB", -> returns false.*/

        public bool Search(List<string> board, string str)
        {



            if (board.Count == 0)
            {
                return false;
            }

            int[,] mark = new int[board.Count, board[0].Length];

            for (int i = 0; i < board.Count; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    if (FindAdjeacent(i, j, str, 0, board, mark) == true)
                    {

                        return true;
                    }
                }
            }

            return false;
        }

        private bool FindAdjeacent(int row, int col, string s, int index, List<string> board, int[,] mark)
        {
            int max_row = board.Count;
            int max_col = board[0].Length; ;


            if (row >= max_row || row < 0 || col < 0 || col >= max_col)
            {
                return false;
            }
            else
            {
                if (index >= s.Length)
                {

                    return true;
                }
                else
                {

                    char c = s[index];
                    if (board[row][col] == c && mark[row, col] == 0)
                    {
                        mark[row, col] = 1;

                        return (FindAdjeacent(row - 1, col, s, index + 1, board, mark) ||
                               FindAdjeacent(row + 1, col, s, index + 1, board, mark) ||
                               FindAdjeacent(row, col + 1, s, index + 1, board, mark) ||
                               FindAdjeacent(row, col - 1, s, index + 1, board, mark));

                    }

                }
            }

            return false;
        }
        #endregion

        #region Leet Combinations, Solution
        /*
         Given two integers n and k, return all possible combinations of k numbers out of 1 ... n.
         For example,
         If n = 4 and k = 2, a solution is:
                [
                  [2,4],
                  [3,4],
                  [2,3],
                  [1,2],
                  [1,3],
                  [1,4],
                ]
         
         */

        public List<List<int>> Combine(int n, int k)
        {
            List<List<int>> result = new List<List<int>>();
            List<int> solution = new List<int>();
            GetCombine(n, k, 1, solution, result);
            return result;
        }
        private void GetCombine(int n, int k, int level, List<int> solution, List<List<int>> result)
        {
            if (solution.Count == k)
            {

                result.Add(new List<int>(solution));
                return;
            }
            for (int i = level; i <= n; i++)
            {
                solution.Add(i);
                GetCombine(n, k, i + 1, solution, result);
                solution.Remove(i);
            }
        }

        /*Combinations, Solution, iterator solution */
        public List<Stack<int>> CombineWhileLoop(int n, int k)
        {

            List<Stack<int>> result = new List<Stack<int>>();
            Stack<int> temp = new Stack<int>();

            // start with 1 
            for (int i = 1; i <= n; i++)
            {



                for (int j = i; j <= n; j++)
                {

                    temp.Push(j);
                    if (temp.Count == k)
                    {
                        result.Add(new Stack<int>(temp));
                        temp.Pop();

                    }

                }


                temp.Clear(); // the different loop and recurise       


            }

            return result;
        }

        #endregion

        #region Leet Minimum Window Substring

        /* Given a string S and a string T, find the minimum window in S which will contain all the characters in T in complexity O(n).

        For example,
        S = "ADOBECODEBANC"
        T = "ABC"
        Minimum window is "BANC".

        Note:
        If there is no such window in S that covers all characters in T, return the emtpy string "".

        If there are multiple such windows, you are guaranteed that there will always be only one unique minimum window in S.*/


        /*
         thought: Min(i) is the array, it is minimum window in S contain the i th characters in T 
         * 
         * if s[j] = t[j] Min(i) = Min(i-1)+ s[i-1 .... j]
         * else min(i) = Min(i-1)
         */


        /* O(n*m) */

        public string MinWindow(String s, String t)
        {
            // times appear in T
            Dictionary<char, int> needToFill = new Dictionary<char, int>();

            // keys is the letter in T and values is the index of this letterin S 
            Dictionary<char, List<int>> charAppearenceRecorder = new Dictionary<char, List<int>>();

            // keys is the leter in T and the values is the bit status, if the T ="ABC" then the bit status of T is "012"
            // if find the letter in S then set that bit to 1 
            Dictionary<char, int> charBit = new Dictionary<char, int>();

            int bit_cnt = 0;

            for (int i = 0; i < t.Length; i++)
            {
                if (needToFill.ContainsKey(t[i]))
                {
                    needToFill[t[i]] = needToFill[t[i]] + 1;
                }
                else
                {
                    needToFill.Add(t[i], 1);
                    charBit.Add(t[i], bit_cnt++);
                    charAppearenceRecorder.Add(t[i], new List<int>());
                }
            }

            long upper = (1 << bit_cnt) - 1;
            int bit_status = 0;
            int minWinStart = -1;
            int minWinEnd = s.Length;
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (needToFill.ContainsKey(c))
                {
                    List<int> charList = charAppearenceRecorder[c];
                    charList.Add(i);
                    if (charList.Count == needToFill[c])
                    {
                        bit_status |= (1 << charBit[c]);
                    }
                    if (charList.Count > needToFill[c] && bit_status != upper)
                    {
                        charList.RemoveAt(0);
                    }
                    if (bit_status == upper)
                    {
                        int start = StartIndex(charAppearenceRecorder);
                        //  int start = charList[0];
                        if (i - start <= minWinEnd - minWinStart)
                        {
                            minWinEnd = i;
                            minWinStart = start;
                        }
                        char charToShift = s[start];
                        charList = charAppearenceRecorder[charToShift];
                        charList.RemoveAt(0);
                        // set that bit to 0 
                        bit_status -= (1 << charBit[charToShift]);
                    }
                }
            }



            return minWinStart == -1 ? "" : s.Substring(minWinStart, minWinEnd - minWinStart + 1);
        }
        private int StartIndex(Dictionary<char, List<int>> c)
        {
            int s = int.MaxValue;
            foreach (List<int> item in c.Values)
            {
                if (s > item[0])
                {
                    s = item[0];
                }
            }

            return s;
        }

        /*O(NlogM)*/

        public string MinWindow2(String s, String t)
        {
            Dictionary<char, int> needToFill = new Dictionary<char, int>();
            Dictionary<char, List<int>> charAppearenceRecorder = new Dictionary<char, List<int>>();
            // not use the bit use a sorted windows to store the current windows
            SortedDictionary<int, char> winMap = new SortedDictionary<int, char>();
            int minWinStart = -1;
            int minWinEnd = s.Length;
            for (int i = 0; i < t.Length; i++)
            {
                if (!needToFill.ContainsKey(t[i]))
                {
                    needToFill.Add(t[i], 1);
                    charAppearenceRecorder.Add(t[i], new List<int>());
                }
                else
                {
                    needToFill[t[i]] = needToFill[t[i]] + 1;
                }
            }

            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (needToFill.ContainsKey(c))
                {
                    List<int> charList = charAppearenceRecorder[c];
                    if (charList.Count < needToFill[c])
                    {
                        charList.Add(i);
                        winMap.Add(i, c);
                    }
                    else
                    {
                        int idxToErase = charList[0];
                        charList.RemoveAt(0);
                        winMap.Remove(idxToErase);
                        winMap.Add(i, c);
                        charList.Add(i);
                    }
                    if (winMap.Count == t.Length)
                    {
                        int start = winMap.Keys.First<int>();
                        int end = winMap.Keys.Last<int>();
                        if (end - start < minWinEnd - minWinStart)
                        {
                            minWinStart = start;
                            minWinEnd = end;
                        }
                    }
                }
            }

            return minWinStart != -1 ? s.Substring(minWinStart, minWinEnd - minWinStart + 1) : "";
        }


        public string MinWindow3(string s, string t)
        {
            if (s == null || t == null)
            {
                return null;
            }

            if (s.Length == 0 && t.Length == 0)
            {
                return "";
            }
            if (s.Length < t.Length)
            {
                return "";
            }

            Dictionary<char, int> NeedFind = new Dictionary<char, int>();
            Dictionary<char, int> AlreadyFind = new Dictionary<char, int>();

            for (int i = 0; i < t.Length; i++)
            {

                //if(AlreadyFind.ContainsKey(t[i]))
                //{

                //} else{

                //    AlreadyFind[t[i]] = AlreadyFind[t[i]]+1;
                //}

                if (NeedFind.ContainsKey(t[i]))
                {
                    NeedFind[t[i]] = NeedFind[t[i]] + 1;
                }
                else
                {
                    NeedFind.Add(t[i], 1);
                    AlreadyFind.Add(t[i], 0);

                }
            }
            int minStart = -1;
            int minEnd = s.Length;
            int start = 0;
            int len = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (AlreadyFind.ContainsKey(s[i]))
                {
                    AlreadyFind[s[i]] = AlreadyFind[s[i]] + 1;

                    if (AlreadyFind[s[i]] <= NeedFind[s[i]])
                    {
                        len++;
                    }

                    if (len == t.Length)
                    {
                        while (!NeedFind.ContainsKey(s[start]) || AlreadyFind[s[start]] > NeedFind[s[start]])
                        {

                            if (NeedFind.ContainsKey(s[start]))
                            {
                                AlreadyFind[s[start]] = AlreadyFind[s[start]] - 1;
                            }

                            start++;
                        }
                        if (i - start < minEnd - minStart)
                        {
                            minStart = start;
                            minEnd = i;
                        }

                    }
                }


            }
            if (minStart == -1)
            {
                return "";
            }
            return s.Substring(minStart, minEnd - minStart + 1);
        }

        /**/
        #endregion

        #region Leet Substring with Concatenation of All Words
        //        You are given a string, S, and a list of words, L, that are all of the same length. Find all starting indices of substring(s) in S that is a concatenation of each word in L exactly once and without any intervening characters.

        //For example, given:
        //S: "barfoothefoobarman"
        //L: ["foo", "bar"]

        //You should return the indices: [0,9].
        //(order does not matter).

        public List<int> Concatenation(string s, string[] words)
        {
            int length = words[0].Length;
            int totalLength = length * words.Count();
            int index = 0;
            List<string> listWords = words.ToList<string>();

            List<int> result = new List<int>();
            for (int i = 0; i < s.Length; i++)
            {

                int j;
                for (j = i; j < s.Length; j = j + length)
                {
                    if (s.Substring(j, length) != listWords[index])
                    {
                        result.Clear();
                        index = 0;
                        break;

                    }
                    else
                    {
                        result.Add(i);
                        i = j - length - 1;
                        index = index + 1;
                    }


                }


            }

            return result;
        }
        public List<int> Concatenation2(string s, string[] words)
        {


            List<int> list = new List<int>();
            int len = words.Length;
            if (len == 0)
            {
                return list;
            }
            int wordLen = words[0].Length;
            Dictionary<string, int> wordsMap = new Dictionary<string, int>();
            for (int i = 0; i < len; i++)
            {
                int num = 1;
                if (wordsMap.ContainsKey(words[i]) != false)
                {
                    num += wordsMap[words[i]];
                }
                wordsMap.Add(words[i], num);
            }
            int slen = s.Length;
            int max = slen - len * wordLen + 1;
            for (int i = 0; i < max; i++)
            {
                Dictionary<string, int> numMap = new Dictionary<string, int>();
                int j = 0;
                for (; j < len; j++)
                {
                    int start = i + j * wordLen;
                    int end = start + wordLen;
                    String tempStr = s.Substring(start, end - start);
                    if (!wordsMap.ContainsKey(tempStr))
                    {
                        break;
                    }
                    int num = 1;
                    if (numMap.ContainsKey(tempStr) != false)
                    {
                        num += numMap[tempStr];
                    }
                    if (num > wordsMap[tempStr])
                    {
                        break;
                    }
                    numMap.Add(tempStr, num);
                }
                if (j == len)
                {
                    list.Add(i);
                }
            }
            return list;
        }

        #endregion
    }

}



