Public Class Form1
    Dim p As PictureBox
    Dim t As Integer
    Dim bloc As String
    Dim direc As String
    Dim pic1lo As String
    Dim pic1a As String
    Dim r As New Random
    Dim helim As String
    Dim score As Integer
    Dim collision1a4 As String
    Dim gravity As String
    Dim pic1 As String


    Sub Start()
        collision1a4 = "f"
        gravity = "t"
    End Sub



    Sub randmove(p As PictureBox)
        Dim x As Integer
        Dim y As Integer
        MoveTo(p, x, y)
        x = r.Next(-10, 11)
        y = r.Next(-10, 11)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        PictureBox1a.Location = PictureBox1.Location
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        Select Case e.KeyCode

            Case Keys.Up
                MoveTo(PictureBox1, 0, 0)
                    Case Keys.Down
                MoveTo(PictureBox1, 0, 0)
            Case Keys.Left
                    MoveTo(PictureBox1, -5, 0)
                    Case Keys.Right
                    MoveTo(PictureBox1, 5, 0)
                    Case Keys.W
                    MoveTo(PictureBox1, 0, 0)
                    Case Keys.S
                    MoveTo(PictureBox1, 0, 0)
                    Case Keys.A
                    MoveTo(PictureBox1, -5, 0)
                    Case Keys.D
                    MoveTo(PictureBox1, 5, 0)
                    Case Keys.F
                PictureBox1a.Location = PictureBox1.Location
                PictureBox1a.Visible = True
                bullet.Location = PictureBox1.Location
                bloc = "1"
                MoveTo(PictureBox1, -2, -4)
                MoveTo(PictureBox1, -2, 4)
                PictureBox1.Refresh()
                pic1a = "t"

            Case Keys.Space
                MoveTo(PictureBox1, 0, -10)
                MoveTo(PictureBox1, 0, -10)
                MoveTo(PictureBox1, 0, -10)
                MoveTo(PictureBox1, 0, -10)
                MoveTo(PictureBox1, 0, -10)

            Case Keys.H
                helim = "t"


        End Select
    End Sub
    Sub MoveTo(p As PictureBox, distx As Integer, disty As Integer)
        If IsClear(p, distx, disty, "WALL") Then
            p.Location += New Point(distx, disty)
        End If

        If p.Name = "PictureBox1" And Collision(p, "WIN") Then
            Me.BackColor = Color.Green
            Return
        Else
            Me.BackColor = Color.White
        End If

    End Sub
    Function IsClear(p As PictureBox, distx As Integer, disty As Integer, t As String) As Boolean
        Dim b As Boolean

        p.Location += New Point(distx, disty)
        b = Not Collision(p, t)
        p.Location -= New Point(distx, disty)
        Return b
    End Function



    Function Collision(p As PictureBox, t As String)
        Dim col As Boolean

        For Each c In Controls
            Dim obj As Control
            obj = c
            If p.Bounds.IntersectsWith(obj.Bounds) And (obj.Name.ToUpper.EndsWith(t) Or
obj.Name.ToUpper.StartsWith(t)) And obj.Visible Then
                col = True
            End If
        Next
        Return col
    End Function

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

        Static headstart As Integer
        Static c As New Collection
        c.Add(PictureBox1.Location)
        headstart = headstart + 1
        If headstart > 10 Then
            p.Location = c.Item(1)
            c.Remove(1)
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles bullet.Click

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

        If bloc = "1" Then
            MoveTo(bullet, 150, 0.5)
        End If

    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        If gravity = "t" Then
            MoveTo(PictureBox1, 0, 6)
            MoveTo(PictureBox1, 0, 6)
            MoveTo(PictureBox1, 0, 6)
            MoveTo(PictureBox1, 0, 6)
        End If


    End Sub

    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick

        MoveTo(PictureBox2, 0, 6)
        MoveTo(PictureBox2, 0, 6)
        MoveTo(PictureBox2, 0, 6)
        MoveTo(PictureBox2, 0, 6)
    End Sub

    Private Sub Timer5_Tick(sender As Object, e As EventArgs) Handles Timer5.Tick
        If pic1a = "t" Then
            PictureBox1a.Visible = False
            pic1a = "f"

        End If
    End Sub

    Private Sub PictureBox1a_Click(sender As Object, e As EventArgs) Handles PictureBox1a.Click

    End Sub

    Private Sub Timer6_Tick(sender As Object, e As EventArgs) Handles Timer6.Tick
        If bullet.Location = PictureBox2.Location Then
            MoveTo(PictureBox2, 3, -1)
            PictureBox2.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)

        End If
    End Sub

    Private Sub Timer7_Tick(sender As Object, e As EventArgs) Handles Timer7.Tick
        If helim = "t" Then
            MoveTo(Helicopter, 0.1, 10)
            If PictureBox1.Bounds.IntersectsWith(Helicopter.Bounds) Then
                MoveTo(PictureBox1, -1, -70)
                PictureBox1.Visible = False
                MoveTo(Helicopter, -0.1, -20)
            End If

        End If
        PictureBox1.Visible = True
    End Sub

    Private Sub FileSystemWatcher1_Changed(sender As Object, e As IO.FileSystemEventArgs) Handles FileSystemWatcher1.Changed
    End Sub

    Private Sub Timer8_Tick(sender As Object, e As EventArgs) Handles Timer8.Tick
        If collision1a4 = "t" Then
            Timer9.Enabled = False
            MoveTo(Helicopter, -0.1, -10)
            MoveTo(PictureBox1, -0.1, -70)

        End If
    End Sub

    Private Sub Timer9_Tick(sender As Object, e As EventArgs) Handles Timer9.Tick
        gravity = "t"
    End Sub

    Private Sub Timer10_Tick(sender As Object, e As EventArgs) Handles Timer10.Tick
        If collision1a4 = "d" Then
            collision1a4 = "f"
            Timer9.Enabled = True
            helim = "f"
        End If
    End Sub
End Class
