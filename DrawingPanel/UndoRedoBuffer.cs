using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DrawingPanel
{
    public enum UndoRedoAction
    {
        uraUpdate,
        uraInsert,
        uraDelete
    }

    public class BufferElement
    {

        public BaseObject RefElem;
        public UndoRedoAction Action;     
        public BaseObject OldElem;
        public BaseObject NewElem;

        public BufferElement(BaseObject oRefElem, BaseObject oNewElem, BaseObject oOldElem, UndoRedoAction aAction)
        {
            RefElem = oRefElem;
            OldElem = oOldElem;
            NewElem = oNewElem;
            Action = aAction;
        }

    }

    /// <summary>
    /// двухсвязный список
    /// </summary>
    public class UndoRedoObj
    {
        public UndoRedoObj Next;
        public UndoRedoObj Prev;
        public object Elem;

        public UndoRedoObj(object Obj)
        {
            Elem = Obj;
        }

    }

    /// <summary>
    /// Undo/Redo
    /// </summary>
    //[Serializable]
    public class UndoRedoBuffer
    {
        private UndoRedoObj Top;
        private UndoRedoObj Bottom;
        private UndoRedoObj Current;
        private int _BuffSize;
        private int _N_elem;
        private bool At_Bottom;

        public UndoRedoBuffer(int i)
        {

            this.BuffSize = i;
            this._N_elem = 0;
            Top = null;
            Bottom = null;
            Current = null;
            At_Bottom = true;
        }

        public int BuffSize
        {
            get
            {
                return _BuffSize;
            }
            set
            {
                _BuffSize = value;
            }
        }

        public int N_elem
        {
            get
            {
                return _N_elem;
            }
        }

        public void add2Buff(object o)
        {
            if (o != null)
            {
                UndoRedoObj g = new UndoRedoObj(o);
                if (this.N_elem == 0)
                {
                    g.Next = null;
                    g.Prev = null;
                    Top = g;
                    Bottom = g;
                    Current = g;
                }
                else
                {
                    g.Prev = Current;
                    g.Next = null;
                    Current.Next = g;
                    Top = g;
                    Current = g;
                    if (this.N_elem == 1)
                    {
                        Bottom.Next = g;
                    }
                }

                this._N_elem++;
                if (this.BuffSize < this.N_elem)
                {
                    this.Bottom = this.Bottom.Next;
                    this.Bottom.Prev = null;
                    this._N_elem--;
                }
                At_Bottom = false;
            }


        }

        public object Undo()
        {
            if (Current != null)
            {
                object obj = Current.Elem;
                if (Current.Prev != null)
                {
                    Current = Current.Prev;
                    this._N_elem--;
                    this.At_Bottom = false;
                }
                else
                {
                    this.At_Bottom = true;
                }
                return obj;
            }
            return null;
        }

        public object Redo()
        {
            if (Current != null)
            {
                object obj;
                if (!At_Bottom)
                {
                    if (Current.Next != null)
                    {
                        Current = Current.Next;
                        this._N_elem++;
                    }
                }
                else
                {
                    At_Bottom = false;
                }
                obj = Current.Elem;

                return obj;
            }
            //this._N_elem = count();
            return null;
        }

        public bool unDoable()
        {
            return !this.At_Bottom;
        }

        public bool unRedoable()
        {
            if (this.Current == null)
                return false;
            if (this.Current.Next == null)
                return false;
            return true;
        }
    }
}
