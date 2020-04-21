using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TriadCore;
using System.Reflection;
using System.IO;
using System.Windows.Forms;

namespace TriadNSim
{
    public class UserRoutine : TriadCore.Routine
    {
        public static TriadCore.Routine Create(Routine routine)
        {
            string loadFileName = Application.StartupPath + "\\" + routine.Name + ".dll";
            Assembly assembly = Assembly.LoadFile(loadFileName);
            Type routineType = assembly.GetType("TriadCore." + routine.Name);
            object obj = Activator.CreateInstance(routineType);
            return obj as TriadCore.Routine;
        }
    }
}
