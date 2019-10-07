using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CShape
{
    class Program
    {
        static void Main(string[] args)
        {

            NoteClass v1 = new NoteClass("v1");
            NoteClass v2 = new NoteClass("v2");
            NoteClass v3 = new NoteClass("v3");
            NoteClass v4 = new NoteClass("v4");
            NoteClass v5 = new NoteClass("v5");
            NoteClass v6 = new NoteClass("v6");
            NoteClass v7 = new NoteClass("v7");
            NoteClass v8 = new NoteClass("v8");
            NoteClass v9 = new NoteClass("v9");
            NoteClass v10 = new NoteClass("v10");
            NoteClass v11 = new NoteClass("v11");

            v1.AddPath(v2, 9);
            v1.AddPath(v4, 8);
            v2.AddPath(v5, 1);
            v2.AddPath(v4, 2);
            v3.AddPath(v1, 1);
            v3.AddPath(v7, 9);
            v4.AddPath(v3, 3);
            v5.AddPath(v4, 5);
            v5.AddPath(v9, 1);
            v6.AddPath(v4, 1);
            v6.AddPath(v5, 3);
            v6.AddPath(v7, 9);
            v7.AddPath(v4, 2);
            v7.AddPath(v10, 1);
            v8.AddPath(v5, 2);
            v8.AddPath(v11, 6);
            v9.AddPath(v6, 6);
            v9.AddPath(v7, 3);
            v9.AddPath(v8, 7);
            v9.AddPath(v11, 10);
            v10.AddPath(v9, 1);
            v10.AddPath(v11, 9);

            NoteClass[] notes = new NoteClass[11] 
            { v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11 };

            //foreach(NoteClass note in notes)
            //{ Console.WriteLine(note.ToString()); }

            //Console.WriteLine(v11.GetShortestPath());

            Console.ReadKey();
        }
    }
}
