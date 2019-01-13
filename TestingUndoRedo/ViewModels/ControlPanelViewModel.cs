using GuiLabs.Undo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TestingUndoRedo.ViewModels
{
    public class ControlPanelViewModel : ViewModel
    {
        public ControlPanelViewModel(ActionManager actionManager)
            : base(actionManager)
        { }

        private int _Slider;
        public int Slider
        {
            get { return _Slider; }
            set
            {
                SetAndNotify(ref _Slider, value);
                _Slider = value;
            }
        }

        private bool _Toggle;
        public bool Toggle
        {
            get { return _Toggle; }
            set
            {
                SetAndNotify(ref _Toggle, value);
                _Toggle = value;
            }
        }
    }
}
