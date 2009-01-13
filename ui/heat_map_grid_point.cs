using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace FightinZigbees
{
  public class HeatMapGridPoint : GridPoint
  {
    public HeatMapGridPoint(Grid grid, Point point, float intensity) : base(grid, point)
    {
      if(HeatMapGridPoint.img == null)
      {
        HeatMapGridPoint.img = new Bitmap("resources/graphics/gradient.png");
        HeatMapGridPoint.alpha_matrix = new float[][]{
          new float[] { 1, 0, 0, 0, 0 },
          new float[] { 0, 1, 0, 0, 0 },
          new float[] { 0, 0, 1, 0, 0 },
          new float[] { 0, 0, 0, 1, 0 },
          new float[] { 0, 0, 0, 0, 1 }
        };
      }

      this.intensity = intensity;
      HeatMapGridPoint.alpha_matrix[3][3] = 2 * this.intensity - 0.000001f; // for some reason if we get a 2.0 for that value, we get a big hole in the center.
    }

    public override void draw(Graphics g)
    {
      ColorMatrix cm = new ColorMatrix(HeatMapGridPoint.alpha_matrix);
      ImageAttributes imgAttribs = new ImageAttributes();
      imgAttribs.SetColorMatrix(cm, ColorMatrixFlag.Default, ColorAdjustType.Default);

      float width  = 2 * this._grid.cell_width  + this._grid.cell_width * this.intensity;
      float height = 2 * this._grid.cell_height + this._grid.cell_height * this.intensity;

      g.DrawImage(
        HeatMapGridPoint.img,
        new Rectangle((int)(this._point.X - width / 2), (int)(this._point.Y - height / 2), (int)width, (int)height),
        0, 0, HeatMapGridPoint.img.Width, HeatMapGridPoint.img.Height,
        GraphicsUnit.Pixel,
        imgAttribs
      );
      /*
      g.FillEllipse(new SolidBrush(Color.FromArgb(128,Color.White)), new Rectangle((int)(this._point.X - width / 2), (int)(this._point.Y - height / 2), (int)width, (int)height));
      */
    }

    protected static Image img;
    protected static float[][] alpha_matrix;
    protected float intensity;
  }
}
