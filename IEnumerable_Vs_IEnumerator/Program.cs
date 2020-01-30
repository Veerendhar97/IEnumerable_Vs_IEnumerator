using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerable_Vs_IEnumerator
{
    class Student
    {
        public int Sno { get; set; }
        public string Sname { get; set; }
        public  float Marks { get; set; }
    }
    class Institute:IEnumerable
    {
        List<Student> stu = new List<Student>();

        public IEnumerator GetEnumerator()
        {
            //  return stu.GetEnumerator();
            return new InstituteEnumarator(this);
        }
        public Student this[int index]
        {
            get
            {
                return stu[index];
            }
        }
        public int Count()
        {
            return stu.Count;
        }
        public void Insert(Student a)
        {
            stu.Add(a);
        }

    }
    class InstituteEnumarator : IEnumerator
    {
        int CurIndex ;
        Institute i1 = new Institute();
        Student s;
        public InstituteEnumarator(Institute i2)
        {
            i1 = i2;
            CurIndex = -1;
        }
        public object Current 
        {
            get
            {
                return s;
            }
        }
        public bool MoveNext()
        {
            if (++CurIndex >= i1.Count())
                return false;
            else
                s = i1[CurIndex];
            return true;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Institute inst = new Institute();
            inst.Insert( new Student { Sno = 5, Sname = "Arun", Marks = 10 });
            inst.Insert( new Student { Sno = 10, Sname = "Pranay", Marks = 15 });
            inst.Insert(new Student { Sno = 1, Sname = "Zubair", Marks = 30 });
            inst.Insert(new Student { Sno = 7, Sname = "Varun", Marks= 19 });
            inst.Insert(new Student { Sno = 14, Sname = "Arun", Marks= 10 });

            Institute institute = new Institute();
            
            // List<Student> e = new List<Student>() { e1, e2, e3, e4, e5 };
            foreach(Student i in inst)
            {
                Console.WriteLine(i.Sno + "   " + i.Sname + "  " + i.Marks);
            }
            Console.ReadKey();
        }
    }
}
