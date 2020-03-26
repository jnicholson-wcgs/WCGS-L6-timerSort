/*
 * Lower 6 C# Sorting template
 * 1) Read and understand the existing code and structure
 * 2) Comment the existing code
 * 3) Write and test the bubble() and merge() sort algorithms. 
 *    You may have to write/modify this in an exam
 * 4) Write and test the quick sort alogorithm - this is a quite a bit harder. 
 *    You may have to describe this algo in 
 * 5) Write and test the heap sort alogorithm - not part of the currciulum.
 *    This may be needed for your NEA.
 * Ensure that all code is commented.
 * When you have finished, commit the code back to github with a link to your repl.it code
 * so that it can be reviewed and executed.
 * 
 * My code lives here: <Insert repl.it link here>
 */


using System;
using System.Diagnostics;
using System.Collections.Generic;

class MainClass {

  abstract class sorter {
    protected String name {get;}
    public String GetName () {return name;}

    public sorter (String name) {this.name = name;}
    public abstract void sort (int [] tosort);
  }

  class bubble : sorter {
    public bubble() : base ("bubble") {}
    public override void sort (int [] tosort) {
      //
      // Implement the bubble sort algo here.
      //
      //Console.WriteLine ("{0} sort", this.name);
      return;
    }
  }

  class merge : sorter {
    public merge() : base ("merge") {}
    public override void sort (int [] tosort) {
      //
      // Implement the merge sort algo here.
      //
      //Console.WriteLine ("{0} sort", this.name);
      return ;
    }
  }
  public static void Main (string[] args) {
    Stopwatch sw = new Stopwatch();

    List<sorter> sorters = new List<sorter>();

  //
  // Three sets of data to test with your sorter algorithms courtesy of random.com
  //

  int[][] data = 
    {
    /* 10 items = short */
    new int[] { 14, 1, 15, 17, 20, 13, 2, 8, 5, 3},
    /* 50 items = a bit longer */
    new int[] { 83, 8, 133, 156, 199, 92, 194, 52, 152, 197, 66, 154, 170, 138, 47, 130, 163, 106, 172, 128, 113, 181, 135, 15, 69, 182, 160, 140, 159, 200, 112, 169, 91, 65, 55, 131, 33, 63, 40, 150, 161, 9, 39, 62, 78, 145, 20, 32, 178, 94},
    /* 100 = should sort out the algos */
    new int[] { 488, 243, 78, 486, 463, 418, 175, 306, 59, 90, 331, 13, 298, 50, 257, 448, 218, 464, 467, 356, 1, 120, 434, 98, 371, 154, 493, 270, 164, 96, 302, 237, 457, 299, 361, 38, 292, 60, 262, 128, 312, 136, 122, 310, 153, 80, 167, 93, 52, 296, 408, 11, 482, 39, 106, 475, 174, 181, 289, 31, 73, 274, 411, 178, 244, 316, 368, 201, 63, 221, 57, 236, 14, 235, 461, 47, 79, 10, 112, 421, 349, 211, 182, 319, 226, 375, 176, 111, 314, 108, 209, 238, 103, 304, 190, 255, 452, 422, 7, 500 }
    }
  ;

    //
    // Single Core - Implement the bubble and merge sort algorithms
    //

    sorters.Add (new bubble());
    sorters.Add (new merge());

    //
    // Dual Core - Implement Quick sort
    //sorters.Add (new quick());
    
    // 
    // Quad Core - Implement heap sort
    //
    //sorters.Add (new heap());

    // Iterate through all the sort routines on the three sets of data to compare the alogorithm speed

    foreach (sorter s in sorters) {
      
      for (int x = 0; x < data.Length; x++) {
        sw.Reset();
        sw.Start();
        s.sort (data[x]);
        sw.Stop();
        Console.WriteLine("{1} sort, list length {2}, Elapsed={0}",sw.Elapsed, s.GetName(), data[x].Length);
      }
      
    }
  }
}
