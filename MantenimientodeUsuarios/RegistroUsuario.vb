Imports System.Data
Imports System.Data.SqlClient
Public Class RegistroUsuario
    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        txtApellido.Clear()
        txtClave.Clear()
        txtNombre.Clear()
        txtUsuario.Clear()
    End Sub

    Private Sub btnRegresar_Click(sender As Object, e As EventArgs) Handles btnRegresar.Click
        Login.Show()
        Hide()
    End Sub

    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        Try
            Dim Guardar As New SqlCommand
            With Guardar
                .Connection = conexion
                .CommandText = "Registro"
                .CommandType = CommandType.StoredProcedure
                'Agregando los campos
                .Parameters.Add("@Nombre", SqlDbType.Char, 20)
                .Parameters("@Nombre").Value = txtNombre.Text
                .Parameters.Add("@Apellido", SqlDbType.Char, 20)
                .Parameters("@Apellido").Value = txtApellido.Text
                .Parameters.Add("@Usuario", SqlDbType.Char, 20)
                .Parameters("@Usuario").Value = txtUsuario.Text
                .Parameters.Add("@Clave", SqlDbType.VarChar, 20)
                .Parameters("@Clave").Value = txtClave.Text
            End With
            conexion.Open()
            If Guardar.ExecuteNonQuery() > 0 Then
                MessageBox.Show("Registrado exitosamente", "Megabyte", MessageBoxButtons.OK, MessageBoxIcon.Information)
                conexion.Close()
            Else
                MessageBox.Show("No se pudo registrar", "Megabyte", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            conexion.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class