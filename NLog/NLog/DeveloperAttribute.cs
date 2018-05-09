using System;


namespace NLog
{

    public class DeveloperAttribute : System.Attribute
    {
        private string name;
        private int age;

        public DeveloperAttribute(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public virtual string DeveloperName
        {
            get { return name; }
        }

        public virtual int DeveloperAge
        {
            get { return age; }
        }
    }
}