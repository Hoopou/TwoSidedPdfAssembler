using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace TwoSidedPdfAssembler
{
    public class ImagePathFinder
    {
        public List<Image> AutoCut(Image image, Color backgroundColor, Panel showpanel, int tolerance = 80)
        {

            var bmp = new Bitmap(image);
            int w = bmp.Width;
            int h = bmp.Height;
            var basecolor = bmp.GetPixel(w - 1, h - 1);


            var firstpixelOfBackgroundColor = 1;
            for (int i = image.Width / 2; i < image.Width; i++)
            {
                if (bmp.GetPixel(i, 0) == backgroundColor || isSameColorWithTolerance(bmp.GetPixel(i, 0), basecolor, tolerance)) { firstpixelOfBackgroundColor = i; break; }
            }
            if (firstpixelOfBackgroundColor == -1) return new List<Image>();

            List<Tile> activeTiles = new List<Tile>();
            activeTiles.Add(new Tile() { Cost = 1, X = firstpixelOfBackgroundColor, Y = 0, Distance = 0 });
            var visitedTiles = new List<Tile>();
                walk(visitedTiles, bmp, activeTiles.First(), basecolor, tolerance, showpanel);
                
            //t.Join();

            //while (activeTiles.Any())
            //{
            //	var checkTile = activeTiles.OrderBy(x => x.CostDistance).First();

            //	if ( checkTile.Y == h)//checkTile.X == finish.X &&
            //	{
            //		Console.WriteLine("We are at the destination!");
            //		//We can actually loop through the parents of each tile to find our exact path which we will show shortly. 
            //		return;
            //	}

            //	visitedTiles.Add(checkTile);
            //	activeTiles.Remove(checkTile);

            //	var walkableTiles = GetWalkableTiles(bmp, checkTile, h-1,basecolor, tolerance);

            //	foreach (var walkableTile in walkableTiles)
            //	{
            //		//We have already visited this tile so we don't need to do so again!
            //		if (visitedTiles.Any(x => x.X == walkableTile.X && x.Y == walkableTile.Y))
            //			continue;

            //		//It's already in the active list, but that's OK, maybe this new tile has a better value (e.g. We might zigzag earlier but this is now straighter). 
            //		if (activeTiles.Any(x => x.X == walkableTile.X && x.Y == walkableTile.Y))
            //		{
            //			var existingTile = activeTiles.First(x => x.X == walkableTile.X && x.Y == walkableTile.Y);
            //			if (existingTile.CostDistance > checkTile.CostDistance)
            //			{
            //				activeTiles.Remove(existingTile);
            //				activeTiles.Add(walkableTile);
            //			}
            //		}
            //		else
            //		{
            //			//We've never seen this tile before so add it to the list. 
            //			activeTiles.Add(walkableTile);
            //			bmp.SetPixel(walkableTile.X, walkableTile.Y, Color.Red);
            //		}
            //	}

            //	showpanel.BackgroundImage = null;
            //	showpanel.BackgroundImage = (Image)bmp;
            //	showpanel.Refresh();
            //} 

            List<Image> splittedList = splitImages(bmp, visitedTiles, backgroundColor, tolerance);

            showpanel.BackgroundImage = null;
            showpanel.BackgroundImage = (Image)splittedList.First();
            showpanel.Refresh();

            return splittedList;
        }

        private bool walk(List<Tile> visitedTiles, Bitmap map, Tile currentTile, Color baseColor, int tolerance, Panel showpanel)
        {
            if (visitedTiles.Contains(currentTile)) return false;

            visitedTiles.Add(currentTile);

            map.SetPixel(currentTile.X, currentTile.Y, Color.Red);
            //if(visitedTiles.Count%200 = 0)
            //{

            //showpanel.BackgroundImage = null;
            //showpanel.BackgroundImage = (Image)map;
            //showpanel.Refresh();
            //}

            if (currentTile.Y == map.Height - 1)
            {
                return true;
            }
            try
            {

                var walkableTiles = GetWalkableTiles(map, currentTile, map.Height, baseColor, tolerance);

                foreach (var tile in walkableTiles)
                {
                    bool canWalk = walk(visitedTiles, map, tile, baseColor, tolerance, showpanel);
                    if (!canWalk)
                    {
                        visitedTiles.Remove(tile);
                    }
                    else
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception e) { return false; }
        }

        public List<Tile> GetWalkableTiles(Bitmap map, Tile currentTile, int targetPixelRow, Color baseColor, int tolerance)
        {
            var possibleTiles = new List<Tile>()
            {
                new Tile { X = currentTile.X, Y = currentTile.Y + 1, Parent = currentTile, Cost = currentTile.Cost + 1},
                new Tile { X = currentTile.X - 1, Y = currentTile.Y, Parent = currentTile, Cost = currentTile.Cost + 1 },
                new Tile { X = currentTile.X + 1, Y = currentTile.Y, Parent = currentTile, Cost = currentTile.Cost + 1 },
                new Tile { X = currentTile.X, Y = currentTile.Y - 1, Parent = currentTile, Cost = currentTile.Cost + 1 },
            };

            possibleTiles.ForEach(tile => tile.SetDistance(targetPixelRow));

            var maxX = map.Width;
            var maxY = map.Height;


            return possibleTiles
                    .Where(tile => tile.X >= 0 && tile.X <= maxX)
                    .Where(tile => tile.Y >= 0 && tile.Y <= maxY)
                    .Where(tile => (map.GetPixel(tile.X, tile.Y) == baseColor) || isSameColorWithTolerance(map.GetPixel(tile.X, tile.Y), baseColor, tolerance))
                    .ToList();
        }

        private bool isSameColorWithTolerance(Color c1, Color c2, int tolerance)
        {
            //var tolelanceColor = Color.FromArgb(0, 0, 0, tolerance);
            if (Math.Abs(c1.A - c2.A) <= tolerance && Math.Abs(c1.R - c2.R) <= tolerance && Math.Abs(c1.G - c2.G) <= tolerance && Math.Abs(c1.B - c2.B) <= tolerance)
                return true;
            return false;
        }

        private List<Image> splitImages(Bitmap currentImage, List<Tile> splitArray, Color backgroundColor, int tolerance)
        {
            var imgList = new List<Image>();
            //var secondImage = currentImage.Clone();
            
            var leftImageWidth = splitArray.OrderByDescending(x => x.X).FirstOrDefault().X;
            var rightImageStartX = splitArray.OrderBy(x => x.X).FirstOrDefault().X;

            Bitmap leftImage = new Bitmap(leftImageWidth, currentImage.Height);
            Bitmap rightImage = new Bitmap(currentImage.Width- rightImageStartX, currentImage.Height);

            using (Graphics g = Graphics.FromImage(leftImage))
            {
                g.DrawImage(currentImage, new Rectangle(0, 0, leftImage.Width, leftImage.Height),
                                 new Rectangle(0,0, leftImage.Width, leftImage.Height),
                                 GraphicsUnit.Pixel);
            }

            using (Graphics g = Graphics.FromImage(rightImage))
            {
                g.DrawImage(currentImage, new Rectangle(0, 0, rightImage.Width, rightImage.Height),
                                 new Rectangle(rightImageStartX, 0,currentImage.Width- rightImageStartX,currentImage.Height),
                                 GraphicsUnit.Pixel);
            }

            //Replacing the pixels out of the bounds 

            //for left image
            for(int y = 0; y<leftImage.Height; y++)
            {

                var leftPixelList = splitArray.Where(p => p.Y == y).OrderBy(p => p.X).Where(p => p.X < leftImage.Width);
                if (leftPixelList == null || leftPixelList.Count() == 0) continue;
                var leftPixel = leftPixelList.FirstOrDefault();
                var leftPixelEndAt = leftPixelList.LastOrDefault() == leftPixel? leftImage.Width : leftPixelList.LastOrDefault().X+1;


                for (var x = leftPixel.X; x < leftPixelEndAt; x++)
                {
                    leftImage.SetPixel(x, y, backgroundColor);
                }
            }

            //for right image
            for (int y = 0; y < rightImage.Height; y++)
            {

                var rightPixelList = splitArray.Where(p => p.Y == y).OrderBy(p => p.X).Where(p => p.X >= rightImageStartX);
                if (rightPixelList == null || rightPixelList.Count()==0) continue;
                var rightPixel = rightPixelList.FirstOrDefault();
                var rightPixelEndAt = rightPixelList.LastOrDefault() == rightPixel ? rightImageStartX :rightPixelList.LastOrDefault().X ;

                if (rightPixelEndAt > rightImageStartX)
                {
                    Console.WriteLine();
                }

                for (var x = rightPixelEndAt; x<=rightPixel.X; x++)
                {
                   // if (rightImage.GetPixel(x, y) == backgroundColor || isSameColorWithTolerance(rightImage.GetPixel(x, y), backgroundColor, tolerance)) break;
                    rightImage.SetPixel(x - rightImageStartX, y, backgroundColor);
                }
            }


            foreach(var point in splitArray)
            {
                if(point.X - rightImageStartX >= 0)
                {
                    rightImage.SetPixel(point.X - rightImageStartX, point.Y, backgroundColor);
                }

                if (point.X < leftImageWidth)
                {
                    leftImage.SetPixel(point.X , point.Y, backgroundColor);
                }
            }



            imgList.Add(ImageHelper.CropImage((Image)leftImage, backgroundColor, tolerance));
            imgList.Add(ImageHelper.CropImage((Image)rightImage, backgroundColor, tolerance));

            return imgList;

        }
    }

}
public class Tile
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Cost { get; set; }
    public int Distance { get; set; }
    public int CostDistance => Cost + Distance;
    public Tile Parent { get; set; }

    //The distance is essentially the estimated distance, ignoring walls to our target. 
    //So how many tiles left and right, up and down, ignoring walls, to get there. 
    public void SetDistance(int targetY)//int targetX, int targetY
    {
        this.Distance = Math.Abs(targetY - Y);//Math.Abs(targetX - X) + Math.Abs(targetY - Y);
    }
}
