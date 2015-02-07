using Base;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BoytrixWpf.ViewModels
{
    public class ShippingMethodViewModel : VMBase
    {       
        public ShippingMethodViewModel()
        {
            this.AddCommand = new DelegateCommand(this.OnAddNewShippingMethodClickCommand);
        }

#region Member variable
        private bool saveEnabled;
        private bool deleteEnabled;
        private bool exitEnabled;
        private bool addEnabled;

           private bool saveVisible;
        private bool deleteVisible;
        private bool exitVisible;
        private bool addVisible;
private  int priority;
private  string shippingMethodName;
private  bool allowUserToAddRows;
#endregion

        #region Command Properties
        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        #endregion


#region Notifying Properties
       public bool SaveEnabled
       {
            get
            {
                return this.saveEnabled;
            }

            set
            {
                this.saveEnabled = value;
                this.RaisePropertyChanged(() => this.SaveEnabled);
            }
       }

      public bool DeleteEnabled
       {
            get
            {
                return this.deleteEnabled;
            }

            set
            {
                this.deleteEnabled = value;
                this.RaisePropertyChanged(() => this.DeleteEnabled);
            }
       }

      public bool AddEnabled
       {
            get
            {
                return this.addEnabled;
            }

            set
            {
                this.addEnabled = value;
                this.RaisePropertyChanged(() => this.AddEnabled);
            }
       }

      public bool ExitEnabled
       {
            get
            {
                return this.exitEnabled;
            }

            set
            {
                this.exitEnabled = value;
                this.RaisePropertyChanged(() => this.ExitEnabled);
            }
      }

        /// <summary>
        /// Sets visiblity of controls
        /// </summary>
           public bool SaveVisible
       {
            get
            {
                return this.saveVisible;
            }

            set
            {
                this.saveVisible = value;
                this.RaisePropertyChanged(() => this.SaveVisible);
            }
       }

      public bool DeleteVisible
       {
            get
            {
                return this.deleteVisible;
            }

            set
            {
                this.deleteVisible = value;
                this.RaisePropertyChanged(() => this.DeleteVisible);
            }
       }

      public bool AddVisible
       {
            get
            {
                return this.addVisible;
            }

            set
            {
                this.addVisible = value;
                this.RaisePropertyChanged(() => this.AddVisible);
            }
       }

      public bool ExitVisible
       {
            get
            {
                return this.exitVisible;
            }

            set
            {
                this.exitVisible = value;
                this.RaisePropertyChanged(() => this.ExitVisible);
            }
      }

        public int Priority
        {
            get{
                return this.priority;
            }
            set{
                 this.priority = value;
                this.RaisePropertyChanged(() => this.Priority);
            }
        }

        public string ShippingMethodName
        {
            get{
                return this.shippingMethodName;
            }
            set{
                 this.shippingMethodName = value;
                this.RaisePropertyChanged(() => this.ShippingMethodName);
            }
        }

        public bool AllowUserToAddRows{
            get{
                return this.allowUserToAddRows;
            }
            set{
                  this.allowUserToAddRows = value;
                this.RaisePropertyChanged(() => this.AllowUserToAddRows);
            }
        }
#endregion

        #region button Commands
        private void OnAddNewShippingMethodClickCommand()
        {

                //DataGridViewImageCell cell = (DataGridViewImageCell)dgvShippingMethod.Rows[e.RowIndex].Cells[e.ColumnIndex];
               // var shippingMethodCellValue = dgvShippingMethod.Rows[e.RowIndex].Cells[0].Value ?? "";
                if (priority.ToString().Length > 0)
                {
                    this.SaveEnabled = true;
                    this.DeleteEnabled = true;

                    this.DeleteVisible = true;
                    this.DeleteEnabled = true;
                    AllowUserToAddRows = false;

                }
                else
                {
                    this.SaveEnabled = false;
                    this.DeleteEnabled = false;
                }
              //  this.dgvShippingMethod.CellEndEdit -= addhandler;

        

            //this.dgvShippingMethod.CellDoubleClick -= edithandler;
            //this.dgvShippingMethod.CellEndEdit += addhandler;
        }

       #endregion
    }
}
