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

class MainClass
{

    abstract class sorter
    {
        protected String name { get; }
        public String GetName() { return name; }

        public sorter(String name) { this.name = name; }
        public abstract void sort(int[] tosort, int[] sorted);

        public void checker (int[] tosort, int[] sorted) // checks if the item is correctly sorted
        {
            int checker = 0;
            for (int i = 0; i < tosort.Length; i++)
            {
                Console.Write(tosort[i] + " "); //printing out the sorted list
                if (tosort[i] == sorted[i])
                {
                    checker++;
                }

            }
            if (checker == tosort.Length)
            {
                Console.WriteLine("\nSorted correctly");
            }
            else
            {
                Console.WriteLine("\nSorted incorrectly");
            }

            Console.WriteLine("{0} sort", this.name); 
        }
    }

    class bubble : sorter
    {
        public bubble() : base("bubble") { }
        public override void sort(int[] tosort, int[] sorted)
        {
            //
            // Implement the bubble sort algo here.
            if (tosort.Length != 1) // if the array is just one item, then theres no need to sort it (and you obviously cant sort a single item!)
            {
                int temp = 0;

                for (int i = 0; i < tosort.Length; i++) // for each pass in the bubble sort
                {
                    for (int j = 0; j < tosort.Length - 1; j++) // for all items being copared in that pass
                    {
                        if (tosort[j] > tosort[j + 1]) //if item is greater than the item to the right
                        {
                            temp = tosort[j + 1];  // assign it  to a temp variable
                            tosort[j + 1] = tosort[j]; // assign the smaller number to the left position
                            tosort[j] = temp; // assign the data in the temp variable to the right position
                        }
                    }
                }

            }

            checker(tosort, sorted); // data is checked whether or not the data has been sorrted or not
        }
    }

    class merge : sorter
    {
        public merge() : base("merge") { }

        public override void sort(int[] tosort, int[] sorted)
        {
            //
            // Implement the merge sort algo here.

            if (tosort.Length != 1)  // if the array is just one item, then theres no need to sort it (and you obviously cant sort a single item!)
            {
                tosort = mergeSort(tosort); // the return value is assigned into the tosort array
            }

            checker(tosort, sorted); // data is checked whether or not the data has been sorrted or not

        }

        public static int[] mergeSort(int[] tosort)
        {
            int[] left; // this is our left array
            int[] right; // this is our right array
            int[] final_array = new int[tosort.Length]; // this will store the final sorted numbers

            int midPoint = tosort.Length / 2; // The exact midpoint of our array 

            left = new int[midPoint]; // left array (which is always half of the total length of the original array)

            if (tosort.Length % 2 == 0)
            {
                right = new int[midPoint]; //if array has an even number of elements, the left and right array will have the same number of elements, elseif array has an odd number of elements, the right array will have one more element than left
            }
            else
            {
                right = new int[midPoint + 1]; 
            }

            
            for (int i = 0; i < midPoint; i++) // items are added to the left array
            {
                left[i] = tosort[i];
            }

            //add items to the right array   
            int n = 0;
            
            for (int i = midPoint; i < tosort.Length; i++) 
            {
                right[n] = tosort[i];
                n++;
            }

            //Recursively divide both right and left arrays (which Kilian was asking how to do on google meets)

            if (left.Length != 1) // cant be running into a stack overflow error here, so this recursion will only be excuted if, and only if there is more than one item left to be divided
            {
                left = mergeSort(left); // the left and right arrays are halved each time, allowing it to broken until only one element of the array is there
            }
           

            if (right.Length != 1)
            {
              right = mergeSort(right);
            }

            //at this point, the whole list has been broken down into individual items, so the next step is join them back
            
            final_array = merger(left, right); //the left and right arrays are merged and sorted. 
            return final_array;
            
        }

        public static int[] merger(int[] left, int[] right) //This combines 2 small arrays into one big array
        {
            int resultLength = right.Length + left.Length; // 
            int[] result = new int[resultLength];

            int indexLeft = 0;
            int indexRight = 0;
            int indexResult = 0;
            
            while (indexLeft < left.Length || indexRight < right.Length) //while either array is not empty 
            {
                  
                if (indexLeft < left.Length) //if just one of the arrays are empty, then all its items will be added to the results array (so no need to sort)
                {
                    result[indexResult] = left[indexLeft];
                    indexLeft++;
                    indexResult++;
                }
                else if (indexRight < right.Length)
                {
                    result[indexResult] = right[indexRight];
                    indexRight++;
                    indexResult++;
                }
                else if (indexLeft < left.Length && indexRight < right.Length) //if both arrays have elements (finally, the sorting algorithm begins)
                {

                    if (left[indexLeft] <= right[indexRight]) // If item on left array is less than item on right array, add that item to the result array
                    {
                        result[indexResult] = left[indexLeft];
                        indexLeft++;
                        indexResult++;
                    }
                    else // the item in the right array wll be added to the results array
                    {
                        result[indexResult] = right[indexRight];
                        indexRight++;
                        indexResult++;
                    }
                }
            }
            return result;
        }

    }

    class quick : sorter
    {
        public quick() : base("quick") { }

        public override void sort(int[] tosort, int[] sorted)
        {
            //
            // Implement the quick sort algo here.
            if (tosort.Length != 1) 
            {
                Quicksort(tosort, 0, tosort.Length - 1); // the  algorithm quires you to state the start, end for the first recursion
            }

            checker(tosort, sorted); // data is checked whether or not the data has been sorrted or not
        }

         static void Quicksort(int[] numbers, int left, int right)
        {
            int i = left; //  i is the left index (smaller number)
            int j = right; // j is the right index (bigger number)

            var pivot = numbers[right]; // the pivot is set as the right side of the list of the numbers (as this is most common method and also shown in the computerphile video)

            while (i <= j) // i must always be greater than j, and if there not, that means that something has gone wrong in the algorithm (could just use "true" instead, but this is easier to understand as to why it always loops)
            {
                while (numbers[i] < pivot)// i keeps increasing until the item 'numbers[i]' is greater than the pivot, which means that the number should be moved/ swapped around since it is greater
                    i++;

                while (numbers[j] > pivot)// j keeps decreasing until the item 'numbers[i]' is less than the pivot, which means that the number should be moved/ swapped around since it is smaller
                    j--;

                if (i <= j) // swap the numbers in the list (if the items in the list aren't arent sorted already)
                {
                    var tmp = numbers[i];
                    numbers[i] = numbers[j];
                    numbers[j] = tmp;

                    i++;
                    j--;
                }
            }

            if (left < j) 
            {
                Quicksort(numbers, left, j); // recursivley call the quicksort method in order to sort the left side of the list 
            }

            if (right > i)
            {
                Quicksort(numbers, i, right);// recursivley call the quicksort method in order to sort the right side of the list
            } 
        }
    }

    class heap : sorter
    {
        public heap() : base("heap") { }
        public override void sort(int[] tosort, int[] sorted)
        {
            //
            // Implement the heap sort algo here.
            if (tosort.Length != 0)
            {
                HeapSort(tosort);
            }
           

            checker(tosort, sorted); // data is checked whether or not the data has been sorrted or not
        }

        static void HeapSort(int[] array)
        {
            int length = array.Length;
            for (int i = length / 2 - 1; i >= 0; i--) 
            {
                Create_Max_Heap(array, length, i); //First step is to build the max heap in oder to find the largest number (and the next largest numbers for later steps)
            }
            for (int i = length - 1; i >= 0; i--) // you swap the first and last numebers in the list ( the first number is the highest, you can say it is sorted and place it at the end, just before the previous higher numbers)
            {
                int temp = array[0];
                array[0] = array[i];
                array[i] = temp;
                Create_Max_Heap(array, i, 0);// after the first Max heap function, the algorithm only needs to swap with its 2 child nodes (no need to fully build a max heap from scratch) You could call this heapify
            }
        }

        static void Create_Max_Heap(int[] array, int length, int i) //After the 
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            if (left < length && array[left] > array[largest])//if the left child node is greater, then this must be swapped with the item at the top of the bianry tree
            {
                largest = left;
            }
            if (right < length && array[right] > array[largest])//if the right child node is greater, then this must be swapped with the item at the top of the bianry tree
            {
                largest = right;
            }
            if (largest != i) // swapping algorithm to swap the large number, (so that we always get it in the top of our binary tree)
            {
                int swap = array[i];
                array[i] = array[largest];
                array[largest] = swap;
                Create_Max_Heap(array, length, largest); // Recursivley call Mac heap function to make sure that the largest number is always at the top
            }
        }
    }

    public static void Main(string[] args)
    {
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
    new int[] { 488, 243, 78, 486, 463, 418, 175, 306, 59, 90, 331, 13, 298, 50, 257, 448, 218, 464, 467, 356, 1, 120, 434, 98, 371, 154, 493, 270, 164, 96, 302, 237, 457, 299, 361, 38, 292, 60, 262, 128, 312, 136, 122, 310, 153, 80, 167, 93, 52, 296, 408, 11, 482, 39, 106, 475, 174, 181, 289, 31, 73, 274, 411, 178, 244, 316, 368, 201, 63, 221, 57, 236, 14, 235, 461, 47, 79, 10, 112, 421, 349, 211, 182, 319, 226, 375, 176, 111, 314, 108, 209, 238, 103, 304, 190, 255, 452, 422, 7, 500 },
    /* 1000 =  I just coped the original 100 list 10 times to create the 1000 integer long list :) */
    new int[] {488, 243, 78, 486, 463, 418, 175, 306, 59, 90, 331, 13, 298, 50, 257, 448, 218, 464, 467, 356, 1, 120, 434, 98, 371, 154, 493, 270, 164, 96, 302, 237, 457, 299, 361, 38, 292, 60, 262, 128, 312, 136, 122, 310, 153, 80, 167, 93, 52, 296, 408, 11, 482, 39, 106, 475, 174, 181, 289, 31, 73, 274, 411, 178, 244, 316, 368, 201, 63, 221, 57, 236, 14, 235, 461, 47, 79, 10, 112, 421, 349, 211, 182, 319, 226, 375, 176, 111, 314, 108, 209, 238, 103, 304, 190, 255, 452, 422, 7, 500, 488, 243, 78, 486, 463, 418, 175, 306, 59, 90, 331, 13, 298, 50, 257, 448, 218, 464, 467, 356, 1, 120, 434, 98, 371, 154, 493, 270, 164, 96, 302, 237, 457, 299, 361, 38, 292, 60, 262, 128, 312, 136, 122, 310, 153, 80, 167, 93, 52, 296, 408, 11, 482, 39, 106, 475, 174, 181, 289, 31, 73, 274, 411, 178, 244, 316, 368, 201, 63, 221, 57, 236, 14, 235, 461, 47, 79, 10, 112, 421, 349, 211, 182, 319, 226, 375, 176, 111, 314, 108, 209, 238, 103, 304, 190, 255, 452, 422, 7, 500, 488, 243, 78, 486, 463, 418, 175, 306, 59, 90, 331, 13, 298, 50, 257, 448, 218, 464, 467, 356, 1, 120, 434, 98, 371, 154, 493, 270, 164, 96, 302, 237, 457, 299, 361, 38, 292, 60, 262, 128, 312, 136, 122, 310, 153, 80, 167, 93, 52, 296, 408, 11, 482, 39, 106, 475, 174, 181, 289, 31, 73, 274, 411, 178, 244, 316, 368, 201, 63, 221, 57, 236, 14, 235, 461, 47, 79, 10, 112, 421, 349, 211, 182, 319, 226, 375, 176, 111, 314, 108, 209, 238, 103, 304, 190, 255, 452, 422, 7, 500, 488, 243, 78, 486, 463, 418, 175, 306, 59, 90, 331, 13, 298, 50, 257, 448, 218, 464, 467, 356, 1, 120, 434, 98, 371, 154, 493, 270, 164, 96, 302, 237, 457, 299, 361, 38, 292, 60, 262, 128, 312, 136, 122, 310, 153, 80, 167, 93, 52, 296, 408, 11, 482, 39, 106, 475, 174, 181, 289, 31, 73, 274, 411, 178, 244, 316, 368, 201, 63, 221, 57, 236, 14, 235, 461, 47, 79, 10, 112, 421, 349, 211, 182, 319, 226, 375, 176, 111, 314, 108, 209, 238, 103, 304, 190, 255, 452, 422, 7, 500, 488, 243, 78, 486, 463, 418, 175, 306, 59, 90, 331, 13, 298, 50, 257, 448, 218, 464, 467, 356, 1, 120, 434, 98, 371, 154, 493, 270, 164, 96, 302, 237, 457, 299, 361, 38, 292, 60, 262, 128, 312, 136, 122, 310, 153, 80, 167, 93, 52, 296, 408, 11, 482, 39, 106, 475, 174, 181, 289, 31, 73, 274, 411, 178, 244, 316, 368, 201, 63, 221, 57, 236, 14, 235, 461, 47, 79, 10, 112, 421, 349, 211, 182, 319, 226, 375, 176, 111, 314, 108, 209, 238, 103, 304, 190, 255, 452, 422, 7, 500, 488, 243, 78, 486, 463, 418, 175, 306, 59, 90, 331, 13, 298, 50, 257, 448, 218, 464, 467, 356, 1, 120, 434, 98, 371, 154, 493, 270, 164, 96, 302, 237, 457, 299, 361, 38, 292, 60, 262, 128, 312, 136, 122, 310, 153, 80, 167, 93, 52, 296, 408, 11, 482, 39, 106, 475, 174, 181, 289, 31, 73, 274, 411, 178, 244, 316, 368, 201, 63, 221, 57, 236, 14, 235, 461, 47, 79, 10, 112, 421, 349, 211, 182, 319, 226, 375, 176, 111, 314, 108, 209, 238, 103, 304, 190, 255, 452, 422, 7, 500, 488, 243, 78, 486, 463, 418, 175, 306, 59, 90, 331, 13, 298, 50, 257, 448, 218, 464, 467, 356, 1, 120, 434, 98, 371, 154, 493, 270, 164, 96, 302, 237, 457, 299, 361, 38, 292, 60, 262, 128, 312, 136, 122, 310, 153, 80, 167, 93, 52, 296, 408, 11, 482, 39, 106, 475, 174, 181, 289, 31, 73, 274, 411, 178, 244, 316, 368, 201, 63, 221, 57, 236, 14, 235, 461, 47, 79, 10, 112, 421, 349, 211, 182, 319, 226, 375, 176, 111, 314, 108, 209, 238, 103, 304, 190, 255, 452, 422, 7, 500, 488, 243, 78, 486, 463, 418, 175, 306, 59, 90, 331, 13, 298, 50, 257, 448, 218, 464, 467, 356, 1, 120, 434, 98, 371, 154, 493, 270, 164, 96, 302, 237, 457, 299, 361, 38, 292, 60, 262, 128, 312, 136, 122, 310, 153, 80, 167, 93, 52, 296, 408, 11, 482, 39, 106, 475, 174, 181, 289, 31, 73, 274, 411, 178, 244, 316, 368, 201, 63, 221, 57, 236, 14, 235, 461, 47, 79, 10, 112, 421, 349, 211, 182, 319, 226, 375, 176, 111, 314, 108, 209, 238, 103, 304, 190, 255, 452, 422, 7, 500, 488, 243, 78, 486, 463, 418, 175, 306, 59, 90, 331, 13, 298, 50, 257, 448, 218, 464, 467, 356, 1, 120, 434, 98, 371, 154, 493, 270, 164, 96, 302, 237, 457, 299, 361, 38, 292, 60, 262, 128, 312, 136, 122, 310, 153, 80, 167, 93, 52, 296, 408, 11, 482, 39, 106, 475, 174, 181, 289, 31, 73, 274, 411, 178, 244, 316, 368, 201, 63, 221, 57, 236, 14, 235, 461, 47, 79, 10, 112, 421, 349, 211, 182, 319, 226, 375, 176, 111, 314, 108, 209, 238, 103, 304, 190, 255, 452, 422, 7, 500, 488, 243, 78, 486, 463, 418, 175, 306, 59, 90, 331, 13, 298, 50, 257, 448, 218, 464, 467, 356, 1, 120, 434, 98, 371, 154, 493, 270, 164, 96, 302, 237, 457, 299, 361, 38, 292, 60, 262, 128, 312, 136, 122, 310, 153, 80, 167, 93, 52, 296, 408, 11, 482, 39, 106, 475, 174, 181, 289, 31, 73, 274, 411, 178, 244, 316, 368, 201, 63, 221, 57, 236, 14, 235, 461, 47, 79, 10, 112, 421, 349, 211, 182, 319, 226, 375, 176, 111, 314, 108, 209, 238, 103, 304, 190, 255, 452, 422, 7, 500 }
    }
        ;

        int[][] sorted_data =
            {
            /* 10 items = short */
            new int[] {1,2,3,5,8,13,14,15,17,20},
            /* 50 items = a bit longer */
            new int[] {8,9,15,20,32,33,39,40,47,52,55,62,63,65,66,69,78,83,91,92,94,106,112,113,128,130,131,133,135,138,140,145,150,152,154,156,159,160,161,163,169,170,172,178,181,182,194,197,199,200 },
            /* 100 = should sort out the algos */
            new int[] {1,7,10,11,13,14,31,38,39,47,50,52,57,59,60,63,73,78,79,80,90,93,96,98,103,106,108,111,112,120,122,128,136,153,154,164,167,174,175,176,178,181,182,190,201,209,211,218,221,226,235,236,237,238,243,244,255,257,262,270,274,289,292,296,298,299,302,304,306,310,312,314,316,319,331,349,356,361,368,371,375,408,411,418,421,422,434,448,452,457,461,463,464,467,475,482,486,488,493,500},
            /* 1000 = I just coped the original 100 list 10 times to create the 1000 integer long list :) */
            new int[] {1,1,1,1,1,1,1,1,1,1,7,7,7,7,7,7,7,7,7,7,10,10,10,10,10,10,10,10,10,10,11,11,11,11,11,11,11,11,11,11,13,13,13,13,13,13,13,13,13,13,14,14,14,14,14,14,14,14,14,14,31,31,31,31,31,31,31,31,31,31,38,38,38,38,38,38,38,38,38,38,39,39,39,39,39,39,39,39,39,39,47,47,47,47,47,47,47,47,47,47,50,50,50,50,50,50,50,50,50,50,52,52,52,52,52,52,52,52,52,52,57,57,57,57,57,57,57,57,57,57,59,59,59,59,59,59,59,59,59,59,60,60,60,60,60,60,60,60,60,60,63,63,63,63,63,63,63,63,63,63,73,73,73,73,73,73,73,73,73,73,78,78,78,78,78,78,78,78,78,78,79,79,79,79,79,79,79,79,79,79,80,80,80,80,80,80,80,80,80,80,90,90,90,90,90,90,90,90,90,90,93,93,93,93,93,93,93,93,93,93,96,96,96,96,96,96,96,96,96,96,98,98,98,98,98,98,98,98,98,98,103,103,103,103,103,103,103,103,103,103,106,106,106,106,106,106,106,106,106,106,108,108,108,108,108,108,108,108,108,108,111,111,111,111,111,111,111,111,111,111,112,112,112,112,112,112,112,112,112,112,120,120,120,120,120,120,120,120,120,120,122,122,122,122,122,122,122,122,122,122,128,128,128,128,128,128,128,128,128,128,136,136,136,136,136,136,136,136,136,136,153,153,153,153,153,153,153,153,153,153,154,154,154,154,154,154,154,154,154,154,164,164,164,164,164,164,164,164,164,164,167,167,167,167,167,167,167,167,167,167,174,174,174,174,174,174,174,174,174,174,175,175,175,175,175,175,175,175,175,175,176,176,176,176,176,176,176,176,176,176,178,178,178,178,178,178,178,178,178,178,181,181,181,181,181,181,181,181,181,181,182,182,182,182,182,182,182,182,182,182,190,190,190,190,190,190,190,190,190,190,201,201,201,201,201,201,201,201,201,201,209,209,209,209,209,209,209,209,209,209,211,211,211,211,211,211,211,211,211,211,218,218,218,218,218,218,218,218,218,218,221,221,221,221,221,221,221,221,221,221,226,226,226,226,226,226,226,226,226,226,235,235,235,235,235,235,235,235,235,235,236,236,236,236,236,236,236,236,236,236,237,237,237,237,237,237,237,237,237,237,238,238,238,238,238,238,238,238,238,238,243,243,243,243,243,243,243,243,243,243,244,244,244,244,244,244,244,244,244,244,255,255,255,255,255,255,255,255,255,255,257,257,257,257,257,257,257,257,257,257,262,262,262,262,262,262,262,262,262,262,270,270,270,270,270,270,270,270,270,270,274,274,274,274,274,274,274,274,274,274,289,289,289,289,289,289,289,289,289,289,292,292,292,292,292,292,292,292,292,292,296,296,296,296,296,296,296,296,296,296,298,298,298,298,298,298,298,298,298,298,299,299,299,299,299,299,299,299,299,299,302,302,302,302,302,302,302,302,302,302,304,304,304,304,304,304,304,304,304,304,306,306,306,306,306,306,306,306,306,306,310,310,310,310,310,310,310,310,310,310,312,312,312,312,312,312,312,312,312,312,314,314,314,314,314,314,314,314,314,314,316,316,316,316,316,316,316,316,316,316,319,319,319,319,319,319,319,319,319,319,331,331,331,331,331,331,331,331,331,331,349,349,349,349,349,349,349,349,349,349,356,356,356,356,356,356,356,356,356,356,361,361,361,361,361,361,361,361,361,361,368,368,368,368,368,368,368,368,368,368,371,371,371,371,371,371,371,371,371,371,375,375,375,375,375,375,375,375,375,375,408,408,408,408,408,408,408,408,408,408,411,411,411,411,411,411,411,411,411,411,418,418,418,418,418,418,418,418,418,418,421,421,421,421,421,421,421,421,421,421,422,422,422,422,422,422,422,422,422,422,434,434,434,434,434,434,434,434,434,434,448,448,448,448,448,448,448,448,448,448,452,452,452,452,452,452,452,452,452,452,457,457,457,457,457,457,457,457,457,457,461,461,461,461,461,461,461,461,461,461,463,463,463,463,463,463,463,463,463,463,464,464,464,464,464,464,464,464,464,464,467,467,467,467,467,467,467,467,467,467,475,475,475,475,475,475,475,475,475,475,482,482,482,482,482,482,482,482,482,482,486,486,486,486,486,486,486,486,486,486,488,488,488,488,488,488,488,488,488,488,493,493,493,493,493,493,493,493,493,493,500,500,500,500,500,500,500,500,500,500 },
        };

        //
        // Single Core - Implement the bubble and merge sort algorithms
        //

        sorters.Add(new bubble());
        sorters.Add(new merge());

        //
        // Dual Core - Implement Quick sort

        sorters.Add (new quick()); //This will be coming right up in few moments

        // 
        // Quad Core - Implement heap sort
        //
        sorters.Add (new heap());// I will attempt to code this

        // Iterate through all the sort routines on the three sets of data to compare the alogorithm speed

        foreach (sorter s in sorters)
        {

            for (int x = 0; x < data.Length; x++)
            {
                sw.Reset();
                sw.Start();
                s.sort(data[x], sorted_data[x]); // passing the sorted list too to act as a checker
                sw.Stop();
                Console.WriteLine("{1} sort, list length {2}, Elapsed={0}", sw.Elapsed, s.GetName(), data[x].Length);
                Console.WriteLine();
            }
            
        }
        Console.ReadLine();
    }
}
