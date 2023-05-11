Public Class formVentasRealizadas

    Private Sub formVentasRealizadas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lvwVentasR.View = View.Details
        lvwVentasR.GridLines = True

        lvwVentasR.Columns.Add("IdVenta", 50, HorizontalAlignment.Left)
        lvwVentasR.Columns.Add("Cliente", 180, HorizontalAlignment.Left)
        lvwVentasR.Columns.Add("Vendedor", 180, HorizontalAlignment.Left)
        lvwVentasR.Columns.Add("Fecha de Venta", 120, HorizontalAlignment.Left)
        lvwVentasR.Columns.Add("SubTotal", 60, HorizontalAlignment.Left)
        lvwVentasR.Columns.Add("IGV", 60, HorizontalAlignment.Left)
        lvwVentasR.Columns.Add("Total", 60, HorizontalAlignment.Left)

        shvCommand = shvConn.CreateCommand
        shvCommand.CommandText = "SP_VentasRealizadas"

        shvConn.Open()

        shvReader = shvCommand.ExecuteReader

        Dim row As ListViewItem

        While shvReader.Read()

            row = New ListViewItem(shvReader(0).ToString)
            row.SubItems.Add(shvReader(1))
            row.SubItems.Add(shvReader(2))
            row.SubItems.Add(shvReader(3))
            row.SubItems.Add(FormatCurrency(shvReader(4)))
            row.SubItems.Add(FormatCurrency(shvReader(5)))
            row.SubItems.Add(FormatCurrency(shvReader(6)))

            lvwVentasR.Items.Add(row)

        End While

        shvReader.Close()
        shvConn.Close()

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click

        Close()

    End Sub

End Class