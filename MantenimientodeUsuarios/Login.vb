Imports System.Data
Imports System.Data.SqlClient
Public Class Login
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        RegistroUsuario.Show()
    End Sub

    Private Sub btnAcceder_Click(sender As Object, e As EventArgs) Handles btnAcceder.Click
        Dim dt = Login(txtUsuario.Text, txtClave.Text)

        If (dt.Rows.Count > 0) Then
            MsgBox("Bienvenido " + dt.Rows(0)(0).ToString, MsgBoxStyle.Exclamation, "Mensaje ")
        Else
            MsgBox("Usuario o contraseña incorrecta", MsgBoxStyle.Critical, "Alerta")
        End If
        txtUsuario.Text = ""
        txtClave.Text = ""
    End Sub

    Public Function Login(usu As String, pass As String) As DataTable
        Dim cmd As SqlCommand = New SqlCommand("vai_logueo", conexion)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.AddWithValue("@Nombre", usu)
        cmd.Parameters.AddWithValue("@Clave", pass)
        Dim da As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim dtable1 As DataTable = New DataTable()
        da.Fill(dtable1)
        Return dtable1
    End Function

End Class
