using System;
using System.ComponentModel;
﻿using SQLite;
using System.Drawing;

namespace Todorin.Models
{
    public class Item
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public bool Checked { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
		public Color TintColor { get; set; }

        public Color CurrentColor
		{
			get
			{
				return Checked ? Color.Gray : TintColor;
			}
		}
	}
}