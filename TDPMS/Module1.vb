Imports System.Text
Imports System.Windows.Forms

Module Module1

    Public db As String = "data.mdb"
    Dim cnn As New OleDb.OleDbConnection("Provider=Microsoft.Jet.Oledb.4.0; Data Source=" & Application.StartupPath & "\" & db)
    Public ds As New DataSet
    Public dt As New DataTable
    Dim cmd As New OleDb.OleDbCommand
    Public Path As String = Application.StartupPath
    Function Ql(ByVal query As String) As Boolean
        Try
            If Not cnn.State = ConnectionState.Open Then cnn.Open()
            cmd.Connection = cnn
            cmd.CommandText = query
            cmd.ExecuteNonQuery()
            cnn.Close()
            Return True
        Catch ex As Exception
            MsgBox("error:QL=" & query)
            Return False
        End Try
    End Function
    Function CRT(ByVal table As String, ByVal feilds As String()) As Boolean
        Try
            If Ql("CREATE TABLE " & table & " ( " & A2S(feilds) & " )") Then Return True 'Customer_Number Counter,Customer_Name TEXT(50) NOT NULL , Customer_Surname TEXT(40)
            Return False
        Catch ex As Exception
            Return False
        End Try
    End Function
    Function INS(ByVal table As String, ByVal feilds As String(), ByVal val As String())
        Try

            If Ql("INSERT INTO " & table & "( " & A2S(feilds) & ") VALUES ( " & A2S(val) & " )") Then Return True
            Return False
        Catch ex As Exception
            Return False
        End Try
    End Function
    Function UPD(ByVal table As String, ByVal SetVal As String, ByVal Condition As String)
        Try

            If Ql("Update " & table & " set " & SetVal & " WHERE " & cCk(Condition)) Then Return True
            Return False
        Catch ex As Exception
            Return False
        End Try
    End Function
    Function DEL(ByVal table As String, ByVal condition As String) As Boolean
        Try
            If Ql("Delete from " & table & " WHERE " & cCk(condition)) Then Return True
            Return False

        Catch ex As Exception
            Return False
        End Try
    End Function
    Function A2S(ByVal a As String()) As String
        Dim s As String = ""
        For i = 0 To a.Length - 1
            s += a(i)
            If i <> a.Length - 1 Then
                s += ","
            End If
        Next
        Return s
    End Function
    Function CAQ(ByVal TbValues() As String, ByVal TbSyntax() As String) As String()
        Try
            If TbValues.Length <> TbSyntax.Length Then MsgBox("Size dont match") : Return TbValues

            For i = 0 To TbValues.Length - 1
                If TbSyntax(i) = "T" Or TbSyntax(i) = "D" Then
                    TbValues(i) = "'" & IIf(TbValues(i).Trim.Length = 0, "-", TbValues(i)) & "'"
                Else
                    TbValues(i) = Val(TbValues(i))
                End If
            Next
            Return TbValues
        Catch ex As Exception
            Return TbValues
        End Try
    End Function
    Function GDs(ByVal table As String, ByVal condition As String) As DataSet
        Try

            If Not cnn.State = ConnectionState.Open Then cnn.Open()
            Dim s As String = "SELECT * FROM " & table & " Where " & cCk(condition)
            Dim da As New OleDb.OleDbDataAdapter(s, cnn)
            If ds.Tables.Contains(table) Then ds.Tables.Remove(table)
            da.Fill(ds, table)
            Return ds
        Catch ex As Exception
            MsgBox("GDS:" & ex.Message)
            Return ds
        End Try

    End Function

    Function GDx(ByVal table As String, ByVal condition As String) As DataSet
        Dim dx As New DataSet
        Try

            If Not cnn.State = ConnectionState.Open Then cnn.Open()
            Dim s As String = "SELECT * FROM " & table & " Where " & cCk(condition)
            Dim da As New OleDb.OleDbDataAdapter(s, cnn)
            If dx.Tables.Contains(table) Then dx.Tables.Remove(table)
            da.Fill(dx, table)
            Return dx
        Catch ex As Exception
            MsgBox("GDS:" & ex.Message)
            Return dx
        End Try

    End Function
    Function GDs(cells As String, ByVal table As String, ByVal condition As String) As DataSet
        If Not cnn.State = ConnectionState.Open Then cnn.Open()
        If cells.Length = 0 Then cells = "*"
        Dim s As String = "SELECT " & cells & " FROM " & table & " Where " & cCk(condition)
        Dim da As New OleDb.OleDbDataAdapter(s, cnn)
        If ds.Tables.Contains(table) Then ds.Tables.Remove(table)
        da.Fill(ds, table)
        Return ds
    End Function
    Function GDsFQ(ByVal Query As String, datatableName As String) As DataSet
        Try
            If Not cnn.State = ConnectionState.Open Then cnn.Open()
            Dim s As String = Query
            Dim da As New OleDb.OleDbDataAdapter(s, cnn)
            If ds.Tables.Contains(datatableName) Then ds.Tables.Remove(datatableName)
            da.Fill(ds, datatableName)
            Return ds
        Catch ex As Exception
            MsgBox("GDS:" & ex.Message)
            Return ds
        End Try

    End Function
    Function GVa(ByVal table As String, ByVal ReturnCell As String, ByVal condition As String)
        GDs(table, cCk(condition))
        If ds.Tables(table).Rows.Count = 0 Then Return Nothing
        Return ds.Tables(table).Rows(0).Item(ReturnCell)
    End Function
    Function cCk(ByVal condition As String) As String
        Dim x As String = ""
        If condition.Length > 3 Then
            x = condition
        Else
            x = " 1 = 1"
        End If
        Return x
    End Function
    Function DGC(ByVal dg As DataGridView, ByVal row As Integer, ByVal cell As Integer) As DataGridViewCell
        Return dg.Rows(row).Cells(cell)
    End Function
    Function C2A(ByVal array1 As String(), ByVal array2 As String()) As String
        Dim str As String = ""
        Try
            For i = 0 To array1.Length - 1
                str += array1(i) & "=" & array2(i)
                If i <> array1.Length - 1 Then
                    str += ","
                End If
            Next
            Return str
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return "error:001213"
    End Function
    Function AnV(ByVal array1 As String(), ByVal array2 As String()) As String()
        Dim str(array1.Length - 1) As String

        Try
            'Customer_Number Counter,Customer_Name TEXT(50) NOT NULL , Customer_Surname TEXT(40)
            For i = 0 To array1.Length - 1
                str(i) = array1(i)
                If array2(i) = "C" Then
                    str(i) += " Counter"
                ElseIf array2(i) = "T" Then
                    str(i) += " TEXT(100)"
                ElseIf array2(i) = "N" Then
                    str(i) += " Number"
                ElseIf array2(i) = "D" Then
                    str(i) += " DATE"
                End If
            Next
            Return str
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        End Try
        Return Nothing
    End Function
    Function Max(ByVal table As String, ByVal condition As String, ByVal cell As String) As String
        Try
            If Not cnn.State = ConnectionState.Open Then cnn.Open()
            Dim s As String = "SELECT Max(" & cell & ")as cell FROM " & table & " Where " & cCk(condition)
            Dim da As New OleDb.OleDbDataAdapter(s, cnn)
            If ds.Tables.Contains(table) Then ds.Tables.Remove(table)
            da.Fill(ds, table)
            If ds.Tables(table).Rows(0).Item("cell").ToString.Length = 0 Then Return 0
            Return ds.Tables(table).Rows(0).Item("cell")
        Catch ex As Exception
            Return 0
        End Try
        Return 0
    End Function
    Function Num(ByVal nmbr As Integer, ByVal len As Integer) As String
        Try
            Dim str As String = ""
            For i = 0 To len - nmbr.ToString.Length - 1
                str += "0"
            Next
            Return str & nmbr
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Function EXV(ByVal table As String, ByVal condition As String) As Boolean
        Try
            GDs(table, condition)
            If ds.Tables(table).Rows.Count = 0 Then Return False
            If ds.Tables(table).Rows.Count >= 1 Then Return True
            Return False
        Catch ex As Exception
            Return False
        End Try
    End Function
    Sub dgFill(ByVal dv As DataGridView, ByVal feilds As String(), ByVal table As String)
        Try
            dv.Rows.Clear()
            For i = 0 To GDs(table, "").Tables(table).Rows.Count - 1
                With GDs(table, "").Tables(table).Rows(i)
                    dv.Rows.Add()
                    For j = 0 To feilds.Length - 1
                        DGC(dv, i, j).Value = .Item(feilds(j))
                    Next
                End With
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Sub Clr(ByVal root As Control)
        For Each cntrl As Control In root.Controls
            Clr(cntrl)
            If TypeOf cntrl Is TextBox Then   'If c.Name.StartsWith("t") Then
                CType(cntrl, TextBox).Text = String.Empty
            End If
        Next cntrl
    End Sub
    Sub ENB(ByVal root As Control, B As Boolean)
        For Each cntrl As Control In root.Controls
            Clr(cntrl)
            If TypeOf cntrl Is TextBox Then   'If c.Name.StartsWith("t") Then
                CType(cntrl, TextBox).Enabled = B
            End If
        Next cntrl
    End Sub
    Sub fillGVCmb(ByVal dgv As DataGridView, ByVal table As String, ByVal condition As String, ByVal CellInfo As String(), ByVal RowIndex As Integer, ByVal CellIndex As Integer)
        Try
            Dim dgvcc As New DataGridViewComboBoxCell

            dgvcc = dgv.Rows(RowIndex).Cells(CellIndex)
            dgvcc.DataSource = Nothing
            dgvcc.Value = Nothing
            dgvcc.DataSource = GDs(table, condition).Tables(table)
            dgvcc.DisplayMember = CellInfo(0)
            dgvcc.ValueMember = CellInfo(1)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub
    Function invoiceNumnber(ByVal table As String, ByVal typeOfNum As Integer, ByVal returncellNo As String) As String
        Dim st As String = ""
        If typeOfNum < 0 Then typeOfNum = 1

        If typeOfNum = 1 Then
            st = "Purchase"
        ElseIf typeOfNum = 2 Then
            st = "Sales"
        ElseIf typeOfNum = 3 Then
            st = "Bank-Purchase"
        ElseIf typeOfNum = 4 Then
            st = "Bank-Sales"
        ElseIf typeOfNum = 5 Then
            st = "Transaction"
        ElseIf typeOfNum = 6 Then
            st = "Purchase-Order"
        ElseIf typeOfNum = 7 Then
            st = "Sales-Order"
        ElseIf typeOfNum = 8 Then
            st = "Bank-Purchase-Order"
        ElseIf typeOfNum = 9 Then
            st = "Bank-Sales-Order"
        End If

        If Max(table, "type='" & st & "'", returncellNo) = Nothing Then
            Return typeOfNum & Num(1, 5)
        Else
            Return Max(table, "type='" & st & "'", returncellNo) + 1
        End If
    End Function
    Function IfTableExist(ByVal table) As Boolean
        Try
            ds = GDs(table, "")
            If ds.Tables.Contains(table) <> 0 Then Return True
            Return False
        Catch ex As Exception
            Return False
        End Try
    End Function
    Function SpellNumber(ByVal MyNumber As String) As String
        Dim Dollars As String = ""
        Dim Cents As String = ""
        Dim Temp As String = ""
        Dim DecimalPlace, Count As Integer
        Dim Place(9) As String
        Place(2) = " Thousand "
        Place(3) = " Million "
        Place(4) = " Billion "
        Place(5) = " Trillion "
        ' String representation of amount.
        MyNumber = Trim(Str(MyNumber))
        ' Position of decimal place 0 if none.
        DecimalPlace = InStr(MyNumber, ".")
        ' Convert cents and set MyNumber to dollar amount.
        If DecimalPlace > 0 Then
            MyNumber = Mid(MyNumber, DecimalPlace + 1) & "00"
            Cents = GetTens(MyNumber.Substring(0, 2)) 'Left(Mid(MyNumber, DecimalPlace + 1) & "00", 2)
            MyNumber = Trim(MyNumber.Substring(0, DecimalPlace - 1)) 'Left(MyNumber, DecimalPlace - 1)
        End If
        Count = 1
        Do While MyNumber <> ""
            Temp = GetHundreds(MyNumber.Substring(MyNumber.Length - 3, 3)) 'Right(MyNumber, 3)
            If Temp <> "" Then Dollars = Temp & Place(Count) & Dollars
            If Len(MyNumber) > 3 Then
                MyNumber = MyNumber.Substring(0, MyNumber.Length - 3) 'Left(MyNumber, Len(MyNumber) - 3)
            Else
                MyNumber = ""
            End If
            Count = Count + 1
        Loop
        Select Case Dollars
            Case ""
                Dollars = "No Rupees"
            Case "One"
                Dollars = "One Rupees"
            Case Else
                Dollars = Dollars & " Rupees"
        End Select
        Select Case Cents
            Case ""
                Cents = " and No paysay"
            Case "One"
                Cents = " and One paysay"
            Case Else
                Cents = " and " & Cents & " paysay"
        End Select
        SpellNumber = Dollars & Cents
    End Function
    ' Converts a number from 100-999 into text 
    Function GetHundreds(ByVal MyNumber As String) As String
        Dim Result As String = ""
        If Val(MyNumber) = 0 Then : Return "" : Exit Function : End If
        MyNumber = "000" & MyNumber
        MyNumber = MyNumber.Substring(MyNumber.Length - 3, 3) 'Right("000" & MyNumber, 3)
        ' Convert the hundreds place.
        If Mid(MyNumber, 1, 1) <> "0" Then
            Result = GetDigit(Mid(MyNumber, 1, 1)) & " Hundred "
        End If
        ' Convert the tens and ones place.
        If Mid(MyNumber, 2, 1) <> "0" Then
            Result = Result & GetTens(Mid(MyNumber, 2))
        Else
            Result = Result & GetDigit(Mid(MyNumber, 3))
        End If
        GetHundreds = Result
    End Function
    ' Converts a number from 10 to 99 into text. 
    Function GetTens(ByVal TensText As String) As String
        Dim Result As String
        Result = ""           ' Null out the temporary function value.
        If Val(TensText.Substring(0, 1)) = 1 Then   'Left(TensText, 1) If value between 10-19...
            Select Case Val(TensText)
                Case 10 : Result = "Ten"
                Case 11 : Result = "Eleven"
                Case 12 : Result = "Twelve"
                Case 13 : Result = "Thirteen"
                Case 14 : Result = "Fourteen"
                Case 15 : Result = "Fifteen"
                Case 16 : Result = "Sixteen"
                Case 17 : Result = "Seventeen"
                Case 18 : Result = "Eighteen"
                Case 19 : Result = "Nineteen"
                Case Else
            End Select
        Else                                 ' If value between 20-99...
            Select Case Val(TensText.Substring(0, 1))   'Left(TensText, 1)
                Case 2 : Result = "Twenty "
                Case 3 : Result = "Thirty "
                Case 4 : Result = "Forty "
                Case 5 : Result = "Fifty "
                Case 6 : Result = "Sixty "
                Case 7 : Result = "Seventy "
                Case 8 : Result = "Eighty "
                Case 9 : Result = "Ninety "
                Case Else
            End Select
            Result = Result & GetDigit(TensText.Substring(TensText.Length - 1, 1))  'Right(TensText, 1) Retrieve ones place.
        End If
        GetTens = Result
    End Function
    ' Converts a number from 1 to 9 into text. 
    Function GetDigit(ByVal Digit As String) As String
        Select Case Val(Digit)
            Case 1 : GetDigit = "One"
            Case 2 : GetDigit = "Two"
            Case 3 : GetDigit = "Three"
            Case 4 : GetDigit = "Four"
            Case 5 : GetDigit = "Five"
            Case 6 : GetDigit = "Six"
            Case 7 : GetDigit = "Seven"
            Case 8 : GetDigit = "Eight"
            Case 9 : GetDigit = "Nine"
            Case Else : GetDigit = ""
        End Select
    End Function
    Public Sub Settings(ByVal formName As Windows.Forms.Form, ByVal panelName As Panel, ByVal mdifrm As Windows.Forms.Form)
        formName.BackColor = Color.White
        formName.MdiParent = mdifrm
        formName.Dock = DockStyle.Fill
        Dim x As Integer = (formName.Width / 2) - (panelName.Width / 2)
        Dim y As Integer = (formName.Height / 2) - (panelName.Height / 2)
        panelName.Location = New Point(x, y)
    End Sub
    Function insertData(ByVal table As String, ByVal feilds As String, ByVal val As String)
        Try

            If Not cnn.State = ConnectionState.Open Then cnn.Open()
            cmd.Connection = cnn
            cmd.CommandText = "INSERT INTO " & table & "( " & feilds & ") VALUES ( " & val & " )"
            cmd.ExecuteNonQuery()
            cnn.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Function updateData(ByVal table As String, ByVal SetVal As String, ByVal Condition As String)
        Try

            If Not cnn.State = ConnectionState.Open Then cnn.Open()
            cmd.Connection = cnn
            cmd.CommandText = "Update " & table & " set " & SetVal & " WHERE " & conditionCheck(Condition)
            cmd.ExecuteNonQuery()
            cnn.Close()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Function GetDs(ByVal table As String, ByVal condition As String) As DataSet
        Try

            If Not cnn.State = ConnectionState.Open Then cnn.Open()
            Dim s As String = "SELECT * FROM " & table & " Where " & conditionCheck(condition)
            Dim da As New OleDb.OleDbDataAdapter(s, cnn)
            If ds.Tables.Contains(table) Then ds.Tables.Remove(table)
            da.Fill(ds, table)
            Return ds
        Catch ex As Exception
            Return ds
        End Try

    End Function
    Function DelData(ByVal table As String, ByVal condition As String) As Boolean
        Try
            If cnn.State = ConnectionState.Closed Then cnn.Open()

            cmd.Connection = cnn
            cmd.CommandText = "Delete from " & table & " WHERE " & conditionCheck(condition)
            cmd.ExecuteNonQuery()
            cnn.Close()
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
    Function getValue(ByVal table As String, ByVal ReturnCell As String, ByVal condition As String)
        GetDs(table, conditionCheck(condition))
        If ds.Tables(table).Rows.Count = 0 Then Return Nothing
        Return ds.Tables(table).Rows(0).Item(ReturnCell)
    End Function
    Function conditionCheck(ByVal condition As String) As String
        Dim x As String = ""
        If condition.Length > 3 Then
            x = condition
        Else
            x = " 1 = 1"
        End If
        Return x
    End Function
    Public Sub child_show(ByVal frm As Form, ByVal mdi As Form)
        Dim frm_exist As Boolean = False
        Try
            For Each child As Form In mdi.MdiChildren
                If child.Name = frm.Name Then
                    frm_exist = True
                End If
            Next
            If Not frm_exist Then
                frm.MdiParent = mdi
                'frm.WindowState = FormWindowState.Minimized

                frm.Dock = DockStyle.Fill
                frm.Show()
                frm.WindowState = FormWindowState.Normal
            Else
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Public Sub MDISettings(ByVal formName As Windows.Forms.Form, ByVal panelName As Panel, ByVal mdifrm As Windows.Forms.Form)
        formName.BackColor = Color.White
        formName.MdiParent = mdifrm
        formName.Dock = DockStyle.Fill
        Dim x As Integer = (formName.Width / 2) - (panelName.Width / 2)
        Dim y As Integer = (formName.Height / 2) - (panelName.Height / 2)
        panelName.Location = New Point(x, y)
    End Sub
    Function AutoCompleteFiller(Field As String) As AutoCompleteStringCollection
        Try
            Dim T1 As New AutoCompleteStringCollection()
            Dim lst As New List(Of String)
            ds = GDs("AutoCompleteTb", "Field='" & Field & "'")
            For i = 0 To ds.Tables("AutoCompleteTb").Rows.Count - 1
                lst.Add(ds.Tables("AutoCompleteTb").Rows(i).Item("txt").ToString.Trim)
            Next
            T1.AddRange(lst.ToArray)
            Return T1
        Catch ex As Exception
            MessageBox.Show("Can not open connection ! ")
            Return Nothing
        End Try
    End Function
    Sub trapTextboxs(obj As Object)

        For Each ctrl As Control In obj.Controls
            If TypeOf ctrl Is TextBox Then
                CType(ctrl, TextBox).AutoCompleteCustomSource = AutoCompleteFiller(CType(ctrl, TextBox).Name)
                CType(ctrl, TextBox).AutoCompleteMode = AutoCompleteMode.Suggest
                CType(ctrl, TextBox).AutoCompleteSource = AutoCompleteSource.CustomSource
            End If
        Next

    End Sub
    Sub AutoCompletInserter(txt As String, Field As String)
        Try
            If Not EXV(TbAutoCompName, "txt='" & txt & "' and Field='" & Field & "'") Then
                insertData(TbAutoCompName, "txt,Field", "'" & txt & "','" & Field & "'")
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub CheckAllAutoCompletFields(formName As Object)
        Try
            For Each ctrl As Control In formName.Controls
                If TypeOf ctrl Is TextBox Then
                    AutoCompletInserter(CType(ctrl, TextBox).Text, CType(ctrl, TextBox).Name)
                End If
            Next
        Catch ex As Exception

        End Try

    End Sub
    Sub DgAutoCompletInserter(dgg As DataGridView, FrmNum As Double)
        Try
            For i = 0 To dgg.RowCount - 1
                For j = 0 To dgg.ColumnCount - 1
                    If dgg.Rows(i).Cells(j).ReadOnly = False Then
                        AutoCompletInserter(dgg.Rows(i).Cells(j).Value, FrmNum)
                    End If
                Next
            Next
        Catch ex As Exception

        End Try
    End Sub
#Region "Clear all textboxs"
    Sub clr(obj As Object)
        For Each ctrl As Control In obj.Controls
            If TypeOf ctrl Is TextBox Then
                CType(ctrl, TextBox).Clear()
            End If
        Next
    End Sub
#End Region
#Region "Check for empty fields"
    Function AnyEmptyFields(fields As String(), formName As Form) As Boolean
        Try


            Dim TT As TextBox
            For i = 0 To fields.Count - 1
                TT = formName.Controls.Find(fields(i), True)(0)
                TT.BackColor = Color.White 'System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
                If TT.Text.Length = 0 Then
                    TT.Select()
                    TT.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
                    Return False
                End If
            Next
            Return True
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function
#End Region
    Public Function GMx4mSkey(columName As String, tableName As String, Condition As String, PreFix As String) As String
        Try
            Dim num As Integer = 0
            Dim str As String = ""
            Dim sizeOfPrefix As Integer = PreFix.Length
            If Not cnn.State = ConnectionState.Open Then cnn.Open()
            Dim s As String = "SELECT Max(" & columName & ")as x FROM " & tableName & " Where " & cCk(Condition)
            '"select isnull(max(SUBSTRING(" & columName & "," & sizeOfPrefix + 1 & ",len(" & columName & ")-" & sizeOfPrefix & ")),0) as x from " & tableName & " where " & Condition & ""
            Dim da As New OleDb.OleDbDataAdapter(s, cnn)
            If ds.Tables.Contains(tableName) Then ds.Tables.Remove(tableName)
            da.Fill(ds, tableName)
            str = ds.Tables(tableName).Rows(0).Item("x").ToString
            num = Val(str.Substring(1, str.Length - 1))
            If Val(num) = 0 Then Return PreFix & "01"
            Return PreFix & num + 1
        Catch ex As Exception
            Return PreFix & SpName.Substring(0, 6) & "01"
        End Try
    End Function
    Public Function SpDateKey(columName As String, tableName As String, PreFix As String) As String
        Dim str As String = ""
        Dim i = 0
h1:
        i += 1
        str = PreFix & SpName.Substring(0, 6) & WholeNum(i, 2)
        If EXV(tableName, columName & "='" & str & "'") Then GoTo h1

        Return str
    End Function
    Public Function SpDateKey2(columName As String, tableName As String, PreFix As String) As String
        Dim str As String = ""
        Dim i = 0
h1:
        i += 1
        str = PreFix & "-" & WholeNum(i, 2)
        If EXV(tableName, columName & "='" & str & "'") Then GoTo h1

        Return str
    End Function
    Function SpName() As String
        Dim gd() As String = Now.Date.ToString.Split(" "c)
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
    Public Function WholeNum(ByVal Number As Integer, ByVal Size As Integer) As String
        Dim zerro As String = ""
        For i = Number.ToString.Length To Size - 1
            zerro += "0"
        Next
        Return zerro & Number
    End Function
    Function ConvertNum(ByVal Input As Long) As String 'Call this function passing the number you desire to be changed
        Dim output As String = Nothing
        If Input < 1000 Then
            output = FindNumber(Input) 'if its less than 1000 then just look it up
        Else
            Dim nparts() As String 'used to break the number up into 3 digit parts
            Dim n As String = Input 'string version of the number
            Dim i As Long = Input.ToString.Length 'length of the string to help break it up

            Do Until i - 3 <= 0
                n = n.Insert(i - 3, ",") 'insert commas to use as splitters
                i = i - 3 'this insures that we get the correct number of parts
            Loop
            nparts = n.Split(",") 'split the string into the array

            i = Input.ToString.Length 'return i to initial value for reuse
            Dim p As Integer = 0 'p for parts, used for finding correct suffix
            For Each s As String In nparts
                Dim x As Long = CLng(s) 'x is used to compare the part value to other values
                p = p + 1
                If p = nparts.Length Then 'if p = number of elements in the array then we need to do something different
                    If x <> 0 Then
                        If CLng(s) < 100 Then
                            output = output & " And " & FindNumber(CLng(s)) ' look up the number, no suffix 
                        Else                                                ' required as this is the last part
                            output = output & " " & FindNumber(CLng(s))
                        End If
                    End If
                Else 'if its not the last element in the array
                    If x <> 0 Then
                        If output = Nothing Then 'we have to check this so we don't add a leading space
                            output = output & FindNumber(CLng(s)) & " " & FindSuffix(i, CLng(s)) 'look up the number and suffix
                        Else 'spaces must go in the right place
                            output = output & " " & FindNumber(CLng(s)) & " " & FindSuffix(i, CLng(s)) 'look up the snumber and suffix
                        End If
                    End If
                End If
                i = i - 3 'reduce the suffix counter by 3 to step down to the next suffix
            Next
        End If
        Return output
    End Function

    Function FindNumber(ByVal Number As Long) As String
        Dim Words As String = Nothing
        Dim Digits() As String = {"Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven",
      "Eight", "Nine", "Ten"}
        Dim Teens() As String = {"", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen",
       "Eighteen", "Nineteen"}

        If Number < 11 Then
            Words = Digits(Number)

        ElseIf Number < 20 Then
            Words = Teens(Number - 10)

        ElseIf Number = 20 Then
            Words = "Twenty"

        ElseIf Number < 30 Then
            Words = "Twenty " & Digits(Number - 20)

        ElseIf Number = 30 Then
            Words = "Thirty"

        ElseIf Number < 40 Then
            Words = "Thirty " & Digits(Number - 30)

        ElseIf Number = 40 Then
            Words = "Fourty"

        ElseIf Number < 50 Then
            Words = "Fourty " & Digits(Number - 40)

        ElseIf Number = 50 Then
            Words = "Fifty"

        ElseIf Number < 60 Then
            Words = "Fifty " & Digits(Number - 50)

        ElseIf Number = 60 Then
            Words = "Sixty"

        ElseIf Number < 70 Then
            Words = "Sixty " & Digits(Number - 60)

        ElseIf Number = 70 Then
            Words = "Seventy"

        ElseIf Number < 80 Then
            Words = "Seventy " & Digits(Number - 70)

        ElseIf Number = 80 Then
            Words = "Eighty"

        ElseIf Number < 90 Then
            Words = "Eighty " & Digits(Number - 80)

        ElseIf Number = 90 Then
            Words = "Ninety"

        ElseIf Number < 100 Then
            Words = "Ninety " & Digits(Number - 90)

        ElseIf Number < 1000 Then
            Words = Number.ToString
            Words = Words.Insert(1, ",")
            Dim wparts As String() = Words.Split(",")
            Words = FindNumber(wparts(0)) & " " & "Hundred"
            Dim n As String = FindNumber(wparts(1))
            If CLng(wparts(1)) <> 0 Then
                Words = Words & " And " & n
            End If
        End If

        Return Words
    End Function

    Function FindSuffix(ByVal Length As Long, ByVal l As Long) As String
        Dim word As String

        If l <> 0 Then
            If Length > 12 Then
                word = "Trillion"
            ElseIf Length > 9 Then
                word = "Billion"
            ElseIf Length > 6 Then
                word = "Million"
            ElseIf Length > 3 Then
                word = "Thousand"
            ElseIf Length > 2 Then
                word = "Hundred"
            Else
                word = ""
            End If
        Else
            word = ""
        End If

        Return word
    End Function
    Sub OpenAllForms(frm As Form)
        Try


            For Each t As Type In frm.GetType().Assembly.GetTypes()
                If t.BaseType.Name = "Form" Then
                    If t.Name = frm.Name Then Continue For
                    CType(Activator.CreateInstance(t), Form).Show()
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub
    Sub dgTextboxToCombo(d As DataGridView, row As Integer, column As Integer, dt As DataTable)
        Try
            Dim gridComboBox As New DataGridViewComboBoxCell

            With d
                If .Rows.Count = 0 Then Exit Sub
                'For i = 0 To dt.Rows.Count - 1
                '    gridComboBox.Items.Add(dt.Rows(i).Item(0))
                'Next
                gridComboBox.DataSource = dt
                gridComboBox.DisplayMember = "Answer"
                gridComboBox.ValueMember = "Answer"
                'gridComboBox.Items.Add("B") 'Populate the Combobox
                'gridComboBox.Items.Add("C") 'Populate the Combobox
                .Item(column, row) = gridComboBox
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Sub dgsetting(d As DataGridView)
        With d
            .GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
            .ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .Anchor = System.Windows.Forms.AnchorStyles.Top
            .RowHeadersVisible = False
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .Rows.Clear()
            .Columns(1).ReadOnly = True
            .Columns(3).DataGridView.EditMode = DataGridViewEditMode.EditOnEnter
        End With
        dgcolor(d)
    End Sub
    Sub filldg(dgg As DataGridView, FormVal As String)
        Dim dtt As New DataTable
        dt = GDs(TNq, "FormRef=" & FormVal & " order by Sn ").Tables(TNq)
        Dim str As String = ""
        dgsetting(dgg)
        Dim x As Integer = 0
        Dim y As String() = {"", ""}
        Dim ans As String = ""
        Dim r As Integer = 0
        For i = 0 To dt.Rows.Count - 1

            With dgg
                Try
                    x = dt.Rows(i).Item("Question").ToString.Length
                    y = dt.Rows(i).Item("Question").ToString.Substring(1, x - 2).Split(":"c)
                Catch ex As Exception
                    ' MsgBox(ex.Message)
                End Try



                If Not y(0).ToLower = "empty" Then
                    .Rows.Add()
                    .Rows(r).Cells(1).Value = dt.Rows(i).Item("SN")
                    .Columns(1).ReadOnly = True
                    .Rows(r).Cells(2).Value = dt.Rows(i).Item("Question")

                    If dt.Rows(i).Item("Question").ToString.Trim.Length = 0 Then
                        .Rows(i).Cells(2).ReadOnly = IIf(dt.Rows(i).Item("Question").ToString.Trim.Length = 0, False, True)
                    Else
                        .Rows(i).Cells(2).ReadOnly = IIf(dt.Rows(i).Item("Question").ToString.Split(" ")(0).ToLower = "other", False, True)
                    End If


                    If Not dt.Rows(i).Item("AnsTypeRef") = 0 Then
                        dgTextboxToCombo(dgg, r, 3, GDs("Answer", TNa, "AnsTypeRef='" & dt.Rows(i).Item("AnsTypeRef") & "'").Tables(TNa))
                        dtt = GDs("Answer", TNa, "AnsTypeRef='" & dt.Rows(i).Item("AnsTypeRef") & "'").Tables(TNa)
                        Try
                            str = dtt.Rows(0).Item(0)
                        Catch ex As Exception
                            str = ""
                        End Try

                        .Rows(r).Cells(3).Value = str
                    End If

                ElseIf y(0).ToLower = "empty" Then
                    Dim temp As Integer = 0
                    ans = dt.Rows(i).Item("AnsTypeRef")
                    For j = 0 To y(1) - 1
                        .Rows.Add()
                        .Rows(j + r).Cells(1).Value = Chr(97 + j + r)
                        .Columns(1).ReadOnly = True
                        .Rows(j + r).Cells(2).ReadOnly = False
                        .Columns(3).DataGridView.EditMode = DataGridViewEditMode.EditOnEnter
                        If Not ans = 0 Then
                            dgTextboxToCombo(dgg, j + r, 3, GDs("Answer", TNa, "AnsTypeRef='" & ans & "'").Tables(TNa))
                            str = GDs("Answer", TNa, "AnsTypeRef='" & ans & "'").Tables(TNa).Rows(0).Item(0)
                            .Rows(j + r).Cells(3).Value = str
                        End If
                        temp = j
                    Next
                    r = r + temp
                End If

            End With

            r += 1
        Next
    End Sub

    Sub dgcolor(d As DataGridView)
        'Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        'DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Silver
        'DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black

        d.DefaultCellStyle.SelectionBackColor = Color.White
        d.DefaultCellStyle.SelectionForeColor = Color.Black
        '    'For i = 0 To d.ColumnCount - 1
        '    '    d.Columns(i).DefaultCellStyle = DataGridViewCellStyle1
        '    'Next
        '    ' Set RowHeadersDefaultCellStyle.SelectionBackColor so that its default
        '    ' value won't override DataGridView.DefaultCellStyle.SelectionBackColor.
        '    d.RowHeadersDefaultCellStyle.SelectionBackColor = Color.Empty

        '    ' Set the background color for all rows and for alternating rows. 
        '    ' The value for alternating rows overrides the value for all rows. 
        '    d.RowsDefaultCellStyle.BackColor = Color.LightGray
        '    d.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray

        '    ' Set the row and column header styles.
        '    d.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        '    d.ColumnHeadersDefaultCellStyle.BackColor = Color.Black
        '    d.RowHeadersDefaultCellStyle.BackColor = Color.Black
    End Sub
    Sub DigitTextBox_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
        'Just Digits
        If e.KeyChar = ChrW(8) Then
            e.Handled = False
        End If
        'Allow Backspace
    End Sub
    Friend Function GetDefaultBrowser() As String

        ' '' ''Dim p As New Process()
        ' '' ''p.StartInfo.FileName = GetDefaultBrowser()
        ' '' ''p.StartInfo.Arguments = "http://www.idea.org.pk/"
        ' '' ''p.Start()

        Dim browser As String = [String].Empty
        Dim key As Microsoft.Win32.RegistryKey = Nothing
        Dim Quote As String = Chr(34)
        Try

            key = My.Computer.Registry.ClassesRoot.OpenSubKey("HTTP\shell\open\command", False)

            ' trim off quotes
            browser = key.GetValue(Nothing).ToString().ToLower().Replace(Quote, "")
            If Not browser.EndsWith("exe") Then
                ' get rid of everything after the 'exe'
                browser = browser.Substring(0, browser.LastIndexOf(".exe") + 4)

            End If

        Finally
            If key IsNot Nothing Then
                key.Close()
            End If
        End Try

        Return browser

    End Function
    Sub ClearRecord(table As String, condition As String, d As DataGridView, frmNo As Integer)
        Dim a As String() = Now.ToString.Split(" ")
        Dim b As String() = a(0).Split("/")
        Dim cc As String() = a(1).Split(":")
        Dim valu As String = cc(2) & cc(1) & cc(0) 'b(0) & b(1) & b(2) & 
        Dim temp As String = InputBox("Enter " & valu, "Erase Record", "")

        If temp = valu Then
            DEL(table, condition)
            filldg(d, frmNo)
        Else
            MsgBox("Invalid input")
        End If
    End Sub
    Sub CreateNav(frmNum As Integer, panl As Panel)
        'Dim objForm As Form
        'Dim FullTypeName As String
        'Dim FormInstanceType As Type
        'FullTypeName = Application.ProductName & ".Form" & WholeNum(frmNum + 2, 2)
        'FormInstanceType = Type.GetType(FullTypeName, True, True)
        'objForm = CType(Activator.CreateInstance(FormInstanceType), Form)
        Dim usc As New UserControl1
        usc.frmNum = frmNum
        panl.Controls.Add(usc)
        panl.Location = New Point(10, 477)
        panl.Size = New Point(400, 50)
    End Sub

    Function Enc64(str As String) As String

        Dim bytesToEncode As Byte()
        bytesToEncode = Encoding.UTF8.GetBytes(str)

        Dim encodedText As String
        encodedText = Convert.ToBase64String(bytesToEncode)

        Return encodedText


    End Function
    Function Dec64(str As String) As String

        Try
            Dim decodedBytes As Byte()
            decodedBytes = Convert.FromBase64String(str)

            Dim decodedText As String
            decodedText = Encoding.UTF8.GetString(decodedBytes)
            Return decodedText

        Catch ex As Exception
            Return str
        End Try

    End Function
End Module
