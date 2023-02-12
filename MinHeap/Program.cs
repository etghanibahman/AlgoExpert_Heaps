using System;
using System.Collections.Generic;

namespace MinHeap
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Case___1
            var array = new List<int>() { 48, 12, 24, 7, 8, -5, 24, 391, 24, 56, 2, 6, 8, 41 };
            Console.WriteLine($"Initial Array is : {String.Join(',', array)}");
            MinHeap sampleMinHeap = new MinHeap(array);

            Console.WriteLine($"Heap is : \n{String.Join(',', sampleMinHeap.heap)}");

            sampleMinHeap.Insert(76);
            Console.WriteLine($"Heap after insertion of 76 is : \n{String.Join(',', sampleMinHeap.heap)}");
            var peekedItem = sampleMinHeap.Peek();
            var removedItem = sampleMinHeap.Remove();
            Console.WriteLine($"peekedItem is {peekedItem}");
            Console.WriteLine($"removedItem is {removedItem}");
            Console.WriteLine($"Heap is : \n{String.Join(',', sampleMinHeap.heap)}");
            peekedItem = sampleMinHeap.Peek();
            removedItem = sampleMinHeap.Remove();
            Console.WriteLine($"peekedItem is {peekedItem}");
            Console.WriteLine($"removedItem is {removedItem}");
            Console.WriteLine($"Heap is : \n{String.Join(',', sampleMinHeap.heap)}");
            peekedItem = sampleMinHeap.Peek();
            sampleMinHeap.Insert(87);

            Console.WriteLine($"peekedItem is {peekedItem}");
            Console.WriteLine($"Heap after insertion of 87 is : \n{String.Join(',', sampleMinHeap.heap)}");

            #endregion

            Console.WriteLine("\nTesting heap construction is finished.....");
        }

        public class MinHeap
        {
            public List<int> heap = new List<int>();

            public MinHeap(List<int> array)
            {
                heap = buildHeap(array);
            }

            public List<int> buildHeap(List<int> array)
            {
                foreach (var item in array)
                {
                    Insert(item);
                }
                return heap;
            }

            public void siftDown(int currentIdx)
            {
                var child1Idx = 2 * currentIdx + 1;
                var child2Idx = 2 * currentIdx + 2;
                var minChildIndex = -1;
                if (child1Idx < heap.Count && child2Idx < heap.Count)
                {
                    minChildIndex = heap[child1Idx] < heap[child2Idx] ? child1Idx : child2Idx;
                }
                else if (child1Idx < heap.Count)
                {
                    minChildIndex = child1Idx;
                }
                if (minChildIndex >= 0 && heap[currentIdx] > heap[minChildIndex])
                {
                    Swap(minChildIndex, currentIdx);
                    siftDown(minChildIndex);
                }
            }

            public void siftUp(int currentIdx)
            {
                var parentIndex = (currentIdx - 1) / 2;
                if (parentIndex >= 0 && heap[parentIndex] > heap[currentIdx])
                {
                    Swap(currentIdx, parentIndex);
                    siftUp(parentIndex);
                }
            }

            public int Peek()
            {
                return heap[0];
            }

            public int Remove()
            {
                var removedItem = heap[0];
                var temp = heap[heap.Count - 1];
                heap.RemoveAt(heap.Count - 1);
                heap[0] = temp;
                siftDown(0);
                return removedItem;
            }

            public void Insert(int value)
            {
                heap.Add(value);
                siftUp(heap.Count - 1);
            }

            private void Swap(int idx1, int idx2)
            {
                var temp = heap[idx1];
                heap[idx1] = heap[idx2];
                heap[idx2] = temp;
            }


        }
    }
}
