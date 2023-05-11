Public Class formMain

    'Se ejecuta al momento de cargar el formMain.vb'
    Private Sub formMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        slUser.Text = shvUsername
        slCargo.Text = shvCargoUser
        txtMainNombre.Text = shvNombre

        If shvCargoUser = "Administrador" Then

            btnEmpleadoPanel.Show()
            btnAddEmpleadoPanel.Show()
            btnProductosPanel.Show()
            btnAddProdPanelE.Show()
            btnAddProdPanelN.Show()
            btnClientePanel.Show()
            btnAddClientePanel.Show()
            btnRlzVentaPanel.Show()

        ElseIf shvCargoUser = "Cajero" Then

            btnProductosPanel.Show()
            btnClientePanel.Show()
            btnAddClientePanel.Show()
            btnRlzVentaPanel.Show()

        ElseIf shvCargoUser = "Encargado de Almacén" Then

            btnProductosPanel.Show()
            btnAddProdPanelE.Show()
            btnAddProdPanelN.Show()

        End If

    End Sub

    Private Sub CerrarSesiónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CerrarSesiónToolStripMenuItem.Click

        Close()

        formLogin.txtPassword.Text = ""
        formLogin.txtPassword.Focus()
        formLogin.Show()

    End Sub

    Private Sub VentasRealizadasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentasRealizadasToolStripMenuItem.Click

        formVentasRealizadas.Show()

    End Sub

    Private Sub VerProveedoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerProveedoresToolStripMenuItem.Click

        formProveedores.Show()

    End Sub

    '' Funciones Principales ''
    ''
    ''
    ''
    ''

    ''
    'Panel Empleados'
    ''
    'panelEmpleadosController.vb'
    ''

    'Muestra el panel de Empleados'
    Private Sub btnEmpleadoPanel_Click(sender As Object, e As EventArgs) Handles btnEmpleadoPanel.Click

        Empleado_ShowEmpleados()

    End Sub

    Private Sub txtBuscarNombreEmp_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarNombreEmp.TextChanged

        Empleado_BuscarEmpleado()

    End Sub

    Private Sub cmbBuscarCargoEmp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBuscarCargoEmp.SelectedIndexChanged

        Empleado_BuscarEmpleado()

    End Sub

    Private Sub txtBuscarDireccionEmp_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarDireccionEmp.TextChanged

        Empleado_BuscarEmpleado()

    End Sub

    Private Sub btnDeleteEmpleado_Click(sender As Object, e As EventArgs) Handles btnDeleteEmpleado.Click

        formDeleteEmpleado.Show()

    End Sub

    ''
    'Panel Agregar Empleados'
    ''
    'panelAddEmpleadosController.vb'
    ''

    'Muestra el panel para Agregar Empleados'
    Private Sub btnAddEmpleadoPanel_Click(sender As Object, e As EventArgs) Handles btnAddEmpleadoPanel.Click

        AddEmpleado_Show()

    End Sub

    Private Sub btnAddEmpleado_Click(sender As Object, e As EventArgs) Handles btnAddEmpleado.Click

        AddEmpleado_Add()

    End Sub

    Private Sub cmbAddEmpCargo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAddEmpCargo.SelectedIndexChanged

        AddEmpleado_cmbAddEmpCargo()

    End Sub

    ''
    'Panel Lista de Productos'
    ''
    'panelProductosController.vb'
    ''

    'Muestra el panel Productos'
    Private Sub btnProductosPanel_Click(sender As Object, e As EventArgs) Handles btnProductosPanel.Click

        Productos_ShowProductos()

    End Sub

    Private Sub txtProdNombre_TextChanged(sender As Object, e As EventArgs) Handles txtProdNombre.TextChanged

        Productos_BuscarProducto()

    End Sub

    Private Sub txtProdMarca_TextChanged(sender As Object, e As EventArgs) Handles txtProdMarca.TextChanged

        Productos_BuscarProducto()

    End Sub

    Private Sub cmbProdCategoria_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProdCategoria.SelectedIndexChanged

        Productos_BuscarProducto()

    End Sub

    Private Sub cmbProdProv_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProdProv.SelectedIndexChanged

        Productos_BuscarProducto()

    End Sub

    Private Sub txtProdPreMayorA_TextChanged(sender As Object, e As EventArgs) Handles txtProdPreMayorA.TextChanged

        Productos_BuscarProducto()

    End Sub

    Private Sub txtProdPreMenorA_TextChanged(sender As Object, e As EventArgs) Handles txtProdPreMenorA.TextChanged

        Productos_BuscarProducto()

    End Sub

    ''
    'Panel Agregar Producto Existente'
    ''
    'panelAddProdEController.vb'
    ''

    'Muestra el panel para agregar productos existentes'
    Private Sub btnAddProdPanelE_Click(sender As Object, e As EventArgs) Handles btnAddProdPanelE.Click

        AddProdE_Show()

    End Sub

    Private Sub txtAddProdEId_TextChanged(sender As Object, e As EventArgs) Handles txtAddProdEId.TextChanged

        AddProdE_ShowData()

    End Sub

    Private Sub btnAddProdEAdd_Click(sender As Object, e As EventArgs) Handles btnAddProdEAdd.Click

        AddProdE_Add()

    End Sub

    ''
    'Panel Agregar Nuevo Producto'
    ''
    'panelAddProdNController.vb'
    ''

    'Muestra el panel para agregar nuevos productos'
    Private Sub btnAddProdPanelN_Click(sender As Object, e As EventArgs) Handles btnAddProdPanelN.Click

        AddProdN_Show()

    End Sub

    Private Sub cmbAddProdNCat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAddProdNCat.SelectedIndexChanged

        AddProdN_cmbAddProdNCat()

    End Sub

    Private Sub cmbAddProdNProv_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAddProdNProv.SelectedIndexChanged

        AddProdN_cmbAddProdNProv()

    End Sub

    Private Sub btnAddProdNAdd_Click(sender As Object, e As EventArgs) Handles btnAddProdNAdd.Click

        AddProdN_Add()

    End Sub

    ''
    'Panel Clientes'
    ''
    'panelClientesController.vb'
    ''

    'Muestra el panel de clientes'
    Private Sub btnClientePanel_Click(sender As Object, e As EventArgs) Handles btnClientePanel.Click

        Clientes_ShowClientes()

    End Sub

    Private Sub txtClienteNombre_TextChanged(sender As Object, e As EventArgs) Handles txtClienteNombre.TextChanged

        Clientes_BuscarClientes()

    End Sub

    Private Sub txtClienteDir_TextChanged(sender As Object, e As EventArgs) Handles txtClienteDir.TextChanged

        Clientes_BuscarClientes()

    End Sub

    ''
    'Panel Agregar Cliente'
    ''
    'panelAddClientesController.vb'
    ''

    'Muestra el panel para agregar clientes'
    Private Sub btnAddClientePanel_Click(sender As Object, e As EventArgs) Handles btnAddClientePanel.Click

        AddClientes_Show()

    End Sub

    Private Sub btnAddClienteAdd_Click(sender As Object, e As EventArgs) Handles btnAddClienteAdd.Click

        AddClientes_Add()

    End Sub

    ''
    'Panel Realizar Venta'
    ''
    'panelRlzVentaController.vb'
    ''

    'Muestra el panel para realizar ventas'
    Private Sub btnRlzVentaPanel_Click(sender As Object, e As EventArgs) Handles btnRlzVentaPanel.Click

        RlzVenta_Show()

    End Sub

    Private Sub txtRlzVentaDniC_TextChanged(sender As Object, e As EventArgs) Handles txtRlzVentaDniC.TextChanged

        RlzVenta_ClienteShowData()

    End Sub

    Private Sub txtRlzVentaPId_TextChanged(sender As Object, e As EventArgs) Handles txtRlzVentaPId.TextChanged

        RlzVenta_ProductoShowData()

    End Sub

    Private Sub txtRlzVentaEId_TextChanged(sender As Object, e As EventArgs) Handles txtRlzVentaEId.TextChanged

        RlzVenta_EmpleadoShowData()

    End Sub

    Private Sub btnRlzVentaAdd_Click(sender As Object, e As EventArgs) Handles btnRlzVentaAdd.Click

        RlzVenta_Add()

    End Sub

    Private Sub btnRlzVentaCompletar_Click(sender As Object, e As EventArgs) Handles btnRlzVentaCompletar.Click

        RlzVenta_Completar()

    End Sub

    Private Sub btnRlzVentaCancel_Click(sender As Object, e As EventArgs) Handles btnRlzVentaCancel.Click

        RlzVenta_Cancelar()

    End Sub

End Class