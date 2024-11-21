# 🎲 **Combinatorial Problems**

Welcome to an introduction to Combinatorial Problems! 🎲 This guide explores the key concepts of permutations, variations, and combinations, with practical examples and essential formulas. Whether you're solving puzzles, designing algorithms, or analyzing probabilities, combinatorics has you covered. Let's dive into this exciting topic together! 🚀


## 📜 **Table of Contents**  
1. 🚀 **Introduction**  
2. 🔄 **Permutations**  
    - 🔑 Definition  
    - 👩‍💻 Code Example  
3. 🌀 **Variations**  
    - 🔑 Definition  
    - 👩‍💻 Code Example  
4. 🤝 **Combinations**  
    - 🔑 Definition  
    - 👩‍💻 Code Example  
5. 🧮 **N Choose K Count**  
    - 🔢 Formula  
6. 💻 **Practical Example**  
7. 📊 **Summary**


## 🚀 **Introduction**  

Combinatorial problems involve arranging, selecting, or counting elements in specific ways. They are widely used in areas such as:  

- Mathematics  
- Computer science  
- Cryptography  
- Probability and statistics  

### 💡 **Key Topics**  
- **Permutations**: Arrangement where the order matters.  
- **Variations**: Arrangement with limited slots, where the order matters.  
- **Combinations**: Selection of elements where the order does not matter.  


## 🔄 **Permutations**  

### 🔑 **Definition**  
Permutation is defined as a mathematical concept that determines the number of possible arrangements for a specific set of elements. Simply put, it represents the different ways in which data can be ordered, typically taken from a list. 

### 📝 **Theory**  
- Total number of permutations for a set of size `n` is calculated as:  
\[
P(n) = n!
\]
- Permutations can be:  
  - **Without repetition** (unique elements).  
  - **With repetition** (some elements may repeat).  

### 👩‍💻 **Code Example**: *Generate Permutations*  

```csharp
static void Permute(int index) {
    if (index >= elements.Length) {
        Print();
    } else {
        for (int i = 0; i < elements.Length; i++) {
            if (!used[i]) {
                used[i] = true;
                permutations[index] = elements[i];
                Permute(index + 1);
                used[i] = false;
            }
        }
    }
}
```

## 🌀 **Variations**

### 🔑 **Definition**  
Variations represent a way of selecting a subset of elements from a larger set, where the order of the elements in the subset matters. The size of the subset is fixed, meaning only a specific number of elements are chosen. Variations are commonly used in problems where the arrangement of items is crucial, such as scheduling, cryptography, or creating unique sequences.

### 📝 **Theory**  

1. **Total Number of Variations**  
The total number of variations is calculated using the formula:  
\[
V(n, k) = \frac{n!}{(n-k)!}
\]  

2. **Types of Variations**  
- **Without repetition**: Each element is used at most once in the subset.  
- **With repetition**: Elements can be reused multiple times within the subset.  


### 👩‍💻 **Code Example**: *Generate Variations*  

```csharp
static void Variations(int index) {
    if (index >= variations.Length) {
        Print();
    } else {
        for (int i = 0; i < elements.Length; i++) {
            if (!used[i]) {
                used[i] = true;
                variations[index] = elements[i];
                Variations(index + 1);
                used[i] = false;
            }
        }
    }
}
```

## 🤝 **Combinations**

### 🔑 **Definition**  
Combinations represent a method of selecting a subset of elements from a larger set, where the order of the elements in the subset does not matter. Unlike variations, the arrangement of the selected elements is irrelevant, making combinations ideal for scenarios such as lottery draws, team selections, or grouping items. The subsets are unique regardless of how the elements are arranged.

### 📝 **Theory**  

1. **Total Number of Combinations**  
The total number of combinations is calculated using the formula:  
\[
C(n, k) = \frac{n!}{k! \cdot (n-k)!}
\]  

2. **Key Difference from Variations**  
In combinations, the order of the elements within a subset does not matter, while in variations, the arrangement is significant.  


### 👩‍💻 **Code Example**: *Generate Combinations*

```csharp
static void Combinations(int index, int start) {
    if (index >= slots.Length) {
        Print();
    } else {
        for (int i = start; i < elements.Length; i++) {
            slots[index] = elements[i];
            Combinations(index + 1, i + 1);
        }
    }
}
```

## 🧮 **N Choose K Count**

### 🔑 **Definition**  
The "N Choose K" problem, also known as the binomial coefficient, represents the number of ways to select `k` elements from a set of `n` elements, where the order of selection does not matter. This concept is fundamental in combinatorics and is used in various fields, including probability theory, statistics, and algorithm design. It calculates how many unique combinations can be formed without considering the arrangement of the chosen elements.

### 🔢 **Formula**  
The number of ways to choose `k` elements from a set of `n` elements is calculated as:  
\[
C(n, k) = \frac{n!}{k! \cdot (n-k)!}
\]  

### 🔑 **Pascal's Triangle**  
The binomial coefficients can also be derived using Pascal's Triangle. Each entry in the triangle is the sum of the two entries directly above it. This property simplifies the computation of coefficients in scenarios where factorial calculation is not practical.


## 💻 Practical Example: Girls and Boys Combinations

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    public static void Main() {
        List<string> girls = Console.ReadLine().Split(", ").ToList();
        string[] girlsComb = new string[3];
        List<string[]> girlsCombs = new List<string[]>();

        GenCombs(0, 0, girls, girlsComb, girlsCombs);
        
        List<string> boys = Console.ReadLine().Split(", ").ToList();
        string[] boysComb = new string[2];
        List<string[]> boysCombs = new List<string[]>();
        
        GenCombs(0, 0, boys, boysComb, boysCombs);
        
        PrintFinalCombs(girlsCombs, boysCombs);
    }

    private static void PrintFinalCombs(List<string[]> girlsCombs, List<string[]> boysCombs) {
        foreach (string[] girl in girlsCombs) {
            foreach (string[] boy in boysCombs) {
                Console.WriteLine($"👩 {string.Join(", ", girl)} + 👦 {string.Join(", ", boy)}");
            }
        }
    }

    private static void GenCombs(int idx, int start, List<string> elements, string[] comb, List<string[]> combs) {
        if (idx >= comb.Length) {
            combs.Add(comb.ToArray());
            return;
        }

        for (int i = start; i < elements.Count; i++) {
            comb[idx] = elements[i];
            GenCombs(idx + 1, i + 1, elements, comb, combs);
        }
    }
}
```

## 📊 Summary

### 🎯 Combinatorial Techniques
- **Permutations**: Arrangement of elements.
- **Variations**: Limited slots, order matters.
- **Combinations**: Selection of elements, order doesn't matter.


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

 > This guide is powered by insights from SoftUni's presentation on Combinatorial Problems.

---

Join me on this learning journey, and feel free to explore and try out the solutions on your own. Happy coding! 😃
