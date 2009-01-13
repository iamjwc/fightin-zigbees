using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace FightinZigbees
{
  public class Grid
  {
    public Grid(int x_cell_count, int y_cell_count)
    {
      this._display_broadcast_nodes = false;
      this._x_cell_count = x_cell_count;
      this._y_cell_count = y_cell_count;
      this.clusters = new List<Cluster>();
      this._renderer_type = Constant.HEAT_MAP_RENDERER;
      this.broadcast_xbs = new BroadcastXbee[Constant.NUM_NODES];
      for(int i = 0; i < Constant.NUM_NODES; i++)
      {
        broadcast_xbs[i] = new BroadcastXbee();
      }
    }

    public bool display_broadcast_nodes
    {
      get { return this._display_broadcast_nodes;}
      set { this._display_broadcast_nodes = value;}
    }

    public int x_cell_count
    {
      get { return this._x_cell_count; }
      set { this._x_cell_count = value; }
    }

    public int y_cell_count
    {
      get { return this._y_cell_count; }
      set { this._y_cell_count = value; }
    }

    public Point location
    {
      get { return this._point; }
      set { this._point = value; }
    }

    public Size size
    {
      get { return this._size; }
      set { this._size = value; }
    }

    public string renderer_type
    {
      get { return this._renderer_type; }
      set { this._renderer_type = value; }
    }

    //Width of a single cell in our grid.
    public float cell_width
    {
      get { return this._size.Width / this._x_cell_count; }
    }
    
    //Height of a single cell in our grid.
    public float cell_height
    {
      get { return this._size.Height / this._y_cell_count; }
    }

    //If you know where it is on the grid but not the 
    //screen, this will scale it for you given a X and Y
    //Coordinate.
    public PointF scale_to_screen_coords(float x, float y)
    {
      return new PointF(
        this.location.X + (x * this.cell_width),
        this.location.Y + (y * this.cell_height)
      );
    }
    //If you know where it is on the grid but not the 
    //screen, this will scale it for you given a location.
    public PointF scale_to_screen_coords(Location loc)
    {
      return this.scale_to_screen_coords(loc.x, loc.y);
    }
    //If you know where the coordinates are on the screen
    //but you need it on the grid, this will convert it.
    public Location scale_to_grid_coords(Point p)
    {
      return new Location(
        (p.X - this.location.X) / this.cell_width,
        (p.Y - this.location.Y) / this.cell_height
      );
    }

    public Point mouse;

    public void hover(Point p)
    {
      this.mouse = p;
    }

    protected bool _should_rerender_cluster;

    public void force_rerender()
    {
      this._should_rerender_cluster = true;
    }

    protected bool should_rerender_cluster()
    {
      return this.cluster_surface == null || this._should_rerender_cluster;
    }

    protected void render_clusters()
    {
      if(!this.should_rerender_cluster())
        return;

      this._should_rerender_cluster = false;

      cluster_image = new Bitmap(this.size.Width + this._point.X, this.size.Height + this._point.Y, PixelFormat.Format32bppArgb);
      cluster_surface = Graphics.FromImage(cluster_image);

      if (_renderer_type != Constant.HEAT_MAP_RENDERER && _renderer_type != Constant.CONVEX_HULL_RENDERER)
      {
        throw new Exception("Invalid cluster renderer type has been specified.");
      }

      ClusterRenderer cluster_renderer;
      if (_renderer_type == Constant.HEAT_MAP_RENDERER)
        cluster_renderer = new ColorHeatMapClusterRenderer(this.cluster_surface, this);
      else
        cluster_renderer = new ConvexHullClusterRenderer(this.cluster_surface, this);
      
      //This will cause the form to load before all the clusters are rendered.
      System.Windows.Forms.Application.DoEvents();

      this.cluster_surface.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
      cluster_renderer.draw(this.clusters);
      
    }

    protected void draw_clusters(Graphics g)
    {
      this.render_clusters();
      g.DrawImage(this.cluster_image, new Point(0,0));
    }

    protected Bitmap cluster_image;
    protected Graphics cluster_surface;

    public void draw_back(Graphics g)
    {
      this.draw_background(g);
      this.draw_grid_lines(g);
    }

    public void draw(Graphics g)
    {
      g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
      this.draw_clusters(g);
      
      if(this.mouse != null)
      {
        ClusterRenderer cluster_centers = new CenterOfMassClusterRenderer(g, this);
        cluster_surface.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        
        cluster_centers.draw(this.clusters);
       
        Location mouse_l = this.scale_to_grid_coords(mouse);

        Cluster c;
        float max_intensity = this.clusters[0].intensity;
        for(int i = 0; i < this.clusters.Count; ++i)
        {
          c = this.clusters[i];
          float distance_away = (c.intensity/max_intensity)/2.0f;
          if(distance_away < 0.25) {
            distance_away = 0.25f;
          }
          if(mouse_l.distance_from(c.location) < distance_away) // Makes the area bigger if the spot is more intense
          {
            new HoverOver(g, this).draw(this.mouse, c);
            break;
          }
        }
        //This displays the broadcasting nodes if the check box is checked.
        if (_display_broadcast_nodes)
        {
          for (int i = 0; i < Constant.NUM_NODES; i++)
          {
            if (mouse_l.distance_from(this.broadcast_xbs[i].location) < .8)
            {
              new HoverOverBroadcastNode(g, this).draw(this.mouse, this.broadcast_xbs[i]);
              break;
            }
          }
        }
      }
    }

    protected void draw_grid_lines(Graphics g)
    {
      Pen pen = new Pen(Color.FromArgb(100, 100, 100), 1);

      for(int i = 1; i <= this._x_cell_count; ++i)
        g.DrawLine(pen, _point.X + i * cell_width, _point.Y, _point.X + i * cell_width, _point.Y + size.Height);
      for(int i = 1; i <= this._y_cell_count; ++i)
        g.DrawLine(pen, _point.X, _point.Y + i * cell_height, _point.X + size.Width, _point.Y + i * cell_height);
    }

    protected void draw_background(Graphics g)
    {
      Brush b = new SolidBrush(Color.FromArgb(40, 40, 40));
      g.FillRectangle(b, this._point.X, this._point.Y, size.Width, size.Height);
    }

    public void add_cluster(Cluster cluster)
    {
      this.clusters.Add(cluster);
      //probably needs to be sorted by intensity somewhere
      //this.clusters.Sort(new ClusterIntensityComparer());
    }

    public void add_broadcast_node(BroadcastXbee bc_xb)
    {
      this.broadcast_xbs[bc_xb.id] = bc_xb;
    }

    public void clear_clusters()
    {
      this.clusters.Clear();
    }

    protected bool _display_broadcast_nodes;
    protected Point _point;
    protected Size _size;
    protected int _x_cell_count;
    protected int _y_cell_count;
    public List<Cluster> clusters;
    protected BroadcastXbee[] broadcast_xbs;
    protected string _renderer_type;
  }
}
