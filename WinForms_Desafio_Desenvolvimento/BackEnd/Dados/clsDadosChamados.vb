Imports System.Data.SQLite

Public Class DadosChamados
    Inherits DadosBase

    Public Shared Function ListarChamados() As DataTable

        Dim dtChamados As New DataTable()

        Try
            Using dbConnection As SQLiteConnection = ObterConexao(),
                  dbCommand As SQLiteCommand = dbConnection.CreateCommand(),
                  dbDataAdapter As New SQLiteDataAdapter(dbCommand)

                dbCommand.CommandText = "SELECT 
                                            chamados.ID, 
                                            Assunto, 
                                            Solicitante, 
                                            departamentos.Descricao AS Departamento, 
                                            DataAbertura 
                                         FROM 
                                            chamados 
                                         INNER JOIN 
                                            departamentos 
                                         ON 
                                            chamados.Departamento = departamentos.ID"

                dbDataAdapter.Fill(dtChamados)
            End Using
        Catch ex As Exception
            MessageBox.Show("Ocorreu um erro ao obter a lista de chamados. Por favor, se o erro persistir, entre em contato com o suporte.",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error)
        End Try

        Return dtChamados
    End Function

    Public Shared Function ObterChamado(idChamado As Integer) As DataRow

        Dim drChamado As DataRow = Nothing

        Try
            Using dbConnection As SQLiteConnection = ObterConexao(),
                  dbCommand As SQLiteCommand = dbConnection.CreateCommand(),
                  dbDataAdapter As New SQLiteDataAdapter(dbCommand)

                dbCommand.CommandText = "SELECT 
                                            ID, 
                                            Assunto, 
                                            Solicitante, 
                                            Departamento, 
                                            DataAbertura 
                                         FROM 
                                            chamados 
                                         WHERE 
                                            ID = @ID"

                dbCommand.Parameters.AddWithValue("@ID", idChamado)

                Dim dtChamados As New DataTable()
                dbDataAdapter.Fill(dtChamados)

                If dtChamados.Rows.Count > 0 Then
                    drChamado = dtChamados.Rows(0)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Erro ao obter o chamado. Por favor, se o erro persistir, entre em contato com o suporte.",
                            "Erro",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error)
        End Try

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
                        dbCommand.CommandText = "INSERT INTO 
                                                        chamados (Assunto, Solicitante, Departamento, DataAbertura) 
                                                 VALUES 
                                                        (@Assunto, @Solicitante, @Departamento, @DataAbertura)"
                    Else
                        dbCommand.CommandText = "UPDATE 
                                                    chamados 
                                                SET 
                                                    Assunto=@Assunto, 
                                                    Solicitante=@Solicitante, 
                                                    Departamento=@Departamento, 
                                                    DataAbertura=@DataAbertura 
                                                WHERE 
                                                    ID=@ID"
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
            Finally
                transaction.Dispose()
                dbConnection.Close()
            End Try
        End Using

        Return (regsAfetados > 0)
    End Function

    Public Shared Function ExcluirChamado(idChamado As Integer) As Boolean

        If idChamado <= 0 Then
            Return False
        End If

        Try
            Using dbConnection As SQLiteConnection = ObterConexao(),
            dbCommand As SQLiteCommand = dbConnection.CreateCommand()

                dbConnection.Open()
                dbCommand.CommandText = "DELETE 
                                         FROM 
                                            chamados 
                                         WHERE 
                                            ID = @ID"

                dbCommand.Parameters.AddWithValue("@ID", idChamado)

                Dim sucesso As Boolean = dbCommand.ExecuteNonQuery() > 0
                Return sucesso
            End Using
        Catch ex As Exception
            Return False
        End Try

    End Function
End Class
