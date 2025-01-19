# 🕪 Introduction to Dynamic Programming

This module explores the foundational concepts of **Dynamic Programming (DP)**, focusing on solving optimization problems efficiently by breaking them into overlapping subproblems. By the end of this guide, you will:

- Understand the principles of DP and its key components.
- Learn to solve classical DP problems such as Fibonacci, Subset Sum, and Longest Common Subsequence.
- Master techniques like memoization and iterative DP.

## 📋 Table of Contents
1. **What is Dynamic Programming?**
2. **Fibonacci Sequence**
3. **Subset Sum Problem**
4. **Move Down/Right Sum**
5. **Longest Common Subsequence**
6. **Where These Algorithms Are Useful**


## 🔗 What is Dynamic Programming?

**Dynamic Programming (DP)** is a method for solving complex problems by breaking them down into simpler subproblems. The key idea is to **store the solutions of subproblems** to avoid redundant work, significantly reducing computation time.

Key concepts involved in DP:

- **Subproblems**: These are smaller versions of the original problem, which can be solved independently.
- **Memoization**: Caching the results of expensive function calls to avoid redundant computations.
- **Optimal Substructure**: This is the property that a problem can be solved optimally by solving its subproblems optimally.
- **Overlapping Subproblems**: Many subproblems share the same solution, allowing the use of memoization.
- **Bottom-Up vs. Top-Down Approach**: Bottom-up is the iterative method, while top-down uses recursion combined with memoization.

DP is particularly useful for problems that have optimal substructure and overlapping subproblems, where a direct brute force solution would be inefficient.


## 🔢 Fibonacci Sequence

**Description**: The Fibonacci sequence is a series of numbers where each number is the sum of the two preceding ones.

- **Recursive Formula**:
  - F(0) = 0, F(1) = 1
  - F(n) = F(n-1) + F(n-2)

### 🟢 Recursive Approach

This approach directly follows the recursive formula but suffers from exponential time complexity (O(2^n)) because it recalculates the same values repeatedly.

```csharp
int Fibonacci(int n) {
    if (n <= 1) return n;
    return Fibonacci(n - 1) + Fibonacci(n - 2);
}
```

### 🔎 Optimized with Memoization

Using memoization stores the results of previous computations in a cache (array), significantly improving performance to O(n).
```csharp
int FibonacciMemo(int n, int[] memo) {
    if (n <= 1) return n;
    if (memo[n] == 0) {
        memo[n] = FibonacciMemo(n - 1, memo) + FibonacciMemo(n - 2, memo);
    }
    return memo[n];
}
```
- Time Complexity: O(n) with memoization.
- Space Complexity: O(n) for the memo array.

## 📊 Subset Sum Problem

**Description**: Given a set of numbers, determine if there is a subset whose sum equals a target value.

### 🔢 No Repetitions (Unbounded)

In this version, each number can only be used once. We calculate all possible sums by iterating over the set.
```csharp
bool SubsetSum(int[] nums, int target) {
    var possibleSums = new HashSet<int> { 0 };
    foreach (var num in nums) {
        var newSums = new HashSet<int>();
        foreach (var sum in possibleSums) {
            newSums.Add(sum + num);
        }
        possibleSums.UnionWith(newSums);
    }
    return possibleSums.Contains(target);
}
```

### 🟢 With Repetitions (Unbounded Knapsack)

Here, numbers can be repeated as often as needed, which is common in problems like the knapsack problem.
```charp
bool[] SubsetSumRepetition(int[] nums, int target) {
    var possible = new bool[target + 1];
    possible[0] = true;
    foreach (var num in nums) {
        for (int sum = num; sum <= target; sum++) {
            possible[sum] |= possible[sum - num];
        }
    }
    return possible;
}
```
- Time Complexity: O(n * target), where `n` is the number of elements in the set and target is the `target` sum.
- Space Complexity: O(target) for the DP array.


## 📈 Move Down/Right Sum

**Description**: In a grid or matrix, find the maximum sum path from the top-left corner to the bottom-right corner, only allowing movements to the right or down.

This problem can be solved using dynamic programming by creating a `dp` table where each cell holds the maximum sum possible to reach that point.
```csharp
int MaxPathSum(int[][] matrix) {
    int rows = matrix.Length, cols = matrix[0].Length;
    int[,] dp = new int[rows, cols];

    dp[0, 0] = matrix[0][0];
    for (int r = 1; r < rows; r++) dp[r, 0] = dp[r - 1, 0] + matrix[r][0];
    for (int c = 1; c < cols; c++) dp[0, c] = dp[0, c - 1] + matrix[0][c];

    for (int r = 1; r < rows; r++) {
        for (int c = 1; c < cols; c++) {
            dp[r, c] = matrix[r][c] + Math.Max(dp[r - 1, c], dp[r, c - 1]);
        }
    }

    return dp[rows - 1, cols - 1];
}
```
- Time Complexity: O(rows * cols)
- Space Complexity: O(rows * cols) for the DP array.

### 🌐 Longest Common Subsequence
**Description**: Given two strings, find the longest subsequence that appears in both strings in the same order, but not necessarily consecutively.

#### 🔢 Dynamic Programming Approach

This solution builds a 2D `dp` table where each entry `dp[i][j]` represents the length of the longest common subsequence of the strings `s1[0..i-1]` and `s2[0..j-1]`.

```csharp
int LongestCommonSubsequence(string s1, string s2) {
    int[,] dp = new int[s1.Length + 1, s2.Length + 1];

    for (int i = 1; i <= s1.Length; i++) {
        for (int j = 1; j <= s2.Length; j++) {
            if (s1[i - 1] == s2[j - 1]) {
                dp[i, j] = dp[i - 1, j - 1] + 1;
            } else {
                dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
            }
        }
    }

    return dp[s1.Length, s2.Length];
}
```

- Time Complexity: O(m * n), where `m` and `n` are the lengths of the two strings.
- Space Complexity: O(m * n) for the DP table.

## 🛠️ Where These Algorithms Are Useful

- Fibonacci Sequence:
  - Use Cases: Modeling biological processes, financial analysis, recursive calculations.
- Subset Sum Problem:
  - Use Cases: Resource allocation, knapsack problems, decision-making algorithms.
- Move Down/Right Sum:
  - Use Cases: Pathfinding in grids, terrain analysis, image processing.
- Longest Common Subsequence:
  - Use Cases: DNA sequence comparison, version control systems, diff tools.
        
## 📚 Summary

- Dynamic Programming is a powerful technique for optimization, reducing the time complexity of problems by solving smaller subproblems and storing intermediate results.
- Memoization avoids redundant calculations, while Optimal Substructure ensures that solving subproblems optimally leads to an optimal solution for the entire problem.
- Mastering DP allows you to solve a wide range of complex problems efficiently.

> Embrace the power of DP and start solving complex problems efficiently! 🚀


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

 > This guide is powered by insights from SoftUni's presentation on Introduction to Dynamic Programming.

---

Join me on this learning journey, and feel free to explore and try out the solutions on your own. Happy coding! 😃
