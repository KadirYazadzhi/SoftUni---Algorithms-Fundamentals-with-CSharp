# 🎲 **Combinatorial Problems with Code Examples**


## 📜 **Table of Contents**  
1. 🚀 **Introduction**  
2. 🔄 **Permutations**  
3. 🌀 **Variations**  
4. 🤝 **Combinations**  
5. 🧮 **N Choose K Count**  
6. 💻 **Practical Example**


## 🚀 **Introduction**  

Combinatorial problems involve arranging, selecting, or counting elements in specific ways. Applications range from mathematics to computer science and beyond!  

### 💡 **Key Topics**  
- **Permutations**: Order matters.  
- **Variations**: Order matters, limited by slots.  
- **Combinations**: Order doesn't matter.  


## 🔄 **Permutations**  

### 🔑 **Definition**  
Permutations are all possible arrangements of a set.  

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
Variations are subsets of elements where the order matters.  

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
Combinations are subsets where order does not matter.

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
