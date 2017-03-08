Imports System.IO
Imports System.Net
Imports System.Windows.Forms
Imports System.Xml

Public Class Upgrade

    Dim locat As String = System.Reflection.Assembly.GetEntryAssembly.Location
    Dim MyDirectory As String = System.IO.Path.GetDirectoryName(locat)
    Public totalsize As String = ""
    Public link As String = ""
    Public Csize As String = ""
    Public amount As String = ""
    Public ext As String = ""
    Dim ds As New DataSet
    Dim dt As New DataTable
    Public AddressToUpgrade As String = "https://dl.dropbox.com/s/ds5iealhn8ifsg9/UpdateChecker.txt?dl=1"
    Public linkPre As String = "https://dl.dropbox.com/s/"
    Public linkPos As String = "?dl=1"
    Private Sub Upgrade_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not CheckForInternetConnection2() Then MsgBox("Please check you net connection and try again.") : Me.Close()

        CheckUpgrade()
        

    End Sub
    Sub CheckUpgrade()
        If File.Exists(MyDirectory + "\" + Me.ProductName + ".old") Then Button2.Enabled = True
        If File.Exists(MyDirectory + "\" + Me.ProductName + ".rol") Then File.Delete(MyDirectory + "\" + Me.ProductName + ".rol")
        Label4.Text = Me.ProductVersion
        Try

            Dim instance As WebClient = New WebClient
            Dim returnValue As String = ""
            Try
                returnValue = instance.DownloadString(AddressToUpgrade)
            Catch ex As Exception
                'MsgBox(ex.Message)
            End Try


            Dim xmlDoc As New XmlDocument
            xmlDoc.LoadXml(returnValue)

            Dim sReader As New StringReader(xmlDoc.InnerXml)
            ds.ReadXml(sReader)

            'SaveContent(MyDirectory + "\Check.xml", returnValue)
            'ds.Clear()
            'ds.ReadXml(MyDirectory + "\Check.xml")

            dt = ds.Tables(0).Select("Name='" & Me.ProductName & "'", "Ver desc").CopyToDataTable
            
            With dt.Rows(0)
                Label6.Text = .Item("Zip")
                Label1.Text = "8pmc6w5td32ko5u"
                Label2.Text = .Item("Exe")
                Label5.Text = .Item("Ver")   ' new version
                Panel2.Visible = True

                link = CreatLink(.Item("Exe"), .Item("Name"), "Exe", True)
                ext = link.Substring(link.Length - 9, 4)
            End With
            Dim vr1, vr2 As Integer
            Dim str1 As String() = Me.ProductVersion.Split(".")
            Dim str2 As String() = Label5.Text.Split(".")
            For i = 0 To str1.Length - 1 '---------------2----------------------------------
                vr1 = vr1 & IIf(i = 3, WholeNum(str1(i), 3), WholeNum(str1(i), 3))
            Next
            For i = 0 To str2.Length - 1 '---------------2----------------------------------
                vr2 = vr2 & IIf(i = 3, WholeNum(str2(i), 3), WholeNum(str2(i), 3))
            Next


            If vr2 > vr1 Then
                Button1.Enabled = True
                My.Settings.UpgradeFlag = "Yes"
            Else
                Button1.Enabled = False
                My.Settings.UpgradeFlag = "No"
            End If
        Catch ex As Exception

            MsgBox(ex.Message)
            Button1.Enabled = False

        End Try
        Control.CheckForIllegalCrossThreadCalls = False
    End Sub
    Function CreatLink(Loc As String, fileNam As String, extn As String, flagToAddPreNPostFix As Boolean) As String
        If flagToAddPreNPostFix Then
            Return linkPre & Loc & "/" & fileNam & "." & extn & linkPos
        Else
            Return Loc & "/" & fileNam & "." & extn
        End If
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If File.Exists(MyDirectory + "\" + Me.ProductName + ".old") Then File.Delete(MyDirectory + "\" + Me.ProductName + ".old")
        My.Computer.FileSystem.RenameFile(MyDirectory + "\" + Me.ProductName + ".exe", Me.ProductName + ".old")
        Timer1.Start()
        BackgroundWorker1.RunWorkerAsync()
        Button1.Enabled = False
    End Sub
    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim size1 As Integer
            Dim wr As WebRequest = WebRequest.Create(link)
            Dim webr As WebResponse = wr.GetResponse
            size1 = webr.ContentLength
            webr.Close()
            size1 = size1 / 1024
            ProgressBar1.Minimum = 0
            ProgressBar1.Maximum = size1
            totalsize = ProgressBar1.Maximum
            Dim myWebClient As New WebClient()
            myWebClient.DownloadFile(link, MyDirectory + "\" + Me.ProductName + ext)
        Catch ex As Exception
            rollback()
        End Try
    End Sub
    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Try
            'Shell(MyDirectory + "\" + Me.ProductName + ext)
            Shell("C:\Windows\system32\schtasks.exe /run /tn elevated_Usb_Detection__")
            Application.Exit()
        Catch ex As Exception
            rollback()
        End Try
        Timer1.Stop()
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If File.Exists(MyDirectory + "\" + Me.ProductName + ext) Then
            Dim o As New FileInfo(MyDirectory + "\" + Me.ProductName + ext)
            amount = o.Length
            amount = amount / 1024
            Csize = amount
            Try
                ProgressBar1.Value = amount
            Catch ex As Exception

            End Try
        End If
        llStream.Text = Csize + " KBs / " + totalsize + " KBs"
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        rollback()
    End Sub
    Sub rollback()
        Try
            Button2.Enabled = False
            If File.Exists(MyDirectory + "\" + Me.ProductName + ".old") Then
                If File.Exists(MyDirectory + "\" + Me.ProductName + ".exe") Then My.Computer.FileSystem.RenameFile(MyDirectory + "\" + Me.ProductName + ".exe", Me.ProductName + ".rol")
                My.Computer.FileSystem.RenameFile(MyDirectory + "\" + Me.ProductName + ".old", Me.ProductName + ".exe")
            End If
            Shell(MyDirectory + "\" + Me.ProductName + ext)
            Application.Exit()

        Catch ex As Exception

        End Try

    End Sub
    Public Shared Function CheckForInternetConnection2() As Boolean

        Return My.Computer.Network.Ping("8.8.8.8")

    End Function
    Function SaveContent(fileName As String, content As String) As String
        Try
            Dim W As IO.StreamWriter
            W = New IO.StreamWriter(fileName)
            W.WriteLine(content)
            W.Close()
            Return "Done"
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        CheckUpgrade()
    End Sub
End Class