# 📖 Searching, Sorting, and Greedy Algorithms

In this module, you'll explore three fundamental categories of algorithms: **Searching**, **Sorting**, and **Greedy Algorithms**. These are critical tools in computer science, enabling efficient data management, problem-solving, and optimization. By the end of this guide, you will:

- Learn how to implement and optimize searching and sorting techniques.
- Understand the differences between simple and advanced algorithms.
- Explore the principles behind greedy algorithms and their application in solving optimization problems.

## 📋 Table of Contents
1. **Searching Algorithms**  
    - Linear Search  
    - Binary Search  
2. **Simple Sorting Algorithms**  
    - Selection Sort  
    - Bubble Sort  
    - Insertion Sort  
3. **Advanced Sorting Algorithms**  
    - Quick Sort  
    - Merge Sort  
4. **Greedy Algorithms**  

## 🔎 Searching Algorithms

### 🟡 Linear Search

**Description**:  
Linear search checks each element in the collection sequentially until the desired element is found or the collection is exhausted. This method is simple but inefficient for large datasets.  

**Time Complexity**:  
- **Best case**: O(1) (target found at the first position).  
- **Worst case**: O(n) (target not found or at the last position).

**Code Example**:
```csharp
using System;

class Program {
    static int LinearSearch(int[] arr, int target) {
        for (int i = 0; i < arr.Length; i++) {
            if (arr[i] == target) {
                return i; // 🎯 Found the target
            }
        }
        return -1; // ❌ Target not found
    }

    static void Main() {
        int[] data = { 10, 20, 30, 40, 50 };
        int result = LinearSearch(data, 30);
        Console.WriteLine(result); // Output: 2
    }
}
```

### 🔵 Binary Search

**Description**:
Binary search operates on sorted datasets. It repeatedly divides the search range in half, comparing the middle element to the target value.

**Time Complexity**:
- **Best case**: O(1) (target is the middle element).
- **Worst case**: O(log(n)) (repeated division of search space).

**Code Example**:
```charp
using System;

class Program {
    static int BinarySearch(int[] arr, int target) {
        int left = 0, right = arr.Length - 1;

        while (left <= right) {
            int mid = (left + right) / 2;

            if (arr[mid] == target) {
                return mid; // 🎯 Found the target
            } else if (arr[mid] < target) {
                left = mid + 1; // 🔎 Search in the right half
            } else {
                right = mid - 1; // 🔎 Search in the left half
            }
        }
        return -1; // ❌ Target not found
    }

    static void Main() {
        int[] data = { 10, 20, 30, 40, 50 };
        int result = BinarySearch(data, 30);
        Console.WriteLine(result); // Output: 2
    }
}
```

## 📊 Simple Sorting Algorithms

### 🟡 Selection Sort

**Description**:
Selection Sort selects the smallest (or largest) element from the unsorted part of the array and swaps it with the first element in the unsorted section.

**Time Complexity**: O(n²).

**Stability**: Not stable.

**Code Example**:
```charp
using System;

class Program {
    static void SelectionSort(int[] arr) {
        for (int i = 0; i < arr.Length - 1; i++) {
            int minIndex = i;

            for (int j = i + 1; j < arr.Length; j++) {
                if (arr[j] < arr[minIndex]) {
                    minIndex = j; // 🔄 Find the minimum element
                }
            }

            // Swap elements
            int temp = arr[minIndex];
            arr[minIndex] = arr[i];
            arr[i] = temp;
        }
    }

    static void Main() {
        int[] data = { 64, 25, 12, 22, 11 };
        SelectionSort(data);

        Console.WriteLine(string.Join(", ", data)); // Output: 11, 12, 22, 25, 64
    }
}
```

### 🔵 Bubble Sort

**Description**:
Bubble Sort repeatedly steps through the array, compares adjacent elements, and swaps them if they are in the wrong order. The largest element "bubbles up" to its correct position with each pass.

**Time Complexity**: O(n²).

**Stability**: Stable.

**Code Example**:
```csharp
using System;

class Program {
    static void BubbleSort(int[] arr) {
        for (int i = 0; i < arr.Length - 1; i++) {
            for (int j = 0; j < arr.Length - i - 1; j++) {
                if (arr[j] > arr[j + 1]) {
                    // Swap adjacent elements
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }

    static void Main() {
        int[] data = { 5, 1, 4, 2, 8 };
        BubbleSort(data);

        Console.WriteLine(string.Join(", ", data)); // Output: 1, 2, 4, 5, 8
    }
}
```

### 🔵 Insertion Sort

**Description**:
Insertion Sort builds the sorted portion of the array one element at a time by inserting unsorted elements into their correct position.

**Time Complexity**: O(n²).

**Stability**: Stable.

**Code Example**:
```charp
using System;

class Program {
    static void InsertionSort(int[] arr) {
        for (int i = 1; i < arr.Length; i++) {
            int key = arr[i];
            int j = i - 1;

            // Shift larger elements one position to the right
            while (j >= 0 && arr[j] > key) {
                arr[j + 1] = arr[j];
                j--;
            }
            arr[j + 1] = key; // Place the key in its correct position
        }
    }

    static void Main() {
        int[] data = { 12, 11, 13, 5, 6 };
        InsertionSort(data);

        Console.WriteLine(string.Join(", ", data)); // Output: 5, 6, 11, 12, 13
    }
}
```


## 📊 Advanced Sorting Algorithms

### 🟢 Quick Sort
**Description**:  
Quick Sort is a divide-and-conquer algorithm. It selects a **pivot element**, partitions the array into two subarrays based on the pivot (elements smaller and larger), and recursively sorts the subarrays.

**Time Complexity**:  
- **Best and Average case**: O(n log(n)).  
- **Worst case**: O(n²) (occurs when the pivot divides the array unevenly).  

**Stability**: Not stable.

**Code Example**:
```csharp
using System;

class Program {
    static void QuickSort(int[] arr, int left, int right) {
        if (left < right) {
            int pivotIndex = Partition(arr, left, right);

            QuickSort(arr, left, pivotIndex - 1);  // Sort left subarray
            QuickSort(arr, pivotIndex + 1, right);  // Sort right subarray
        }
    }

    static int Partition(int[] arr, int left, int right) {
        int pivot = arr[right];
        int i = left - 1;

        for (int j = left; j < right; j++) {
            if (arr[j] < pivot) {
                i++;
                Swap(arr, i, j);  // Swap smaller elements to the left
            }
        }
        Swap(arr, i + 1, right);  // Place the pivot in the correct position
        return i + 1;
    }

    static void Swap(int[] arr, int i, int j) {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    static void Main() {
        int[] data = { 10, 80, 30, 90, 40, 50, 70 };
        QuickSort(data, 0, data.Length - 1);

        Console.WriteLine(string.Join(", ", data)); // Output: 10, 30, 40, 50, 70, 80, 90
    }
}
```

### 🟢 Merge Sort

**Description**:
Merge Sort is a divide-and-conquer algorithm. It divides the array into two halves, recursively sorts each half, and then merges the sorted halves.

**Time Complexity**: O(n log(n)) in all cases.

**Stability**: Stable.

**Code Example**:
```csharp
using System;

class Program {
    static void MergeSort(int[] arr) {
        if (arr.Length <= 1) return;

        int mid = arr.Length / 2;
        int[] left = new int[mid];
        int[] right = new int[arr.Length - mid];

        Array.Copy(arr, 0, left, 0, mid);
        Array.Copy(arr, mid, right, 0, arr.Length - mid);

        MergeSort(left);
        MergeSort(right);

        Merge(arr, left, right);
    }

    static void Merge(int[] arr, int[] left, int[] right) {
        int i = 0, j = 0, k = 0;

        while (i < left.Length && j < right.Length) {
            if (left[i] <= right[j]) {
                arr[k++] = left[i++];
            } else {
                arr[k++] = right[j++];
            }
        }

        while (i < left.Length) {
            arr[k++] = left[i++];
        }

        while (j < right.Length) {
            arr[k++] = right[j++];
        }
    }

    static void Main() {
        int[] data = { 38, 27, 43, 3, 9, 82, 10 };
        MergeSort(data);

        Console.WriteLine(string.Join(", ", data)); // Output: 3, 9, 10, 27, 38, 43, 82
    }
}
```

## 💡 Greedy Algorithms

**Description**:
Greedy algorithms aim to solve optimization problems by making locally optimal choices at each step. These choices may or may not lead to the globally optimal solution.

- **Advantages**: Fast and straightforward.
- **Disadvantages**: May produce incorrect results if the problem does not have the "Greedy Choice Property."

### 🟠 **Problem**: Sum of Coins

- **Goal**: Minimize the number of coins used to make a target sum.
- **Approach**: Start with the largest coin denomination and proceed greedily.

**Code Example**:
```csharp
using System;
using System.Collections.Generic;

class Program {
    static void SumOfCoins(int[] coins, int target) {
        Array.Sort(coins, (a, b) => b.CompareTo(a)); // Sort coins in descending order
        Dictionary<int, int> usedCoins = new Dictionary<int, int>();

        foreach (int coin in coins) {
            if (target == 0) break;

            int count = target / coin;
            if (count > 0) {
                usedCoins[coin] = count;
                target -= coin * count;
            }
        }

        if (target > 0) {
            Console.WriteLine("❌ Cannot reach the target with the given coins.");
        } else {
            Console.WriteLine("✅ Coins used:");
            foreach (var kvp in usedCoins) {
                Console.WriteLine($"  {kvp.Value} coin(s) of {kvp.Key}");
            }
        }
    }

    static void Main() {
        int[] coins = { 1, 2, 5, 10, 25, 50 };
        int target = 87;

        SumOfCoins(coins, target);
        // Output:
        // ✅ Coins used:
        //   1 coin(s) of 50
        //   1 coin(s) of 25
        //   1 coin(s) of 10
        //   2 coin(s) of 1
    }
}
```

### 🟠 **Problem**: Set Cover

- **Goal**: Select the smallest subset of sets whose union covers all required elements.

**Code Example**:
```charp
using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    static void SetCover(List<HashSet<int>> sets, HashSet<int> universe) {
        List<HashSet<int>> selectedSets = new List<HashSet<int>>();

        while (universe.Count > 0) {
            var bestSet = sets.OrderByDescending(s => s.Count(e => universe.Contains(e))).First();
            selectedSets.Add(bestSet);

            foreach (int element in bestSet) {
                universe.Remove(element);
            }
            sets.Remove(bestSet);
        }

        Console.WriteLine("✅ Selected Sets:");
        foreach (var set in selectedSets) {
            Console.WriteLine($"  {string.Join(", ", set)}");
        }
    }

    static void Main() {
        var universe = new HashSet<int> { 1, 2, 3, 4, 5 };
        var sets = new List<HashSet<int>> {
            new HashSet<int> { 1, 2 },
            new HashSet<int> { 2, 4 },
            new HashSet<int> { 3, 5 },
            new HashSet<int> { 4, 5 }
        };

        SetCover(sets, universe);
        // Output:
        // ✅ Selected Sets:
        //   1, 2
        //   2, 4
        //   3, 5
    }
}
```
## 🛠️ Where These Algorithms Are Useful:
- **Searching Algorithms**: Locate data quickly in databases, files, or memory structures.  
- **Sorting Algorithms**: Essential for preprocessing data for tasks like binary search, visualizations, or reporting.  
- **Greedy Algorithms**: Solve optimization problems in network routing, resource allocation, and more.


## 📚 Summary
**Key Takeaways:**

- **Searching Algorithms**:  
  - Linear Search is straightforward but inefficient for large datasets.  
  - Binary Search is faster but requires sorted data.  

- **Sorting Algorithms**:  
  - Simple algorithms like Bubble Sort and Selection Sort are easy to implement but slow for large datasets.  
  - Advanced algorithms like Quick Sort and Merge Sort are more efficient, making them suitable for large-scale applications.  

- **Greedy Algorithms**:  
  - They work by making the best local choice at each step, which can lead to global optimization for some problems.  
  - Not all problems are suitable for greedy solutions; understanding the problem's structure is essential.  

- **Algorithm Complexity**:  
  - Knowing the time and space complexity of each algorithm helps in choosing the right one for a specific problem.  

By mastering these algorithms, you will be equipped to solve real-world problems efficiently, laying a strong foundation for further studies in data structures and algorithms. 🚀


## 💬 Feedback & Contribution

Contributions and feedback are welcome!

- 💡 Have ideas for improvement? Open an issue.
- 🛠️ Want to contribute? Submit a pull request.


## 👨‍💻 Author

If you have any questions or suggestions, feel free to reach out at:

- 📧 Email: kadiryazadzhi@gmail.com
- 🌐 Portfolio: [Kadir Yazadzhi](https://kadiryazadzhi.github.io/portfolio/)

## ❓ Questions?

For further information, explore:
- [SoftUni](softuni.bg)

 > This guide is powered by insights from SoftUni's presentation on Algorithms, Recursion, and Backtracking.

---

Join me on this learning journey, and feel free to explore and try out the solutions on your own. Happy coding! 😃
