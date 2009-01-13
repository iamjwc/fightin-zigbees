using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace FightinZigbees 
{
  public delegate void SliderEventHandler(object sender, EventArgs e);
  public delegate void SlidingEventHandler(object sender, EventArgs e);

  public class Slider : TrackBar
  {
    const int HORZ_LINE_PADDING = 2;
    const int KNOB_RADIUS = 5;
    const int HORZ_KNOB_PADDING = HORZ_LINE_PADDING;
    const int LINE_PEN_SIZE = 3;
    protected Rectangle knob_rect;
    protected PointF click_offset;
    protected Boolean is_dragging;
    protected Boolean slider_moved;
    public event SliderEventHandler Slide;
    public event SlidingEventHandler Sliding;

    public int value
    {
      get { return this._value; }
      set {
        if (value > this.Maximum || value < this.Minimum)
        {
          throw new Exception("The specified slider value falls outside the min / max range.");
        }
        this._value = value;
        set_knob_pos(calculate_knob_pos());
        OnSlide(new EventArgs());
      }
    }

    // raises the event by invoking the delegate   
    protected virtual void OnSlide(EventArgs e) 
    {
      if (Slide != null) 
      {
        //Invokes the delegates.
        Slide(this, e); 
      }
    }

    // raises the event by invoking the delegate   
    protected virtual void OnSliding(EventArgs e)
    {
      if (Sliding != null)
      {
        //Invokes the delegates.
        Sliding(this, e);
      }
    }

    public Slider()
    {
      //Initiates C# built-in double buffering 
      this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
      is_dragging = false;
      slider_moved = false;
      this._value = 0;

      center_knob_vertically();
    }

    protected override void OnSizeChanged(EventArgs e)
    {
      base.OnSizeChanged(e);
      center_knob_vertically();
    }

    protected void center_knob_vertically()
    {
      knob_rect = new Rectangle(HORZ_KNOB_PADDING, this.Size.Height / 2 - KNOB_RADIUS, KNOB_RADIUS * 2, KNOB_RADIUS * 2);
    }

    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    {
      Graphics g = e.Graphics;
      g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
      draw_line(g);
      draw_knob(g);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
      if (is_inside_knob(e.Location))
      {
        click_offset = new PointF(e.Location.X - knob_rect.X, e.Location.Y - knob_rect.Y);
        is_dragging = true;
        slider_moved = true;
      }
      else if(mouse_within_line(e))
      {
        slider_moved = true;
        move_knob_to_mouse(e);
      }

    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
      if (slider_moved == true)
      {
        _value = calculate_new_value();
        OnSlide(new EventArgs());
      }
      is_dragging = false;
      slider_moved = false;
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
      if (is_dragging == true)
      {
        move_knob_to_mouse(e);
        _value = calculate_new_value();
        OnSliding(new EventArgs());
      }
    }

    protected void move_knob_to_mouse(MouseEventArgs e)
    {
      set_knob_pos((int)(e.Location.X - click_offset.X));
      this.Invalidate();
    }

    protected void set_knob_pos(int pos)
    {
      knob_rect.X = pos;
      if (knob_rect.X <= knob_min_pos())
      {
        knob_rect.X = knob_min_pos();
      }
      else if (knob_rect.X >= knob_max_pos())
      {
        knob_rect.X = knob_max_pos();
      }
    }

    protected int knob_max_pos()
    {
      return (this.Width - HORZ_KNOB_PADDING) - knob_rect.Size.Width;
    }

    protected int knob_min_pos()
    {
      return HORZ_KNOB_PADDING;
    }

    public void set_range(int min, int max)
    {
      this.SetRange(min, max);
      if (this.value > max)
      {
        this._value = max;
      }
      else if (this.value < min)
      {
        this._value = min;
      }
      set_knob_pos(calculate_knob_pos());
    }
    
    protected bool is_inside_knob(PointF p)
    {
      if((p.X >= knob_rect.X && p.X <= knob_rect.X + knob_rect.Size.Width) &&
        (p.Y >= knob_rect.Y && p.Y <= knob_rect.Y + knob_rect.Size.Height))
      {
        return true;
      }
      return false;
    }

    protected void draw_line(Graphics g)
    {      
      // Slider Line
      Pen line_pen = new Pen(Color.LightSteelBlue, LINE_PEN_SIZE);
      line_pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
      line_pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
      int y_pos = line_y_pos();
      g.DrawLine(line_pen, new Point(HORZ_LINE_PADDING, y_pos), new Point(this.Size.Width - HORZ_LINE_PADDING, y_pos));
    }

    protected int line_y_pos()
    {
      return this.Size.Height / 2;
    }

    protected Boolean mouse_within_line(MouseEventArgs e)
    {
      float y_pos = (float)line_y_pos();
      if (e.Y < y_pos + LINE_PEN_SIZE / 2.0 && e.Y > y_pos - LINE_PEN_SIZE / 2.0)
      {
        return true;
      }
      return false;
    }

    protected int calculate_new_value()
    {
      // (distance from line start to upper left of knob) / (line length - width of knob)
      //  = (new value) / (max value)
      float line_length = (this.Size.Width - 2f * HORZ_LINE_PADDING);
      float distance_from_line_start_to_upper_left_of_knob = knob_rect.X - HORZ_LINE_PADDING;
      return (int)Math.Round((((this.Maximum - this.Minimum) * distance_from_line_start_to_upper_left_of_knob) / (line_length - knob_rect.Width)) + this.Minimum);
    }

    protected int calculate_knob_pos()
    {
      // (distance from line start to upper left of knob) / (line length - width of knob)
      //  = (new value) / (max value)
      float line_length = (this.Size.Width - 2f * HORZ_LINE_PADDING);
      return (int)Math.Round((((this.value - this.Minimum) * (line_length - knob_rect.Width)) / (this.Maximum - this.Minimum)) + HORZ_KNOB_PADDING);
    }

    protected void draw_knob(Graphics g)
    {
    // Slider Knob
      Pen knob_pen = new Pen(Color.SteelBlue, 1);
      Brush knob_brush = Brushes.LightSteelBlue;
      g.FillEllipse(knob_brush,knob_rect);
      g.DrawEllipse(knob_pen, knob_rect);
    }

    protected int _value;

  }
}

