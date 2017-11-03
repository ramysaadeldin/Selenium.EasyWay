using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Selenium.EazyWay
{
    public static class Driver
    {
        public static bool addOnlyRequiredData = false;
        public static TimeSpan theWaitTime = TimeSpan.FromMinutes(1);
        public static void LoadPage<T>(this IWebDriver source, T input, TimeSpan? waitTime = null, bool requiredDataOnly = false) where T : Page
        {
            addOnlyRequiredData = requiredDataOnly;
            if (waitTime.HasValue)
            {
                theWaitTime = waitTime.Value;
            }
            WebDriverWait wait = new WebDriverWait(source, theWaitTime);

            // check found pageLocation
            if (input.PageLocation != null)
            {
                // if found element must wait
                if (input.PageLocation.WaitByAnotherElement != null)
                {
                    // found find Element
                    if (input.PageLocation.WaitByAnotherElement.FindElementBy != null)
                    {
                        wait.Until<IWebElement>((ctx) =>
                        {
                            IWebElement element = ctx.FindElement(input.PageLocation.WaitByAnotherElement.FindElementBy);
                            return (element.Enabled == true && element.Displayed == true) ? element : null;
                        });
                    }

                }

                // if button is number
                if (input.PageLocation.ElementTypeBy == ElementType.Button)
                {
                    var button = source.FindElement(input.PageLocation.FindElementBy);
                    if (button != null)
                    {
                        IJavaScriptExecutor executor = (IJavaScriptExecutor)source;
                        executor.ExecuteScript("arguments[0].click();", button);
                    }
                }

            }

            // check element in page not null
            if (input.PageElement != null && input.PageElement.Count > 0)
            {

                foreach (var item in input.PageElement)
                {
                    if (addOnlyRequiredData)
                    {
                        if (item.RequiredElement == false)
                        {
                            break;
                        }
                    }

                    // check if required 
                    if (item.WaitByAnotherElement != null)
                    {
                        // found find Element
                        if (item.WaitByAnotherElement.FindElementBy != null)
                        {
                            wait.Until<IWebElement>((ctx) =>
                            {
                                IWebElement element = ctx.FindElement(item.WaitByAnotherElement.FindElementBy);
                                return (element.Enabled == true && element.Displayed == true) ? element : null;
                            });
                        }

                    }


                    // begin Set Value To web element
                
                    if (item.ElementTypeBy == ElementType.Button || item.ElementTypeBy == ElementType.Link)
                    {
                        var button = source.FindElement(item.FindElementBy);
                        if (button != null)
                        {
                            IJavaScriptExecutor executor = (IJavaScriptExecutor)source;
                            executor.ExecuteScript("arguments[0].click();", button);
                        }
                    }
                    else if (item.ElementTypeBy == ElementType.TextBox)
                    {
                        if (item.SetValueElementBy != null)
                        {
                            source.FindElement(item.FindElementBy)?.SendKeys(item.SetValueElementBy);
                        }

                    }
                    else if (item.ElementTypeBy == ElementType.RadioButton || item.ElementTypeBy == ElementType.CheckBox)
                    {
                        source.FindElement(item.FindElementBy)?.Click();

                    }
                    //else if (item.ElementTypeBy == ElementType.SaveFile)
                    //{
                    //    String script = "document.getElementById('fileName').value='" + item.SetValueElementBy + "';";
                    //    ((IJavaScriptExecutor)source).ExecuteScript(script);

                    //}
                    //else if (item.ElementTypeBy == ElementType.DropDownList)
                    //{

                    //    var dropDownList = source.FindElement(item.FindElementBy);
                    //      // not complete

                    //}
                }


            }


        }

    }
}



