using Syncfusion.Maui.DataGrid;
using System.Data;
using System.Reflection;
namespace SfDataGridSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void dataGrid_CellEntered(object sender, DataGridCellEnteredEventArgs e)
        {
            var rowIndex = e.RowColumnIndex.RowIndex;
            var dataRow = GetDataRowBase(rowIndex);
            if (dataRow != null && rowIndex > 0)
            {
                GetDataGridRow(dataRow)!.BackgroundColor = Color.FromArgb("#caf0f8");
            }
        }

        private void dataGrid_CellExited(object sender, DataGridCellExitedEventArgs e)
        {
            var rowIndex = e.RowColumnIndex.RowIndex;
            var dataRow = GetDataRowBase(rowIndex);
            if (dataRow != null && rowIndex > 0)
            {
                GetDataGridRow(dataRow)!.BackgroundColor = (this.dataGrid.DefaultStyle.RowBackground as SolidColorBrush)!.Color;
            }
        }

        private DataRowBase? GetDataRowBase(int index)
        {
            return dataGrid.GetRowGenerator().Items!.FirstOrDefault(x => x.RowIndex == index);
        }

        private DataGridRow? GetDataGridRow(DataRowBase dataRowBase)
        {
            var wholeRowElement = dataRowBase?.GetType()!.GetRuntimeFields().FirstOrDefault(x => x.Name.Equals("WholeRowElement"))!.GetValue(dataRowBase);
            return wholeRowElement as DataGridRow;

        }
    }
}
