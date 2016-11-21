Imports System.IO
Imports System.Net
Imports System.Windows.Forms

Public Class Upgrade
    Dim address As String = "https://dl.dropbox.com/s/ds5iealhn8ifsg9/UpdateChecker.txt?dl=1"
    Dim locat As String = System.Reflection.Assembly.GetEntryAssembly.Location
    Dim MyDirectory As String = System.IO.Path.GetDirectoryName(locat)
    Public totalsize As String = ""
    Public link As String = ""
    Public Csize As String = ""
    Public amount As String = ""
    Public ext As String = ""
    Dim ds As New DataSet
    Dim dt As New DataTable
    Public linkPre As String = "https://dl.dropbox.com/s/"
    Public linkPos As String = "?dl=1"
    Private Sub Upgrade_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MdiParent = FormXmdi
        If Not CheckForInternetConnection2() Then MsgBox("Please check you net connection and try again.") : Me.Close()
        If File.Exists(MyDirectory + "\" + Me.ProductName + ".old") Then Button2.Enabled = True
        If File.Exists(MyDirectory + "\" + Me.ProductName + ".rol") Then File.Delete(MyDirectory + "\" + Me.ProductName + ".rol")
        Label4.Text = Me.ProductVersion
        Try
            Dim instance As WebClient = New WebClient

            Dim returnValue As String
            returnValue = instance.DownloadString(address)

            SaveContent(MyDirectory + "\Check.xml", returnValue)
            ds.Clear()
            ds.ReadXml(MyDirectory + "\Check.xml")

            dt = ds.Tables(0).Select("Name='" & Me.ProductName & "'", "Ver desc").CopyToDataTable
            With dt.Rows(0)
                Label6.Text = CreatLink(.Item("Zip"), .Item("Name"), "zip", False)   ' zip link
                Label1.Text = CreatLink("8pmc6w5td32ko5u", "UpdateChecker", "txt", False)  ' txt link 
                Label2.Text = CreatLink(.Item("Exe"), .Item("Name"), "exe", False) ' exe link
                Label5.Text = .Item("Ver")   ' new version

                link = CreatLink(.Item("Exe"), .Item("Name"), "Exe", True)
                ext = link.Substring(link.Length - 9, 4)
            End With


            If Label4.Text >= Label5.Text Then
            Else
                Button1.Enabled = True
            End If
        Catch ex As Exception
            SaveContent(MyDirectory + "\Check.xml", "")
            MsgBox("No update available")
            Button1.Enabled = True
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
            Shell(MyDirectory + "\" + Me.ProductName + ext)
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
            FormXmdi.Close()

        Catch ex As Exception

        End Try

    End Sub
    Public Shared Function CheckForInternetConnection2() As Boolean
        If My.Computer.Network.Ping("www.Google.com") Then
            Return True
        Else
            Return False
        End If
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
End Class