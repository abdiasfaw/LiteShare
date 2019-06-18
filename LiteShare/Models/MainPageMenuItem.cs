using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteShare.Views {
    public class MainPageMenuItem {
        public MainPageMenuItem() {
            TargetType = typeof(MainPageDetail);
        }
        static int id = 0;
        public bool HasSwitch { get; set; } = false;

        public string Title { get; set; }

        public string Id { get => $"listStyle{++id}"; }

        public Type TargetType { get; set; }
    }
}
