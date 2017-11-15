using System;
namespace TaskList
{
    public class TodoItem
    {
        public string ItemName { get; set; }
        public enum priority { low, medium, high, critical }
        private priority _importance;
        public string ItemId { get; set; }

        public priority Importance
        {
            get { return _importance; }
            set
            {
                _importance = value;
                switch (value)
                {
                    case priority.low:
                        {
                            ImportanceImage = "low_importance.png";
                            break;
                        }
                    case priority.medium:
                        {
                            ImportanceImage = "medium_importance.png";
                            break;
                        }
                    case priority.high:
                        {
                            ImportanceImage = "high_importance.png";
                            break;
                        }
                    case priority.critical:
                        {
                            ImportanceImage = "critical.png";
                            break;
                        }

                }
            }
        }

        public string ImportanceImage { get; set; }

        public TodoItem()
        {
        }
    }
}