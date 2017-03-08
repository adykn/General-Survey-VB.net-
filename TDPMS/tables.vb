Module tables



    Public TNq As String = "Question"
    Public TFq As String() = {"Id", "FormRef", "SN", "Question", "AnsTypeRef"}
    Public TVq As String() = {"", "", "", "", ""}
    Public TSq As String() = {"N", "N", "T", "T", "N"}

    Public TNa As String = "Answers"
    Public TFa As String() = {"Id", "AnsTypeRef", "SN", "Answer", "ref"}
    Public TVa As String() = {"", "", "", "", ""}
    Public TSa As String() = {"N", "N", "T", "T", "T"}

    Public TN1 As String = "RptHeader"
    Public TF1 As String() = {"Id", "Ref", "District", "Village", "UC", "Interviewer", "NoteTaker", "Date_"}
    Public TV1 As String() = {"", "", "", "", "", "", "", ""}
    Public TS1 As String() = {"N", "T", "T", "T", "T", "T", "T", "D"}

    Public TN2 As String = "Labels"
    Public TF2 As String() = {"Id", "Title", "Detail"}
    Public TV2 As String() = {"", "", ""}
    Public TS2 As String() = {"N", "T", "T"}

   
    Public N3 As String = "Basic"
    Public F3 As String() = {"Id", "Ref", "Num", "Date_", "Title", "Valu"}
    Public V3 As String() = {"", "", "", "", "", ""}
    Public S3 As String() = {"N", "T", "T", "D", "T", "T"}

    Public N4 As String = "Population"
    Public F4 As String() = {"Id", "Ref", "Num", "Date_", "Title", "Valu"}
    Public V4 As String() = {"", "", "", "", "", ""}
    Public S4 As String() = {"N", "T", "T", "D", "T", "T"}

    Public N5 As String = "Assets"
    Public F5 As String() = {"Id", "Ref", "Num", "Date_", "Title", "Valu"}
    Public V5 As String() = {"", "", "", "", "", ""}
    Public S5 As String() = {"N", "T", "T", "D", "T", "T"}

    Public N6 As String = "Situation"
    Public F6 As String() = {"Id", "Ref", "Num", "Date_", "Title", "Valu"}
    Public V6 As String() = {"", "", "", "", "", ""}
    Public S6 As String() = {"N", "T", "T", "D", "T", "T"}

    Public N7 As String = "Type"
    Public F7 As String() = {"Id", "Ref", "Num", "Date_", "Title", "Valu"}
    Public V7 As String() = {"", "", "", "", "", ""}
    Public S7 As String() = {"N", "T", "T", "D", "T", "T"}

    Public N8 As String = "Humanitarian"
    Public F8 As String() = {"Id", "Ref", "Num", "Date_", "Title", "Valu"}
    Public V8 As String() = {"", "", "", "", "", ""}
    Public S8 As String() = {"N", "T", "T", "D", "T", "T"}

    Public N9 As String = "Comments"
    Public F9 As String() = {"Id", "Ref", "Num", "Date_", "Title", "Valu"}
    Public V9 As String() = {"", "", "", "", "", ""}
    Public S9 As String() = {"N", "T", "T", "D", "T", "T"}

    Public N10 As String = "Response"
    Public F10 As String() = {"Id", "Ref", "Num", "Date_", "Title", "Valu"}
    Public V10 As String() = {"", "", "", "", "", ""}
    Public S10 As String() = {"N", "T", "T", "D", "T", "T"}

    Public TbSettingName As String = "Setting"
    Public TbSettingFeilds As String() = {"Txt", "Field", "Area"}
    Public TbSettingValues As String() = {"", "", ""}
    Public TbSettingSyntax As String() = {"T", "T", "T"}


    Public TbAutoCompName As String = "AutoCompleteTb"
    Public TbAutoCompFeilds As String() = {"Txt", "Field"}
    Public TbAutoCompValues As String() = {"", ""}
    Public TbAutoCompSyntax As String() = {"T", "T"}


    Sub New()
        createTable(TbAutoCompName, TbAutoCompFeilds, TbAutoCompSyntax)
    End Sub

End Module
