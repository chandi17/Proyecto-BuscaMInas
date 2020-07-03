<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NuevoJuego
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Ayuda = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnPrincipiante = New System.Windows.Forms.Button()
        Me.btnFacil = New System.Windows.Forms.Button()
        Me.btnIntermedio = New System.Windows.Forms.Button()
        Me.btnAvanzado = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(22, Byte), Integer), CType(CType(27, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Ayuda)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.btnCerrar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(657, 31)
        Me.Panel1.TabIndex = 0
        '
        'Ayuda
        '
        Me.Ayuda.AutoSize = True
        Me.Ayuda.Font = New System.Drawing.Font("Candara", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ayuda.ForeColor = System.Drawing.Color.Silver
        Me.Ayuda.Location = New System.Drawing.Point(48, 2)
        Me.Ayuda.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Ayuda.Name = "Ayuda"
        Me.Ayuda.Size = New System.Drawing.Size(120, 24)
        Me.Ayuda.TabIndex = 3
        Me.Ayuda.Text = "Nuevo Juego"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ProyectoBuscaminas.My.Resources.Resources.mina
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 31)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'btnCerrar
        '
        Me.btnCerrar.FlatAppearance.BorderSize = 0
        Me.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCerrar.Image = Global.ProyectoBuscaminas.My.Resources.Resources.Icono_cerrar_FN
        Me.btnCerrar.Location = New System.Drawing.Point(625, 1)
        Me.btnCerrar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(31, 28)
        Me.btnCerrar.TabIndex = 0
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnPrincipiante
        '
        Me.btnPrincipiante.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(121, Byte), Integer))
        Me.btnPrincipiante.FlatAppearance.BorderSize = 0
        Me.btnPrincipiante.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrincipiante.Font = New System.Drawing.Font("Candara", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrincipiante.ForeColor = System.Drawing.Color.Silver
        Me.btnPrincipiante.Location = New System.Drawing.Point(143, 117)
        Me.btnPrincipiante.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnPrincipiante.Name = "btnPrincipiante"
        Me.btnPrincipiante.Size = New System.Drawing.Size(348, 37)
        Me.btnPrincipiante.TabIndex = 1
        Me.btnPrincipiante.Text = "Principiane"
        Me.btnPrincipiante.UseVisualStyleBackColor = False
        '
        'btnFacil
        '
        Me.btnFacil.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(121, Byte), Integer))
        Me.btnFacil.FlatAppearance.BorderSize = 0
        Me.btnFacil.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFacil.Font = New System.Drawing.Font("Candara", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFacil.ForeColor = System.Drawing.Color.Silver
        Me.btnFacil.Location = New System.Drawing.Point(143, 183)
        Me.btnFacil.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnFacil.Name = "btnFacil"
        Me.btnFacil.Size = New System.Drawing.Size(348, 37)
        Me.btnFacil.TabIndex = 2
        Me.btnFacil.Text = "Fácil"
        Me.btnFacil.UseVisualStyleBackColor = False
        '
        'btnIntermedio
        '
        Me.btnIntermedio.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(121, Byte), Integer))
        Me.btnIntermedio.FlatAppearance.BorderSize = 0
        Me.btnIntermedio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIntermedio.Font = New System.Drawing.Font("Candara", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIntermedio.ForeColor = System.Drawing.Color.Silver
        Me.btnIntermedio.Location = New System.Drawing.Point(143, 246)
        Me.btnIntermedio.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnIntermedio.Name = "btnIntermedio"
        Me.btnIntermedio.Size = New System.Drawing.Size(348, 37)
        Me.btnIntermedio.TabIndex = 3
        Me.btnIntermedio.Text = "Intermedio"
        Me.btnIntermedio.UseVisualStyleBackColor = False
        '
        'btnAvanzado
        '
        Me.btnAvanzado.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(101, Byte), Integer), CType(CType(121, Byte), Integer))
        Me.btnAvanzado.FlatAppearance.BorderSize = 0
        Me.btnAvanzado.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAvanzado.Font = New System.Drawing.Font("Candara", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAvanzado.ForeColor = System.Drawing.Color.Silver
        Me.btnAvanzado.Location = New System.Drawing.Point(143, 306)
        Me.btnAvanzado.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnAvanzado.Name = "btnAvanzado"
        Me.btnAvanzado.Size = New System.Drawing.Size(348, 37)
        Me.btnAvanzado.TabIndex = 4
        Me.btnAvanzado.Text = "Avanzado"
        Me.btnAvanzado.UseVisualStyleBackColor = False
        '
        'NuevoJuego
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(3, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.BackgroundImage = Global.ProyectoBuscaminas.My.Resources.Resources.fondo1
        Me.ClientSize = New System.Drawing.Size(657, 442)
        Me.Controls.Add(Me.btnAvanzado)
        Me.Controls.Add(Me.btnIntermedio)
        Me.Controls.Add(Me.btnFacil)
        Me.Controls.Add(Me.btnPrincipiante)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "NuevoJuego"
        Me.Text = "NuevoJuego"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnPrincipiante As Button
    Friend WithEvents btnFacil As Button
    Friend WithEvents btnIntermedio As Button
    Friend WithEvents btnAvanzado As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnCerrar As Button
    Friend WithEvents Ayuda As Label
End Class
