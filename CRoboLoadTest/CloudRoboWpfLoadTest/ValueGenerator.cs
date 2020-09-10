using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CloudRoboWpfLoadTest
{
    public class ValueGenerator
    {
        private string id;
        private string mode;
        private int increment;
        private int startValue;
        private int endValue;
        private int currentValue;

        public ValueGenerator(string id, string mode, int increment, int startValue, int endValue)
        {
            this.id = id;
            this.mode = mode;
            this.increment = increment;
            this.startValue = startValue;
            this.endValue = endValue;

            if (mode.ToLower() == "addition")
            {
                this.currentValue = startValue;
            }
        }
        public string ReplaceValueInMessage(string message)
        {
            if (mode.ToLower() == "random")
            {
                Random rand = new Random();
                currentValue = (int)(rand.NextDouble() * increment);
            }

            if (message.Contains(id))
            {
                message = message.Replace(id, currentValue.ToString());
            }

            if (mode.ToLower() == "addition")
            {
                currentValue += increment;
                if (currentValue > endValue)
                    currentValue = startValue;
            }

            return message;
        }
    }
}
