using System;

namespace nb_e2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var fam = new Family();
            fam.SetParentOf("Frank", "Morgan"); // true
            fam.SetParentOf("Frank", "Dylan"); // true
            fam.Male("Dylan"); // true
            fam.SetParentOf("Joy", "Frank"); // true
            fam.Male("Frank"); // true
            fam.Male("Morgan"); // false
            fam.SetParentOf("July", "Morgan"); // true
            fam.IsMale("Joy"); // false
            fam.IsFemale("Joy"); // false
            fam.GetChildrenOf("Morgan"); // ["Frank", "July"]
            fam.SetParentOf("Jennifer", "Morgan"); // true
            fam.GetChildrenOf("Morgan"); // ["Frank", "Jennifer", "July"]
            fam.GetChildrenOf("Dylan"); // ["Frank"]
            fam.GetParentsOf("Frank"); // ["Dylan", "Morgan"]
            fam.SetParentOf("Morgan", "Frank"); // false
            
            Console.ReadKey();
        }
    }
}
