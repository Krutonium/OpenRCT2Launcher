using System;
using System.Windows.Forms;

namespace HelperLibrary.Classes {
    public static class Funcs {
        private delegate void VoidInvoker<TControl>(TControl c, Action<TControl> action) where TControl : Control;
        public static void RunWithInvoke<TControl>(this TControl c, Action<TControl> action) where TControl : Control {
            if (c.InvokeRequired) {
                c.Invoke(new VoidInvoker<TControl>(RunWithInvoke), c, action);
            } else {
                action(c);
            }
        }

        private delegate TResult FuncInvoker<TControl, TResult>(TControl c, Func<TControl, TResult> action) where TControl : Control;
        public static TResult RunWithInvoke<TControl, TResult>(this TControl c, Func<TControl, TResult> action) where TControl : Control {
            if (c.InvokeRequired) {
                return (TResult)c.Invoke(new FuncInvoker<TControl, TResult>(RunWithInvoke), c, action);
            }
            return action(c);
        }
    }
}
