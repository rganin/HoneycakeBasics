using System;
using HoneycakeBasics.Util;
using Unity.VisualScripting;

namespace HoneycakeBasics.Ui
{
    public class WindowManager: SingletonBase<WindowManager>
    {
        public WindowManager getInstance()
        {
            return Instance;
        }

        public void showPromptDialog(string header, string prompt, Action onConfirm, Action onDecline)
        {
            
        }
    }
}