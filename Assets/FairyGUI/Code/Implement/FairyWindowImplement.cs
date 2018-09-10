using FairyGUI;

public class FairyWindowImplement : FairyWindow
{
    public Window CreateWindow(GObject obj)
    {
        Window window = new Window();
        window.modal = false;
        window.AddChild(obj);
        window.Show();
        return window;
    }
}
