Public Class formProveedores

    Private Sub formProveedores_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lvwProveedor.View = View.Details
        lvwProveedor.GridLines = True

        lvwProveedor.Columns.Add("Id", 50, HorizontalAlignment.Left)
        lvwProveedor.Columns.Add("Nombre", 85, HorizontalAlignment.Left)
        lvwProveedor.Columns.Add("Teléfono", 80, HorizontalAlignment.Left)
        lvwProveedor.Columns.Add("Dirección", 130, HorizontalAlignment.Left)
        lvwProveedor.Columns.Add("Email", 150, HorizontalAlignment.Left)
        lvwProveedor.Columns.Add("N° Productos", 75, HorizontalAlignment.Center)

        shvCommand = shvConn.CreateCommand
        shvCommand.CommandText = "SP_Proveedores"

        shvConn.Open()

        shvReader = shvCommand.ExecuteReader

        Dim row As ListViewItem

        While shvReader.Read()

            row = New ListViewItem(shvReader(0).ToString)
            row.SubItems.Add(shvReader(1))
            row.SubItems.Add(shvReader(2))
            row.SubItems.Add(shvReader(3))
            row.SubItems.Add(shvReader(4))
            row.SubItems.Add(shvReader(5).ToString)

            lvwProveedor.Items.Add(row)

        End While

        shvReader.Close()
        shvConn.Close()

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click

        Close()

    End Sub

End Class