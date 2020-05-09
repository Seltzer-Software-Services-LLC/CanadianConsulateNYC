Imports PRMNYReporting.DailyTracker.Win
Public Class UserLoginView
    Private _userLoginController As UserLoginController
    Public Property ThisUserLoginController As UserLoginController
        Get
            Return _userLoginController
        End Get
        Set(value As UserLoginController)
            _userLoginController = value
        End Set
    End Property

    Private Sub UserLoginView_Load(sender As Object, e As EventArgs) Handles Me.Load
        ThisUserLoginController = New UserLoginController(Me)
    End Sub

    Private Sub tbFirstName_TextChanged(sender As Object, e As EventArgs) Handles tbFirstName.TextChanged

    End Sub

    Private Sub tbLastName_TextChanged(sender As Object, e As EventArgs) Handles tbLastName.TextChanged

    End Sub

    Private Sub tbPassword_TextChanged(sender As Object, e As EventArgs) Handles tbPassword.TextChanged

    End Sub

    Private Sub cmdSubmit_Click(sender As Object, e As EventArgs) Handles cmdSubmit.Click

    End Sub

    Private Sub dtpReportDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpReportDate.ValueChanged

    End Sub
End Class
