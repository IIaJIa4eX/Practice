using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface INotifier
    {
        void Notify();
    }

    public class Notifier1 : INotifier
    {
        public void Notify()
        {
            Debug.WriteLine("Debugging from Notifier 1");
        }

    }
}
