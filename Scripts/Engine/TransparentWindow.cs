using Godot;
using System;
using System.Runtime.InteropServices;

public partial class TransparentWindow : Node
{

    [DllImport("user32.dll")]
    public static extern IntPtr GetActiveWindow();

    [DllImport("user32.dll")]
    private static extern int SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);

    private const int GwlExStyle = -20;

    private const uint WsExLayered = 0x00080000;
    private const uint WsExTransparent = 0x00000020;
    private const uint WsExToolWindow = 0x00000080; // Style for not showing in taskbar

    private IntPtr _hWnd;

    private bool _bClickThrough = true;

    public override void _Ready()
    {
        _hWnd = GetActiveWindow();

        SetWindowLong(_hWnd, GwlExStyle, WsExLayered | WsExTransparent | WsExToolWindow);

        SetClickThrough(true);
       
        
    }

    public void SetClickThrough(bool clickthrough)
    {
        if (clickthrough == _bClickThrough) return;
        _bClickThrough = clickthrough;

        if (clickthrough)
        {
            SetWindowLong(_hWnd, GwlExStyle, WsExLayered | WsExTransparent | WsExToolWindow);
        }
        else
        {
            SetWindowLong(_hWnd, GwlExStyle, WsExLayered | WsExToolWindow);
        }
    }

    public override void _PhysicsProcess(double delta)
    {
        Viewport viewport = GetViewport();

        Image img = viewport.GetTexture().GetImage();
        Rect2 rect = viewport.GetVisibleRect();

        Vector2 mousePosition = viewport.GetMousePosition();
        int viewX = (int)((int)mousePosition.X + rect.Position.X);
        int viewY = (int)((int)mousePosition.Y + rect.Position.Y);

        int x = (int)(img.GetSize().X * viewX / rect.Size.X);
        int y = (int)(img.GetSize().Y * viewY / rect.Size.Y);

        if (x < img.GetSize().X && y < img.GetSize().Y && x >= 0 && y >= 0)
        {

            Color pixel = img.GetPixel(x, y);
            SetClickThrough(pixel.A < 0.5f);


        }

        img.Dispose();
    }
}