Imports System.Data.SqlClient
Imports System.IO
Imports System.Text.RegularExpressions
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel

Module GeneralModule
    Public conn_str As String = GetCon()

    Dim infrag As New infragistics.Init(System.Windows.Forms.Application.StartupPath)
    Public ConnectionString As String = conn_str
    Dim cmd As New SqlCommand
    Dim cn As New SqlConnection(conn_str)
    Public my_reader As SqlDataReader
    Public my_command As SqlCommand
    Dim gcls As New GeneralClass
    Public ds As New DataSet
    Public dsCombo As New DataSet
    Public da As SqlDataAdapter
    Public main_trigger As String = String.Empty
    Public connection As SqlConnection
    Public checkkk As Int32 = 0
    Public checkkk_2 As Int32 = 0
    Public CmbVal As List(Of [String]) = New List(Of String)()

#Region "Expressions"
    '****************************************************************************************
    Function IsEmail(ByVal email As String) As Boolean
        Static emailExpression As New Regex("^[_a-z0-9-]+(.[a-z0-9-]+)@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$")
        Return emailExpression.IsMatch(email)
    End Function

    Function IsNumbers(ByVal input As String, point As String) As Boolean
        Dim temp As String
        If point = "" Then
            temp = "^[0-9]*(\.[0-9]{1,4})?$"
        ElseIf point = "." Then
            temp = "^[0-9]+$"
        End If
        Static Number As New Regex(temp)
        Return Number.IsMatch(input)
    End Function

    Function IsText(input As String) As Boolean
        Static chaacter As New Regex("^[a-zA-Z]+$")
        Return chaacter.IsMatch(input)
    End Function
    '******************************************************************************************
    Function CheckTextbox(textbx As Object, ExpressionVal As String) As Boolean
        Try
            If ExpressionVal.ToLower = "email" Then

                Return IsEmail(textbx.text)

            ElseIf ExpressionVal.ToLower = "text" Then
                Return IsText(textbx.text)

            Else
                Return IsNumbers(textbx.text, "")

            End If
        Catch ex As Exception
            Return False
            textbx.Appearance.BackColor = Color.LightPink
        End Try
    End Function

    'If Not CheckTextbox(textbox1, "Email") Then
    '    MsgBox("")
    '    textbox1.focus()
    '    textbox1.select()
    '    Exit Sub
    'End If


    '******************************************************************************************
#End Region
    Function GetCon() As String
        Dim str As String
        Try
            If Not System.IO.File.Exists(System.Windows.Forms.Application.StartupPath & "\Constr.txt") Then GoTo HERE
            FileOpen(1, System.Windows.Forms.Application.StartupPath & "\Constr.txt", OpenMode.Input)
            str = LineInput(1)
            FileClose(1)

            If str.Length = 0 Then
HERE:
                FileOpen(1, System.Windows.Forms.Application.StartupPath & "\Constr.txt", OpenMode.Output)
                Print(1, "Data Source=als-server-pc;Initial Catalog = Accounts;User ID=als;password=acmelogic")
                FileClose(1)
                System.Windows.Forms.Application.Exit()
            Else
                Return str
            End If
        Catch ex As Exception

        End Try



    End Function
    Sub ColumAdd(headertext As String, ColNamed As String, size As Integer, dg As DataGridView)
        Dim col As New DataGridViewTextBoxColumn
        col.Name = ColNamed
        col.DataPropertyName = ColNamed
        col.HeaderText = headertext
        col.Width = size
        dg.Columns.Add(col)
    End Sub
    Public Function GetDate() As String
        cmd.CommandText = "SELECT GETDATE() AS CurrentDateTime"
        cmd.Connection = con()
        Return cmd.ExecuteScalar
    End Function
    Public Function GetMaxSpId(ByVal PreFixKeyWord As String, ByVal PostFixKeyWord As String, ByVal IdLenght As Integer, ByVal FieldName As String, ByVal TableName As String, ByVal condition As String) As String
        Dim NVNO As String = ""
        Dim Zeros As String = ""
        Dim temp As Integer = 0
        Dim num As String = ""
        Dim i As Integer = 0
        Dim dt As String = Now.Year.ToString.Substring(2, 2) & Now.Month & Now.Day

        Try
            condition = ConditionChecker(condition)
            cmd.CommandText = "select isnull(max(" & FieldName & "),0)from " & TableName & " where " & condition & ""
            cmd.Connection = con()
            num = cmd.ExecuteScalar

            Dim x As Integer = Len(num) - (Len(PreFixKeyWord) + 1)

            temp = num.ToString.Substring(Len(PreFixKeyWord) + 1, x) + 1

            For i = Len(temp.ToString) To IdLenght - 1
                Zeros = Zeros & 0
            Next

            NVNO = PreFixKeyWord & dt & Zeros & temp & "-" & PostFixKeyWord
            Return NVNO


        Catch ex As Exception
            For i = 1 To IdLenght - 1
                Zeros = Zeros & 0
            Next
            Return PreFixKeyWord & dt & Zeros & 1 & "-" & PostFixKeyWord
        End Try


    End Function
    Public Sub logFunction(task As String, output As String, frm As Form, remaraks As String, tab As String)
        Dim ll As New Log
        ll.Id = gcls.GetMaxid("Id", "Log", "1=1")
        ll._Date = GetDate()
        ll._Time = GetDate.ToString.Split(" ")(1)
        ll.Usr_No = "01"
        ll.Task = task
        ll.Output = output
        ll.Form_Name = frm.Name & IIf(tab.ToString.Length = 0, "", ":" & tab)
        ll.Remarks = remaraks
        ll.Save()
    End Sub

    Public Sub Inventoryfunction(trans_id As String, trans_item As String, trans_user As String, trans_comments As String, trans_inventory As String, trans_date As String)
        Dim trans As New Pos_Inventory
        trans.Trans_id = trans_id
        trans.Trans_item = trans_item
        trans.Trans_user = trans_user
        trans.Trans_date = trans_date
        trans.Trans_comments = trans_comments
        trans.Trans_inventory = trans_inventory
        trans.Save()
    End Sub

    Function GetDs(TableName As String, Condition As String, dataSett As DataSet) As DataSet

        Dim sqlConn As New SqlConnection(ConnectionString)
        Dim adp As New SqlDataAdapter("GetTable", sqlConn)

        If dataSett.Tables.Contains(TableName) Then dataSett.Tables.Remove(TableName)

        Try
            sqlConn.Open()
            adp.SelectCommand.CommandType = CommandType.StoredProcedure
            adp.SelectCommand.Parameters.Add("@table_name", SqlDbType.NVarChar).Value = TableName
            adp.SelectCommand.Parameters.Add("@Condition", SqlDbType.NVarChar).Value = Condition
            adp.Fill(dataSett, TableName)
        Catch
            Throw
        Finally
            sqlConn.Close()
            adp.Dispose()
            sqlConn.Dispose()
        End Try

        GetDs = dataSett

    End Function
    Public Function GetMaxid(ByVal field As String, ByVal tblname As String, ByVal Condition As String) As Double
        Condition = ConditionChecker(Condition)
        If ds.Tables.Contains(tblname) Then ds.Tables.Remove(tblname)
        Dim con As New SqlConnection(ConnectionString)
        If con.State = ConnectionState.Closed Then con.Open()
        Dim Num As Double = 0
        cmd.CommandText = "select isnull(max(" & field & "),0) from " & tblname & " where " & Condition & ""
        cmd.Connection = con
        Num = cmd.ExecuteScalar

        Return Num + 1.0
    End Function
    Sub CheckNaddCity(City As String)
        Try
            ds = gcls.Gds("tbl_Cities", "city_name='" & City & "'")
            If ds.Tables("tbl_cities").Rows.Count = 0 Then insertdata("tbl_cities", "city_name", "'" & City & "'")
        Catch ex As Exception

        End Try

    End Sub
    Sub CheckNaddLoc(Loc As String)
        Try
            ds = gcls.Gds("tbl_sub_location", "loc_name='" & Loc & "'")
            If ds.Tables("tbl_sub_location").Rows.Count = 0 Then insertdata("tbl_sub_location", "loc_name", "'" & Loc & "'")
        Catch ex As Exception

        End Try

    End Sub
    Sub CenterPenel(f As Object, p As Object)
        Dim x As Integer = (f.Width - p.Width) / 2
        Dim y As Integer = (f.Height - p.Height) / 2
        p.Location = New System.Drawing.Point(x, y)
    End Sub
    Public Sub clr(ByVal PanelOrForm As Control)

        For Each cntrl As Control In PanelOrForm.Controls
            clr(cntrl)
            If TypeOf cntrl Is System.Windows.Forms.TextBox Then
                CType(cntrl, System.Windows.Forms.TextBox).Text = String.Empty
            ElseIf TypeOf cntrl Is Infragistics.Win.UltraWinEditors.UltraTextEditor Then
                CType(cntrl, Infragistics.Win.UltraWinEditors.UltraTextEditor).Text = String.Empty
            End If
        Next cntrl

    End Sub
    Public Sub Enb(ByVal PanelOrForm As Control, boln As Boolean)

        For Each cntrl As Control In PanelOrForm.Controls
            Enb(cntrl, boln)
            If TypeOf cntrl Is System.Windows.Forms.TextBox Then
                CType(cntrl, System.Windows.Forms.TextBox).Enabled = boln
            ElseIf TypeOf cntrl Is Infragistics.Win.UltraWinEditors.UltraTextEditor Then
                CType(cntrl, Infragistics.Win.UltraWinEditors.UltraTextEditor).Enabled = boln
            ElseIf TypeOf cntrl Is System.Windows.Forms.CheckBox Then
                CType(cntrl, System.Windows.Forms.CheckBox).Enabled = boln
            ElseIf TypeOf cntrl Is Infragistics.Win.UltraWinEditors.UltraDateTimeEditor Then
                CType(cntrl, Infragistics.Win.UltraWinEditors.UltraDateTimeEditor).Enabled = boln
            ElseIf TypeOf cntrl Is Infragistics.Win.UltraWinEditors.UltraComboEditor Then
                CType(cntrl, Infragistics.Win.UltraWinEditors.UltraComboEditor).Enabled = boln
            End If
        Next cntrl

    End Sub
    Public Function checkTxtboxNFocusIt(PanelOrForm As Control) As Boolean

        For Each cntrl As Control In PanelOrForm.Controls
            'ClearTextBox(cntrl)
            If TypeOf cntrl Is System.Windows.Forms.TextBox Then
                If CType(cntrl, System.Windows.Forms.TextBox).Text = String.Empty Then CType(cntrl, System.Windows.Forms.TextBox).Focus() : Return False
            ElseIf TypeOf cntrl Is Infragistics.Win.UltraWinEditors.UltraTextEditor Then
                If CType(cntrl, Infragistics.Win.UltraWinEditors.UltraTextEditor).Text = String.Empty Then CType(cntrl, Infragistics.Win.UltraWinEditors.UltraTextEditor).Focus() : Return False
            End If
        Next cntrl
        Return True
    End Function
    'Public Function GetValue(ByVal tblname As String, ByVal Field As String, ByVal createria As String) As String
    '    If ds.Tables.Contains(tblname) Then
    '        ds.Tables.Remove(tblname)
    '    End If
    '    Dim con As New SqlConnection(conn_str)
    '    If con.State = ConnectionState.Closed Then con.Open()
    '    cmd.CommandText = "select " & Field & " from " & tblname & " where " & createria & ""
    '    cmd.Connection = con
    '    da.SelectCommand = cmd
    '    da.Fill(ds, tblname)
    '    Try
    '        GetValue = ds.Tables(tblname).Rows(0).Item(Field)
    '    Catch ex As Exception
    '    End Try
    'End Function
    Public Function WholeNum(ByVal Number As Integer, ByVal Size As Integer) As String
        Dim zerro As String = ""
        For i = Number.ToString.Length To Size - 1
            zerro += "0"
        Next
        Return zerro & Number
    End Function
    Public Function getdata(tableName As String) As DataSet
        connection = New SqlConnection(conn_str)
        connection.Open()
        If ds.Tables.Contains(tableName) Then ds.Tables.Remove(tableName)
        Dim sql As String = "SELECT * From " + tableName
        da = New SqlDataAdapter(sql, connection)
        ds = New DataSet
        da.Fill(ds, tableName)
        connection.Close()
        Return ds
    End Function
    Public Function GetDs(query As String, table As String) As DataSet
        Try
            connection = New SqlConnection(conn_str)
            connection.Open()
            If ds.Tables.Contains(table) Then ds.Tables.Remove(table)
            System.Windows.Forms.Application.DoEvents()
            da = New SqlDataAdapter(query, connection)
            da.Fill(ds, table)
            connection.Close()
            GetDs = ds
        Catch ex As Exception

        End Try

    End Function
    Public Sub ComboFill(table As String, Colums As String, Condition As String, Obj As Object, DispayVal As String, valueM As String)
        Try
            If Condition.Length = 0 Then Condition = " 1=1 "
            If dsCombo.Tables.Contains(table) Then dsCombo.Tables.Remove(table)
            connection = New SqlConnection(conn_str)
            connection.Open()
            System.Windows.Forms.Application.DoEvents()
            da = New SqlDataAdapter("Select " & Colums & " from " & table & " Where " & Condition, connection)
            da.Fill(dsCombo, table)
            connection.Close()
            Obj.DataSource = dsCombo.Tables(table)
            Obj.ValueMember = valueM
            Obj.DisplayMember = DispayVal
            Obj.DisplayLayout.Bands(0).ColHeadersVisible = False
            'Obj.DisplayLayout.Bands(0).Columns(0).Hidden = True
        Catch ex As Exception
        End Try
    End Sub
    Function Exist(table As String, condition As String) As Boolean
        Try
            ds = gcls.Gds(table, condition)
            If ds.Tables(table).Rows.Count = 0 Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Sub Filler(table As String, Colums As String, Condition As String, Obj As Object)
        Try
            If dsCombo.Tables.Contains(table) Then dsCombo.Tables.Remove(table)
            If Condition.Length = 0 Then Condition = " 1=1 "
            connection = New SqlConnection(conn_str)
            connection.Open()
            System.Windows.Forms.Application.DoEvents()
            da = New SqlDataAdapter("Select " & Colums & " from " & table & " Where " & Condition, connection)
            da.Fill(dsCombo, table)
            connection.Close()
            Obj.DataSource = dsCombo.Tables(table)
        Catch ex As Exception

        End Try

    End Sub
    Function SpName() As String
        Dim gd() As String = GetDate.Split(" "c)
        Dim d() As String
        Dim a, b As Integer
        If gd(0).Contains("-") Then
            d = gd(0).Split("-"c)
        Else
            d = gd(0).Split("/"c)
        End If
        Dim t() As String = gd(1).Split(":"c)

        Dim str As String = ""
        If d(0).Length = 4 Then
            a = 0
            b = 2
        Else
            a = 2
            b = 0
        End If

        str = str & WholeNum(d(a).Substring(2, 2), 2)
        str = str & WholeNum(d(1), 2)
        str = str & WholeNum(d(b), 2)
        str = str & WholeNum(t(0), 2)
        str = str & WholeNum(t(1), 2)
        str = str & WholeNum(t(2), 2)
        Return str
    End Function
    Function InvoiceNum(type As String, branchCode As String, column As String, table As String) As String
        Dim str As String
        Dim brCod As String() = branchCode.Split(":")
        Dim c1, c2 As String
        If brCod.Length = 2 Then
            c1 = brCod(0)
            c2 = brCod(1)
        Else
            c1 = " Br "
            c2 = brCod(0)
        End If
        Dim dt As String = SpName().ToString.Substring(0, 6)
        Dim valu As String = GetMaxVal(table, column, c1 & " = " & c2 & " And Ano like '" & dt & "%'")
        Dim Prefix As String = type.Substring(0, 2).ToUpper
        If valu.ToString.Length = 0 Or valu = 0 Then
            str = Prefix & dt & "01-" & c2
        Else
            str = Prefix & (valu + 1) & "-" & c2
        End If
        Return str
    End Function
    Public Function GetMaxSr(Prefix As Char, ByVal field As String, ByVal tblname As String, ByVal Condition As String) As String
        Dim cmd As New SqlCommand
        Dim Zeros As String = ""
        Dim con As New SqlConnection(ConnectionString)
        If con.State = ConnectionState.Closed Then con.Open()
        Dim Num As String = ""
        cmd.CommandText = "select isnull(max(" & field & "),0) from " & tblname & " where " & Condition & ""
        cmd.Connection = con
        Num = cmd.ExecuteScalar
        Try

            If Not Num.ToString.Length = 1 Then
                Num = Num.ToString.Substring(1, Num.ToString.Length - 1)
            End If
            Return Prefix & WholeNum((Val(Num) + 1), 5)
        Catch ex As Exception

            Return Prefix & WholeNum(1, 5)
        End Try

    End Function
    'Public Function Gds(ByVal TableName As String, ByVal Condition As String) As DataSet
    '    Try
    '        If Condition.Length = 0 Then Condition = " 1=1 "

    '        If ds.Tables.Contains(TableName) Then
    '            ds.Tables.Remove(TableName)
    '        End If

    '        connection = New SqlConnection(conn_str)
    '        connection.Open()
    '        Application.DoEvents()
    '        da = New SqlDataAdapter("Select * from " & TableName & " Where " & Condition, connection)
    '        da.Fill(ds, TableName)
    '        Return ds
    '    Catch ex As Exception

    '    End Try

    'End Function
    'public Function GDs(TableName As String, Colums As String, Condition As String) As DataSet
    '    Try
    '       If Condition.Length = 0 Then Condition = " 1=1 "
    '        If ds.Tables.Contains(TableName) Then
    '            ds.Tables.Remove(TableName)
    '        End If

    '        connection = New SqlConnection(conn_str)
    '        connection.Open()
    '        Application.DoEvents()
    '        da = New SqlDataAdapter("Select " & Colums & " from " & TableName & " Where " & Condition, connection)
    '        da.Fill(ds, TableName)
    '        Return ds
    '    Catch ex As Exception

    '    End Try
    'End Function
    Function GetMaxVal(TableName As String, Column As String, Condition As String) As Integer
        Try
            ds = gcls.Gds(TableName, " Max(" & Column & ") as " & Column, Condition)
            If ds.Tables(TableName).Rows.Count = 0 Then Return 0
            If ds.Tables(TableName).Rows(0).Item(Column).ToString.Length = 0 Then Return 0
            Return ds.Tables(TableName).Rows(0).Item(Column)
        Catch ex As Exception

        End Try

    End Function
    '++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    Function con() As SqlConnection
        If cn.State = ConnectionState.Closed Then cn.Open()
        Return cn
    End Function
    Function ConditionChecker(ByVal ToBeCheckCondition As String) As String
        If ToBeCheckCondition = "" Then Return " 1 = 1 "
        Return ToBeCheckCondition
    End Function
    '++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    Function insertdata(ByVal tablename As String, ByVal fields As String, ByVal value As String)
        Try
            cmd.CommandText = "insert into " & tablename & " (" & fields & ") values (" & value & ")"
            cmd.Connection = con()
            cmd.ExecuteNonQuery()
            Return "Saved"
        Catch ex As Exception
            Return "Error"
        End Try

    End Function
    Function deletedata(ByVal tablename As String, ByVal condition As String)
        Try
            cmd.CommandText = "delete from " & tablename & " where " & condition & ""
            cmd.Connection = con()
            cmd.ExecuteNonQuery()
            Return "Delete"
        Catch ex As Exception
            Return "Error"
        End Try
    End Function
    Function Updatedata(ByVal tablename As String, ByVal valu As String, ByVal condition As String)
        Try
            cmd.CommandText = "Update " & tablename & " set " & valu & " where " & condition & ""
            cmd.Connection = con()
            cmd.ExecuteNonQuery()
            Return "Update"
        Catch ex As Exception
            Return "Error"
        End Try
    End Function
    '++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    Function GetImage(ByVal URL As String) As System.Drawing.Image
        Dim Request As System.Net.HttpWebRequest
        Dim Response As System.Net.HttpWebResponse
        Try
            Request = System.Net.WebRequest.Create(URL)
            Response = CType(Request.GetResponse, System.Net.WebResponse)


            If Request.HaveResponse Then 'Did we really get a response?
                If Response.StatusCode = Net.HttpStatusCode.OK Then 'Is the status code 200? (You can check for more)
                    GetImage = System.Drawing.Image.FromStream(Response.GetResponseStream)
                End If
            End If

        Catch e As System.Net.WebException
            MsgBox("A web exception has occured [" & URL & "]." & vbCrLf & " System returned: " & e.Message, MsgBoxStyle.Exclamation, "Error!")
            Exit Try
        Catch e As System.Net.ProtocolViolationException
            MsgBox("A protocol violation has occured [" & URL & "]." & vbCrLf & "  System returned: " & e.Message, MsgBoxStyle.Exclamation, "Error!")
            Exit Try
        Catch e As System.Net.Sockets.SocketException
            MsgBox("Socket error [" & URL & "]." & vbCrLf & "  System returned: " & e.Message, MsgBoxStyle.Exclamation, "Error!")
            Exit Try
        Catch e As System.IO.EndOfStreamException
            MsgBox("An IO stream exception has occured. System returned: " & e.Message, MsgBoxStyle.Exclamation, "Error!")
            Exit Try
        Finally
            GetImage = Nothing
        End Try

    End Function
    Public Function ConvertImage(ByVal myImage As Image) As Byte()

        Dim mstream As New MemoryStream
        myImage.Save(mstream, System.Drawing.Imaging.ImageFormat.Jpeg)

        Dim myBytes(mstream.Length - 1) As Byte
        mstream.Position = 0

        mstream.Read(myBytes, 0, mstream.Length)

        Return myBytes

    End Function
    Public Function ConvertToRbg(ByVal HexColor As String) As Color
        Dim Red As String
        Dim Green As String
        Dim Blue As String
        HexColor = Replace(HexColor, "#", "")
        Red = Val("&H" & Mid(HexColor, 1, 2))
        Green = Val("&H" & Mid(HexColor, 3, 2))
        Blue = Val("&H" & Mid(HexColor, 5, 2))
        Return Color.FromArgb(Red, Green, Blue)
    End Function
    Public Sub CreateWordDocument(path As String, dg As Object)

        Dim objWord As Word.Application
        Dim objDoc As Word.Document
        Dim FileFullName As String = path & "\" & SpName() & ".docx"
        objWord = CreateObject("Word.Application")
        objWord.Visible = True
        objDoc = objWord.Documents.Add

        Dim _RowCount As Integer = dg.Rows.Count - 1
        Dim _ColCount As Integer = dg.Columns.Count - 1

        Dim str As String = "Ledger Report" & vbCrLf & vbCrLf
        objDoc.ActiveWindow.Selection.TypeText(str)

        With objDoc
            .ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekCurrentPageFooter
            .ActiveWindow.Selection.Font.Name = "Arial"
            .ActiveWindow.Selection.Font.Size = 8
            .ActiveWindow.Selection.TypeText("Acme Logic System " & GetDate())
            .ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekMainDocument
            .PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape
            '.PrintOut()
        End With
        Try
            Dim ht1 As Word.Table

            ht1 = objDoc.Tables.Add(objDoc.Bookmarks.Item("\endofdoc").Range, _
                                    _RowCount + 1, _ColCount + 1)
            ht1.Borders.OutsideColor = Word.WdColor.wdColorBlack
            ht1.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle
            ht1.Borders.InsideColor = Word.WdColor.wdColorBlack
            ht1.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle

            For i As Integer = 0 To _RowCount
                ht1.Rows.Add()
                For _col As Integer = 0 To _ColCount
                    Dim colType As Type = dg.Columns(_col).GetType
                    If colType.Name = "DataGridViewImageColumn" Then
                        Dim _image As Image = DirectCast(dg.Rows(i).Cells(_col).Value, Image)
                        Clipboard.SetImage(_image)
                        ht1.Cell(i + 1, _col + 1).Range.Paste()
                    Else
                        ht1.Cell(i + 1, _col + 1).Range.Text = _
                        dg.Rows(i).Cells(_col).Value.ToString()
                    End If
                Next
            Next
            objDoc.SaveAs2(FileFullName)
        Catch ex As Exception

        End Try

    End Sub
    Public Sub CreateExcelDocument(path As String, dg As Object)
        Dim xlApp As Microsoft.Office.Interop.Excel.Application
        Dim xlWorkBook As Workbook
        Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value
        Dim i As Integer
        Dim j As Integer

        xlApp = New Microsoft.Office.Interop.Excel.Application
        xlWorkBook = xlApp.Workbooks.Add(misValue)
        xlWorkSheet = xlWorkBook.Sheets("sheet1")

        Try
            For i = 0 To dg.RowCount - 1
                For j = 0 To dg.ColumnCount - 1
                    For k As Integer = 1 To dg.Columns.Count
                        xlWorkSheet.Cells(1, k) = dg.Columns(k - 1).HeaderText
                        xlWorkSheet.Cells(i + 2, j + 1) = dg(j, i).Value.ToString()
                    Next
                Next
            Next
        Catch ex As Exception

        End Try

        Dim p As String = path & "\" & SpName() & ".xlsx"
        xlWorkSheet.SaveAs(p)
        xlWorkBook.Close()
        xlApp.Quit()

        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)

        Dim res As MsgBoxResult
        res = MsgBox("Process completed, Would you like to open file?", MsgBoxStyle.YesNo)
        If (res = MsgBoxResult.Yes) Then
            Process.Start(p)
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
End Module
