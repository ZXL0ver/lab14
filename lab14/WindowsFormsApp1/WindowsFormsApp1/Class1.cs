using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class SortingThread
    {
        private Thread sortingThread;
        private string[] arr;
        private string algorithm;

        public SortingThread(string[] arr, string algorithm)
        {
            this.arr = arr;
            this.algorithm = algorithm;
            this.sortingThread = new Thread(new ThreadStart(this.Run));
        }

        public void Start()
        {
            this.sortingThread.Start();
        }

        public void Join()
        {
            this.sortingThread.Join();
        }

        private void Run()
        {
            switch (algorithm)
            {
                case "insertion":
                    InsertionSort(arr);
                    break;
                case "selection":
                    SelectionSort(arr);
                    break;
                case "bubble":
                    BubbleSort(arr);
                    break;
                default:
                    throw new ArgumentException("Invalid algorithm: " + algorithm);
            }
        }

        private static void InsertionSort(string[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                string temp = arr[i];
                int j = i - 1;
                while (j >= 0 && arr[j].CompareTo(temp) > 0)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = temp;
            }
        }

        private static void SelectionSort(string[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j].CompareTo(arr[minIndex]) < 0)
                    {
                        minIndex = j;
                    }
                }
                if (minIndex != i)
                {
                    string temp = arr[i];
                    arr[i] = arr[minIndex];
                    arr[minIndex] = temp;
                }
            }
        }

        private static void BubbleSort(string[] arr)
        {
            bool swapped = true;
            int j = 0;
            while (swapped)
            {
                swapped = false;
                j++;
                for (int i = 0; i < arr.Length - j; i++)
                {
                    if (arr[i].CompareTo(arr[i + 1]) > 0)
                    {
                        string temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                        swapped = true;
                    }
                }
            }
        }
    }
}
