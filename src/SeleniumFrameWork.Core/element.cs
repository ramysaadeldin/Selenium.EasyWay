using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.EazyWay
{
    public class Element
    {
        public string SetValueElementBy { get; set; } = null;

        public OpenQA.Selenium.By FindElementBy { get; set; }

        public ElementType ElementTypeBy { get; set; }

        public bool RequiredElement { get; set; }

        public Element WaitByAnotherElement { get; set; }

        public int IndexForDropDownList { get; set; }

    }
}
