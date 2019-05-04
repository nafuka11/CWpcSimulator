using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ComponentModel;	//INotifyPropertyChanged
using System.Collections.ObjectModel;	//ObservableCollection

namespace CWpcSimulator
{
	/// <summary>
	/// ShowStatus.xaml の相互作用ロジック
	/// </summary>
	public partial class StatusWindow : Window
	{
		private StatusType _focusedStatus = StatusType.none;
		public StatusData Status { get; private set; }

		public StatusWindow()
		{
			InitializeComponent();

			Status = new StatusData();
			this.DataContext = Status;
			this.Closing += new CancelEventHandler(StatusWindow_Closing);
			buttonDex.Click += new RoutedEventHandler(buttonDex_Click);
			buttonAgi.Click += new RoutedEventHandler(buttonAgi_Click);
			buttonInt.Click += new RoutedEventHandler(buttonInt_Click);
			buttonStr.Click += new RoutedEventHandler(buttonStr_Click);
			buttonVit.Click += new RoutedEventHandler(buttonVit_Click);
			buttonWil.Click += new RoutedEventHandler(buttonWil_Click);
			buttonWarlike1.Click += new RoutedEventHandler(buttonWarlike1_Click);
			buttonWarlike2.Click += new RoutedEventHandler(buttonWarlike2_Click);
			buttonSociability1.Click += new RoutedEventHandler(buttonSociability1_Click);
			buttonSociability2.Click += new RoutedEventHandler(buttonSociability2_Click);
			buttonBrave1.Click += new RoutedEventHandler(buttonBrave1_Click);
			buttonBrave2.Click += new RoutedEventHandler(buttonBrave2_Click);
			buttonPrudence1.Click += new RoutedEventHandler(buttonPrudence1_Click);
			buttonPrudence2.Click += new RoutedEventHandler(buttonPrudence2_Click);
			buttonCunning1.Click += new RoutedEventHandler(buttonCunning1_Click);
			buttonCunning2.Click += new RoutedEventHandler(buttonCunning2_Click);
		}

		private void buttonDex_Click(object sender, RoutedEventArgs e)
		{
			SetFocusedColor(StatusType.器用度);
		}

		private void buttonAgi_Click(object sender, RoutedEventArgs e)
		{
			SetFocusedColor(StatusType.敏捷度);
		}

		private void buttonInt_Click(object sender, RoutedEventArgs e)
		{
			SetFocusedColor(StatusType.知力);
		}

		private void buttonStr_Click(object sender, RoutedEventArgs e)
		{
			SetFocusedColor(StatusType.筋力);
		}

		private void buttonVit_Click(object sender, RoutedEventArgs e)
		{
			SetFocusedColor(StatusType.生命力);
		}

		private void buttonWil_Click(object sender, RoutedEventArgs e)
		{
			SetFocusedColor(StatusType.精神力);
		}

		private void buttonWarlike1_Click(object sender, RoutedEventArgs e)
		{
			SetFocusedColor(StatusType.好戦);
		}

		private void buttonWarlike2_Click(object sender, RoutedEventArgs e)
		{
			SetFocusedColor(StatusType.温厚);
		}

		private void buttonSociability1_Click(object sender, RoutedEventArgs e)
		{
			SetFocusedColor(StatusType.陽気);
		}

		private void buttonSociability2_Click(object sender, RoutedEventArgs e)
		{
			SetFocusedColor(StatusType.内気);
		}

		private void buttonBrave1_Click(object sender, RoutedEventArgs e)
		{
			SetFocusedColor(StatusType.勇敢);
		}

		private void buttonBrave2_Click(object sender, RoutedEventArgs e)
		{
			SetFocusedColor(StatusType.臆病);
		}

		private void buttonPrudence1_Click(object sender, RoutedEventArgs e)
		{
			SetFocusedColor(StatusType.慎重);
		}

		private void buttonPrudence2_Click(object sender, RoutedEventArgs e)
		{
			SetFocusedColor(StatusType.大胆);
		}

		private void buttonCunning1_Click(object sender, RoutedEventArgs e)
		{
			SetFocusedColor(StatusType.狡猾);
		}

		private void buttonCunning2_Click(object sender, RoutedEventArgs e)
		{
			SetFocusedColor(StatusType.正直);
		}

		private void StatusWindow_Closing(object sender, CancelEventArgs e)
		{
			e.Cancel = true;
			this.Hide();
		}

		private void SetFocusedColor(StatusType type)
		{
			if (_focusedStatus == type)
			{
				_focusedStatus = StatusType.none;
			}
			else
			{
				_focusedStatus = type;
			}

			// SetButtonColors
			Color foreColor = Colors.Black;
			buttonDex.Foreground = new SolidColorBrush(foreColor);
			buttonAgi.Foreground = new SolidColorBrush(foreColor);
			buttonInt.Foreground = new SolidColorBrush(foreColor);
			buttonStr.Foreground = new SolidColorBrush(foreColor);
			buttonVit.Foreground = new SolidColorBrush(foreColor);
			buttonWil.Foreground = new SolidColorBrush(foreColor);
			buttonWarlike1.Foreground = new SolidColorBrush(foreColor);
			buttonWarlike2.Foreground = new SolidColorBrush(foreColor);
			buttonSociability1.Foreground = new SolidColorBrush(foreColor);
			buttonSociability2.Foreground = new SolidColorBrush(foreColor);
			buttonBrave1.Foreground = new SolidColorBrush(foreColor);
			buttonBrave2.Foreground = new SolidColorBrush(foreColor);
			buttonPrudence1.Foreground = new SolidColorBrush(foreColor);
			buttonPrudence2.Foreground = new SolidColorBrush(foreColor);
			buttonCunning1.Foreground = new SolidColorBrush(foreColor);
			buttonCunning2.Foreground = new SolidColorBrush(foreColor);

			foreColor = Colors.RoyalBlue;
			switch (_focusedStatus)
			{
				case StatusType.器用度:
					buttonDex.Foreground = new SolidColorBrush(foreColor);
					break;
				case StatusType.敏捷度:
					buttonAgi.Foreground = new SolidColorBrush(foreColor);
					break;
				case StatusType.知力:
					buttonInt.Foreground = new SolidColorBrush(foreColor);
					break;
				case StatusType.筋力:
					buttonStr.Foreground = new SolidColorBrush(foreColor);
					break;
				case StatusType.生命力:
					buttonVit.Foreground = new SolidColorBrush(foreColor);
					break;
				case StatusType.精神力:
					buttonWil.Foreground = new SolidColorBrush(foreColor);
					break;
				case StatusType.好戦:
					buttonWarlike1.Foreground = new SolidColorBrush(foreColor);
					break;
				case StatusType.温厚:
					buttonWarlike2.Foreground = new SolidColorBrush(foreColor);
					break;
				case StatusType.陽気:
					buttonSociability1.Foreground = new SolidColorBrush(foreColor);
					break;
				case StatusType.内気:
					buttonSociability2.Foreground = new SolidColorBrush(foreColor);
					break;
				case StatusType.勇敢:
					buttonBrave1.Foreground = new SolidColorBrush(foreColor);
					break;
				case StatusType.臆病:
					buttonBrave2.Foreground = new SolidColorBrush(foreColor);
					break;
				case StatusType.慎重:
					buttonPrudence1.Foreground = new SolidColorBrush(foreColor);
					break;
				case StatusType.大胆:
					buttonPrudence2.Foreground = new SolidColorBrush(foreColor);
					break;
				case StatusType.狡猾:
					buttonCunning1.Foreground = new SolidColorBrush(foreColor);
					break;
				case StatusType.正直:
					buttonCunning2.Foreground = new SolidColorBrush(foreColor);
					break;
			}
			((MainWindow)Owner).SetControlColors(_focusedStatus);
		}
		
	}


	public class StatusData : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		private int _dex;
		private int _agi;
		private int _int;
		private int _str;
		private int _vit;
		private int _wil;

		private int _warlike;
		private int _sociability;
		private int _brave;
		private int _prudence;
		private int _cunning;

		private int _lv = 1;
		private int _maxLv = 10;
		private int _minLv = 1;
		private ReadOnlyObservableCollection<SkillAptitude> _skillList;

		public int Dex
		{
			get { return _dex; }
			private set
			{
				if (value == _dex)
				{
					return;
				}
				_dex = value;
				OnPropertyChanged("Dex");
			}
		}

		public int Agi
		{
			get { return _agi; }
			private set
			{
				if (value == _agi)
				{
					return;
				}
				_agi = value;
				OnPropertyChanged("Agi");
			}
		}

		public int Int
		{
			get { return _int; }
			private set
			{
				if (value == _int)
				{
					return;
				}
				_int = value;
				OnPropertyChanged("Int");
			}
		}

		public int Str
		{
			get { return _str; }
			private set
			{
				if (value == _str)
				{
					return;
				}
				_str = value;
				OnPropertyChanged("Str");
			}
		}

		public int Vit
		{
			get { return _vit; }
			private set
			{
				if (value == _vit)
				{
					return;
				}
				_vit = value;
				OnPropertyChanged("Vit");
			}
		}

		public int Wil
		{
			get { return _wil; }
			private set
			{
				if (value == _wil)
				{
					return;
				}
				_wil = value;
				OnPropertyChanged("Wil");
			}
		}

		public int Warlike
		{
			get { return _warlike; }
			private set
			{
				if (value == _warlike)
				{
					return;
				}
				_warlike = value;
				OnPropertyChanged("Warlike");
			}
		}

		public int Sociability
		{
			get { return _sociability; }
			private set
			{
				if (value == _sociability)
				{
					return;
				}
				_sociability = value;
				OnPropertyChanged("Sociability");
			}
		}

		public int Brave
		{
			get { return _brave; }
			private set
			{
				if (value == _brave)
				{
					return;
				}
				_brave = value;
				OnPropertyChanged("Brave");
			}
		}

		public int Prudence
		{
			get { return _prudence; }
			private set
			{
				if (value == _prudence)
				{
					return;
				}
				_prudence = value;
				OnPropertyChanged("Prudence");
			}
		}

		public int Cunning
		{
			get { return _cunning; }
			private set
			{
				if (value == _cunning)
				{
					return;
				}
				_cunning = value;
				OnPropertyChanged("Cunning");
			}
		}

		public int Lv
		{
			get { return _lv; }
			set
			{
				if (value == _lv)
				{
					return;
				}
				_lv = value;
				OnPropertyChanged("Lv");
			}
		}

		public int MaxLv
		{
			get { return _maxLv; }
			set
			{
				if (value == _maxLv)
				{
					return;
				}
				_maxLv = value;
				OnPropertyChanged("MaxLv");
				if (Lv > MaxLv)
				{
					Lv = MaxLv;
				}
			}
		}

		public int MinLv
		{
			get { return _minLv; }
			set
			{
				if (value == _minLv)
				{
					return;
				}
				_minLv = value;
				OnPropertyChanged("MinLv");
				if (Lv < MinLv)
				{
					Lv = MinLv;
				}
			}
		}

		public ReadOnlyObservableCollection<SkillAptitude> SkillList
		{
			get { return _skillList; }
			private set
			{
				if (_skillList != value)
				{
					_skillList = value;
					OnPropertyChanged("SkillList");
				}
			}
		}

		public StatusData()
		{
			var list = new ObservableCollection<SkillAptitude>
	        {
	            new SkillAptitude("器用"),
	            new SkillAptitude("敏捷"),
	            new SkillAptitude("知力"),
	            new SkillAptitude("筋力"),
	            new SkillAptitude("生命"),
	            new SkillAptitude("精神")
	        };

			_skillList = new ReadOnlyObservableCollection<SkillAptitude>(list);
		}

		public void SetStatus(int[] array)
		{
			if (array.Length < 11)
			{
				return;
			}
			Dex = ConvertPhysicalStatus(array[0]);
			Agi = ConvertPhysicalStatus(array[1]);
			Int = ConvertPhysicalStatus(array[2]);
			Str = ConvertPhysicalStatus(array[3]);
			Vit = ConvertPhysicalStatus(array[4]);
			Wil = ConvertPhysicalStatus(array[5]);
			Warlike = ConvertMentalStatus(array[6]);
			Sociability = ConvertMentalStatus(array[7]);
			Brave = ConvertMentalStatus(array[8]);
			Prudence = ConvertMentalStatus(array[9]);
			Cunning = ConvertMentalStatus(array[10]);

			// SetSkill
			// 技能適正にも能力の変化を適応する
			SkillList[0].SetAptitude(Dex, Warlike, Sociability, Brave, Prudence, Cunning);
			SkillList[1].SetAptitude(Agi, Warlike, Sociability, Brave, Prudence, Cunning);
			SkillList[2].SetAptitude(Int, Warlike, Sociability, Brave, Prudence, Cunning);
			SkillList[3].SetAptitude(Str, Warlike, Sociability, Brave, Prudence, Cunning);
			SkillList[4].SetAptitude(Vit, Warlike, Sociability, Brave, Prudence, Cunning);
			SkillList[5].SetAptitude(Wil, Warlike, Sociability, Brave, Prudence, Cunning);
		}

		public static int ConvertPhysicalStatus(int st)
		{
			if (st < 1)
			{
				return 1;
			}
			if (st > 12)
			{
				return 12;
			}
			return st;
		}

		public static int ConvertMentalStatus(int st)
		{
			int status = (int)(Math.Truncate(st / 2.0));

			// どちらがいいかわかりかねる
			//if (Math.Abs(status) > 4)
			//{
			//    return Math.Sign(status) > 0 ? 4 : -4;
			//}

			if (status > 4)
			{
				return 4;
			}
			if (status < -4)
			{
				return -4;
			}
			return status;
		}

		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler handler = this.PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}

	public class SkillAptitude : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public string Header { get; private set; }
		private int _warlike1;		// 好戦性
		private int _warlike2;		// 平和性
		private int _sociability1;
		private int _sociability2;
		private int _brave1;
		private int _brave2;
		private int _prudence1;
		private int _prudence2;
		private int _cunning1;
		private int _cunning2;

		public int Warlike1
		{
			get { return _warlike1; }
			private set
			{
				if (_warlike1 != value)
				{
					_warlike1 = value;
					OnPropertyChanged("Warlike1");
				}
			}
		}

		public int Warlike2
		{
			get { return _warlike2; }
			private set
			{
				if (_warlike2 != value)
				{
					_warlike2 = value;
					OnPropertyChanged("Warlike2");
				}
			}
		}

		public int Sociability1
		{
			get { return _sociability1; }
			private set
			{
				if (_sociability1 != value)
				{
					_sociability1 = value;
					OnPropertyChanged("Sociability1");
				}
			}
		}

		public int Sociability2
		{
			get { return _sociability2; }
			private set
			{
				if (_sociability2 != value)
				{
					_sociability2 = value;
					OnPropertyChanged("Sociability2");
				}
			}
		}

		public int Brave1
		{
			get { return _brave1; }
			private set
			{
				if (_brave1 != value)
				{
					_brave1 = value;
					OnPropertyChanged("Brave1");
				}
			}
		}

		public int Brave2
		{
			get { return _brave2; }
			private set
			{
				if (_brave2 != value)
				{
					_brave2 = value;
					OnPropertyChanged("Brave2");
				}
			}
		}

		public int Prudence1
		{
			get { return _prudence1; }
			private set
			{
				if (_prudence1 != value)
				{
					_prudence1 = value;
					OnPropertyChanged("Prudence1");
				}
			}
		}

		public int Prudence2
		{
			get { return _prudence2; }
			private set
			{
				if (_prudence2 != value)
				{
					_prudence2 = value;
					OnPropertyChanged("Prudence2");
				}
			}
		}

		public int Cunning1
		{
			get { return _cunning1; }
			private set
			{
				if (_cunning1 != value)
				{
					_cunning1 = value;
					OnPropertyChanged("Cunning1");
				}
			}
		}

		public int Cunning2
		{
			get { return _cunning2; }
			private set
			{
				if (_cunning2 != value)
				{
					_cunning2 = value;
					OnPropertyChanged("Cunning2");
				}
			}
		}

		public SkillAptitude(string header)
		{
			Header = header;
		}

		// 技能適正(身体的特徴 + 精神的特徴)を計算する
		public void SetAptitude(int physicalStatus, int warlike, int sociability, int brave, int prudence, int cunning)
		{
			Warlike1 = physicalStatus + warlike;
			Sociability1 = physicalStatus + sociability;
			Brave1 = physicalStatus + brave;
			Prudence1 = physicalStatus + prudence;
			Cunning1 = physicalStatus + cunning;

			Warlike2 = physicalStatus - warlike;
			Sociability2 = physicalStatus - sociability;
			Brave2 = physicalStatus - brave;
			Prudence2 = physicalStatus - prudence;
			Cunning2 = physicalStatus - cunning;
		}

		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler handler = this.PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
