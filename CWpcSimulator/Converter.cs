using System;
using System.Windows.Data;		//IMultiValueConverter
using System.Globalization;		//CultureInfo
using System.Windows.Media;		//Color


namespace CWpcSimulator
{
	public class HPConverter : IMultiValueConverter
	{
		// 生命
		// 精神
		// Lv	の順
		public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo info)
		{
			if (!(values[0] is Int32) || !(values[1] is Int32))
			{
				return Binding.DoNothing;
			}
			int vit = (int)values[0];
			int wil = (int)values[1];
			int lv = (int)values[2];
			return ((vit / 2 + 4) * (lv + 1) + wil / 2).ToString();

			//int vit, wil, lv;

			//if (!Int32.TryParse((string)values[0], out vit) || !Int32.TryParse((string)values[1], out wil) || !Int32.TryParse((string)values[2], out lv))
			//{
			//    return Binding.DoNothing;
			//}

			//return ((vit / 2 + 4) * (lv + 1) + wil / 2).ToString();
		}

		public object[] ConvertBack(object value, Type[] targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}

	}

	// 技能適正に応じてセルのFore/Backgroundを変更
	// parameter：Fore/Back
	public class CellColorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo info)
		{
			if (value == null)
			{
				return Binding.DoNothing;
			}
			int i = (int)value;
			if ((string)parameter == "Back")
			{
				if (i >= 15)
				{
					return new SolidColorBrush(Color.FromRgb(255, 255, 255));
				}
				else if (i >= 9)
				{
					return new SolidColorBrush(Color.FromRgb(0xD5, 0xEA, 0xD8));
				}
				else if (i >= 3)
				{
					return new SolidColorBrush(Color.FromRgb(0x69, 0xBD, 0x83));
				}
				else
				{
					return new SolidColorBrush(Color.FromRgb(42, 123, 85));
				}
			}
			else
			{
				if (i >= 3)
				{
					return new SolidColorBrush(Color.FromRgb(0, 0, 0));
				}
				else
				{
					return new SolidColorBrush(Color.FromRgb(0xD5, 0xEA, 0xD8));
				}
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}

	//public class ReverseBoolConverter : IValueConverter
	//{
	//    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo info)
	//    {
	//        return !(bool)value;
	//    }

	//    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
	//    {
	//        throw new NotImplementedException();
	//    }
	//}

	public enum StatusType
	{
		器用度,
		敏捷度,
		知力,
		筋力,
		生命力,
		精神力,

		好戦,
		陽気,
		勇敢,
		慎重,
		狡猾,

		温厚 = -6,
		内気 = -7,
		臆病 = -8,
		大胆 = -9,
		正直 = -10,

		none = -99
	}
}

