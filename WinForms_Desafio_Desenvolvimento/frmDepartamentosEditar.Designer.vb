﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDepartamentosEditar
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDepartamentosEditar))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblID = New System.Windows.Forms.Label()
        Me.lblDescricao = New System.Windows.Forms.Label()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.txtDescricao = New System.Windows.Forms.TextBox()
        Me.btnSalvar = New System.Windows.Forms.Button()
        Me.btnFechar = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblID, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDescricao, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.txtID, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.txtDescricao, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnSalvar, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.btnFechar, 1, 3)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(2, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(624, 441)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'lblID
        '
        Me.lblID.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblID.Location = New System.Drawing.Point(3, 0)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(114, 40)
        Me.lblID.TabIndex = 0
        Me.lblID.Text = "ID:"
        Me.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDescricao
        '
        Me.lblDescricao.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDescricao.Location = New System.Drawing.Point(3, 40)
        Me.lblDescricao.Name = "lblDescricao"
        Me.lblDescricao.Size = New System.Drawing.Size(114, 40)
        Me.lblDescricao.TabIndex = 1
        Me.lblDescricao.Text = "Descrição:"
        Me.lblDescricao.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtID
        '
        Me.txtID.Enabled = False
        Me.txtID.Location = New System.Drawing.Point(123, 10)
        Me.txtID.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(100, 20)
        Me.txtID.TabIndex = 1
        '
        'txtDescricao
        '
        Me.txtDescricao.Location = New System.Drawing.Point(123, 50)
        Me.txtDescricao.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.txtDescricao.Name = "txtDescricao"
        Me.txtDescricao.Size = New System.Drawing.Size(378, 20)
        Me.txtDescricao.TabIndex = 2
        '
        'btnSalvar
        '
        Me.btnSalvar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalvar.Image = Global.WinForms_Desafio_Desenvolvimento.My.Resources.Resources.disk
        Me.btnSalvar.Location = New System.Drawing.Point(508, 404)
        Me.btnSalvar.Name = "btnSalvar"
        Me.btnSalvar.Size = New System.Drawing.Size(113, 34)
        Me.btnSalvar.TabIndex = 4
        Me.btnSalvar.Text = "Salvar"
        Me.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalvar.UseVisualStyleBackColor = True
        '
        'btnFechar
        '
        Me.btnFechar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFechar.Image = Global.WinForms_Desafio_Desenvolvimento.My.Resources.Resources.door_open_in
        Me.btnFechar.Location = New System.Drawing.Point(387, 404)
        Me.btnFechar.Name = "btnFechar"
        Me.btnFechar.Size = New System.Drawing.Size(114, 34)
        Me.btnFechar.TabIndex = 3
        Me.btnFechar.Text = "Fechar"
        Me.btnFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFechar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnFechar.UseVisualStyleBackColor = True
        '
        'frmDepartamentosEditar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(624, 441)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDepartamentosEditar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Netspeed - Desafio Desenvolvimento"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents lblID As Label
    Friend WithEvents lblDescricao As Label
    Friend WithEvents txtID As TextBox
    Friend WithEvents txtDescricao As TextBox
    Friend WithEvents btnFechar As Button
    Friend WithEvents btnSalvar As Button
End Class
