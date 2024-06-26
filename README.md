# How to hightlight row when hovered in .NET MAUI DataGrid?
We can utilize the [CellEntered](https://help.syncfusion.com/maui/datagrid/grid-events#cellentered-event) and [CellExited](https://help.syncfusion.com/maui/datagrid/grid-events#cellexited-event) events of the [.NET MAUI DataGrid](https://www.syncfusion.com/maui-controls/maui-datagrid) to hightlight the row when hovered.

##### C#

In the `CellEntered` event, we will pass the row index of the current row where the pointer has entered to set the background color of the row.
```C#
private void dataGrid_CellEntered(object sender, DataGridCellEnteredEventArgs e)
{
    var rowIndex = e.RowColumnIndex.RowIndex;
    var dataRow = GetDataRowBase(rowIndex);
    if (dataRow != null && rowIndex > 0)
    {
        GetDataGridRow(dataRow)!.BackgroundColor = Color.FromArgb("#caf0f8");
    }
}
```

In the `CellExited` event, we will pass the row index of the current row where the pointer has exited to revert the the background color of the row.
```C#

private void dataGrid_CellExited(object sender, DataGridCellExitedEventArgs e)
{
    var rowIndex = e.RowColumnIndex.RowIndex;
    var dataRow = GetDataRowBase(rowIndex);
    if (dataRow != null && rowIndex > 0)
    {
        GetDataGridRow(dataRow)!.BackgroundColor = (this.dataGrid.DefaultStyle.RowBackground as SolidColorBrush)!.Color;
    }
}
```
We can use this helper method to get the row element.
```C#
private DataRowBase? GetDataRowBase(int index)
{
    return dataGrid.GetRowGenerator().Items!.FirstOrDefault(x => x.RowIndex == index);
}

private DataGridRow? GetDataGridRow(DataRowBase dataRowBase)
{
    var wholeRowElement = dataRowBase?.GetType()!.GetRuntimeFields().FirstOrDefault(x => x.Name.Equals("WholeRowElement"))!.GetValue(dataRowBase);
    return wholeRowElement as DataGridRow;

}
```

The following GIF demonstrates the highlight of row when hovered.

![DataGrid with DataGridCell Color](SfDataGrid_Row_Hightlight.gif)

[View sample in GitHub](https://github.com/SyncfusionExamples/How-to-hightlight-row-when-hovered-in-MAUI-DataGrid/tree/master)

Take a moment to pursue this [documentation](https://help.syncfusion.com/maui/datagrid/overview), where you can find more about Syncfusion .NET MAUI DataGrid (SfDataGrid) with code examples.
Please refer to this [link](https://www.syncfusion.com/maui-controls/maui-datagrid) to learn about the essential features of Syncfusion .NET MAUI DataGrid(SfDataGrid).

#### Conclusion
I hope you enjoyed learning about how to highlight of row when hovered in .NET MAUI DataGrid?

You can refer to our [.NET MAUI DataGrid's feature tour](https://www.syncfusion.com/maui-controls/maui-datagrid) page to know about its other groundbreaking feature representations. You can also explore our .NET MAUI DataGrid Documentation to understand how to present and manipulate data.
For current customers, you can check out our .NET MAUI components from the [License and Downloads](https://www.syncfusion.com/account/downloads) page. If you are new to Syncfusion, you can try our 30-day free trial to check out our .NET MAUI DataGrid and other .NET MAUI components.
If you have any queries or require clarifications, please let us know in comments below. You can also contact us through our [support forums](https://www.syncfusion.com/forums), [Direct-Trac](https://support.syncfusion.com/account/login?ReturnUrl=%2Faccount%2Fconnect%2Fauthorize%2Fcallback%3Fclient_id%3Dc54e52f3eb3cde0c3f20474f1bc179ed%26redirect_uri%3Dhttps%253A%252F%252Fsupport.syncfusion.com%252Fagent%252Flogincallback%26response_type%3Dcode%26scope%3Dopenid%2520profile%2520agent.api%2520integration.api%2520offline_access%2520kb.api%26state%3D8db41f98953a4d9ba40407b150ad4cf2%26code_challenge%3DvwHoT64z2h21eP_A9g7JWtr3vp3iPrvSjfh5hN5C7IE%26code_challenge_method%3DS256%26response_mode%3Dquery) or [feedback portal](https://www.syncfusion.com/feedback/maui?control=sfdatagrid). We are always happy to assist you!