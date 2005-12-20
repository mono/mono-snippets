using System;
using Gtk;

public class TrayTest
{
    private static EventBox event_box;
    private static Menu menu;
    private static Window window;

    public static void Main()
    {
        Application.Init();
        
        window = new Window("Look at your notification area");
        window.DeleteEvent += delegate(object o, DeleteEventArgs args) {
            Quit();
            args.RetVal = true;
        };
     
        window.WindowPosition = WindowPosition.Center;
        window.BorderWidth = 50;
        window.Add(new Label("Look at your notifcation area"));
        window.ShowAll();
        
        // Build the NotificationAreaIcon, pack an event box to handle clicking, etc.
        // and pack an icon in the event box to display in the "tray"
        NotificationAreaIcon nai_container = new NotificationAreaIcon("Testing");
        event_box = new EventBox();
        event_box.Add(new Image(Stock.Find, IconSize.Menu));
        event_box.ButtonPressEvent += OnNotificationAreaIconButtonPressEvent;
        nai_container.Add(event_box);
        nai_container.ShowAll();
        
        // Build a menu to show when the user right clicks our icon
        menu = new Menu();
        foreach(string item in new string [] { "Apples", "Oranges", "Pears", "Grapes", "Apricots", "Plumbs" }) {
            menu.Append(new MenuItem(item));
        }
        
        menu.Append(new SeparatorMenuItem());
        
        ImageMenuItem quit_item = new ImageMenuItem(Stock.Quit, null);
        quit_item.Activated += delegate(object o, EventArgs args) {
            Quit();
        };
        menu.Append(quit_item);
        
        Application.Run();
    }
    
    private static void OnNotificationAreaIconButtonPressEvent(object o, ButtonPressEventArgs args)
    {
        switch(args.Event.Button) {
            case 1:
                // Show/Hide the main window when user left clicks our icon
                window.Visible = !window.Visible;
                args.RetVal = true;
                return;
            case 3:
                // Properly position and display a menu when user right clicks our icon
                menu.ShowAll();
                menu.Popup(null, null, new MenuPositionFunc(PositionMenu), args.Event.Button, args.Event.Time);
                args.RetVal = true;
                return;
        }
        
        args.RetVal = false;
    }
    
    // Properly calculate position of menu; takes into account the position of the panel
    // containing the NotificationAreaIcon and the edges of the screen
    private static void PositionMenu(Menu menu, out int x, out int y, out bool push_in)
    {
        int button_y, panel_width, panel_height;
        Gtk.Requisition requisition = menu.SizeRequest();

        event_box.GdkWindow.GetOrigin(out x, out button_y);
        (event_box.Toplevel as Gtk.Window).GetSize(out panel_width, out panel_height);

        y = (button_y + panel_height + requisition.Height >= event_box.Screen.Height) 
            ? button_y - requisition.Height
            : button_y + panel_height;

        push_in = true;
    }
    
    private static void Quit()
    {
        Application.Quit();
    }
}
