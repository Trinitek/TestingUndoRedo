
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using GuiLabs.Undo;

namespace TestingUndoRedo.ViewModels
{
    public class MainViewModel : ViewModel
    {
        public MainViewModel()
            : base(new ActionManager())
        {
            ControlPanel1 = new ControlPanelViewModel(ActionManager);
            ControlPanel2 = new ControlPanelViewModel(ActionManager);

            UndoCommand = new RelayCommand(p => Undo());
            RedoCommand = new RelayCommand(p => Redo());
        }

        public ICommand UndoCommand { get; }
        public ICommand RedoCommand { get; }

        void Undo()
        {
            ActionManager.Undo();
        } 

        void Redo()
        {
            ActionManager.Redo();
        }

        public int SliderInternal
        {
            get;
            set;
        }

#pragma warning disable IDE0044 // Add readonly modifier
        private int _slider;
#pragma warning restore IDE0044 // Add readonly modifier
        public int Slider
        {
            get => _slider;
            set => SetAndRecord(() => _slider, value);
        }

        private ControlPanelViewModel _ControPanel1;
        public ControlPanelViewModel ControlPanel1
        {
            get { return _ControPanel1; }
            set
            {
                SetAndNotify(ref _ControPanel1, value);
                _ControPanel1 = value;
            }
        }

        private ControlPanelViewModel _ControPanel2;
        public ControlPanelViewModel ControlPanel2
        {
            get { return _ControPanel2; }
            set
            {
                SetAndNotify(ref _ControPanel2, value);
                _ControPanel2 = value;
            }
        }

    }
}
