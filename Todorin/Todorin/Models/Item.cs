using System;
using System.ComponentModel;

namespace Todorin.Models
{
    public class Item
    {
        public int Id { get; set; }
        public bool Checked { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
    }
}