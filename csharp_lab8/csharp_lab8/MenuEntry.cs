using System;
using System.Collections.Generic;
using System.Text;

namespace Laba8
{
    public class MenuEntry
    {
        public Action RelatedAction { get; set; }
        public string Description;

        public MenuEntry(string description, Action relatedAction)
        {
            Description = description;
            RelatedAction = relatedAction;
        }

        public void ExecuteEntry()
        {
            RelatedAction?.Invoke();
        }
    }
}