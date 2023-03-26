using System;
namespace Samogina_LAB3
{   class LAB3 { 
        static void Main(string[] args) {
            Nodelist list = new Nodelist();
            list.Push_front("4");
            list.Push_front("3");
            list.Push_front("2");
            list.Push_front("1");
            list.Pop_front();
            list.getAt(0).PRINT();
            Console.WriteLine("Da");
        }
    }

    class NODE {
        public object? Data;
        public NODE? Next;
        public NODE? Prev;
        public NODE(object? data, NODE? next, NODE? prev) { Data = data;Next = next;Prev = prev; }
        public NODE() {Data = null; Next = null;Prev = null; }
        public NODE(object? data) { Data=data;Prev = null;Next = null; }
        public void PRINT()
        {
            Console.Write(Data);
            if (Next != null) Console.Write(Next.Data);
        }
    }

    class Nodelist
    {
        protected NODE? Head;
        protected NODE? Tail;
        public NODE Push_front(object data)
        {
            NODE ptr = new NODE(data);
            ptr.Next = Head;
            if (Head != null) { Head.Prev = ptr; }
            if (Tail == null) { Tail = ptr; }
            Head = ptr;
            return ptr;
        }
        public NODE Push_back(object data)
        {
            NODE ptr = new NODE(data);
            ptr.Prev = Tail;
            if (Tail != null) { Tail.Next = ptr; }
            if (Head == null) { Head = ptr; }
            Tail = ptr;
            return ptr;
        }
        public void Pop_front() {
            if (Head == null) return;
            NODE? ptr = Head.Next;
            if (ptr != null) { ptr.Prev = null; }
            else Tail = ptr;

            Head = ptr;
        }
        public void Pop_back()
        {
            if (Tail == null) return;
            NODE? ptr = Tail.Prev;
            if (ptr != null) { ptr.Next = null; }
            else Head = ptr;

            Tail = ptr;
        }
        public NODE getAt(int index)
        {
            NODE? ptr = Head;
            int n = 0;
            while (n != index)
            {
                if (ptr == null) return ptr;
                ptr = ptr.Next;
                n++;
            }
            return ptr;
        }
        public NODE insert(int index,object data) {
            NODE right = getAt(index);
            if (right == null) return Push_back(data);

            NODE left = right.Prev;
            if(left == null) return Push_front(data);

            NODE ptr = new NODE(data);
            ptr.Prev = left;
            ptr.Next = right;
            left.Next= ptr;
            right.Prev= ptr;
            return ptr;
        }
        public void earse(int index)
        {
            NODE ptr=getAt(index);
            if (ptr == null) return;
            if(ptr.Prev== null) { Pop_front();return; }
            if (ptr.Next == null) { Pop_back(); return; }
            NODE left = ptr.Prev;
            NODE righ= ptr.Next;
            left.Next = righ;
            righ.Prev = left;
        }

    }
}