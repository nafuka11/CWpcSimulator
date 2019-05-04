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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CWpcSimulator
{
	/// <summary>
	/// MainWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MainWindow : Window
	{
		StatusWindow statusWindow;
		CheckBox[] checkBoxArray = new CheckBox[48];

		private readonly int AGE_INDEX;
		private readonly int TALENT_INDEX;
		private readonly int PERSONALITY_INDEX;

		private bool canCalcStatus = true;

		private int checkedBoxCount = 0;

		#region Status変化値
		private readonly List<int[]> statusChange = new List<int[]>
		{
			// 精神的特徴は0.5 -> 1

			// 性別
			new int[] { 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0},		// 男
			new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0},		// 女

			// 年齢
			new int[] { 1, 1, 0, -1, -1, 0, 0, 1, 0, -1, 0},	// 子供
			new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},		// 若者
			new int[] { 0, 0, 0, 0, -1, 0, -1, 0, 0, 1, 0},		// 大人
			new int[] { -1, -1, 1, -1, -1, 1, -1, 0, -1, 1, 1},	// 老人

			// 素質
			new int[] { 0, 0, 0, 0, 0, 1, -1, 0, 0, 1, 0},		// 標準型
			new int[] { 1, 1, 0, 0, 0, -1, 0, 1, 0, 0, 0},		// 万能型
			new int[] { -1, 0, -1, 2, 0, 0, 0, 0, 2, 0, 0},		// 勇将型
			new int[] { -2, -1, -2, 3, 1, -1, 1, 0, 1, -1, 0},	// 豪傑型
			new int[] { 0, 0, 2, -1, -1, 0, 0, 0, 0, 1, 0},		// 知将型
			new int[] { 0, -1, 3, -2, -2, 0, 0, 0, 0, 1, 1},	// 策士型
			new int[] { 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 0},		// 英明型
			new int[] { 0, 1, 0, 3, 2, 0, 1, 0, 1, 0, 0},		// 無双型
			new int[] { 1, 0, 3, 0, 0, 2, 0, 0, 0, 1, 1},		// 天才型
			new int[] { -2, -2, -2, -2, -2, -2, 0, 0, -1, 1, 0},	// 凡庸型
			new int[] { 1, 1, 2, 2, 1, 2, 0, 1, 1, 0, -1},		// 英雄型
			new int[] { 2, 2, 2, 2, 2, 2, 0, 0, 0, 0, 0},		// 神仙型

			// 特性
			new int[] { 0, 0, 0, 0, -1, 0, 0, 1, 0, 0, 0},		// 秀麗
			new int[] { 0, 0, 0, 0, 1, 0, 0, -1, 0, 0, 0},		// 醜悪
			new int[] { 0, 0, 0, 0, 0, 0, -1, 0, 1, 0, 0},		// 高貴の出
			new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 1},		// 下賤の出
			new int[] { 0, 0, 1, 0, -1, 0, 0, 1, 0, 0, 1},		// 都会育ち
			new int[] { 0, -1, 0, 0, 1, 0, 0, 0, 0, 0, -1},		// 田舎育ち
			new int[] { 0, 0, 0, 0, 0, -1, -1, 0, 0, 0, -1},	// 裕福
			new int[] { 0, 0, 0, 0, 0, 1, 1, 0, -1, 0, 0},		// 貧乏
			new int[] { 0, 0, -1, 0, 0, 1, 0, 0, 1, 0, -1},		// 厚き信仰
			new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1},		// 不心得者
			new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, -1},		// 誠実
			new int[] { 0, 0, 0, 0, 0, 0, 0, 0, -1, 0, 1},		// 不実
			new int[] { 0, -1, 1, 0, 0, 0, 0, 0, 0, 1, 1},		// 冷静沈着
			new int[] { 0, 1, 0, 0, 0, -1, 0, 0, 0, -1, 0},		// 猪突猛進
			new int[] { 0, 0, 0, 0, 1, -1, 1, 0, -1, -1, 0},	// 貪欲
			new int[] { 0, 0, 0, 0, 0, 0, -1, 0, 0, 0, 0},		// 無欲
			new int[] { 0, 0, 0, 0, -1, 1, -1, 0, 0, 0, 0},		// 献身的
			new int[] { -1, 1, 0, 0, 0, 0, 1, -1, 0, 0, 1},		// 利己的
			new int[] { 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, -1},		// 秩序派
			new int[] { 0, 0, 0, 1, 0, -1, 1, 0, 0, 0, 1},		// 混沌派
			new int[] { 0, 1, 0, 0, -1, 0, 0, 0, 1, -1, 0},		// 進取派
			new int[] { 0, 0, 0, -1, 0, 1, -1, 0, 0, 1, 0},		// 保守派
			new int[] { 0, 1, 0, -1, 0, 0, 0, -1, 0, 1, 0},		// 神経質
			new int[] { 0, 0, -1, 0, 1, 0, 0, 0, 0, 0, 0},		// 鈍感

			new int[] { 1, 0, 0, 0, -1, 0, 0, 0, 0, 0, 0},		// 好奇心旺盛
			new int[] { 0, -1, 0, 0, 0, 1, 0, -1, 0, 0, 0},		// 無頓着
			new int[] { 0, 0, 0, 1, -1, 0, 1, 0, 0, -1, 0},		// 過激
			new int[] { 0, 0, 0, 0, 0, 0, -1, 0, 0, 1, 0},		// 穏健
			new int[] { 1, -1, 0, 0, 0, 0, 0, 0, 1, -1, 0},		// 楽観的
			new int[] { 0, 0, 1, 0, 0, -1, 0, 0, -1, 1, 0},		// 悲観的
			new int[] { -1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0},		// 勤勉
			new int[] { 1, 0, -1, 0, 0, 0, 0, 1, 0, 0, 1},		// 遊び人
			new int[] { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0},		// 陽気
			new int[] { 0, 0, 0, 0, 0, 0, 0, 0, -1, 0, 0},		// 内気
			new int[] { 0, 1, -1, 0, 0, 0, 0, 1, 0, -1, 0},		// 派手
			new int[] { 0, 0, 0, -1, 1, 0, 0, 0, -1, 0, 0},		// 地味
			new int[] { -1, 0, 0, 0, 0, 1, 1, -1, 0, 0, 0},		// 高慢
			new int[] { -1, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0},		// 謙虚
			new int[] { 0, 0, 1, -1, 0, 0, -1, 1, 0, 0, 0},		// 上品
			new int[] { 0, 0, -1, 1, 0, 0, 1, -1, 0, 0, 0},		// 粗野
			new int[] { -1, 0, 0, 1, 0, 0, 0, -1, 1, 0, 0},		// 武骨
			new int[] { 1, 0, 0, -1, 0, 0, 0, 0, -1, 1, 0},		// 繊細
			new int[] { 0, -1, 0, 1, 0, 0, 0, 0, 1, 0, -1},		// 硬派
			new int[] { 1, 0, 0, 0, 0, -1, 0, 1, -1, 0, 0},		// 軟派
			new int[] { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, -1},		// お人好し
			new int[] { 0, 0, 0, 0, 0, 0, 0, -1, 0, 0, 0},		// ひねくれ者
			new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 1, -1, -1},		// 名誉こそ命
			new int[] { 0, 0, 0, 0, 0, 0, -1, 0, 0, 0, 0}		// 愛に生きる
		};
		#endregion

		public MainWindow()
		{
			InitializeComponent();

			#region CheckBoxArrayの設定
			checkBoxArray[0] = checkBox1;
			checkBoxArray[1] = checkBox2;
			checkBoxArray[2] = checkBox3;
			checkBoxArray[3] = checkBox4;
			checkBoxArray[4] = checkBox5;
			checkBoxArray[5] = checkBox6;
			checkBoxArray[6] = checkBox7;
			checkBoxArray[7] = checkBox8;
			checkBoxArray[8] = checkBox9;
			checkBoxArray[9] = checkBox10;
			checkBoxArray[10] = checkBox11;
			checkBoxArray[11] = checkBox12;
			checkBoxArray[12] = checkBox13;
			checkBoxArray[13] = checkBox14;
			checkBoxArray[14] = checkBox15;
			checkBoxArray[15] = checkBox16;
			checkBoxArray[16] = checkBox17;
			checkBoxArray[17] = checkBox18;
			checkBoxArray[18] = checkBox19;
			checkBoxArray[19] = checkBox20;
			checkBoxArray[20] = checkBox21;
			checkBoxArray[21] = checkBox22;
			checkBoxArray[22] = checkBox23;
			checkBoxArray[23] = checkBox24;
			checkBoxArray[24] = checkBox25;
			checkBoxArray[25] = checkBox26;
			checkBoxArray[26] = checkBox27;
			checkBoxArray[27] = checkBox28;
			checkBoxArray[28] = checkBox29;
			checkBoxArray[29] = checkBox30;
			checkBoxArray[30] = checkBox31;
			checkBoxArray[31] = checkBox32;
			checkBoxArray[32] = checkBox33;
			checkBoxArray[33] = checkBox34;
			checkBoxArray[34] = checkBox35;
			checkBoxArray[35] = checkBox36;
			checkBoxArray[36] = checkBox37;
			checkBoxArray[37] = checkBox38;
			checkBoxArray[38] = checkBox39;
			checkBoxArray[39] = checkBox40;
			checkBoxArray[40] = checkBox41;
			checkBoxArray[41] = checkBox42;
			checkBoxArray[42] = checkBox43;
			checkBoxArray[43] = checkBox44;
			checkBoxArray[44] = checkBox45;
			checkBoxArray[45] = checkBox46;
			checkBoxArray[46] = checkBox47;
			checkBoxArray[47] = checkBox48;
			#endregion

			AGE_INDEX = comboSex.Items.Count;
			TALENT_INDEX = AGE_INDEX + comboAge.Items.Count;
			PERSONALITY_INDEX = TALENT_INDEX + comboTalent.Items.Count;

			this.statusWindow = new StatusWindow();

			this.Loaded +=new RoutedEventHandler(MainWindow_Loaded);
			this.buttonReset.Click += new RoutedEventHandler(buttonReset_Click);
			this.buttonStatus.Click += new RoutedEventHandler(buttonStatus_Click);
			foreach (CheckBox cb in checkBoxArray)
			{
				cb.Checked += new RoutedEventHandler(checkBox_CheckedChanged);
				cb.Unchecked += new RoutedEventHandler(checkBox_UnCheckedChanged);
			}

			comboSex.SelectedIndex = 0;
			comboTalent.SelectedIndex = 0;
			this.comboSex.SelectionChanged += new SelectionChangedEventHandler(comboBox_SelectionChanged);
			this.comboAge.SelectionChanged += new SelectionChangedEventHandler(comboAge_SelectionChanged);
			this.comboTalent.SelectionChanged += new SelectionChangedEventHandler(comboTalent_SelectionChanged);
			comboAge.SelectedIndex = 1;
			// groupPersonality.Header = "特性 (" + checkedBoxCount.ToString() + ")";
		}

		private void MainWindow_Loaded(object sender, RoutedEventArgs e)
		{
			statusWindow.Owner = this;
			if (this.Left + this.Width + statusWindow.Width < System.Windows.SystemParameters.PrimaryScreenWidth)
			{
				statusWindow.Left = this.Left + this.Width;
			}
			else
			{
				statusWindow.Left = this.Left - statusWindow.Width;
			}
			statusWindow.Top = this.Top;
			statusWindow.Show();
		}

		private void buttonStatus_Click(object sender, RoutedEventArgs e)
		{
			if (statusWindow.IsVisible)
			{
				statusWindow.Hide();
			}
			else
			{
				if (this.Left + this.Width + statusWindow.Width < System.Windows.SystemParameters.PrimaryScreenWidth)
				{
					statusWindow.Left = this.Left + this.Width;
				}
				else
				{
					statusWindow.Left = this.Left - statusWindow.Width;
				}
				statusWindow.Top = this.Top;
				statusWindow.Show();
			}
		}

		private void buttonReset_Click(object sender, RoutedEventArgs e)
		{
			comboSex.SelectedIndex = 0;
			comboAge.SelectedIndex = 1;
			comboTalent.SelectedIndex = 0;

			canCalcStatus = false;
			foreach (CheckBox cb in checkBoxArray)
			{
				cb.IsChecked = false;
			}
			canCalcStatus = true;

			CalcStatus();
		}

		private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			CalcStatus();
		}

		private void comboAge_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			switch (comboAge.SelectedIndex)
			{
				// 大人・老人
				case 2:
				case 3:
					statusWindow.Status.MinLv = 2;
					break;
				default:
					statusWindow.Status.MinLv = 1;
					if (statusWindow.Status.Lv == 2)
					{
						statusWindow.Status.Lv = 1;
					}
					break;
			}
			CalcStatus();
		}

		private void comboTalent_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			switch (comboTalent.SelectedIndex)
			{
				case 9:
				case 10:
					statusWindow.Status.MaxLv = 12;
					break;
				case 11:
					statusWindow.Status.MaxLv = 15;
					break;
				default:
					statusWindow.Status.MaxLv = 10;
					break;
			}
			CalcStatus();
		}	

		private void checkBox_CheckedChanged(object sender, RoutedEventArgs e)
		{
			checkedBoxCount += 1;
			groupPersonality.Header = "特性 (" + checkedBoxCount.ToString() + ")";

			CalcStatus();
		}

		private void checkBox_UnCheckedChanged(object sender, RoutedEventArgs e)
		{
			checkedBoxCount -= 1;
			groupPersonality.Header = "特性 (" + checkedBoxCount.ToString() + ")";

			CalcStatus();
		}

		// ステータスを再計算する
		private void CalcStatus()
		{
			if (!canCalcStatus || comboSex.SelectedIndex < 0 || comboAge.SelectedIndex < 0 || comboTalent.SelectedIndex < 0)
			{
				return;
			}

			int[] tmpSt = new int[] { 6, 6, 6, 6, 6, 6, 0, 0, 0, 0, 0 };

			AddIntArray(tmpSt, statusChange[comboSex.SelectedIndex]);
			AddIntArray(tmpSt, statusChange[comboAge.SelectedIndex + AGE_INDEX]);
			AddIntArray(tmpSt, statusChange[comboTalent.SelectedIndex + TALENT_INDEX]);

			for (int i = 0; i < checkBoxArray.Length; i++)
			{
				if (checkBoxArray[i].IsChecked == true)
				{
					AddIntArray(tmpSt, statusChange[i + PERSONALITY_INDEX]);
				}
			}

			statusWindow.Status.SetStatus(tmpSt);
		}

		private void AddIntArray(int[] array, int[] addArray)
		{
			if (array.Length != addArray.Length)
			{
				return;
			}
			for (int i = 0; i < array.Length; i++)
			{
				array[i] += addArray[i];
			}
		}

		// 引数の省略はC#4.0から
		public void SetControlColors(StatusType type)
		{
			for (int i = 0; i < statusChange.Count; i++)
			{
				int st;
				if (type == StatusType.none)
				{
					st = 0;
				}
				else
				{
					st = statusChange[i][Math.Abs((int)type)];
					if ((int)type < 0)
					{
						st = -st;
					}
				}

				Color color;

				if (st > 0)
				{
					color = Colors.RoyalBlue;
				}
				else if (st < 0)
				{
					color = Colors.Crimson;
				}
				else
				{
					color = Colors.Black;
				}

				if (i < AGE_INDEX)
				{
					((ComboBoxItem)comboSex.Items[i]).Foreground = new SolidColorBrush(color);
				}
				else if (i >= AGE_INDEX && i < TALENT_INDEX)
				{
					((ComboBoxItem)comboAge.Items[i - AGE_INDEX]).Foreground = new SolidColorBrush(color);
				}
				else if (i >= TALENT_INDEX && i < PERSONALITY_INDEX)
				{
					((ComboBoxItem)comboTalent.Items[i - TALENT_INDEX]).Foreground = new SolidColorBrush(color);
				}
				else
				{
					checkBoxArray[i - PERSONALITY_INDEX].Foreground = new SolidColorBrush(color);
				}
			}
		}
	}
}
