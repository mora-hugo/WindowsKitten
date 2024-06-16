using Godot;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public partial class TransparentWindow : Node
{

    [DllImport("user32.dll")]
    public static extern IntPtr GetActiveWindow();

    //  SetWindowLong() modifies a specific flag value associated with a window.
    [DllImport("user32.dll")]
    private static extern int SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);
	
    private const int GwlExStyle = -20;
	
    // "Properties" of the window to be set, Layered is to have transparent pixels, Transparent is to make the window click-through
    private const uint WsExLayered = 0x00080000;
    private const uint WsExTransparent = 0x00000020;

    // index reference of the window
    private IntPtr _hWnd;

    private bool _bClickThrough = true;
    public override void _Ready()
    {
        // Get the reference of the game window
        _hWnd = GetActiveWindow();

        // setting the flags of becoming a layered and transparent window
        SetWindowLong(_hWnd, GwlExStyle, WsExLayered | WsExTransparent);
        
        SetClickThrough(true);
    }

    // Call this method via your preferred detection algorythm (personally I check the 
    // pixel under cursor to have alpha < 0.5f but you do you)
    public void SetClickThrough(bool clickthrough)
    {
        //Ensure abusive call to windows api
        
        if (clickthrough == _bClickThrough) return;
        _bClickThrough = clickthrough;
        
        if (clickthrough)
        {
            SetWindowLong(_hWnd, GwlExStyle, WsExLayered | WsExTransparent);
        }
        else
        {
            SetWindowLong(_hWnd, GwlExStyle, WsExLayered);
        }
    }

    public override void _PhysicsProcess(double delta)
    {
        Viewport viewport = GetViewport();
        
        Image img = viewport.GetTexture().GetImage();
        Rect2 rect = viewport.GetVisibleRect();
        
        // Getting the mouse position in the viewport
        Vector2 mousePosition = viewport.GetMousePosition();
        int viewX = (int) ((int)mousePosition.X + rect.Position.X);
        int viewY = (int) ((int)mousePosition.Y + rect.Position.Y);

        // Getting the mouse position relative to the image (image will be the size of the window)
        int x = (int)(img.GetSize().X * viewX / rect.Size.X);
        int y = (int)(img.GetSize().Y * viewY / rect.Size.Y);

        // Getting the pixel at the mouse position coordinates
        if (x < img.GetSize().X && y < img.GetSize().Y && x >= 0 && y >= 0)
        {
            
            Color pixel = img.GetPixel(x, y);
            SetClickThrough(pixel.A < 0.5f); 
            

        }
        // Very important to dispose the rendered image or will bloat memory !!!!!
        img.Dispose();
    }
}
