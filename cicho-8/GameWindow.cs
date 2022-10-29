using System.Diagnostics;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace cicho_8;

public class GameWindow
{

    private VideoMode _videoMode;
    private RenderWindow _window;

    int tickCount = 0;
    int gameTime = 0;
    int scale = 4;
    
    private Text text;
    private RectangleShape _curs;

    private Clock _timer;

    public void Init()
    {
        _videoMode = new VideoMode(800, 600);
        _window = new RenderWindow(_videoMode, "SFML works!");

        _window.Closed += OnClosed;
        _window.KeyPressed += OnKeyPressed;
        _window.Resized += OnResized;
        _window.TextEntered += OnTextEntered;
        
        _timer = new Clock();
        
        text = new Text("> print lol", new Font("resources/GamerGirl.ttf"), 8);
        text.Position = new Vector2f(0, 0);
        text.FillColor = new SFML.Graphics.Color(255, 255, 255, 255);

        _curs = new RectangleShape();
        _curs.Size = new Vector2f(8, 8);
        _curs.FillColor = new Color(255, 0, 0, 150);
    }

    private void OnTextEntered(object? sender, TextEventArgs e)
    {
        var value = e.ToString().ToLower();
        Console.WriteLine(value);
    }


    private void OnResized(object? sender, SizeEventArgs e)
    {
        
    }

    private void OnKeyPressed(object? sender, KeyEventArgs e)
    {
        
    }

    private void OnClosed(object? sender, EventArgs e)
    {
        VirtualSystem.Shutdown();
        _window.Close();
    }

    public void Run()
    {
        VirtualSystem.Boot();
        
        Init();
        _timer.Restart();
        
        int lastTime = _timer.ElapsedTime.AsMilliseconds();
        int lastTimer = _timer.ElapsedTime.AsMilliseconds(); //to output the ticks and fps in the console
        double unprocessed = 0; //counts unprocessed ticks to compensate
        double msPerTick = 1000 / 60d; //frames per seconds
        int frames = 0;
        int ticks = 0;

        while (VirtualSystem.IsRunning)
        {
            int now = _timer.ElapsedTime.AsMilliseconds();
            unprocessed += (now - lastTime) / msPerTick; //calculates unprocessed time
            lastTime = now;
            bool shouldRender = true;
            
            //if game skipped updates, compensate for that 
            while (unprocessed >= 1) {
                ticks++;
                Update();
                unprocessed -= 1;
                shouldRender = true;
            }

            if (shouldRender) {
                frames++;
                Draw();
            }

            if (_timer.ElapsedTime.AsMilliseconds() - lastTimer > 1000) {
                lastTimer += 1000;
                Console.WriteLine(ticks + " ticks, " + frames + " f/s");
                frames = 0;
                ticks = 0;
            }
            
        }
    }
    
    void Update()
    {
        _window.DispatchEvents();
        tickCount++; //future use?
    }

    void Draw()
    {
        Clear();
        //Begin
        _window.Draw(text);
        //End
        _window.Display();
    }

    void Clear()
    {
        _window.Clear();
    }
    
}