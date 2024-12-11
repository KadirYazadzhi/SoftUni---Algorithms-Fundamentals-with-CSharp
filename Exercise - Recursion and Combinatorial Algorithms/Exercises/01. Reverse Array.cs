using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    static void Main() {
        string[] args = Console.ReadLine().Split(" ").ToArray();
        
        Reverse(args, 0); 
        Console.WriteLine(string.Join(" ", args));
    }

    private static void Reverse(string[] args, int idx) {
        if (idx >= args.Length / 2) {
            return;
        }
        
        string temp = args[idx];
        args[idx] = args[args.Length - 1 - idx];
        args[args.Length - 1 - idx] = temp;
        
        Reverse(args, idx + 1);
    }
}
