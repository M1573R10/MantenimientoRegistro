Imports System.Data
Imports System.Data.SqlClient
Module ModuloGeneral
    Public cadena As String = "Data Source=ORDENADOR;Initial Catalog=MantenimientoUsuarios;Integrated Security=True"
    Public conexion As New SqlConnection(cadena)
End Module
