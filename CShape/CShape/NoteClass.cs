using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CShape
{
    class NoteClass
    {
        private string id;
        public string ID { get { return this.id; } }
        Hashtable paths = new Hashtable();
        public Hashtable Paths { get { return this.paths; } }
        
        public NoteClass(string id)
        { this.id = id; }
        public NoteClass(string id, NoteClass note, double value, bool isTwoway = false)
        {
            this.id = id;
            this.paths.Add(note, value);
            if (isTwoway) // 双向
            { note.paths.Add(this, value); }
        }
        
        public void AddPath(NoteClass note, double value, bool isTwoway = false)
        {
            this.paths.Add(note, value);
            if (isTwoway)
            { note.paths.Add(this, value); }
        }
        public NoteClass GetShortestPath()
        {
            double min = 99999;
            NoteClass result_note = null;
            foreach(NoteClass note in this.paths.Keys)
            {
                if ((double)this.paths[note] < min)
                {
                    min = (double)this.paths[note];
                    result_note = note;
                }
            }
            return result_note;
        }
        public override string ToString()
        {
            String str = "";
            foreach(NoteClass note in this.paths.Keys)
            {
                str += String.Format("{0} → {1}: {2} \n",
                                    this.id, note.id, this.paths[note]);
            }
            return str;
        }
    }
}
