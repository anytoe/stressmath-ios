using System;
using System.Collections.Generic;
using UIKit;
using Foundation;

namespace MathSpeedChallenge
{
	public class GameButtonSource: UICollectionViewSource
	{
		public GameButtonSource () : base ()
		{
			Rows = new List<string> ();
			Rows.Add ("Button 1");
			Rows.Add ("Button 2");
		}

		public List<string> Rows { get; private set; }


		public override nint NumberOfSections (UICollectionView collectionView)
		{
			return 1;
		}

		public override nint GetItemsCount (UICollectionView collectionView, nint section)
		{
			return Rows.Count;
		}

		//		public override Int32 NumberOfSections(UICollectionView collectionView)
		//		{
		//			return 1;
		//		}
		//
		//		public override Int32 GetItemsCount(UICollectionView collectionView, Int32 section)
		//		{
		//			return Rows.Count;
		//		}

		public override Boolean ShouldHighlightItem (UICollectionView collectionView, NSIndexPath indexPath)
		{
			return false;
		}

		public override void ItemHighlighted (UICollectionView collectionView, NSIndexPath indexPath)
		{
			// nothing to do
		}

		public override void ItemUnhighlighted (UICollectionView collectionView, NSIndexPath indexPath)
		{
			// nothing to do
		}

		public override UICollectionViewCell GetCell (UICollectionView collectionView, NSIndexPath indexPath)
		{
			var cell = (GameButtonCell)collectionView.DequeueReusableCell (GameButtonCell.Key, indexPath);
//			if (cell == null) {
//				cell = GameButtonCell.Create ();
//			}
//
//			string buttonText = Rows [indexPath.Row];
//
//			cell.Text = buttonText;
			return cell;
		}
	}
}

