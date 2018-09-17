using FairyGUI;
using System.Collections.Generic;
using RunTimeExcuteSpace;

namespace SimpleUI
{
    public partial class WindowManage :SingleInstance<WindowManage>
    {
        protected Dictionary<string, UIMedia> allWindows = new Dictionary<string, UIMedia>();
        public Dictionary<string, UIMedia> AllWindows { get { return allWindows; } }

        partial void LoadWindow();
       

        public WindowManage()
        {
            LoadWindow();           
        }

        UIMedia GetCreateCommand(string key)
        {
            if(!allWindows.ContainsKey(key))
            {
                string methodName = string.Format("{0}Mapping", key);
                RunTimeExcute.GenericExcuteMethod<CreateInstanceMapping>(methodName);
                return GetCreateCommand(key);
            }
            return allWindows[key];
        }


        Window MainMenuWindow;
        public bool AddMainMenu(WindowName windowName)
        {
            UIMedia createCommand = GetCreateCommand(windowName.Key);
            if (createCommand != null)
            {
                GComponent component = createCommand.Inject();
                if (component != null)
                {
                    if(MainMenuWindow == null)
                    {
                        MainMenuWindow = new Window();
                        MainMenuWindow.name = "MainMenuWindow";
                    }
                    MainMenuWindow.AddChild(component);
                    MainMenuWindow.Show();
                    return true;
                }
            }
            return false;
        }


        Window lastWindow;
        GComponent lastWindowContent;
        UIMdeiaDispose lastDispose;
        public bool OpenWindow(WindowName windowName)
        {
            UIMedia createCommand = GetCreateCommand(windowName.Key);

            if(createCommand != null)
            {
                GComponent component = createCommand.Inject();

                if (component != null)
                {
                    if(lastWindow != null && lastWindowContent != null && lastDispose != null)
                    {
                        if(lastDispose.Disposable)
                        {
                            lastWindowContent.Dispose();
                        }
                    }

                    if(lastWindow == null)
                    {
                        lastWindow = new Window();
                        lastWindow.name = "ModalWindow";
                        lastWindow.modal = true;
                    }

                    lastDispose = component as UIMdeiaDispose;

                    lastWindowContent = component;
                    lastWindow.AddChild(component);
                    lastWindow.Show();
                    return true;
                }
            }           
            return false;
        }
        public bool CloseWindow(WindowName windowName, bool disposeChild = true)
        {
            if (disposeChild && lastWindowContent != null)
            {

                if (lastDispose.Disposable)
                {
                    lastWindowContent.Dispose();
                    lastDispose = null;
                    lastWindowContent = null;
                }
            }
            return true;
        }
    }
}
