Module TablesWash
    Public TNW01 As String = "CommunalWater"
    Public TFW01 As String() = {"Id", "Ref", "Num", "Date_", "Question", "valu"}
    Public TVW01 As String() = {"", "", "", "", "", ""}
    Public TSW01 As String() = {"N", "T", "T", "D", "T", "T"}

    Public TNW02 As String = "PrivateWater"
    Public TFW02 As String() = {"Id", "Ref", "Num", "Date_", "Question", "valu"}
    Public TVW02 As String() = {"", "", "", "", "", ""}
    Public TSW02 As String() = {"N", "T", "T", "D", "T", "T"}

    Public TNW03 As String = "Sanitation"
    Public TFW03 As String() = {"Id", "Ref", "Num", "Date_", "Question", "valu", "Percentage"}
    Public TVW03 As String() = {"", "", "", "", "", "", ""}
    Public TSW03 As String() = {"N", "T", "T", "D", "T", "T", "T"}

    Public TNW04 As String = "Hygiene"
    Public TFW04 As String() = {"Id", "Ref", "Num", "Date_", "Question", "valu"}
    Public TVW04 As String() = {"", "", "", "", "", ""}
    Public TSW04 As String() = {"N", "T", "T", "D", "T", "T"}

    Public TNW05 As String = "HygieneGenderWise"
    Public TFW05 As String() = {"Id", "Ref", "Num", "Date_", "Gendr", "N", "G1", "G2", "G3", "G4", "G5"}
    Public TVW05 As String() = {"", "", "", "", "", "", "", "", "", "", ""}
    Public TSW05 As String() = {"N", "T", "T", "D", "T", "T", "T", "T", "T", "T", "T"}

    Public TNW06 As String = "Rehabilitation"
    Public TFW06 As String() = {"Id", "Ref", "Num", "Date_", "TypesSchemes", "Availibility", "RequiredSchemes", "IDPBenefi", "HOSTBenefi"}
    Public TVW06 As String() = {"", "", "", "", "", "", "", "", ""}
    Public TSW06 As String() = {"N", "T", "T", "D", "T", "T", "T", "T", "T"}

    Public TNW07 As String = "Garbage"
    Public TFW07 As String() = {"Id", "Ref", "Num", "Date_", "Question", "valu"}
    Public TVW07 As String() = {"", "", "", "", "", ""}
    Public TSW07 As String() = {"N", "T", "T", "D", "T", "T"}

    Public TNW08 As String = "NoteTakerComments"
    Public TFW08 As String() = {"Id", "Ref", "Num", "Date_", "Comments"}
    Public TVW08 As String() = {"", "", "", "", ""}
    Public TSW08 As String() = {"N", "T", "T", "D", "T"}

End Module
