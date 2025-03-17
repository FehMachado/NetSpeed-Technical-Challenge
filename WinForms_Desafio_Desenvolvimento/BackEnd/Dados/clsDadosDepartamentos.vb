Imports System.Data.SQLite

Public Class DadosDepartamentos
    Inherits DadosBase

    Public Shared Function ListarDepartamentos() As DataTable

        Dim dtDepartamentos As New DataTable()

        Try
            Using dbConnection As SQLiteConnection = ObterConexao(),
            dbCommand As SQLiteCommand = dbConnection.CreateCommand(), dbDataAdapter As New SQLiteDataAdapter(dbCommand)
                dbCommand.CommandText = "SELECT 
                                            id, 
                                            descricao 
                                        FROM 
                                            departamentos"
                dbDataAdapter.Fill(dtDepartamentos)
            End Using
        Catch ex As Exception
            MessageBox.Show("Ocorreu um erro ao obter a lista de departamentos. Por favor, se o erro persistir, entre em contato com o suporte.",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error)
        End Try

        Return dtDepartamentos
    End Function

    Public Shared Function GravarDepartamento(ID As Integer, Descricao As String) As Boolean
        Dim regsAfetados As Integer = -1

        Using dbConnection As SQLiteConnection = ObterConexao()
            dbConnection.Open()
            Dim transaction As SQLiteTransaction = dbConnection.BeginTransaction()

            Try
                Using dbCommand As SQLiteCommand = dbConnection.CreateCommand()
                    dbCommand.Transaction = transaction

                    If ID = 0 Then
                        dbCommand.CommandText = "INSERT INTO 
                                                        departamentos (Descricao) 
                                                 VALUES 
                                                        (@Descricao)"
                    Else
                        dbCommand.CommandText = "UPDATE 
                                                    departamentos 
                                                SET 
                                                    Descricao=@Descricao 
                                                WHERE 
                                                    ID=@ID"
                    End If

                    dbCommand.Parameters.AddWithValue("@Descricao", Descricao)

                    If ID <> 0 Then
                        dbCommand.Parameters.AddWithValue("@ID", ID)
                    End If

                    regsAfetados = dbCommand.ExecuteNonQuery()
                    transaction.Commit()
                End Using
            Catch ex As Exception
                transaction.Rollback()
                Return False
            Finally
                transaction.Dispose()
                dbConnection.Close()
            End Try
        End Using

        Return (regsAfetados > 0)
    End Function

    Public Shared Function ObterDepartamento(idDepartamento As Integer) As DataRow

        Dim drDepartamentos As DataRow = Nothing

        Try
            Using dbConnection As SQLiteConnection = ObterConexao(),
                dbCommand As SQLiteCommand = dbConnection.CreateCommand(),
                dbDataAdapter As New SQLiteDataAdapter(dbCommand)

                dbCommand.CommandText = "SELECT 
                                            id,
                                            descricao 
                                        FROM 
                                            departamentos 
                                        WHERE 
                                            ID = @ID"

                dbCommand.Parameters.AddWithValue("@ID", idDepartamento)

                Dim dtDepartamentos As New DataTable()
                dbDataAdapter.Fill(dtDepartamentos)

                If dtDepartamentos.Rows.Count > 0 Then
                    drDepartamentos = dtDepartamentos.Rows(0)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Erro ao obter o departamento. Por favor, se o erro persistir, entre em contato com o suporte.",
                           "Erro",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Error)
        End Try

        Return drDepartamentos
    End Function

    Public Shared Function ExcluirDepartamento(idDepartamento As Integer) As Boolean

        If idDepartamento <= 0 Then
            Return False
        End If

        Try
            Using dbConnection As SQLiteConnection = ObterConexao(),
              dbCommand As SQLiteCommand = dbConnection.CreateCommand()

                dbConnection.Open()
                dbCommand.CommandText = "DELETE 
                                        FROM 
                                            departamentos 
                                        WHERE 
                                            ID = @ID"

                dbCommand.Parameters.AddWithValue("@ID", idDepartamento)

                Dim sucesso As Boolean = dbCommand.ExecuteNonQuery() > 0
                Return sucesso
            End Using
        Catch ex As Exception
            Return False
        End Try

    End Function
End Class
