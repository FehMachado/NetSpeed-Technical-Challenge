Imports System.Data
Imports System.Windows.Forms

Public Class frmChamadosListar

    Private Sub frmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim dtChamados As DataTable = DadosChamados.ListarChamados()
        Me.dgvChamados.DataSource = dtChamados

    End Sub

    Private Sub btnExcluir_Click(sender As Object, e As EventArgs) Handles btnExcluir.Click

        If Me.dgvChamados.SelectedRows.Count = 0 Then Exit Sub

        ' ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~

        Dim dgvr As DataGridViewRow = Me.dgvChamados.SelectedRows(0)
        Dim drv As DataRowView = DirectCast(dgvr.DataBoundItem, DataRowView)

        Dim idChamado As Integer = CInt(drv("ID"))

        Dim dlgResult As DialogResult =
            MessageBox.Show(Me, $"Confirma a exclusão do Chamado nº {idChamado} ?",
                            Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If dlgResult <> DialogResult.Yes Then Exit Sub

        ' ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~

        Dim sucesso As Boolean = DadosChamados.ExcluirChamado(idChamado)

        If sucesso Then

            ' Apenas para listar os dados novamente
            Me.frmPrincipal_Load(sender, e)

        End If

    End Sub

    Private Sub btnAbrir_Click(sender As Object, e As EventArgs) Handles btnAbrir.Click

        If Me.dgvChamados.SelectedRows.Count = 0 Then Exit Sub

        ' ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~

        Dim dgvr As DataGridViewRow = Me.dgvChamados.SelectedRows(0)
        Dim drv As DataRowView = DirectCast(dgvr.DataBoundItem, DataRowView)

        Dim idChamado As Integer = CInt(drv("ID"))

        ' ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~

        Dim frm As New frmChamadosEditar()
        frm.AbrirChamado(idChamado)

        Dim dlgResult As DialogResult = frm.ShowDialog()

        If dlgResult = DialogResult.OK Then

            ' Atualiza a listar os dados caso tenham sido salvas
            Me.frmPrincipal_Load(sender, e)

        End If

    End Sub

    Private Sub btnNovo_Click(sender As Object, e As EventArgs) Handles btnNovo.Click

        Dim frm As New frmChamadosEditar()

        Dim dlgResult As DialogResult = frm.ShowDialog()

        If dlgResult = DialogResult.OK Then

            ' Atualiza a listar os dados caso tenham sido salvas
            Me.frmPrincipal_Load(sender, e)

        End If

    End Sub

    Private Sub btnRelatorio_Click(sender As Object, e As EventArgs) Handles btnRelatorio.Click

        Dim frm As New frmChamadosRelatorio()
        frm.ShowDialog()

    End Sub

    Private Sub dgvChamados_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvChamados.CellDoubleClick

        ' Verifica se a linha clicada é válida
        If e.RowIndex >= 0 Then
            ' Obtém os dados da linha selecionada
            Dim dgvr As DataGridViewRow = Me.dgvChamados.Rows(e.RowIndex)
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
