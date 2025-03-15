Imports System.Data.SQLite

Public Class DadosChamados
    Inherits DadosBase

    Public Shared Function ListarChamados() As DataTable
        Dim dtChamados As New DataTable()

        Using dbConnection As SQLiteConnection = ObterConexao()
            Using dbCommand As SQLiteCommand = dbConnection.CreateCommand()
                dbCommand.CommandText = "SELECT chamados.ID, Assunto, Solicitante, departamentos.Descricao AS Departamento, DataAbertura FROM chamados INNER JOIN departamentos ON chamados.Departamento = departamentos.ID"

                Using dbDataAdapter As New SQLiteDataAdapter(dbCommand)
                    dbDataAdapter.Fill(dtChamados)
                End Using
            End Using
        End Using

        Return dtChamados
    End Function

    Public Shared Function ObterChamado(idChamado As Integer) As DataRow
        Dim drChamado As DataRow = Nothing

        Using dbConnection As SQLiteConnection = ObterConexao()
            Using dbCommand As SQLiteCommand = dbConnection.CreateCommand()
                dbCommand.CommandText = $"SELECT * FROM chamados WHERE ID = {idChamado}"

                Using dbDataAdapter As New SQLiteDataAdapter(dbCommand)
                    Dim dtChamados As New DataTable()
                    dbDataAdapter.Fill(dtChamados)
                    If dtChamados.Rows.Count > 0 Then
                        drChamado = dtChamados.Rows(0)
                    End If
                End Using
            End Using
        End Using

        Return drChamado
    End Function

    Public Shared Function GravarChamado(ID As Integer, Assunto As String, Solicitante As String, Departamento As Integer, DataAbertura As DateTime) As Boolean
        Dim regsAfetados As Integer = -1

        Using dbConnection As SQLiteConnection = ObterConexao()
            dbConnection.Open()
            Dim transaction As SQLiteTransaction = dbConnection.BeginTransaction()

            Try
                Using dbCommand As SQLiteCommand = dbConnection.CreateCommand()
                    dbCommand.Transaction = transaction

                    If ID = 0 Then
                        dbCommand.CommandText = "INSERT INTO chamados (Assunto, Solicitante, Departamento, DataAbertura) VALUES (@Assunto, @Solicitante, @Departamento, @DataAbertura)"
                    Else
                        dbCommand.CommandText = "UPDATE chamados SET Assunto=@Assunto, Solicitante=@Solicitante, Departamento=@Departamento, DataAbertura=@DataAbertura WHERE ID=@ID"
                    End If

                    dbCommand.Parameters.AddWithValue("@Assunto", Assunto)
                    dbCommand.Parameters.AddWithValue("@Solicitante", Solicitante)
                    dbCommand.Parameters.AddWithValue("@Departamento", Departamento)
                    dbCommand.Parameters.AddWithValue("@DataAbertura", DataAbertura.ToShortDateString())

                    If ID <> 0 Then
                        dbCommand.Parameters.AddWithValue("@ID", ID)
                    End If

                    regsAfetados = dbCommand.ExecuteNonQuery()
                    transaction.Commit()
                End Using
            Catch ex As Exception
                transaction.Rollback()
                MessageBox.Show("Erro ao inserir os dados: " & ex.Message)
            Finally
                dbConnection.Close()
            End Try
        End Using

        Return (regsAfetados > 0)
    End Function

    Public Shared Function ExcluirChamado(idChamado As Integer) As Boolean
        Dim regsAfetados As Integer = -1

        Using dbConnection As SQLiteConnection = ObterConexao()
            Using dbCommand As SQLiteCommand = dbConnection.CreateCommand()
                dbCommand.CommandText = $"DELETE FROM chamados WHERE ID = {idChamado}"
                dbConnection.Open()
                regsAfetados = dbCommand.ExecuteNonQuery()
                dbConnection.Close()
            End Using
        End Using

        Return (regsAfetados > 0)
    End Function
End Class
