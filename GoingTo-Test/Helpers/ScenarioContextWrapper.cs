using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace GoingTo_Test.Helpers
{
    class ScenarioContextWrapper
    {
        public static void SaveValue<T>(string key, T value)
        {
            if (ScenarioContext.Current.ContainsKey(key))
            {
                ScenarioContext.Current[key] = value;
            }
            else
            {
                ScenarioContext.Current.Add(key, value);
            }
        }

        public static T GetValue<T>(string key)
        {
            if (ScenarioContext.Current.ContainsKey(key))
            {
                return ScenarioContext.Current.Get<T>(key);
            }

            return default(T);
        }
    }
}
