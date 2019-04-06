using System;
using System.Windows.Forms;
using System.Drawing;
using Minesweeper.Resources;
using Minesweeper.Extensions;

namespace Minesweeper.Components
{
	public class MineLabel : Label
	{
		private int _value;

		protected bool SuppressTextChange { get; set; }

		protected Font GetDigital7Font(float emSize)
		{
			return new Font(FontProvider.Digital7, emSize);
		}

		protected virtual void OnValueChanged(object sender, EventArgs e)
		{
			if (ValueChanged != null)
			{
				ValueChanged(sender, e);
			}
		}

		public event EventHandler ValueChanged;

		public override string Text
		{
			get
			{
				return Value.ToString().PadLeft(3, '0');
			}
			
			set
			{
				int param;
				int.TryParse(value, out param);
				_value = param;
				OnTextChanged(null);
				OnValueChanged(this, null);
			}
		}

		public int Value
		{
			get
			{
				return _value;
			}

			set
			{
				if (value >= 0 && value <= 999)
				{
					_value = value;
				}

				OnTextChanged(null);
				OnValueChanged(this, null);
			}
		}

		public MineLabel()
		{
			this.StyleChanged += new EventHandler(OnStyleChanged);
			this.FontChanged +=new EventHandler(OnStyleChanged);
			this.BackColorChanged += new EventHandler(OnStyleChanged);
			this.ForeColorChanged += new EventHandler(OnStyleChanged);
			OnStyleChanged(this, null);
		}

		void OnStyleChanged(object sender, EventArgs e)
		{
			this.BackColor = Color.Black;
			this.ForeColor = Color.Red;
			this.Font = new System.Drawing.Font(FontProvider.LcdDot, this.Font.Size);
			this.AutoSize = false;
		}
	}
}
