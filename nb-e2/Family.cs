using nb_e2.Models;
using System;
using System.Collections.Generic;

namespace nb_e2
{
    class Family
    {
        private readonly List<FamilyMember> _listOfMembers;

        public Family()
        {
            _listOfMembers = new List<FamilyMember>();
        }

        /// <summary>
        /// Sets Gender to Male. If parent found will set to Female.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool Male(string name)
        {
            FamilyMember member = _listOfMembers.Find(x => x.Name == name);
            // No match in name so returns false.
            if (member == null)
            {
                Console.WriteLine(false);
                return false;
            }
            // Gender already set.
            else if (member.Gender != null)
            {
                Console.WriteLine(false);
                return false;
            }
            else
            {
                SetPartnersGender(member, "Female"); // Helper method.
                _listOfMembers.Find(x => x.Name == name).Gender = "Male";
                Console.WriteLine(true);
                return true;
            }
        }

        /// <summary>
        /// Sets Gender to Female. If parent found will set to Male.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool Female(string name)
        {
            FamilyMember member = _listOfMembers.Find(x => x.Name == name);
            // No match in name so returns false.
            if (member == null)
            {
                Console.WriteLine(false);
                return false;
            }
            // Gender already set.
            else if (member.Gender != null)
            {
                Console.WriteLine(false);
                return false;
            }
            else
            {
                SetPartnersGender(member, "Male"); // Helper method.
                _listOfMembers.Find(x => x.Name == name).Gender = "Female";
                Console.WriteLine(true);
                return true;
            }
        }

        /// <summary>
        /// Returns bool when querying Gender. Returns false if gender is not set.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool IsMale(string name)
        {
            FamilyMember member = _listOfMembers.Find(x => x.Name == name);

            if (member != null)
            {
                if (member.Gender == "Male")
                {
                    Console.WriteLine(true);
                    return true;
                }
                else
                {
                    Console.WriteLine(false);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Returns bool when querying Gender. Returns false if gender is not set.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool IsFemale(string name)
        {
            FamilyMember member = _listOfMembers.Find(x => x.Name == name);

            if (member != null)
            {
                if (member.Gender == "Female")
                {
                    Console.WriteLine(true);
                    return true;
                }
                else
                {
                    Console.WriteLine(false);
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// Sets relationship.
        /// </summary>
        /// <param name="childName"></param>
        /// <param name="parentName"></param>
        /// <returns></returns>
        public bool SetParentOf(string childName, string parentName)
        {
            FamilyMember child = _listOfMembers.Find(x => x.Name == childName);
            FamilyMember parent = _listOfMembers.Find(x => x.Name == parentName);

            // Child cannot be same as Parent.
            if (childName == parentName)
            {
                Console.WriteLine(false);
                return false;
            }
            // Are the children of the child member the same as the parent?
            if (AvoidBeingOwnAncestor(child, parentName))
            {
                Console.WriteLine(false);
                return false;
            }
            // Child is a new member.
            if (child == null)
            {
                FamilyMember newMember = new FamilyMember
                {
                    Name = childName,
                    Children = new List<string>(),
                    Parents = new List<string>()
                };
                _listOfMembers.Add(newMember);
            }
            // Parent is a new member.
            if (parent == null)
            {
                FamilyMember newMember = new FamilyMember
                {
                    Name = parentName,
                    Children = new List<string>(),
                    Parents = new List<string>()
                };
                _listOfMembers.Add(newMember);
            }
            // If Child has two Parents we cannot set Parents to Child.
            if (_listOfMembers.Find(x => x.Name == childName).Parents.Count == 2)
            {
                Console.WriteLine(false);
                return false;
            }
            else
            {
                _listOfMembers.Find(x => x.Name == childName).Parents.Add(parentName);
                _listOfMembers.Find(x => x.Name == parentName).Children.Add(childName);
                Console.WriteLine(true);
                return true;
            }
        }

        /// <summary>
        /// Returns Array of Strings of all Parents.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string[] GetParentsOf(string name)
        {
            string[] parents = _listOfMembers.Find(x => x.Name == name).Parents.ToArray();
            Console.WriteLine(parents.Length);
            return parents;
        }

        /// <summary>
        /// Returns Array of Strings of all Children.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string[] GetChildrenOf(string name)
        {
            string[] children = _listOfMembers.Find(x => x.Name == name).Children.ToArray();
            Console.WriteLine(children.Length);
            return children;
        }

        /// <summary>
        /// HELPER method. If partner exists && has no gender it will set it.
        /// </summary>
        /// <param name="member"></param>
        /// <param name="gender"></param>
        public void SetPartnersGender(FamilyMember member, string gender)
        {
            List<string> children = member.Children;
            if (children != null)
            {
                foreach (string child in children)
                {
                    List<string> parents = _listOfMembers.Find(x => x.Name == child).Parents;

                    foreach (string parent in parents)
                    {
                        if (_listOfMembers.Find(x => x.Name == parent).Gender == null && _listOfMembers.Find(x => x.Name == parent).Name != member.Name)
                        {
                            _listOfMembers.Find(x => x.Name == parent).Gender = gender;
                        }
                    }
                }
            }
            else
            {
                // Do nothing.
            }
        }
        /// <summary>
        /// HELPER method. This will check if we are trying to set someone as their own ancestor.
        /// </summary>
        /// <param name="child"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public bool AvoidBeingOwnAncestor(FamilyMember member, string name)
        {
            if (member != null)
            {
                foreach (string x in member.Children)
                {
                    if (x == name)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}