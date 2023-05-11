Imports System.Data.SqlClient

Module GlobalVariables

    Public shvCargoUser As String
    Public shvUsername As String
    Public shvNombre As String

    Public shvConn = New SqlConnection("Server=(Local); Database=TIENDA_ABD2020; Integrated Security=SSPI")
    Public shvCommand As SqlCommand
    Public shvReader As SqlDataReader

End Module