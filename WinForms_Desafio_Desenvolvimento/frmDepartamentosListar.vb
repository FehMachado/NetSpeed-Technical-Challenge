Imports System.Data
Imports System.Windows.Forms

Public Class frmDepartamentosListar

    Private Sub frmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim dtDepartamentos As DataTable = DadosDepartamentos.ListarDepartamentos()
        Me.dgvDepartamentos.DataSource = dtDepartamentos

    End Sub

    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click

        If Me.dgvDepartamentos.SelectedRows.Count = 0 Then Exit Sub


        Dim dgvr As DataGridViewRow = Me.dgvDepartamentos.SelectedRows(0)
        Dim drv As DataRowView = DirectCast(dgvr.DataBoundItem, DataRowView)

        Dim idDepto As Integer = CInt(drv("ID"))

        Dim dlgResult As DialogResult =
            MessageBox.Show(Me, $"Confirma a exclusão do Chamado nº {idDepto} ?",
                            Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If dlgResult <> DialogResult.Yes Then Exit Sub

        Dim sucesso As Boolean = DadosDepartamentos.ExcluirDepartamento(idDepto)

        If sucesso Then

            ' Apenas para listar os dados novamente
            Me.frmPrincipal_Load(sender, e)

        End If

    End Sub

    Private Sub btnAbrir_Click(sender As Object, e As EventArgs) Handles btnAbrir.Click

        If Me.dgvDepartamentos.SelectedRows.Count = 0 Then Exit Sub

        Dim dgvr As DataGridViewRow = Me.dgvDepartamentos.SelectedRows(0)
        Dim drv As DataRowView = DirectCast(dgvr.DataBoundItem, DataRowView)

        Dim idDepartamento As Integer = CInt(drv("ID"))

        Dim frm As New frmDepartamentosEditar()
        frm.AbrirDepartamento(idDepartamento)

        Dim dlgResult As DialogResult = frm.ShowDialog()

        If dlgResult = DialogResult.OK Then

            ' Apenas para listar os dados novamente
            Me.frmPrincipal_Load(sender, e)

        End If

    End Sub

    Private Sub btnNovo_Click(sender As Object, e As EventArgs) Handles btnNovo.Click
        Dim frm As New frmDepartamentosEditar()

        Dim dlgResult As DialogResult = frm.ShowDialog()

        If dlgResult = DialogResult.OK Then
            ' Apenas para listar os dados novamente
            Me.frmPrincipal_Load(sender, e)

        End If

    End Sub

    Private Sub btnRelatorio_Click(sender As Object, e As EventArgs) Handles btnRelatorio.Click

        Dim frm As New frmDepartamentosRelatorio()
        frm.ShowDialog()

    End Sub

    Private Sub dgvDepartamentos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDepartamentos.CellDoubleClick

        If e.RowIndex >= 0 Then
            ' Obtém os dados da linha selecionada
            Dim dgvr As DataGridViewRow = Me.dgvDepartamentos.Rows(e.RowIndex)
            Dim drv As DataRowView = DirectCast(dgvr.DataBoundItem, DataRowView)
            Dim idChamado As Integer = CInt(drv("ID"))

            ' Abre o formulário de edição com os dados do chamado
            Dim frm As New frmChamadosEditar()
            frm.AbrirChamado(idChamado)

            Dim dlgResult As DialogResult = frm.ShowDialog()

            ' Atualiza a lista caso as alterações tenham sido salvas
            If dlgResult = DialogResult.OK Then
                Me.frmPrincipal_Load(sender, e)
            End If
        End If

    End Sub

End Class
