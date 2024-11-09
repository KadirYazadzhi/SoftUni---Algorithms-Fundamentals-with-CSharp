# 🧩 Algorithms: Recursion and Backtracking

Welcome to an introduction to **Algorithm Complexity**, **Recursion**, and **Backtracking**! This guide covers core concepts, examples, and when to choose recursion vs. iteration. Let's dive into the fascinating world of algorithms! 🚀


## 📖 Table of Contents
1. [Algorithmic Complexity](#algorithmic-complexity)
2. [Recursion](#recursion)
3. [Backtracking](#backtracking)
4. [Recursion vs. Iteration](#recursion-vs-iteration)
5. [Summary](#summary)


## 🧮 Algorithmic Complexity

### Why Analyze Algorithms?
Analyzing algorithms helps predict the resources required for execution, including:
- 🕰️ **Time (CPU)**
- 💾 **Memory (RAM)**
- 📶 **Bandwidth**
- 📂 **Disk Usage**

### Example: Counting Operations
```csharp
long GetOperationsCount(int n) {
    long counter = 0;
    for (int i = 0; i < n; i++)
        for (int j = 0; j < n; j++)
            counter++;
    return counter;
}
```

### Resulting Complexity
- **T(n) = 3n2n2 + 3n + 3, simplifies to O(n^2)**


### ⏲️ Time Complexity
Different cases:
- **Worst-case**: Upper limit of time
- **Average-case**: Expected time
- **Best-case**: Lower limit of time

### 📊 Asymptotic Notations

- **Big O (O(n))**: Upper bound
- **Big Theta (Θ(n))**: Tight bound
- **Big Omega (Ω(n))**: Lower bound

## 🔄 Recursion

### What is Recursion?

**Recursion** is a method where the solution depends on solutions to smaller instances of the same problem. It typically has:

- **Base Case**: Condition to stop recursion
- **Recursive Call**: Function calls itself with modified arguments

### 📝 Example: Array Sum

Problem: Find the sum of all elements in an array using recursion.

```csharp
static int Sum(int[] array, int index) {
    if (index == array.Length - 1) {
        return array[index];
    }
    return array[index] + Sum(array, index + 1);
}
```

### 🔢 Example: Factorial Calculation

Recursive definition of factorial: **n! = n * (n-1)! for n > 0 0! = 1**

```csharp
static long GetFactorial(int num) {
    if (num == 0) return 1;
    return num * GetFactorial(num - 1);
}
```

## 🔙 Backtracking

**Backtracking** is a class of algorithms that finds all possible solutions by building up solutions incrementally and removing those that fail to satisfy constraints.

### Example: The 8 Queens Problem ♛

Place 8 queens on a chessboard such that no two queens threaten each other.

```csharp
static void PutQueens(int row) {
    if (row == 8) PrintSolution();
    else {
        for (int col = 0; col < 8; col++) {
            if (CanPlaceQueen(row, col)) {
                SetQueen(row, col);
                PutQueens(row + 1);
                RemoveQueen(row, col);
            }
        }
    }
}
```


## 🔄 Recursion vs. Iteration

When to use each approach:

- **Recursion**: Good for **branching problems**, such as combinatorial tasks and complex tree traversals.
- **Iteration**: Better for **linear tasks** where each step only depends on the previous one.

### ⚠️ Warning: Infinite Recursion

Recursion without a proper base case can cause **stack overflow**. Always ensure recursive functions have a termination condition.

## 📚 Summary
Key Takeaways:

- **Algorithm Complexity** is essential for understanding the efficiency of algorithms.
- **Recursion** is powerful but requires careful base cases to avoid infinite loops.
- **Backtracking** is suitable for problems involving multiple potential solutions, like the 8-Queens puzzle.
- Choose **recursion** or **iteration** based on the nature of the problem.

## ❓ Questions?

For further information, explore:
- [SoftUni](softuni.bg)

 > This guide is powered by insights from SoftUni's presentation on Algorithms, Recursion, and Backtracking.
