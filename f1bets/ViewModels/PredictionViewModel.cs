using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace f1bets.ViewModels
{
    public class PredictionViewModel
    {
        public int Competition_id { get; set; }
        public List<int> Driver_id { get; set; } = new List<int>();

        private int selectedDriver1_id;
        public int SelectedDriver1_id
        {
            get
            {
                return selectedDriver1_id;
            }
            set
            {
                selectedDriver1_id = value;
                Driver_id.Add(selectedDriver1_id);
            }
        }
        private int selectedDriver2_id;
        public int SelectedDriver2_id
        {
            get
            {
                return selectedDriver2_id;
            }
            set
            {
                selectedDriver2_id = value;
                Driver_id.Add(selectedDriver2_id);
            }
        }
        private int selectedDriver3_id;
        public int SelectedDriver3_id
        {
            get
            {
                return selectedDriver3_id;
            }
            set
            {
                selectedDriver3_id = value;
                Driver_id.Add(selectedDriver3_id);
            }
        }
    }
}
