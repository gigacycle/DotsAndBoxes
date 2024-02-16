Public Class ftmSettings
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmMain.hMax = txtX.Value
        frmMain.vMax = txtY.Value
        Me.Hide()
    End Sub

    Private Sub ftmSettings_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Button1.Focus()
    End Sub
End Class