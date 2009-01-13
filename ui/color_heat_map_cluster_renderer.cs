using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace FightinZigbees 
{
  public class ColorHeatMapClusterRenderer : ClusterRenderer
  {
    public ColorHeatMapClusterRenderer(Graphics g, Grid grid) : base(g, grid)
    {
      ColorHeatMapClusterRenderer.create_palette_index();
      this.g = this.g;
    }

    public void clear()
    {
      this.output = new Bitmap(
        this._grid.size.Width + this._grid.location.X * 2,
        this._grid.size.Height + this._grid.location.Y * 2,
        PixelFormat.Format32bppArgb
      );

      this.surface = Graphics.FromImage(output);
      this.surface.Clear(Color.Black);
    }

    public override void draw(List<Cluster> clusters)
    {
      //I added this to subtract from the X, Y coord
      //to center the heat map.
      float radius = this._grid.cell_width / 2;
      if (this.surface == null)
        this.clear();

      surface.TranslateTransform(-this.grid.location.X, -this.grid.location.Y);

      PointF pasdf = this._grid.scale_to_screen_coords(new Location(1, 1));

      ImageAttributes remapper = new ImageAttributes();
      remapper.SetRemapTable(ColorHeatMapClusterRenderer.color_map);

      HeatMapClusterRenderer hm = new HeatMapClusterRenderer(this.surface, this._grid);
      hm.draw(clusters);
    
      Rectangle dest_rectangle = new Rectangle(this.grid.location, this.grid.size);

      dest_rectangle.Width += this.grid.location.X * 2;
      dest_rectangle.Height += this.grid.location.Y * 2;

      
      for (int i = 0; i < 12; ++i)
        this.g.DrawImage(output, dest_rectangle, 0, 0, output.Width, output.Height, GraphicsUnit.Pixel, remapper);
    }

    protected static void create_palette_index()
    {
      if(ColorHeatMapClusterRenderer.color_map != null)
        return;

      ColorHeatMapClusterRenderer.color_map = new ColorMap[255];

      // Change this path to wherever you saved the palette image.
      Bitmap palette = (Bitmap)Bitmap.FromFile(@"resources/graphics/heat_maps_with_transparency.png");

      // Loop through each pixel and create a new color mapping
      for (int i = 0; i < 255; i++)
      {
        ColorHeatMapClusterRenderer.color_map[i] = new ColorMap();
        ColorHeatMapClusterRenderer.color_map[i].OldColor = Color.FromArgb(i, i, i);
        ColorHeatMapClusterRenderer.color_map[i].NewColor = Color.FromArgb(i, palette.GetPixel(i, 0));
      }
    }

    protected Bitmap output;
    protected Graphics surface;
    protected static ColorMap[] color_map;
  }
}
