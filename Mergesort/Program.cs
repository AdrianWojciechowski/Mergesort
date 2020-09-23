using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mergesort
{
    class Program
    {
        //Mergesort algorithm
        //Speed: O(n*log(n))
        //Memory: O(n)
        private static void mergesort(int[] t, int low, int high)
        {
            if (low < high)
            {
                int mid = low + (high - low) / 2;   //Splitting array in half
                mergesort(t, low, mid);             //Sorting first half
                mergesort(t, mid + 1, high);        //Sorting second half
                merge(t, low, mid, high);           //Merging first and second half
            }
        }

        private static void merge(int[] t, int low, int mid, int high)
        {
            //create temp variables
            int i, j, k;
            int n1 = mid - low + 1;
            int n2 = high - mid;

            // create temp arrays
            int[] left = new int[n1];
            int[] right = new int[n2];

            // Copy data to temp arrays left and right
            for (i = 0; i < n1; i++)
                left[i] = t[low + i];
            for (j = 0; j < n2; j++)
                right[j] = t[mid + 1 + j];

            /* Merge the temp arrays back into arr[low..high]*/
            i = 0; // Initial index of first subarray 
            j = 0; // Initial index of second subarray 
            k = low; // Initial index of merged subarray 
            while (i < n1 && j < n2)
            {
                if (left[i] <= right[j])
                {
                    t[k] = left[i];
                    i++;
                }
                else
                {
                    t[k] = right[j];
                    j++;
                }
                k++;
            }

            // Copy the remaining elements of left, if there are any
            while (i < n1)
            {
                t[k] = left[i];
                i++;
                k++;
            }

            // Copy the remaining elements of right, if there are any
            while (j < n2)
            {
                t[k] = right[j];
                j++;
                k++;
            }
        }

        static void Main(string[] args) { 
            int[] t = {89, 9, 43, 21, 28, 0, 6, 49};
            mergesort(t, 0, 7);
            for (int x = 0; x < 8; x++)
                Console.WriteLine(t[x]);
            Console.ReadLine();
        }
    }
}
