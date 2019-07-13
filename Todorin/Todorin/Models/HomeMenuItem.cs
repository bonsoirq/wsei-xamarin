using System;
using System.Collections.Generic;
using System.Text;

namespace Todorin.Models
{
    public enum MenuItemType
    {
        Tasks,
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
