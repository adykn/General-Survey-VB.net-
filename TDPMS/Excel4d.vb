Imports Microsoft.Office.Interop
Imports System.Runtime.InteropServices
Imports Microsoft.Office.Interop.Excel

Public Class Excel4d
    'some help from below links
    'https://www.add-in-express.com/creating-addins-blog/2013/10/24/excel-tables-ranges-vbnet/
    'https://siddharthrout.wordpress.com/vb-net-and-excel/
    Private _ExcelApp As New Excel.Application
    Private _WorkBook1 As Excel.Workbook
    Private _WorkSheet1 As Excel.Worksheet

    Sub New()
        ExcelApp = New Excel.Application
    End Sub
    Public Property ExcelApp As Excel.Application
        Get
            Return _ExcelApp
        End Get
        Set(ByVal value As Excel.Application)
            _ExcelApp = value
            _WorkBook1 = value.Workbooks.Add
            ClearWorkBook()
        End Set
    End Property
    Public Property WorkBook1 As Excel.Workbook
        Get
            Return _WorkBook1
        End Get
        Set(ByVal value As Excel.Workbook)
            _WorkBook1 = value
            WorkSheet1 = value.ActiveSheet

        End Set
    End Property
    Public Property WorkSheet1 As Excel.Worksheet
        Get
            Return _WorkSheet1
        End Get
        Set(ByVal value As Excel.Worksheet)
            _WorkSheet1 = value

        End Set
    End Property
    Sub addSheet()
        WorkSheet1 = WorkBook1.Sheets.Add
    End Sub
    Function GetActiveWorkbook() As Excel.Workbook
        Return ExcelApp.ActiveWorkbook
    End Function
    Function GetActiveSheet() As Excel.Worksheet
        Return ExcelApp.ActiveSheet
    End Function
    Function GetFullPath(wb As Excel.Workbook)
        Return wb.FullName
    End Function
    Function GetPath(wb As Excel.Workbook) As String
        Return wb.Path
    End Function
    Function GetName(wb As Excel.Workbook)
        Return wb.Name
    End Function
    Sub ClearWorkBook()
        For Each xs As Excel.Worksheet In WorkBook1.Sheets
            If xs.Name = "Sheet1" Then Continue For
            xs.Delete()
        Next
    End Sub
    Sub DeletSheet(NewSheetName As String)
        If DoesSheetExists(NewSheetName) Then
            For Each xs As Excel.Worksheet In WorkBook1.Sheets
                If xs.Name = NewSheetName Then
                    xs.Delete()
                End If
            Next
            MsgBox("The sheet " & NewSheetName & " Doesn't exists. Please select another name.")
        End If
    End Sub
    Function DoesSheetExists(ByVal shtName As String) As Boolean
        DoesSheetExists = False
        For Each xs As Excel.Worksheet In WorkBook1.Sheets
            If xs.Name = shtName Then
                DoesSheetExists = True
            End If
        Next
    End Function
    Sub SilentSave(path As String, fileName As String)
        If fileName.Length = 0 Then fileName = SpName().Substring(0, 6) & ".xls"
        With ExcelApp
            .Visible = False
            .Application.DisplayAlerts = False
            .ActiveWorkbook.SaveAs(path + fileName, -4143)
            .Quit()
        End With

        releaseObject(ExcelApp.ActiveWorkbook)
        releaseObject(ExcelApp)
    End Sub

    Sub SaveWB(wb As Excel.Workbook)
        If wb.FileFormat = Excel.XlFileFormat.xlExcel9795 Then
            wb.SaveAs(wb.FullName, Excel.XlFileFormat.xlWorkbookNormal)
        Else
            wb.Save()
        End If
    End Sub
    Sub MakeXslFile(d As DataSet, directry As String, fileName As String, KillProcess As Boolean, OpenXslFile As Boolean, Chart As Boolean, Optional formatCells As Boolean = False)

        Try
            Dim CelCount = 0
            Dim RowCount = 0
            If d.Tables.Count = 0 Then MsgBox("Dataset is empty") : Exit Sub
            If fileName.Length = 0 Then fileName = SpName().Substring(0, 6) & Now.Hour & Now.Minute & Now.Second & ".xls"

            For l = 0 To d.Tables.Count - 1
                dt = d.Tables(l)

                GetActiveSheet.Name = dt.TableName
                CelCount = dt.Columns.Count
                RowCount = dt.Rows.Count
                For i = 0 To CelCount - 1
                    GetActiveSheet.Cells(1, i + 1) = dt.Columns(i).ColumnName
                    GetActiveSheet.Cells(1, i + 1).Font.Bold = True
                Next
                For i = 0 To RowCount - 1
                    For j = 0 To CelCount - 1
                        GetActiveSheet.Cells(i + 2, j + 1) = dt.Rows(i).Item(j)
                    Next

                Next
                Dim a As Integer = 0
                Dim str As String = ""
                a = Math.Floor(CelCount / 26)
                For m = 1 To a
                    str += "A"
                Next
                Dim temp As String = IIf(CelCount > 26, str & Chr(65 + CelCount - 1 - 26), Chr(65 + CelCount - 1))
                If formatCells Then
                    Try

                        With GetActiveSheet.Range("A1:" & temp & +(1).ToString)
                            .Interior.ColorIndex = 1 '<~~ Cell Back Color Black
                            With .Font
                                .ColorIndex = 2 '<~~ Font Color White
                                .Size = 8
                                .Name = "Tahoma"
                                '.Underline = Excel.XlUnderlineStyle.xlUnderlineStyleSingle
                                .Bold = True
                            End With

                        End With
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try

                    Try
                        GetActiveSheet.Columns("A:" & temp).EntireColumn.AutoFit()
                        With GetActiveSheet.Range("A1:" & temp + (RowCount + 1).ToString)
                            With .Borders(Excel.XlBordersIndex.xlEdgeLeft)
                                .LineStyle = Excel.XlLineStyle.xlDouble
                                .ColorIndex = 0
                                .TintAndShade = 0
                                .Weight = Excel.XlBorderWeight.xlThin
                            End With
                            With .Borders(Excel.XlBordersIndex.xlEdgeTop)
                                .LineStyle = Excel.XlLineStyle.xlContinuous
                                .ColorIndex = 0
                                .TintAndShade = 0
                                .Weight = Excel.XlBorderWeight.xlThin
                            End With
                            With .Borders(Excel.XlBordersIndex.xlEdgeBottom)
                                .LineStyle = Excel.XlLineStyle.xlContinuous
                                .ColorIndex = 0
                                .TintAndShade = 0
                                .Weight = Excel.XlBorderWeight.xlThin
                            End With
                            With .Borders(Excel.XlBordersIndex.xlEdgeRight)
                                .LineStyle = Excel.XlLineStyle.xlContinuous
                                .ColorIndex = 0
                                .TintAndShade = 0
                                .Weight = Excel.XlBorderWeight.xlThin
                            End With
                            With .Borders(Excel.XlBordersIndex.xlInsideVertical)
                                .LineStyle = Excel.XlLineStyle.xlContinuous
                                .ColorIndex = 0
                                .TintAndShade = 0
                                .Weight = Excel.XlBorderWeight.xlThin
                            End With
                            With .Borders(Excel.XlBordersIndex.xlInsideHorizontal)
                                .LineStyle = Excel.XlLineStyle.xlContinuous
                                .ColorIndex = 0
                                .TintAndShade = 0
                                .Weight = Excel.XlBorderWeight.xlThin
                            End With
                        End With
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                End If
                If Chart Then
                    'create chart
                    Dim chartPage As Excel.Chart
                    Dim xlCharts As Excel.ChartObjects
                    Dim myChart As Excel.ChartObject
                    Dim chartRange As Excel.Range

                    xlCharts = GetActiveSheet.ChartObjects
                    myChart = xlCharts.Add(10, 80, 300, 250)
                    chartPage = myChart.Chart '  -------v----------------------v-----------< 1
                    chartRange = GetActiveSheet.Range("A2", temp + (RowCount + 2).ToString)
                    chartPage.SetSourceData(Source:=chartRange)
                    chartPage.ChartType = Excel.XlChartType.xlColumnClustered
                End If
                If l < d.Tables.Count - 1 Then addSheet()
            Next
            If KillProcess Then
                Dim proc As System.Diagnostics.Process
                For Each proc In System.Diagnostics.Process.GetProcessesByName("EXCEL")
                    proc.Kill()
                Next
            End If

            SilentSave(directry, fileName)
            releaseObject(GetActiveSheet)




            If OpenXslFile Then Process.Start("EXCEL.EXE", """" & directry + fileName & """")

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Sub MakeXslFileWithHeaders(tble As String, directry As String, fileName As String, Optional KillProcess As Boolean = True, Optional OpenXslFile As Boolean = True)




        Try
            Dim dx As New DataSet
            Dim dx1 As New DataSet
            Dim CelCount = 0
            Dim RowCount = 0
            dx = GDs("distinct title,num", tble, " 1=1 order by Num")
            dx = GDs(TN1, "")

            With GetActiveSheet.Pictures.Insert(Path & "\logo.png")
                .Left = 5 'GetActiveSheet.Range("a1").Left
                .Top = 5 'GetActiveSheet.Range("b2").Top
                .Height = 75
            End With

            GetActiveSheet.Cells(1, 1) = "Report ID"
            GetActiveSheet.Cells(1, 1).Font.Bold = True
            GetActiveSheet.Cells(1, 2) = "District"
            GetActiveSheet.Cells(1, 2).Font.Bold = True
            GetActiveSheet.Cells(1, 3) = "Village"
            GetActiveSheet.Cells(1, 3).Font.Bold = True
            GetActiveSheet.Cells(1, 4) = "UC"
            GetActiveSheet.Cells(1, 4).Font.Bold = True

            CelCount = 4 + dx.Tables(tble).Rows.Count
            RowCount = dx.Tables(TN1).Rows.Count



            For i = 0 To dx.Tables(tble).Rows.Count - 1
                With dx.Tables(tble).Rows(i)
                    GetActiveSheet.Cells(1, i + 5) = .Item("Title")
                    GetActiveSheet.Cells(1, i + 5).Font.Bold = True
                End With
            Next
            With GetActiveSheet.Range("E1:" & Chr(65 + CelCount - 1) & "1")
                .Orientation = 90
                .HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                .VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom

            End With
            With GetActiveSheet.Range("A1:" & Chr(65 + CelCount - 1) + (1).ToString)
                .Interior.ColorIndex = 15 '<~~ Cell Back Color Black
                With .Font
                    .ColorIndex = 2 '<~~ Font Color White
                    .Size = 11
                    .Name = "Tahoma"
                    '.Underline = Excel.XlUnderlineStyle.xlUnderlineStyleSingle
                    .Bold = True
                End With

            End With

            With GetActiveSheet.Range("A1:" & Chr(65 + CelCount - 1) + (RowCount + 1).ToString)
                With .Borders(Excel.XlBordersIndex.xlEdgeLeft)
                    .LineStyle = Excel.XlLineStyle.xlDouble
                    .ColorIndex = 0
                    .TintAndShade = 0
                    .Weight = Excel.XlBorderWeight.xlThin
                End With
                With .Borders(Excel.XlBordersIndex.xlEdgeTop)
                    .LineStyle = Excel.XlLineStyle.xlContinuous
                    .ColorIndex = 0
                    .TintAndShade = 0
                    .Weight = Excel.XlBorderWeight.xlThin
                End With
                With .Borders(Excel.XlBordersIndex.xlEdgeBottom)
                    .LineStyle = Excel.XlLineStyle.xlContinuous
                    .ColorIndex = 0
                    .TintAndShade = 0
                    .Weight = Excel.XlBorderWeight.xlThin
                End With
                With .Borders(Excel.XlBordersIndex.xlEdgeRight)
                    .LineStyle = Excel.XlLineStyle.xlContinuous
                    .ColorIndex = 0
                    .TintAndShade = 0
                    .Weight = Excel.XlBorderWeight.xlThin
                End With
                With .Borders(Excel.XlBordersIndex.xlInsideVertical)
                    .LineStyle = Excel.XlLineStyle.xlContinuous
                    .ColorIndex = 0
                    .TintAndShade = 0
                    .Weight = Excel.XlBorderWeight.xlThin
                End With
                With .Borders(Excel.XlBordersIndex.xlInsideHorizontal)
                    .LineStyle = Excel.XlLineStyle.xlContinuous
                    .ColorIndex = 0
                    .TintAndShade = 0
                    .Weight = Excel.XlBorderWeight.xlThin
                End With
            End With



            For i = 0 To dx.Tables(TN1).Rows.Count - 1

                dx1 = GDs(tble, "ref='" & dx.Tables(TN1).Rows(i).Item("ref") & "'")
                GetActiveSheet.Cells(2 + i, 1) = dx.Tables(TN1).Rows(i).Item("ref")
                GetActiveSheet.Cells(2 + i, 2) = dx.Tables(TN1).Rows(i).Item("District")
                GetActiveSheet.Cells(2 + i, 3) = dx.Tables(TN1).Rows(i).Item("Village")
                GetActiveSheet.Cells(2 + i, 4) = dx.Tables(TN1).Rows(i).Item("UC")
                For j = 0 To dx1.Tables(tble).Rows.Count - 1
                    GetActiveSheet.Cells(2 + i, 5 + j) = dx1.Tables(tble).Rows(j).Item(5)
                Next


            Next
            With GetActiveSheet.Range("A2:D" & dx.Tables(TN1).Rows.Count + 1)
                .Interior.ColorIndex = 44 '<~~ Cell Back Color Black
                With .Font
                    .ColorIndex = 1 '<~~ Font Color White
                    .Size = 10
                End With
            End With

            GetActiveSheet.Columns("A:Z").EntireColumn.AutoFit()
            SilentSave(directry, fileName)

            If KillProcess Then
                Dim proc As System.Diagnostics.Process
                For Each proc In System.Diagnostics.Process.GetProcessesByName("EXCEL")
                    proc.Kill()
                Next
            End If

            If OpenXslFile Then Process.Start("EXCEL.EXE", """" & directry + fileName & """")

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try



    End Sub
    Sub MakeXslFileWithHeadersB(tble As String, directry As String, fileName As String, Optional KillProcess As Boolean = True, Optional OpenXslFile As Boolean = True)




        Try
            Dim dx As New DataSet
            Dim dx1 As New DataSet
            Dim CelCount = 0
            Dim RowCount = 0
            Dim r As Integer = 3

            dx = GDs("distinct title,num", tble, " 1=1 order by Num")
            dx = GDs(TN1, "")

            CelCount = dx.Tables(TN1).Rows.Count + 1
            RowCount = dx.Tables(tble).Rows.Count + r - 1

            GetActiveSheet.Cells(1, 1) = "Report Ref#"
            GetActiveSheet.Cells(1, 1).Font.Bold = True
            GetActiveSheet.Cells(2, 1) = "UC"
            GetActiveSheet.Cells(2, 1).Font.Bold = True
            GetActiveSheet.Cells(3, 1) = "Village"
            GetActiveSheet.Cells(3, 1).Font.Bold = True

            For i = 0 To dx.Tables(tble).Rows.Count - 1
                With dx.Tables(tble).Rows(i)
                    GetActiveSheet.Cells(i + r + 1, 1) = .Item("Title")
                    GetActiveSheet.Cells(i + r + 1, 1).Font.Bold = True
                End With
            Next
            
            With GetActiveSheet.Range("b1:" & Chr(65 + CelCount - 1) & "1")
                .Orientation = 90
                .HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                .VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom

            End With
            With GetActiveSheet.Range("b1:" & Chr(65 + CelCount - 1) + (r).ToString)
                .Interior.ColorIndex = 15 '<~~ Cell Back Color Black
                With .Font
                    .ColorIndex = 2 '<~~ Font Color White
                    .Size = 11
                    .Name = "Tahoma"
                    '.Underline = Excel.XlUnderlineStyle.xlUnderlineStyleSingle
                    .Bold = True
                End With

            End With
            

            With GetActiveSheet.Range("A1:" & Chr(65 + CelCount - 1) + (RowCount + 1).ToString)
                With .Borders(Excel.XlBordersIndex.xlEdgeLeft)
                    .LineStyle = Excel.XlLineStyle.xlDouble
                    .ColorIndex = 0
                    .TintAndShade = 0
                    .Weight = Excel.XlBorderWeight.xlThin
                End With
                With .Borders(Excel.XlBordersIndex.xlEdgeTop)
                    .LineStyle = Excel.XlLineStyle.xlContinuous
                    .ColorIndex = 0
                    .TintAndShade = 0
                    .Weight = Excel.XlBorderWeight.xlThin
                End With
                With .Borders(Excel.XlBordersIndex.xlEdgeBottom)
                    .LineStyle = Excel.XlLineStyle.xlContinuous
                    .ColorIndex = 0
                    .TintAndShade = 0
                    .Weight = Excel.XlBorderWeight.xlThin
                End With
                With .Borders(Excel.XlBordersIndex.xlEdgeRight)
                    .LineStyle = Excel.XlLineStyle.xlContinuous
                    .ColorIndex = 0
                    .TintAndShade = 0
                    .Weight = Excel.XlBorderWeight.xlThin
                End With
                With .Borders(Excel.XlBordersIndex.xlInsideVertical)
                    .LineStyle = Excel.XlLineStyle.xlContinuous
                    .ColorIndex = 0
                    .TintAndShade = 0
                    .Weight = Excel.XlBorderWeight.xlThin
                End With
                With .Borders(Excel.XlBordersIndex.xlInsideHorizontal)
                    .LineStyle = Excel.XlLineStyle.xlContinuous
                    .ColorIndex = 0
                    .TintAndShade = 0
                    .Weight = Excel.XlBorderWeight.xlThin
                End With
            End With



            For i = 0 To dx.Tables(TN1).Rows.Count - 1
                r += 1
                dx1 = GDs(tble, "ref='" & dx.Tables(TN1).Rows(i).Item("ref") & "' order by Num")
                GetActiveSheet.Cells(r - 3, 2 + i) = dx.Tables(TN1).Rows(i).Item("ref")
                GetActiveSheet.Cells(r - 3, 2 + i).Font.Bold = True
                GetActiveSheet.Cells(r - 2, 2 + i) = dx.Tables(TN1).Rows(i).Item("UC")
                GetActiveSheet.Cells(r - 2, 2 + i).Font.Bold = True
                GetActiveSheet.Cells(r - 1, 2 + i) = dx.Tables(TN1).Rows(i).Item("Village")
                GetActiveSheet.Cells(r - 1, 2 + i).Font.Bold = True

                For j = 0 To dx1.Tables(tble).Rows.Count - 1
                    GetActiveSheet.Cells(r + j, 2 + i) = dx1.Tables(tble).Rows(j).Item(5)
                    If j = dx1.Tables(tble).Rows.Count - 1 Then r = 3
                Next

            Next
            With GetActiveSheet.Range("A" & r + 1 & ":A" & dx.Tables(tble).Rows.Count + r)
                .Interior.ColorIndex = 44 '<~~ Cell Back Color Black
                With .Font
                    .ColorIndex = 1 '<~~ Font Color White
                    .Size = 10
                End With
            End With
            GetActiveSheet.Columns("A:Z").EntireColumn.AutoFit()
            SilentSave(directry, fileName)

            If KillProcess Then
                Dim proc As System.Diagnostics.Process
                For Each proc In System.Diagnostics.Process.GetProcessesByName("EXCEL")
                    proc.Kill()
                Next
            End If

            If OpenXslFile Then Process.Start("EXCEL.EXE", """" & directry + fileName & """")

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try



    End Sub
    Sub SimpleMakeXlsfile(d As DataSet, directry As String, fileName As String, KillProcess As Boolean, OpenXslFile As Boolean)
        Try

            For l = 0 To ds.Tables.Count - 1
                dt = ds.Tables(l)
                GetActiveSheet.Name = dt.TableName
                For i = 0 To dt.Columns.Count - 1
                    GetActiveSheet.Cells(1, i + 1) = dt.Columns(i).ColumnName
                    GetActiveSheet.Cells(1, i + 1).Font.Bold = True
                Next
                For i = 0 To dt.Rows.Count - 1
                    For j = 0 To dt.Columns.Count - 1
                        GetActiveSheet.Cells(i + 2, j + 1) = dt.Rows(i).Item(j)
                    Next

                Next
                GetActiveSheet.Columns("A:Z").EntireColumn.AutoFit()
                If l < ds.Tables.Count - 1 Then addSheet()
            Next

            SilentSave(directry, fileName)

            If KillProcess Then
                Dim proc As System.Diagnostics.Process
                For Each proc In System.Diagnostics.Process.GetProcessesByName("EXCEL")
                    proc.Kill()
                Next
            End If

            If OpenXslFile Then Process.Start("EXCEL.EXE", """" & directry + fileName & """")

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
    Sub ProtectWB(wb As Excel.Workbook, passWord As String, protect As Boolean)
        If protect Then
            wb.Protect(passWord, True, False)
        Else
            wb.Unprotect(passWord)
        End If
    End Sub
    Sub MakeFavorite(wb As Excel.Workbook)
        wb.AddToFavorites()
    End Sub
    Sub EditBuiltInProperty(wb As Excel.Workbook, propName As String, propValue As String)

        Dim props As Microsoft.Office.Core.DocumentProperties = wb.BuiltinDocumentProperties
        Dim prop As Microsoft.Office.Core.DocumentProperty = Nothing

        prop = props.Item(propName)
        If Not prop Is Nothing Then
            prop.Value = propValue
        End If

        'You can choose to save it.
        'I prefer to leave it to the user to do manually
        'wb.Save()

        Marshal.ReleaseComObject(prop)
        Marshal.ReleaseComObject(props)
    End Sub
    Sub EditCustomProperty(wb As Excel.Workbook, propName As String, propValue As String)

        Dim props As Microsoft.Office.Core.DocumentProperties = wb.CustomDocumentProperties
        Dim prop As Microsoft.Office.Core.DocumentProperty = Nothing

        For i = 1 To props.Count
            If props.Item(i).Name = propName Then
                prop = props.Item(i)
            End If
        Next

        If Not prop Is Nothing Then
            'If the property exists, edit it.
            prop.Value = propValue
        Else
            'It doesn't exist...so let's create it.
            props.Add(propName, False, _
                Microsoft.Office.Core.MsoDocProperties.msoPropertyTypeString, propValue)
        End If

        'You can choose to save it.
        'I prefer to leave it to the user to do manually
        'wb.Save()

        Marshal.ReleaseComObject(prop)
        Marshal.ReleaseComObject(props)
    End Sub
    Function GetWorksheetName(sheet As Excel.Worksheet)
        Return sheet.Name
    End Function
    Function GetWorksheetCodeName(sheet As Excel.Worksheet) As String
        Return sheet.CodeName
    End Function
    Function GetSheetByIndex(wb As Excel.Workbook, index As Integer)
        Return wb.Worksheets(index)
    End Function
    Function GetSheetByName(wb As Excel.Workbook, sheetName As String)
        Return wb.Worksheets(sheetName)
    End Function
    Sub CopyActiveSheet(newWorkbook As Boolean)
        Dim sheet As Excel.Worksheet = ExcelApp.ActiveSheet

        If newWorkbook Then
            sheet.Copy() 'Creates a new workbook and copies sheet into it
        Else
            sheet.Copy(, sheet) 'Copies a new sheet after the one copied.
        End If
    End Sub
    Sub HideSheet(ws As Excel.Worksheet, makeItHard As Boolean)
        If makeItHard Then
            ws.Visible = Excel.XlSheetVisibility.xlSheetVeryHidden
        Else
            ws.Visible = Excel.XlSheetVisibility.xlSheetHidden
        End If
    End Sub
    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub
End Class
